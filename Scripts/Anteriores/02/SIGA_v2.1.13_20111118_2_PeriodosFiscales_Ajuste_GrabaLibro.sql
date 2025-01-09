
UPDATE Compras SET PeriodoFiscal = NULL
GO


DELETE PeriodosFiscales
GO


/* ------------ Registros de la Tabla PERIODOSFISCALES ------------ */

INSERT INTO PeriodosFiscales
   (PeriodoFiscal, TotalNetoVentas, TotalImpuestosVentas, TotalVentas, TotalNetoCompras, 
    TotalImpuestosCompras, TotalCompras, Posicion, FechaCierre, UsuarioCierre)
SELECT PeriodoFiscal
      ,SUM(TotalNetoVentas) AS TotalNetoVentas
      ,SUM(TotalIVAVentas) AS TotalIVAVentas
      ,SUM(TotalVentas) as TotalVentas      
      ,SUM(TotalNetoCompras) AS TotalNetoCompras
      ,SUM(TotalIVACompras) AS TotalIVACompras
      ,SUM(TotalCompras) as TotalCompras
      ,SUM(TotalIVAVentas) - SUM(TotalIVACompras) AS Posicion
      ,CONVERT(date, FechaCierre) AS FechaCierre
      ,'Admin' AS UsuarioCierre
FROM 
(
SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
      ,SUM(Subtotal) AS TotalNetoVentas
      ,SUM(TotalImpuestos) AS TotalIVAVentas
      ,SUM(ImporteTotal) as TotalVentas      
      ,0 AS TotalNetoCompras
      ,0 AS TotalIVACompras
      ,0 AS TotalCompras
      ,CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120) AS FechaCierre
  FROM Ventas
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
UNION ALL
SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
      ,0 AS TotalNetoVentas
      ,0 AS TotalIVAVentas
      ,0 AS TotalVentas      
      ,SUM(Neto210+Neto105+Neto270) AS TotalNetoCompras
      ,SUM(IVA210+IVA105+IVA270) AS TotalIVACompras
      ,SUM(ImporteTotal) as TotalCompras
      ,CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120) AS FechaCierre
  FROM Compras
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
) A
  GROUP BY A.PeriodoFiscal, A.FechaCierre
GO


/* ------------ Dejo abierto el Periodo Fiscal Actual  ------------ */

UPDATE PeriodosFiscales SET 
    FechaCierre = NULL
   ,UsuarioCierre = NULL
 WHERE YEAR(FechaCierre) = YEAR(GETDATE()) AND MONTH(FechaCierre) = MONTH(GETDATE())
GO


/* ------------ Actualizar Campo de la Tabla COMPRAS ------------ */

UPDATE Compras SET PeriodoFiscal = YEAR(Fecha)*100+MONTH(Fecha) 
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
GO
