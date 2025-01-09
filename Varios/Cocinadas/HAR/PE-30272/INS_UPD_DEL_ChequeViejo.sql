SET NOEXEC OFF
SET ANSI_WARNINGS ON
SET XACT_ABORT ON
SET IMPLICIT_TRANSACTIONS OFF
SET ARITHABORT ON
SET NOCOUNT ON
SET QUOTED_IDENTIFIER ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
GO

BEGIN TRAN
-- =======================================================
-- Trigger disable's for table: [dbo].[Cheques]
-- =======================================================
Print 'Trigger disable''s for table: [dbo].[Cheques]'

ALTER TABLE [dbo].[Cheques] DISABLE TRIGGER [ChequesActualizaHistorial]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO

INSERT INTO [dbo].[Cheques]
       ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]
      , [FechaEmision], [FechaCobro], [Titular], [Importe], [IdCajaIngreso]
      , [NroPlanillaIngreso], [NroMovimientoIngreso], [IdCajaEgreso], [NroPlanillaEgreso], [NroMovimientoEgreso]
      , [EsPropio], [IdCuentaBancaria], [IdEstadoCheque], [IdEstadoChequeAnt], [Cuit]
      , [IdCliente], [IdProveedor], [FotoFrente], [FotoDorso], [IdProveedorPreasignado]
      , [IdUsuarioActualizacion], [IdTipoCheque], [NroOperacion])
SELECT  [IdSucursal], [NumeroCheque] + 1000000, [IdBanco], [IdBancoSucursal], [IdLocalidad]
      , [FechaEmision], [FechaCobro], [Titular], [Importe], [IdCajaIngreso]
      , [NroPlanillaIngreso], [NroMovimientoIngreso], [IdCajaEgreso], [NroPlanillaEgreso], [NroMovimientoEgreso]
      , [EsPropio], [IdCuentaBancaria], [IdEstadoCheque], [IdEstadoChequeAnt], [Cuit]
      , [IdCliente], [IdProveedor], [FotoFrente], [FotoDorso], [IdProveedorPreasignado]
      , [IdUsuarioActualizacion], [IdTipoCheque], [NroOperacion] 
  FROM [dbo].[Cheques]
 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO

UPDATE ChequesHistorial         SET [NumeroCheque] = [NumeroCheque] + 1000000 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
UPDATE DepositosCheques         SET [NumeroCheque] = [NumeroCheque] + 1000000 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
UPDATE CuentasCorrientesCheques SET [NumeroCheque] = [NumeroCheque] + 1000000 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBancoCheque=72 AND IdBancoSucursalCheque=237 AND IdLocalidadCheque=2000
UPDATE LibrosBancos             SET [NumeroCheque] = [NumeroCheque] + 1000000 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBancoCheque=72 AND IdBancoSucursalCheque=237 AND IdLocalidadCheque=2000
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO

DELETE FROM [dbo].[Cheques] WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO

-- =======================================================
-- Trigger enable's for table: [dbo].[Cheques]
-- =======================================================
Print 'Trigger enable''s for table: [dbo].[Cheques]'

ALTER TABLE [dbo].[Cheques] ENABLE TRIGGER [ChequesActualizaHistorial]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO

IF @@TRANCOUNT>0
	COMMIT

SET NOEXEC OFF
GO
