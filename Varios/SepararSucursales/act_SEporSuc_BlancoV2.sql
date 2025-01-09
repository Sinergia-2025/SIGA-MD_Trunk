
PRINT '22. Inserto Tabla: CajasDetalle // Solo de Pagos'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT [IdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.CuentasCorrientesProv CC, SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.IdTipoComprobante = CC.IdTipoComprobante
         AND TC.GrabaLibro = 'True'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND CC.Letra = 'R' --AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'PAGO')
         AND CC.IdSucursal = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '23. Inserto Tabla: CuentasCorrientesProv // Comprobantes y Recibos NO Estandares'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesProv]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTransfBancaria]
           ,[ImporteTickets]
           ,[IdCuentaBancaria]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[ImporteRetenciones]
           ,[ImporteTarjetas]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdProveedor]
           ,[FechaActualizacion])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTransfBancaria]
      ,[ImporteTickets]
      ,[IdCuentaBancaria]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[ImporteRetenciones]
      ,[ImporteTarjetas]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdProveedor]
      ,[FechaActualizacion]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesProv] CC
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'True'
         AND TC.EsRecibo = 'False'
         AND TC.EsAnticipo = 'False'
         AND TC.IdTipoComprobante = CC.IdTipoComprobante
     )
   OR EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'True'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND CC.Letra = 'R' --AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'PAGO')
         AND TC.IdTipoComprobante = CC.IdTipoComprobante
     )
GO

PRINT '24. Inserto Tabla: CuentasCorrientesProvPagos // Comprobantes y Recibos NO Estandares'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesProvPagos]
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
           ,[IdProveedor])
SELECT [IdSucursal]
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
      ,[IdProveedor]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesProvPagos] CCP
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'True'
         AND TC.EsRecibo = 'False'
         AND TC.EsAnticipo = 'False'
         AND TC.IdTipoComprobante = CCP.IdTipoComprobante
     )
   OR EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'True'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND CCP.Letra = 'R' --AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'PAGO')
         AND TC.IdTipoComprobante = CCP.IdTipoComprobante
     )
GO

PRINT '25. Inserto Tabla: CajasDetalle // Solo de Recibos Estandares'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT [IdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC, SIGA_A_2015.dbo.CuentasCorrientesProv CC, SIGA_A_2015.dbo.CuentasCorrientesProvPagos CCP
       WHERE TC.IdTipoComprobante = CCP.IdTipoComprobante2
         AND TC.GrabaLibro = 'True'
         AND (CCP.Letra <> 'R' AND TC.IdTipoComprobante IN ('ANTICIPO', 'PAGO'))
         AND CCP.IdSucursal = CC.IdSucursal
         AND CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante         
         AND CCP.IdProveedor = CC.IdProveedor         
         AND CC.IdSucursal = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '26. Inserto Tabla: CuentasCorrientesProv // Recibos Estandares Depurados'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesProv]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTransfBancaria]
           ,[ImporteTickets]
           ,[IdCuentaBancaria]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[ImporteRetenciones]
           ,[ImporteTarjetas]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdProveedor]
           ,[FechaActualizacion])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTransfBancaria]
      ,[ImporteTickets]
      ,[IdCuentaBancaria]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[ImporteRetenciones]
      ,[ImporteTarjetas]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdProveedor]
      ,[FechaActualizacion]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesProv] CC
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC, SIGA_A_2015.dbo.CuentasCorrientesProvPagos CCP
       WHERE TC.IdTipoComprobante = CCP.IdTipoComprobante2
         AND TC.GrabaLibro = 'True'
         AND (CCP.Letra <> 'R' AND TC.IdTipoComprobante IN ('ANTICIPO', 'PAGO'))
         AND CCP.IdSucursal = CC.IdSucursal
         AND CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante
         AND CCP.IdProveedor = CC.IdProveedor
     )
GO
