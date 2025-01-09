
SELECT IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, FechaVencimiento, ImporteTotal
      ,IdFormasPago, Observacion, Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria, IdCuentaBancaria
      ,TipoDocVendedor, NroDocVendedor, ImporteRetenciones, IdCaja, NumeroPlanilla, NumeroMovimiento
      ,IdEstadoComprobante, IdUsuario, IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta, MetodoGrabacion, IdFuncion, COUNT(*) AS Registros
  FROM CuentasCorrientes A
 GROUP BY IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, FechaVencimiento, ImporteTotal
      ,IdFormasPago, Observacion, Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria, IdCuentaBancaria
      ,TipoDocVendedor, NroDocVendedor, ImporteRetenciones, IdCaja, NumeroPlanilla, NumeroMovimiento
      ,IdEstadoComprobante, IdUsuario, IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta, MetodoGrabacion, IdFuncion  
HAVING COUNT(*)>1
