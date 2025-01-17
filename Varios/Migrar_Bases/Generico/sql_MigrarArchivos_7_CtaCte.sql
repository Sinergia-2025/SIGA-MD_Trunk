--delete CuentasCorrientes

PRINT '1. CuentasCorrientes: Inserto Comprobantes, excluyendo los ANTICIPOS.'
GO

INSERT INTO CuentasCorrientes
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,ImporteTotal
           ,IdFormasPago
           ,Observacion
           ,Saldo
           ,CantidadCuotas
           ,ImportePesos
           ,ImporteDolares
           ,ImporteEuros
           ,ImporteCheques
           ,ImporteTarjetas
           ,ImporteTickets
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,TipoDocVendedor
           ,NroDocVendedor
           ,ImporteRetenciones
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,IdUsuario
           ,IdEstadoComprobante
           ,IdCliente
           ,FechaActualizacion
           ,IdClienteCtaCte
           ,IdCategoria
           ,SaldoCtaCte
           ,IdAsiento
           ,IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos
           ,IdCobrador
           ,IdEstadoCliente
           ,NumeroOrdenCompra
           ,Referencia)
SELECT IdSucursal
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,FechaVencimiento
      ,Saldo AS xxImporteTotal
      ,IdFormasPago
      ,Observacion
      ,Saldo
      ,CantidadCuotas
      ,ImportePesos
      ,ImporteDolares
      ,ImporteEuros
      ,ImporteCheques
      ,ImporteTarjetas
      ,ImporteTickets
      ,ImporteTransfBancaria
      ,IdCuentaBancaria
      ,TipoDocVendedor
      ,NroDocVendedor
      ,ImporteRetenciones
      ,NULL AS IdCaja
      ,NULL AS NumeroPlanilla
      ,NULL AS NumeroMovimiento
      ,'admin' AS IdUsuario
      ,'' AS IdEstadoComprobante
      ,NroDocCliente AS IdCliente
      ,Fecha AS FechaActualizacion
      ,NroDocCliente AS IdClienteCtaCte
      ,1 AS IdCategoria	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,NULL AS SaldoCtaCte
      ,NULL AS IdAsiento
      ,NULL AS IdPlanCuenta
      ,'M' AS MetodoGrabacion
      ,'FacturacionV2' AS IdFuncion
      ,NULL AS ImprimeSaldos
      ,1 AS IdCobrador	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,1 AS IdEstadoCliente	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,NULL AS NumeroOrdenCompra
      ,NULL AS Referencia
   FROM MO_SIGA.dbo.CuentasCorrientes
  WHERE Saldo <> 0
    AND IdTipoComprobante NOT IN ('ANTICIPO', 'RECIBO')
GO


PRINT ''
PRINT '2. CuentasCorrientes: Inserto los ANTICIPOS como SALDOINICIAL2+.'
GO

INSERT INTO CuentasCorrientes
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,ImporteTotal
           ,IdFormasPago
           ,Observacion
           ,Saldo
           ,CantidadCuotas
           ,ImportePesos
           ,ImporteDolares
           ,ImporteEuros
           ,ImporteCheques
           ,ImporteTarjetas
           ,ImporteTickets
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,TipoDocVendedor
           ,NroDocVendedor
           ,ImporteRetenciones
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,IdUsuario
           ,IdEstadoComprobante
           ,IdCliente
           ,FechaActualizacion
           ,IdClienteCtaCte
           ,IdCategoria
           ,SaldoCtaCte
           ,IdAsiento
           ,IdPlanCuenta
           ,MetodoGrabacion
           ,IdFuncion
           ,ImprimeSaldos
           ,IdCobrador
           ,IdEstadoCliente
           ,NumeroOrdenCompra
           ,Referencia)
SELECT IdSucursal
      ,'SALDOINICIAL2+' AS IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,FechaVencimiento
      ,Saldo AS xxImporteTotal
      ,IdFormasPago
      ,Observacion
      ,Saldo
      ,CantidadCuotas
      ,ImportePesos
      ,ImporteDolares
      ,ImporteEuros
      ,ImporteCheques
      ,ImporteTarjetas
      ,ImporteTickets
      ,ImporteTransfBancaria
      ,IdCuentaBancaria
      ,TipoDocVendedor
      ,NroDocVendedor
      ,ImporteRetenciones
      ,NULL AS IdCaja
      ,NULL AS NumeroPlanilla
      ,NULL AS NumeroMovimiento
      ,'admin' AS IdUsuario
      ,'' AS IdEstadoComprobante
      ,NroDocCliente AS IdCliente
      ,Fecha AS FechaActualizacion
      ,NroDocCliente AS IdClienteCtaCte
      ,1 AS IdCategoria	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,NULL AS SaldoCtaCte
      ,NULL AS IdAsiento
      ,NULL AS IdPlanCuenta
      ,'M' AS MetodoGrabacion
      ,'RecibosNuevos' AS IdFuncion
      ,NULL AS ImprimeSaldos
      ,1 AS IdCobrador	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,1 AS IdEstadoCliente	-- Deberia salir del Cliente. En este caso solo hay 1.
      ,NULL AS NumeroOrdenCompra
      ,NULL AS Referencia
   FROM MO_SIGA.dbo.CuentasCorrientes
  WHERE Saldo <> 0
    AND IdTipoComprobante = 'ANTICIPO'
GO


PRINT ''
PRINT '3. CuentasCorrientesPagos: Inserto Comprobantes, excluyendo los ANTICIPOS.'
GO

INSERT INTO [CuentasCorrientesPagos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc]
           ,[ImporteCapital]
           ,[ImporteInteres])
SELECT [IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[SaldoCuota] AS XXImporteCuota
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,0 AS [DescuentoRecargo]
           ,0 AS [DescuentoRecargoPorc]
           ,[SaldoCuota] AS [ImporteCapital]
           ,0 AS [ImporteInteres]
   FROM MO_SIGA.dbo.CuentasCorrientesPagos
  WHERE SaldoCuota <> 0
    AND IdTipoComprobante <> 'ANTICIPO'
GO


PRINT ''
PRINT '4. CuentasCorrientesPagos: Inserto los ANTICIPOS como SALDOINICIAL2+.'
GO

INSERT INTO [CuentasCorrientesPagos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc]
           ,[ImporteCapital]
           ,[ImporteInteres])
SELECT [IdSucursal]
      ,'SALDOINICIAL2+' AS IdTipoComprobante
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[SaldoCuota] AS XXImporteCuota
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,0 AS [DescuentoRecargo]
           ,0 AS [DescuentoRecargoPorc]
           ,[SaldoCuota] AS [ImporteCapital]
           ,0 AS [ImporteInteres]
   FROM MO_SIGA.dbo.CuentasCorrientesPagos
  WHERE SaldoCuota <> 0
    AND IdTipoComprobante = 'ANTICIPO'
GO

