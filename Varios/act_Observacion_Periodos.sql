
SELECT * FROM CuentasCorrientes
 where NumeroComprobante = 876
go

update MovimientosVentas
   set Observacion = 'PERIODO: 2015/08.'
 where NumeroComprobante = 876
go


update CuentasCorrientesPagos
   set Observacion = 'PERIODO: 2015/08.'
 where NumeroComprobante = 876
go

update CuentasCorrientes
   set Observacion = 'PERIODO: 2015/08.'
 where NumeroComprobante = 876
go

update VentasObservaciones
   set Observacion = 'PERIODO: 2015/08.'
 where NumeroComprobante = 876
go

update Ventas
   set Observacion = 'PERIODO: 2015/08.'
 where NumeroComprobante = 876
go
