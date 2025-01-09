

UPDATE Compras SET PeriodoFiscal = NULL
GO


DELETE PeriodosFiscales
GO


/* ------------ Registros de la Tabla PERIODOSFISCALES ------------ */

INSERT INTO PeriodosFiscales
   (PeriodoFiscal, TotalNetoVentas, TotalImpuestosVentas, TotalVentas, TotalNetoCompras
   ,TotalImpuestosCompras, TotalCompras, Posicion
   ,TotalRetenciones, TotalPercepciones, PosicionFinal
   ,FechaCierre, UsuarioCierre)
SELECT PeriodoFiscal
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
      ,CONVERT(date, FechaCierre) AS FechaCierre
      ,'Admin' AS UsuarioCierre
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
      ,0 as TotalRetenciones
      ,SUM(PercepcionIVA) as TotalPercepciones      
      ,CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120) AS FechaCierre
  FROM Compras
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
) A
  GROUP BY A.PeriodoFiscal, A.FechaCierre
GO

/* ------------ Actualizar Campo de la Tabla COMPRAS ------------ */

UPDATE Compras SET PeriodoFiscal = YEAR(Fecha)*100+MONTH(Fecha) 
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
GO

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales
 SET PeriodosFiscales.TotalRetenciones =   
       ( SELECT SUM(ImporteTotal) FROM Retenciones R
           WHERE PeriodosFiscales.PeriodoFiscal = YEAR(R.FechaEmision)*100+MONTH(R.FechaEmision)
            AND R.IdTipoImpuesto = 'RIVA'
         ) 
  WHERE PeriodoFiscal IN (SELECT DISTINCT YEAR(FechaEmision)*100+MONTH(FechaEmision) FROM Retenciones WHERE IdTipoImpuesto = 'RIVA')
GO

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales SET
    PosicionFinal = Posicion - TotalRetenciones - TotalPercepciones
GO

/* ------------ Dejo abierto el Periodo Fiscal Actual  ------------ */

UPDATE PeriodosFiscales SET 
    FechaCierre = NULL
   ,UsuarioCierre = NULL
 WHERE YEAR(FechaCierre) = YEAR(GETDATE()) AND MONTH(FechaCierre) = MONTH(GETDATE())
GO
