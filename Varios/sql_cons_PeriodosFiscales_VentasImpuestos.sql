
SELECT YEAR(V.Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
      ,SUM(VI.Neto) AS TotalNetoVentas
      ,SUM(VI.Importe) AS TotalIVAVentas
      ,SUM(VI.Total) AS TotalVentas      
  FROM VentasImpuestos VI
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
  INNER JOIN Ventas V ON V.IdSucursal = VI.IdSucursal
                     AND V.IdTipoComprobante = VI.IdTipoComprobante
                     AND V.Letra = VI.Letra
                     AND V.CentroEmisor = VI.CentroEmisor
                     AND V.NumeroComprobante = VI.NumeroComprobante
  WHERE VI.IdTipoImpuesto = 'IVA'
    AND TC.GrabaLibro = 'True'
    AND RIGHT(TC.IdTipoComprobante,4) <> '-CYO'
    AND CONVERT(varchar(11), V.Fecha, 120) >= '2017-03-01'
    AND CONVERT(varchar(11), V.Fecha, 120) <= '2017-03-31'
  GROUP BY YEAR(V.Fecha)*100+MONTH(V.Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, V.Fecha-DAY(V.Fecha)), 120)
  ORDER BY 1 DESC
GO
