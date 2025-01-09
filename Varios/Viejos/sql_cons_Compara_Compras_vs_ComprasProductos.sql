select C.IdSucursal, C.IdTipoComprobante, C.Letra, C.CentroEmisor, C.NumeroComprobante, C.fecha,
       C.subtotal, CP.NetoDetalle
 from Compras C,
(
select IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, sum(ImporteTotalNeto) as NetoDetalle
 from ComprasProductos
group by IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) CP
 where C.IdSucursal=CP.IdSucursal
 and C.IdTipoComprobante=CP.IdTipoComprobante
 and C.Letra=CP.Letra
 and C.CentroEmisor=CP.CentroEmisor
 and C.NumeroComprobante=CP.NumeroComprobante
 and ROUND(C.subtotal,1)<>ROUND(CP.NetoDetalle,1)
 