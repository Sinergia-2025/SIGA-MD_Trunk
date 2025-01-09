--SELECT VI.*, VI1.*
UPDATE VI
   SET IdTipoImpuesto = 'IMINT'
     , Bruto = 0
     , Neto = 0
     , Total = VI1.Importe
  FROM (SELECT VI.IdSucursal, VI.IdTipoComprobante, VI.Letra, VI.CentroEmisor, VI.NumeroComprobante, VI.IdTipoImpuesto, VI.Alicuota, VI.Importe
             , SUM(VP.ImporteImpuestoInterno) AS TotalImpuestoInterno
          FROM SIGA_Minimercado.dbo.VentasImpuestos VI
         INNER JOIN SIGA_Minimercado.dbo.VentasProductos VP 
                                    ON VP.IdSucursal = VI.IdSucursal
                                   AND VP.IdTipoComprobante = VI.IdTipoComprobante
                                   AND VP.Letra = VI.Letra
                                   AND VP.CentroEmisor = VI.CentroEmisor
                                   AND VP.NumeroComprobante = VI.NumeroComprobante
         INNER JOIN SIGA_Minimercado.dbo.TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
         WHERE VI.Alicuota = 0
           AND VI.Importe <> 0
           AND VI.IdTipoImpuesto = 'IVA'
           AND TC.GrabaLibro = 'True'
           --AND VI.NumeroComprobante = 23910
         GROUP BY VI.IdSucursal, VI.IdTipoComprobante, VI.Letra, VI.CentroEmisor, VI.NumeroComprobante, VI.IdTipoImpuesto, VI.Alicuota, VI.Importe) VI1
 INNER JOIN SIGA_Minimercado.dbo.VentasImpuestos VI 
                                    ON VI.IdSucursal = VI1.IdSucursal
                                   AND VI.IdTipoComprobante = VI1.IdTipoComprobante
                                   AND VI.Letra = VI1.Letra
                                   AND VI.CentroEmisor = VI1.CentroEmisor
                                   AND VI.NumeroComprobante = VI1.NumeroComprobante
                                   AND VI.IdTipoImpuesto = VI1.IdTipoImpuesto
                                   AND VI.Alicuota = VI1.Alicuota
 WHERE VI1.TotalImpuestoInterno <> 0
   --AND VI.Importe + VI1.Importe = VI1.TotalImpuestoInterno
