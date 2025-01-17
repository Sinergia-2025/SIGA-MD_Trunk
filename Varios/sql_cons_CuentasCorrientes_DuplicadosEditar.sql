
SELECT * FROM CuentasCorrientes 
WHERE EXISTS
(
SELECT IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, FechaVencimiento, ImporteTotal
      ,IdFormasPago, Observacion, Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria, IdCuentaBancaria
      ,TipoDocVendedor, NroDocVendedor, ImporteRetenciones, IdCaja, NumeroPlanilla, NumeroMovimiento
      ,IdEstadoComprobante, IdUsuario, IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta, MetodoGrabacion, IdFuncion, COUNT(*) AS Registros
  FROM CuentasCorrientes A
 WHERE CuentasCorrientes.IdTipoComprobante = A.IdTipoComprobante
   AND CuentasCorrientes.Letra = A.Letra
   AND CuentasCorrientes.CentroEmisor = A.CentroEmisor
   AND CuentasCorrientes.NumeroComprobante = A.NumeroComprobante
   AND CuentasCorrientes.Fecha = A.Fecha
   AND CuentasCorrientes.FechaVencimiento = A.FechaVencimiento
   AND CuentasCorrientes.ImporteTotal = A.ImporteTotal
   AND CuentasCorrientes.IdFormasPago = A.IdFormasPago
   AND CuentasCorrientes.Observacion = A.Observacion
   AND CuentasCorrientes.Saldo = A.Saldo
   AND CuentasCorrientes.CantidadCuotas = A.CantidadCuotas
   AND CuentasCorrientes.ImportePesos = A.ImportePesos
   AND CuentasCorrientes.ImporteDolares = A.ImporteDolares
   AND CuentasCorrientes.ImporteEuros = A.ImporteEuros
   AND CuentasCorrientes.ImporteCheques = A.ImporteCheques
   AND CuentasCorrientes.ImporteTarjetas = A.ImporteTarjetas
   AND CuentasCorrientes.ImporteTickets = A.ImporteTickets
   AND CuentasCorrientes.ImporteTransfBancaria = A.ImporteTransfBancaria
--   AND CuentasCorrientes.IdCuentaBancaria = A.IdCuentaBancaria
   AND CuentasCorrientes.TipoDocVendedor = A.TipoDocVendedor
   AND CuentasCorrientes.NroDocVendedor = A.NroDocVendedor
   AND CuentasCorrientes.ImporteRetenciones = A.ImporteRetenciones
   AND CuentasCorrientes.IdCaja = A.IdCaja
   AND CuentasCorrientes.NumeroPlanilla = A.NumeroPlanilla
   AND CuentasCorrientes.NumeroMovimiento = A.NumeroMovimiento
   AND CuentasCorrientes.IdEstadoComprobante = A.IdEstadoComprobante
   AND CuentasCorrientes.IdUsuario = A.IdUsuario
   AND CuentasCorrientes.IdCliente = A.IdCliente
   AND CuentasCorrientes.FechaActualizacion = A.FechaActualizacion
   AND CuentasCorrientes.IdClienteCtaCte = A.IdClienteCtaCte
   AND CuentasCorrientes.IdCategoria = A.IdCategoria
--   AND CuentasCorrientes.SaldoCtaCte = A.SaldoCtaCte
--   AND CuentasCorrientes.IdAsiento = A.IdAsiento
--   AND CuentasCorrientes.IdPlanCuenta = A.IdPlanCuenta
   AND CuentasCorrientes.MetodoGrabacion = A.MetodoGrabacion
   AND CuentasCorrientes.IdFuncion = A.IdFuncion
--   AND Observacion LIKE '%Provisorio%'
   AND IdCliente=1
 
  GROUP BY IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, FechaVencimiento, ImporteTotal
      ,IdFormasPago, Observacion, Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria, IdCuentaBancaria
      ,TipoDocVendedor, NroDocVendedor, ImporteRetenciones, IdCaja, NumeroPlanilla, NumeroMovimiento
      ,IdEstadoComprobante, IdUsuario, IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta, MetodoGrabacion, IdFuncion
  HAVING COUNT(*)>1
) 
  ORDER BY IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, IdSucursal
