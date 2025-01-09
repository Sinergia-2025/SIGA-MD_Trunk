--------- Sucursal 1 ---------

-- Creo los nuevos tipos de comprobantes

INSERT INTO CuentasCorrientesProv
      (IdSucursal, IdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTransfBancaria, ImporteTickets, IdCuentaBancaria
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, ImporteRetenciones
      ,ImporteTarjetas, IdEstadoComprobante, IdUsuario, IdProveedor
      ,FechaActualizacion, IdAsiento, IdPlanCuenta)
SELECT IdSucursal, 'AJUSTECOM'+RIGHT(IdTipoComprobante,1) AS XXIdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTransfBancaria, ImporteTickets, IdCuentaBancaria
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, ImporteRetenciones
      ,ImporteTarjetas, IdEstadoComprobante, IdUsuario, IdProveedor
      ,FechaActualizacion, IdAsiento, IdPlanCuenta
  FROM CuentasCorrientesProv
 WHERE IdSucursal = 1 
   AND IdTipoComprobante in ('AJUSTECOM2+', 'AJUSTECOM2-')
GO

--- Reapunto las cuotas (campo 1)
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante = 'AJUSTECOM'+RIGHT(IdTipoComprobante,1)
 WHERE IdSucursal = 1 
   AND IdTipoComprobante in ('AJUSTECOM2+', 'AJUSTECOM2-')
GO

--- Reapunto las cuotas (campo 2)
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante2 = 'AJUSTECOM'+RIGHT(IdTipoComprobante2,1)
 WHERE IdSucursal = 1 
   AND IdTipoComprobante2 in ('AJUSTECOM2+', 'AJUSTECOM2-')
GO

--- Borro el Ajuste Original
DELETE CuentasCorrientesProv
 WHERE IdSucursal = 1
   AND IdTipoComprobante in ('AJUSTECOM2+', 'AJUSTECOM2-')
GO

--------- Sucursal 2 ---------

-- Creo los nuevos tipos de comprobantes

INSERT INTO CuentasCorrientesProv
      (IdSucursal, IdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTransfBancaria, ImporteTickets, IdCuentaBancaria
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, ImporteRetenciones
      ,ImporteTarjetas, IdEstadoComprobante, IdUsuario, IdProveedor
      ,FechaActualizacion, IdAsiento, IdPlanCuenta)
SELECT IdSucursal, 'AJUSTECOM2'+RIGHT(IdTipoComprobante,1) AS XXIdTipoComprobante
      ,Letra, CentroEmisor, NumeroComprobante
      ,Fecha, FechaVencimiento, ImporteTotal, IdFormasPago, Observacion
      ,Saldo, CantidadCuotas, ImportePesos, ImporteDolares, ImporteEuros
      ,ImporteCheques, ImporteTransfBancaria, ImporteTickets, IdCuentaBancaria
      ,IdCaja, NumeroPlanilla, NumeroMovimiento, ImporteRetenciones
      ,ImporteTarjetas, IdEstadoComprobante, IdUsuario, IdProveedor
      ,FechaActualizacion, IdAsiento, IdPlanCuenta
  FROM CuentasCorrientesProv
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTECOM+', 'AJUSTECOM-')
GO

--- Reapunto las cuotas (campo 1)
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante = 'AJUSTECOM2'+RIGHT(IdTipoComprobante,1)
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTECOM+', 'AJUSTECOM-')
GO

--- Reapunto las cuotas (campo 2)
UPDATE CuentasCorrientesProvPagos
   SET IdTipoComprobante2 = 'AJUSTECOM2'+RIGHT(IdTipoComprobante2,1)
 WHERE IdSucursal = 2 
   AND IdTipoComprobante2 in ('AJUSTECOM+', 'AJUSTECOM-')
GO

--- Borro el Ajuste Original
DELETE CuentasCorrientesProv
 WHERE IdSucursal = 2 
   AND IdTipoComprobante in ('AJUSTECOM+', 'AJUSTECOM-')
GO
