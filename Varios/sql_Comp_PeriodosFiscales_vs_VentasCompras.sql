SELECT P.PeriodoFiscal
      ,P.TotalNetoVentas
      ,P.TotalImpuestosVentas
      ,P.TotalVentas
      ,V.TotalNetoVentasV
      ,V.TotalImpuestosVentasV
      ,V.TotalVentasV
      ,P.TotalImpuestosVentas-V.TotalImpuestosVentasV AS Diferencia
 FROM 
	(SELECT PeriodoFiscal
	      ,TotalNetoVentas
	      ,TotalImpuestosVentas
	      ,TotalVentas
	  FROM PeriodosFiscales
	 ) P,
	(SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
	      ,SUM(Subtotal) AS TotalNetoVentasV
	      ,SUM(TotalImpuestos) AS TotalImpuestosVentasV
	      ,SUM(ImporteTotal) AS TotalVentasV
	  FROM Ventas
	  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
	  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
	) V
 WHERE P.PeriodoFiscal=V.PeriodoFiscal
   AND P.TotalImpuestosVentas <> V.TotalImpuestosVentasV
GO

SELECT P.PeriodoFiscal
      ,P.TotalNetoCompras
      ,P.TotalImpuestosCompras
      ,P.TotalCompras
      ,C.TotalNetoComprasC
      ,C.TotalImpuestosComprasC
      ,C.TotalComprasC
      ,P.TotalImpuestosCompras-C.TotalImpuestosComprasC AS Diferencia
 FROM 
	(SELECT PeriodoFiscal
	      ,TotalNetoCompras
	      ,TotalImpuestosCompras
	      ,TotalCompras
	  FROM PeriodosFiscales
	 ) P,
	(SELECT PeriodoFiscal
           ,SUM(Neto210+Neto105+Neto270) AS TotalNetoComprasC
           ,SUM(IVA210+IVA105+IVA270) AS TotalImpuestosComprasC
           ,SUM(ImporteTotal) as TotalComprasC
       FROM Compras
       WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
       GROUP BY PeriodoFiscal
	) C
 WHERE P.PeriodoFiscal=C.PeriodoFiscal
   AND P.TotalImpuestosCompras <> C.TotalImpuestosComprasC
GO
