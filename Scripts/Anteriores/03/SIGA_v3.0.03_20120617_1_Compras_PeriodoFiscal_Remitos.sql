
-- Inserto los periodos que faltan apra que no de error. En estado CERRADO.
INSERT INTO PeriodosFiscales
   (PeriodoFiscal, TotalNetoVentas, TotalImpuestosVentas, TotalVentas
   ,TotalNetoCompras, TotalImpuestosCompras, TotalCompras, Posicion
   ,TotalRetenciones, TotalPercepciones, PosicionFinal, FechaCierre, UsuarioCierre)
SELECT DISTINCT YEAR(Fecha)*100+MONTH(Fecha), 0, 0, 0
      ,0, 0, 0,0
      ,0, 0, 0, CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120), 'admin'
   FROM Compras  
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE EsComercial = 'True')
    AND PeriodoFiscal IS NULL
    AND YEAR(Fecha)*100+MONTH(Fecha) NOT IN (SELECT PeriodoFiscal FROM PeriodosFiscales)
GO

-- Actualizo los remitos con el Periodo Fiscal en base a la fecha.
UPDATE Compras SET PeriodoFiscal = YEAR(Fecha)*100+MONTH(Fecha) 
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE EsComercial = 'True')
    AND PeriodoFiscal IS NULL
GO
