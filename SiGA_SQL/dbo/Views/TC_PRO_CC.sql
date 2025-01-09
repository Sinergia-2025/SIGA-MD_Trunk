create view TC_PRO_CC as 
select cc.idproveedor,Nombreproveedor,''NombreLocalidad,cc.IdTipoComprobante,Letra,CentroEmisor,numerocomprobante,
year(FechaVencimiento) as AñoVencimiento,month(FechaVencimiento) as MesVencimiento,
FechaVencimiento,ImporteTotal,Saldo,cc.Observacion
from siga.dbo.cuentascorrientesProv cc
left join siga.dbo.proveedores c on cc.idproveedor=c.Idproveedor