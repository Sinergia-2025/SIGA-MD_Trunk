
PRINT ''
PRINT '1. Menu Nuevo: Pedidos\Impresión Masiva de Pedidos'
GO

IF EXISTS (SELECT Id FROM Funciones F WHERE F.Id = 'Pedidos')
BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	 VALUES
	   ('ImpresionMasivaPedido', 'Impresión Masiva de Pedidos', 'Impresión Masiva de Pedidos', 
	    'True', 'False', 'True', 'True', 'Pedidos', 12, 'Eniac.Win', 'ImpresionMasivaPedido', NULL, NULL)
	;

	INSERT INTO RolesFunciones 
	              (IdRol,IdFuncion)
	SELECT IdRol,'ImpresionMasivaPedido'
      FROM RolesFunciones WHERE IdFuncion = 'ConsultarPedidos'
	;
    
END;


PRINT ''
PRINT '2. Tabla EstadosClientes: Ajusto Ancho del Campo NombreEstadoCliente'
GO

-- Por programa permito 20, para evitar tocar en el futuro.
ALTER TABLE EstadosClientes ALTER COLUMN NombreEstadoCliente varchar(30) NOT NULL
GO


PRINT ''
PRINT '3. Tabla ComprasImpuestos: Reasigno Signo de las NCs malas.'
GO

UPDATE CI
   SET CI.Bruto = CI.Bruto * (-1)
  FROM ComprasImpuestos CI
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE CI.Bruto > 0
GO

UPDATE CI
   SET CI.BaseImponible = CI.BaseImponible * (-1)
  FROM ComprasImpuestos CI
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE CI.BaseImponible > 0
GO

UPDATE CI
   SET CI.Importe = CI.Importe * (-1)
  FROM ComprasImpuestos CI
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE CI.Importe > 0
GO


PRINT ''
PRINT '4. Compras: BrutoNoGravado'
GO

UPDATE Compras
 SET Compras.BrutoNoGravado =   
       (SELECT Bruto FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 0
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 0
         )
GO

PRINT ''
PRINT '5. Compras: Bruto105'
GO

UPDATE Compras
 SET Compras.Bruto105 =   
       (SELECT Bruto FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
GO

PRINT ''
PRINT '6. Compras: Bruto210'
GO

UPDATE Compras
 SET Compras.Bruto210 =   
       (SELECT Bruto FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
GO


PRINT ''
PRINT '7. Compras: Bruto270'
GO

UPDATE Compras
 SET Compras.Bruto270 =   
       (SELECT Bruto FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
GO

-----------------------------------------------------------

PRINT ''
PRINT '8. Compras: NetoNoGravado'
GO

UPDATE Compras
 SET Compras.NetoNoGravado =   
       (SELECT BaseImponible FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 0
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 0
         )
GO

PRINT ''
PRINT '9. Compras: Neto105'
GO

UPDATE Compras
 SET Compras.Neto105 =   
       (SELECT BaseImponible FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
GO

PRINT ''
PRINT '10. Compras: Neto210'
GO

UPDATE Compras
 SET Compras.Neto210 =   
       (SELECT BaseImponible FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
GO


PRINT ''
PRINT '11. Compras: Neto270'
GO

UPDATE Compras
 SET Compras.Neto270 =   
       (SELECT BaseImponible FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
GO

-----------------------------------------------------------

PRINT ''
PRINT '12. Compras: IVA105'
GO

UPDATE Compras
 SET Compras.IVA105 =   
       (SELECT Importe FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 10.5
         )
GO

PRINT ''
PRINT '13. Compras: IVA210'
GO

UPDATE Compras
 SET Compras.IVA210 =   
       (SELECT Importe FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 21
         )
GO


PRINT ''
PRINT '14. Compras: IVA270'
GO

UPDATE Compras
 SET Compras.IVA270 =   
       (SELECT Importe FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
 WHERE IdFuncion = 'MovimientosDeComprasV2'
  AND EXISTS
         (SELECT 1 FROM ComprasImpuestos CI
           WHERE Compras.IdSucursal = CI.IdSucursal
             AND Compras.IdTipoComprobante = CI.IdTipoComprobante
             AND Compras.Letra = CI.Letra
             AND Compras.CentroEmisor = CI.CentroEmisor
             AND Compras.NumeroComprobante = CI.NumeroComprobante
             AND Compras.IdProveedor = CI.IdProveedor
             AND CI.IdTipoImpuesto = 'IVA'
             AND CI.Alicuota = 27
         )
GO


PRINT ''
PRINT '14. Compras: Recalculo Campos por NC Incorrectas.'
GO

UPDATE C
   SET C.TotalBruto = C.TotalBruto * (-1)
  FROM Compras C
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE C.TotalBruto > 0
GO

UPDATE C
   SET C.TotalNeto = C.TotalNeto * (-1)
  FROM Compras C
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE C.TotalNeto > 0
GO

UPDATE C
   SET C.TotalIVA = C.TotalIVA * (-1)
  FROM Compras C
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante AND TC.CoeficienteValores < 0 
 WHERE C.TotalIVA > 0
GO


PRINT ''
PRINT '15. Tabla PeriodosFiscales'
GO

DECLARE @periodoDesde int = 201801
DECLARE @periodoHasta int = 201812

UPDATE dbo.PeriodosFiscales
   SET TotalNetoVentas = A.TotalNetoVentas
      ,TotalImpuestosVentas = A.TotalIVAVentas
      ,TotalVentas = A.TotalVentas
      ,TotalNetoCompras = A.TotalNetoCompras
      ,TotalImpuestosCompras = A.TotalIVACompras
      ,TotalCompras = A.TotalCompras
      ,Posicion = A.TotalIVAVentas - A.TotalIVACompras
      ,TotalRetenciones = A.TotalRetenciones
      ,TotalPercepciones = A.TotalPercepciones
      --,PosicionFinal = A.TotalIVAVentas - A.TotalIVACompras - A.TotalRetenciones - A.TotalPercepciones -- SE CALCULA AL FINAL EN UN UPDATE
  FROM (SELECT PeriodoFiscal
              ,SUM(TotalNetoVentas) AS TotalNetoVentas
              ,SUM(TotalIVAVentas) AS TotalIVAVentas
              ,SUM(TotalVentas) AS TotalVentas      
              ,SUM(TotalNetoCompras) AS TotalNetoCompras
              ,SUM(TotalIVACompras) AS TotalIVACompras
              ,SUM(TotalCompras) AS TotalCompras
              ,SUM(TotalIVAVentas) - SUM(TotalIVACompras) AS Posicion
              ,SUM(TotalRetenciones) AS TotalRetenciones
              ,SUM(TotalPercepciones) AS TotalPercepciones
              ,0 AS PosicionFinal
        FROM 
        (
        SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
              ,SUM(Subtotal) AS TotalNetoVentas
              ,SUM(TotalImpuestos) AS TotalIVAVentas
              ,SUM(ImporteTotal) AS TotalVentas      
              ,0 AS TotalNetoCompras
              ,0 AS TotalIVACompras
              ,0 AS TotalCompras
              ,0 AS TotalRetenciones
              ,0 AS TotalPercepciones
          FROM Ventas
          WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
            AND YEAR(Fecha)*100+MONTH(Fecha) >= @periodoDesde AND YEAR(Fecha)*100+MONTH(Fecha) <= @periodoHasta
          GROUP BY YEAR(Fecha)*100+MONTH(Fecha)
        UNION ALL
        SELECT PeriodoFiscal
              ,0 AS TotalNetoVentas
              ,0 AS TotalIVAVentas
              ,0 AS TotalVentas      
              ,SUM(Neto210+Neto105+Neto270) AS TotalNetoCompras
              ,SUM(IVA210+IVA105+IVA270) AS TotalIVACompras
              ,SUM(ImporteTotal) as TotalCompras
              ,0 as TotalRetenciones
              ,SUM(PercepcionIVA) as TotalPercepciones      
          FROM Compras
          WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
            AND PeriodoFiscal >= @periodoDesde AND PeriodoFiscal <= @periodoHasta
          GROUP BY PeriodoFiscal
        ) A
          GROUP BY A.PeriodoFiscal) A
 INNER JOIN PeriodosFiscales PF ON PF.PeriodoFiscal = A.PeriodoFiscal
 WHERE A.PeriodoFiscal >= @periodoDesde AND A.PeriodoFiscal <= @periodoHasta
;

UPDATE PeriodosFiscales
 SET PeriodosFiscales.TotalRetenciones = ISNULL(
       ( SELECT SUM(ImporteTotal) FROM Retenciones R
           WHERE PeriodosFiscales.PeriodoFiscal = YEAR(R.FechaEmision)*100+MONTH(R.FechaEmision)
            AND R.IdTipoImpuesto = 'RIVA'
         ) , 0)
  WHERE PeriodoFiscal >= @periodoDesde AND PeriodoFiscal <= @periodoHasta
;

UPDATE PeriodosFiscales SET
    PosicionFinal = Posicion - TotalRetenciones - TotalPercepciones
 WHERE PeriodoFiscal >= @periodoDesde AND PeriodoFiscal <= @periodoHasta
;

PRINT ''
PRINT '16. Nueva Funcion: CRM\Actualización Masiva'
GO

IF EXISTS (SELECT Id FROM Funciones F WHERE F.Id = 'CRM')
BEGIN

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, 
		  EsMenu, EsBoton, [Enabled], Visible, 
		  IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	  VALUES
		 ('CRMActualizacionMasiva', 'CRM - Actualización Masiva', 'CRM - Actualización Masiva', 
		  'True', 'False', 'True', 'True', 
		  'CRM', 900, 'Eniac.Win', 'CRMActualizacionMasiva', NULL, NULL)
	;

	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMActualizacionMasiva' AS Pantalla FROM Roles
		WHERE Id IN ('Adm', 'Soporte')
	;

END;
