
SELECT NombreSucursal, Descripcion, Letra,
       SUM(NetoNoGravado) AS NetoNoGravado, SUM(Neto-NetoNoGravado) AS Neto, 
       SUM(IVA105) AS IVA105, SUM(IVA21) AS IVA21, SUM(IVA27) AS IVA27,
       SUM(Neto+IVA105+IVA21+IVA27) AS Total
  FROM
( 
SELECT S.Nombre AS NombreSucursal, 
      TC.Descripcion, 
      VI.Letra,
      SUM(VI.Neto) AS Neto,
 CASE VI.Alicuota
      WHEN 0 Then SUM(VI.Neto)
      ELSE 0 
 END NetoNoGravado,
 CASE VI.Alicuota
      WHEN 10.5 Then SUM(VI.Importe)
      ELSE 0 
 END IVA105,
 CASE VI.Alicuota
      WHEN 21 Then SUM(VI.Importe)
      ELSE 0 
 END IVA21,
 CASE VI.Alicuota
      WHEN 27 Then SUM(VI.Importe)
      ELSE 0 
 END IVA27
 FROM VentasImpuestos VI
 INNER JOIN Sucursales S ON VI.IdSucursal = S.IdSucursal
 INNER JOIN Ventas V ON VI.IdSucursal = V.IdSucursal
                    AND VI.IdTipoComprobante = V.IdTipoComprobante
                    AND VI.Letra = V.Letra
                    AND VI.CentroEmisor = V.CentroEmisor
                    AND VI.NumeroComprobante = V.NumeroComprobante
 
 INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante
 
 WHERE VI.IdSucursal IN (1)
   AND TC.AfectaCaja = 'True'
   AND TC.EsComercial = 'True'
  
   AND YEAR(V.Fecha) = 2011
 GROUP BY S.Nombre, TC.Descripcion, VI.Letra, VI.Alicuota
) Detalle
GROUP BY NombreSucursal, Descripcion, Letra
ORDER BY NombreSucursal, Descripcion, Letra

