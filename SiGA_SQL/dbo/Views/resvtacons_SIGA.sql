create view resvtacons_SIGA as
select v.idtipocomprobante as TiCBT,Letra,CentroEmisor as CE,NumeroComprobante as NroCbt,
year(Fecha) as Año,month(Fecha) as Mes,Fecha,ltrim(rtrim(NombreEmpleado)) as Vendedor,NombreCliente as Cliente,
v.Observacion,NombreLocalidad as Ciudad,NombreCategoria as TipoCliente from Ventas v
left join Empleados e on v.NroDocVendedor=e.NroDocEmpleado
left join Clientes c on v.IdCliente=c.IdCliente
left join Localidades l on c.IdLocalidad=l.IdLocalidad
left join Categorias ca on c.IdCategoria=ca.IdCategoria