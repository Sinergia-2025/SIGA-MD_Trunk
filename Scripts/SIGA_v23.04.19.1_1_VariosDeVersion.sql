PRINT ''
PRINT '1. Menu: Nueva opción Alerta de Proveedores con comprobantes vencidos'
IF dbo.ExisteFuncion('AlertaProvComprobantesVencidos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('AlertaProvComprobantesVencidos', 'Alerta de Proveedores con comprobantes vencidos', 'Alerta de Proveedores con comprobantes vencidos', 'False', 'False', 'True', 'True'
        ,NULL, 999, '', 'AlertaProvComprobantesVencidos', NULL, 'DiasVencimiento=1;SaldoMinimo=0;CantidadComprobantes=1'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertaProvComprobantesVencidos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Compras: Corrección de signo de ImporteTransfBancaria'
UPDATE C
   SET ImporteTransfBancaria = ImporteTransfBancaria * -1
  FROM Compras C
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
 WHERE TC.CoeficienteValores < 0
   AND C.ImporteTransfBancaria > 0
   
PRINT ''
PRINT '3. CajasDetalle: Corrección de signo de ImporteBancos'
UPDATE Cd
   SET ImporteBancos = ImporteBancos * -1
  FROM CajasDetalle Cd
 INNER JOIN Compras C ON C.IdSucursal = Cd.IdSucursal
                     AND C.IdCaja = Cd.IdCaja
                     AND C.NumeroPlanilla = Cd.NumeroPlanilla
                     AND C.NumeroMovimiento = Cd.NumeroMovimiento
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
 WHERE TC.CoeficienteValores < 0
   AND Cd.ImporteBancos < 0

PRINT ''
PRINT '4. CajasDetalle: Corrección de IdTipoMovimiento'
UPDATE Cd
   SET IdTipoMovimiento = 'I'
  FROM CajasDetalle Cd
 WHERE Cd.ImporteCheques + Cd.ImporteTarjetas + Cd.ImportePesos + Cd.ImporteBancos + Cd.ImporteDolares > 0
   AND Cd.IdTipoMovimiento = 'E'

PRINT ''
PRINT '5. LibrosBancos: Corrección de signo de Importe y de IdTipoMovimiento'
UPDATE Lb
   SET Importe = Importe * -1
     , IdTipoMovimiento = 'I'
	 , FechaActualizacionAsiento = GETDATE()	--Para que se pueda rastrear por si rompimos algo.
  FROM LibrosBancos Lb
 WHERE Lb.Observacion LIKE '%Cred%Compra%'
   AND Lb.Importe < 0
GO
