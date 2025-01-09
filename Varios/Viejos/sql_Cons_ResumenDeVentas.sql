SELECT S.Nombre AS NombreSucursal
      ,TC.Descripcion
      ,V.Letra
      ,VI.Alicuota
      --,VI.Neto
      --,VI.Importe
      --,vI.Total
      ,SUM(VI.Neto) as Neto
      ,SUM(VI.Importe) as Importe
      ,SUM(VI.Total) as Total
  FROM Sucursales S, Ventas V, VentasImpuestos VI, TiposComprobantes TC
 WHERE S.IdSucursal = V.IdSucursal
   AND V.IdSucursal = VI.IdSucursal
   AND V.IdTipoComprobante = VI.IdTipoComprobante
   AND V.Letra = VI.Letra 
   AND V.CentroEmisor = VI.CentroEmisor
   AND V.NumeroComprobante = VI.NumeroComprobante
   AND V.IdTipoComprobante = TC.IdTipoComprobante
   AND TC.AfectaCaja = 'True' 
   AND S.IdSucursal IN (1)
   AND CONVERT(varchar(11), V.Fecha, 120) >= '2011-08-01'
   AND CONVERT(varchar(11), V.Fecha, 120) <= '2011-08-29'
  GROUP BY S.Nombre, TC.Descripcion, V.Letra, VI.Alicuota
  ORDER BY S.Nombre, TC.Descripcion, V.Letra, VI.Alicuota