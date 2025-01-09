

CREATE view [dbo].[TC_CLI_VE] as
select 
cc.idcliente,NombreCliente,''NombreLocalidad,cc.IdTipoComprobante,Letra,CentroEmisor,numerocomprobante,
year(FechaMovimiento) as Año,month(FechaMovimiento) as Mes,FechaMovimiento as Fecha,
nombreproducto,cantidad,precio,-(cantidad*precio) as monto,
cc.Observacion,
case 
when NombreCliente like 'EDE%' then 'SCADA'
when NombreCliente like 'ALERCON%' or NombreCliente like 'gavia%' or NombreCliente like 'cargill%'
then 'GRANDES CLIENTES'
else 'CLIENTES'
 end as TipoCliente,
 case 
when NombreCliente like 'EDE%' then 'TERCEROS'
when NombreCliente like 'ALERCON%' or NombreCliente like 'gavia%' or NombreCliente like 'cargill%'
then 'PROPIOS'
else 'PROPIOS'
 end as TipoPropiedad

from siga.dbo.MovimientosVentas cc
left join siga.dbo.MovimientosVentasProductos d on cc.IdSucursal=d.IdSucursal and cc.IdTipoMovimiento=d.IdTipoMovimiento and cc.NumeroMovimiento=d.NumeroMovimiento
left join siga.dbo.clientes c on cc.idcliente=c.IdCliente
left join siga.dbo.localidades l on c.IdLocalidad=l.IdLocalidad
left join siga.dbo.productos p on d.Idproducto=p.Idproducto