UPDATE CuentasCorrientesPagos
 SET CuentasCorrientesPagos.SaldoCuota =
(
select sub.Saldo
 from CuentasCorrientes sub
 where CuentasCorrientesPagos.IdSucursal        = sub.IdSucursal
   AND CuentasCorrientesPagos.IdTipoComprobante = sub.IdTipoComprobante
   AND CuentasCorrientesPagos.Letra             = sub.Letra
   AND CuentasCorrientesPagos.CentroEmisor      = sub.CentroEmisor
   AND CuentasCorrientesPagos.NumeroComprobante = sub.NumeroComprobante
)
 where CuentasCorrientesPagos.IdTipoComprobante NOT IN ('RECIBO','ANTICIPO')
go
