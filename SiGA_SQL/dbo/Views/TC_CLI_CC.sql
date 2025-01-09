create view TC_CLI_CC as 
select cc.idcliente,NombreCliente,NombreLocalidad,cc.IdTipoComprobante,Letra,CentroEmisor,numerocomprobante,
year(FechaVencimiento) as AñoVencimiento,month(FechaVencimiento) as MesVencimiento,
FechaVencimiento,ImporteTotal,Saldo,cc.Observacion
from siga.dbo.cuentascorrientes cc
left join siga.dbo.clientes c on cc.idcliente=c.IdCliente
left join siga.dbo.localidades l on c.IdLocalidad=l.IdLocalidad