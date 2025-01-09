
select * from ventasproductos
 where idtipocomprobante='eNCRED'
 and Cantidad>0
go


update ventasproductos
  set Cantidad = Cantidad*(-1)
 where idtipocomprobante='eNCRED'
 and Cantidad>0
go

select * from MovimientosVentasProductos
 where IdTipoMovimiento='DEVOLUCION'
  and Cantidad<0
  and NumeroMovimiento IN 
  (
 select NumeroMovimiento from MovimientosVentas
 where idtipocomprobante='eNCRED'
)
go

update MovimientosVentasProductos
  set Cantidad = Cantidad*(-1)
 where IdTipoMovimiento='DEVOLUCION'
  and Cantidad<0
  and NumeroMovimiento IN 
  (
 select NumeroMovimiento from MovimientosVentas
 where idtipocomprobante='eNCRED'
)
go
