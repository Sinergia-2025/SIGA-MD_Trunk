select v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor, v.NumeroComprobante, v.fecha,
       v.subtotal, vp.NetoDetalle
 from ventas v,
(
select IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(ImporteTotalNeto) as NetoDetalle
 from ventasProductos
group by IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) VP
 where v.IdSucursal=vp.IdSucursal
 and v.IdTipoComprobante=vp.IdTipoComprobante
 and v.Letra=vp.Letra
 and v.CentroEmisor=vp.CentroEmisor
 and v.NumeroComprobante=vp.NumeroComprobante
 and ROUND(v.subtotal,1)<>ROUND(vp.NetoDetalle,1)
 