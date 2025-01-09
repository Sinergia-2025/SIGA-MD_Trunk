

CREATE view [dbo].[TC_PRO_CO] as
select cc.idproveedor,Nombreproveedor,''NombreLocalidad,cc.IdTipoComprobante,Letra,CentroEmisor,numerocomprobante,
year(FechaMovimiento) as Año,month(FechaMovimiento) as Mes,FechaMovimiento as Fecha,
nombreproducto,cantidad,precio,cantidad*precio as monto,
cc.Observacion,
case 
when nombreproducto like 'SI%' then 'COSTO DE DESARROLLO'
else 'COSTOS DE ESTRUCTURA'
 end as TipoCompra
 from siga.dbo.MovimientosCompras cc
left join siga.dbo.MovimientosComprasProductos d on cc.IdSucursal=d.IdSucursal and cc.IdTipoMovimiento=d.IdTipoMovimiento and cc.NumeroMovimiento=d.NumeroMovimiento
left join siga.dbo.proveedores c on cc.idproveedor=c.Idproveedor
left join siga.dbo.productos p on d.Idproducto=p.Idproducto