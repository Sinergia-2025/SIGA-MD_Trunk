PRINT ''
PRINT '1. Parametros: Corregir Turnos por Zona.'
GO
IF NOT EXISTS (SELECT * FROM Rubros R
                WHERE EXISTS (SELECT P.ValorParametro FROM Parametros P
	                           WHERE P.IdParametro = 'TURNOSPRODUCTOZONA'
                                 AND R.IdRubro = P.ValorParametro)
               )
	UPDATE Parametros
	   SET ValorParametro = '0'
	 WHERE IdParametro = 'TURNOSPRODUCTOZONA'
GO

PRINT ''
PRINT '2. Funcion Consultar Precios por Cuotas: Ajuste de Nombre.'
GO
IF dbo.ExisteFuncion('Precios') = 1 AND dbo.ExisteFuncion('ConsultarPreciosPorCuotas') = 1
	UPDATE Funciones
	   SET Nombre = 'Consultar Precios por Listas / Formas de Pago / Cuotas'
		  ,Descripcion = 'Consultar Precios por Listas / Formas de Pago / Cuotas'
	 WHERE Id = 'ConsultarPreciosPorCuotas'
	GO

PRINT ''
PRINT '3. Funcion Consultar Precios por Cuotas: Alta si no existe pero con Nombre Distinto.'
GO
IF dbo.ExisteFuncion('Precios') = 1 AND dbo.ExisteFuncion('ConsultarPreciosPorCuotas') = 0
    BEGIN
        DECLARE @parametro VARCHAR(MAX)
        -- Predeterminado por Listas de Precios
        SET @parametro = 'LP';

        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
             ('ConsultarPreciosPorCuotas', 'Consultar Precios por Listas / Formas de Pago / Cuotas', 'Consultar Precios por Listas / Formas de Pago / Cuotas', 'True', 'False', 'True', 'True'
             ,'Precios', 24, 'Eniac.Win', 'ConsultarPreciosPorCuotas', NULL, @parametro
             ,'True', 'S', 'N', 'N', 'N');

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'ConsultarPreciosPorCuotas' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;


PRINT ''
PRINT '4. Tabla Ventas: Ajuste ePreComprobantes que deberian tener CUIT (RI/MO/EX).'
GO
UPDATE Ventas 
   SET Ventas.NombreCliente = C.NombreCliente
      ,Ventas.CUIT = C.CUIT
 FROM Ventas V 
 INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
 INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
 WHERE V.IdTipoComprobante like 'ePre%'
   AND CF.SolicitaCUIT = 'True'
   AND V.CUIT IS NULL
GO


PRINT ''
PRINT '5. Tabla Ventas: Ajuste ePreComprobantes que deberian tener DNI (CF).'
GO
UPDATE Ventas 
   SET Ventas.NombreCliente = C.NombreCliente
      ,Ventas.TipoDocCliente = C.TipoDocCliente
      ,Ventas.NroDocCliente = C.NroDocCliente 
 FROM Ventas V 
 INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
 INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
 WHERE V.IdTipoComprobante like 'ePre%'
   AND CF.SolicitaCUIT = 'False'
   AND C.EsClienteGenerico = 'False'
   AND V.NroDocCliente IS NULL
GO
