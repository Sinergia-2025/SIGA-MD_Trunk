-- SOLO ESTABAN MAL EN LA SUCURSLA 2

-- Creo los nuevos tipos de comprobantes

INSERT INTO CuentasCorrientes 
      (IdSucursal, IdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria
      ,IdCuentaBancaria, TipoDocVendedor, NroDocVendedor, ImporteRetenciones
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, IdUsuario, IdEstadoComprobante
      ,IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta)
SELECT IdSucursal, 'AJUSTE2'+RIGHT(IdTipoComprobante,1) AS XXIdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTarjetas, ImporteTickets, ImporteTransfBancaria
      ,IdCuentaBancaria, TipoDocVendedor, NroDocVendedor, ImporteRetenciones
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, IdUsuario, IdEstadoComprobante
      ,IdCliente, FechaActualizacion, IdClienteCtaCte, IdCategoria
      ,SaldoCtaCte, IdAsiento, IdPlanCuenta
  FROM CuentasCorrientes
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTE+', 'AJUSTE-')
GO

--- Reapunto las cuotas (campo 1)
UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante = 'AJUSTE2'+RIGHT(IdTipoComprobante,1)
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTE+', 'AJUSTE-')
GO

--- Reapunto las cuotas (campo 2)
UPDATE CuentasCorrientesPagos
   SET IdTipoComprobante2 = 'AJUSTE2'+RIGHT(IdTipoComprobante2,1)
 WHERE IdSucursal = 2 
   AND IdTipoComprobante2 in ('AJUSTE+', 'AJUSTE-')
GO

--- Borro el Ajuste Original
DELETE CuentasCorrientes
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTE+', 'AJUSTE-')
GO
