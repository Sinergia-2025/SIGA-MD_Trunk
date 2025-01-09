
PRINT '27. Inserto Tabla: CajasDetalle // Solo de Cheques'
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
(
SELECT * FROM SIGA_A_2015.dbo.Cheques CH
 WHERE CH.IdSucursal = CajasDetalle.IdSucursal
   AND ((CH.IdCajaIngreso = CajasDetalle.IdCaja
         AND CH.NroPlanillaIngreso = CajasDetalle.NumeroPlanilla
         AND CH.NroMovimientoIngreso = CajasDetalle.NumeroMovimiento)
        OR 
        (CH.IdCajaEgreso= CajasDetalle.IdCaja
         AND CH.NroPlanillaEgreso = CajasDetalle.NumeroPlanilla
         AND CH.NroMovimientoEgreso= CajasDetalle.NumeroMovimiento))
)
 AND NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CajasDetalle CD2
          WHERE CD2.IdSucursal = CajasDetalle.IdSucursal
         AND CD2.IdCaja = CajasDetalle.IdCaja
         AND CD2.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CD2.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )

PRINT '28. Inserto Tabla: Cheques'
GO

INSERT INTO [SIGA].[dbo].[Cheques]
           ([IdSucursal]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad]
           ,[FechaEmision]
           ,[FechaCobro]
           ,[Titular]
           ,[Importe]
           ,[IdCajaIngreso]
           ,[NroPlanillaIngreso]
           ,[NroMovimientoIngreso]
           ,[IdCajaEgreso]
           ,[NroPlanillaEgreso]
           ,[NroMovimientoEgreso]
           ,[EsPropio]
           ,[IdCuentaBancaria]
           ,[IdEstadoCheque]
           ,[IdEstadoChequeAnt]
           ,[Cuit]
           ,[IdCliente]
           ,[IdProveedor]
           ,[FotoFrente]
           ,[FotoDorso])
SELECT [IdSucursal]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[FechaEmision]
      ,[FechaCobro]
      ,[Titular]
      ,[Importe]
      ,[IdCajaIngreso]
      ,[NroPlanillaIngreso]
      ,[NroMovimientoIngreso]
      ,[IdCajaEgreso]
      ,[NroPlanillaEgreso]
      ,[NroMovimientoEgreso]
      ,[EsPropio]
      ,[IdCuentaBancaria]
      ,[IdEstadoCheque]
      ,[IdEstadoChequeAnt]
      ,[Cuit]
      ,[IdCliente]
      ,[IdProveedor]
      ,[FotoFrente]
      ,[FotoDorso]
  FROM [SIGA_A_2015].[dbo].[Cheques]
GO

-- Lo borro porque tiene le historial del insert actual

PRINT '29.1. Borro Tabla: ChequesHistorial'
GO

DELETE [SIGA].[dbo].[ChequesHistorial]
GO

PRINT '29.2 Inserto Tabla: ChequesHistorial'
GO

INSERT INTO [SIGA].[dbo].[ChequesHistorial]
           ([IdSucursal]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad]
           ,[FechaEmision]
           ,[FechaCobro]
           ,[Titular]
           ,[Importe]
           ,[IdCajaIngreso]
           ,[NroPlanillaIngreso]
           ,[NroMovimientoIngreso]
           ,[IdCajaEgreso]
           ,[NroPlanillaEgreso]
           ,[NroMovimientoEgreso]
           ,[EsPropio]
           ,[IdCuentaBancaria]
           ,[IdEstadoCheque]
           ,[IdEstadoChequeAnt]
           ,[IdCliente]
           ,[IdProveedor]
           ,[Cuit])
SELECT [IdSucursal]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[FechaEmision]
      ,[FechaCobro]
      ,[Titular]
      ,[Importe]
      ,[IdCajaIngreso]
      ,[NroPlanillaIngreso]
      ,[NroMovimientoIngreso]
      ,[IdCajaEgreso]
      ,[NroPlanillaEgreso]
      ,[NroMovimientoEgreso]
      ,[EsPropio]
      ,[IdCuentaBancaria]
      ,[IdEstadoCheque]
      ,[IdEstadoChequeAnt]
      ,[IdCliente]
      ,[IdProveedor]
      ,[Cuit]
  FROM [SIGA_A_2015].[dbo].[ChequesHistorial]
GO

PRINT '30. Inserto Tabla: CuentasCorrientesProvCheques'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesProvCheques]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad]
           ,[IdProveedor])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[IdProveedor]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesProvCheques] CCH
   WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientesProv CCP
       WHERE CCP.IdSucursal = CCH.IdSucursal
         AND CCP.IdTipoComprobante = CCH.IdTipoComprobante
         AND CCP.Letra = CCH.Letra
         AND CCP.CentroEmisor = CCH.CentroEmisor
         AND CCP.NumeroComprobante = CCH.NumeroComprobante
         AND CCP.IdProveedor = CCH.IdProveedor
     )
GO

PRINT '31.1. Inserto Tabla: CuentasCorrientesCheques'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesCheques]
           ([NumeroCheque]
           ,[IdBancoCheque]
           ,[IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdLocalidadCheque]
           ,[IdBancoSucursalCheque])
SELECT [NumeroCheque]
      ,[IdBancoCheque]
      ,[IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdLocalidadCheque]
      ,[IdBancoSucursalCheque]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesCheques] CCH
  WHERE [IdTipoComprobante] <> 'RECIBOPROV'
   AND EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientes CC
       WHERE CC.IdSucursal = CCH.IdSucursal
         AND CC.IdTipoComprobante = CCH.IdTipoComprobante
         AND CC.Letra = CCH.Letra
         AND CC.CentroEmisor = CCH.CentroEmisor
         AND CC.NumeroComprobante = CCH.NumeroComprobante
     )
GO

PRINT '31.2. Inserto Tabla: CuentasCorrientesCheques'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesCheques]
           ([NumeroCheque]
           ,[IdBancoCheque]
           ,[IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdLocalidadCheque]
           ,[IdBancoSucursalCheque])
SELECT [NumeroCheque]
      ,[IdBancoCheque]
      ,3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdLocalidadCheque]
      ,[IdBancoSucursalCheque]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesCheques] CCH
  WHERE [IdTipoComprobante] = 'RECIBOPROV'
   AND EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientes CC
       WHERE 1 = CCH.IdSucursal
         AND CC.IdTipoComprobante = CCH.IdTipoComprobante
         AND CC.Letra = CCH.Letra
         AND CC.CentroEmisor = CCH.CentroEmisor
         AND CC.NumeroComprobante = CCH.NumeroComprobante
     )
GO

PRINT '32. Inserto Tabla: CuentasCorrientesRetenciones'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesRetenciones]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdTipoImpuesto]
           ,[EmisorRetencion]
           ,[NumeroRetencion]
           ,[IdCliente])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdTipoImpuesto]
      ,[EmisorRetencion]
      ,[NumeroRetencion]
      ,[IdCliente]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesRetenciones]
GO

PRINT '33.1. Inserto Tabla: VentasCheques'
GO

INSERT INTO [SIGA].[dbo].[VentasCheques]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
  FROM [SIGA_A_2015].[dbo].[VentasCheques] VC
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE V.IdSucursal = VC.IdSucursal
         AND V.IdTipoComprobante = VC.IdTipoComprobante
         AND V.Letra = VC.Letra
         AND V.CentroEmisor = VC.CentroEmisor
         AND V.NumeroComprobante = VC.NumeroComprobante
         AND V.IdSucursal = 1
     )
GO

PRINT '33.2. Inserto Tabla: VentasCheques'
GO

INSERT INTO [SIGA].[dbo].[VentasCheques]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
  FROM [SIGA_A_2015].[dbo].[VentasCheques] VC
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = VC.IdSucursal
         AND V.IdTipoComprobante = VC.IdTipoComprobante
         AND V.Letra = VC.Letra
         AND V.CentroEmisor = VC.CentroEmisor
         AND V.NumeroComprobante = VC.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '34.1. Inserto Tabla: VentasChequesRechazados'
GO

INSERT INTO [SIGA].[dbo].VentasChequesRechazados
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad])
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
  FROM [SIGA_A_2015].[dbo].VentasChequesRechazados VC
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE V.IdSucursal = VC.IdSucursal
         AND V.IdTipoComprobante = VC.IdTipoComprobante
         AND V.Letra = VC.Letra
         AND V.CentroEmisor = VC.CentroEmisor
         AND V.NumeroComprobante = VC.NumeroComprobante
         AND V.IdSucursal = 1
     )
GO

PRINT '34.2. Inserto Tabla: VentasChequesRechazados'
GO

INSERT INTO [SIGA].[dbo].[VentasChequesRechazados]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
  FROM [SIGA_A_2015].[dbo].[VentasChequesRechazados] VC
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = VC.IdSucursal
         AND V.IdTipoComprobante = VC.IdTipoComprobante
         AND V.Letra = VC.Letra
         AND V.CentroEmisor = VC.CentroEmisor
         AND V.NumeroComprobante = VC.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '35. Inserto Tabla: CajasDetalle // Solo de Retenciones'
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
     ( SELECT * FROM [SIGA_A_2015].[dbo].[Retenciones] RET
       WHERE RET.IdSucursal = CajasDetalle.IdSucursal
         AND RET.IdCajaIngreso = CajasDetalle.IdCaja
         AND RET.NroPlanillaIngreso = CajasDetalle.NumeroPlanilla
         AND RET.NroMovimientoIngreso = CajasDetalle.NumeroMovimiento
     )
 AND NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CajasDetalle CD2
          WHERE CD2.IdSucursal = CajasDetalle.IdSucursal
         AND CD2.IdCaja = CajasDetalle.IdCaja
         AND CD2.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CD2.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO 

PRINT '36. Inserto Tabla: Retenciones'
GO

INSERT INTO [SIGA].[dbo].[Retenciones]
           ([IdSucursal]
           ,[IdTipoImpuesto]
           ,[EmisorRetencion]
           ,[NumeroRetencion]
           ,[FechaEmision]
           ,[BaseImponible]
           ,[Alicuota]
           ,[ImporteTotal]
           ,[IdCajaIngreso]
           ,[NroPlanillaIngreso]
           ,[NroMovimientoIngreso]
           ,[IdEstado]
           ,[IdCliente])
SELECT [IdSucursal]
      ,[IdTipoImpuesto]
      ,[EmisorRetencion]
      ,[NumeroRetencion]
      ,[FechaEmision]
      ,[BaseImponible]
      ,[Alicuota]
      ,[ImporteTotal]
      ,[IdCajaIngreso]
      ,[NroPlanillaIngreso]
      ,[NroMovimientoIngreso]
      ,[IdEstado]
      ,[IdCliente]
  FROM [SIGA_A_2015].[dbo].[Retenciones]
GO

PRINT '37. Inserto Tabla: Depositos'
GO

INSERT INTO [SIGA].[dbo].[Depositos]
           ([IdSucursal]
           ,[NumeroDeposito]
           ,[IdCuentaBancaria]
           ,[Fecha]
           ,[UsoFechaCheque]
           ,[ImporteTotal]
           ,[Observacion]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[ImporteTickets]
           ,[FechaAplicado]
           ,[PeriodoContable]
           ,[IdEstado]
           ,[IdCaja])
SELECT [IdSucursal]
      ,[NumeroDeposito]
      ,[IdCuentaBancaria]
      ,[Fecha]
      ,[UsoFechaCheque]
      ,[ImporteTotal]
      ,[Observacion]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[FechaAplicado]
      ,[PeriodoContable]
      ,[IdEstado]
      ,[IdCaja]
  FROM [SIGA_A_2015].[dbo].[Depositos]
  WHERE IdCuentaBancaria = 2
GO

PRINT '38. Inserto Tabla: DepositosCheques'
GO

INSERT INTO [SIGA].[dbo].[DepositosCheques]
           ([IdSucursal]
           ,[NumeroDeposito]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad])
SELECT [IdSucursal]
      ,[NumeroDeposito]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
  FROM [SIGA_A_2015].[dbo].[DepositosCheques] DC
WHERE EXISTS 
     (SELECT * FROM [SIGA].[dbo].[Depositos] D
       WHERE D.IdSucursal = DC.IdSucursal
         AND D.NumeroDeposito = DC.NumeroDeposito)
GO

PRINT '39. Inserto Tabla: LibrosBancos'
GO

INSERT INTO [SIGA].[dbo].[LibrosBancos]
           ([IdSucursal]
           ,[IdCuentaBancaria]
           ,[NumeroMovimiento]
           ,[IdCuentaBanco]
           ,[IdTipoMovimiento]
           ,[Importe]
           ,[FechaMovimiento]
           ,[FechaAplicado]
           ,[Observacion]
           ,[Conciliado]
           ,[NumeroCheque]
           ,[IdBancoCheque]
           ,[IdBancoSucursalCheque]
           ,[IdLocalidadCheque])
SELECT [IdSucursal]
      ,[IdCuentaBancaria]
      ,[NumeroMovimiento]
      ,[IdCuentaBanco]
      ,[IdTipoMovimiento]
      ,[Importe]
      ,[FechaMovimiento]
      ,[FechaAplicado]
      ,[Observacion]
      ,[Conciliado]
      ,[NumeroCheque]
      ,[IdBancoCheque]
      ,[IdBancoSucursalCheque]
      ,[IdLocalidadCheque]
  FROM [SIGA_A_2015].[dbo].[LibrosBancos]
  WHERE IdCuentaBancaria = 2
GO
