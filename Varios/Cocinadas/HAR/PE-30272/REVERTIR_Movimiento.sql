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

--USE [SIGA_HAR_2]
--GO

BEGIN TRAN

-- =======================================================
-- Foreign key constraint nochecks's for table: [dbo].[ChequesHistorial]
-- =======================================================
Print 'Foreign key constraint nochecks''s for table: [dbo].[ChequesHistorial]'

ALTER TABLE [dbo].[ChequesHistorial] NOCHECK CONSTRAINT [FK_ChequesHistorial_Proveedores]
ALTER TABLE [dbo].[ChequesHistorial] NOCHECK CONSTRAINT [FK_ChequesHistorial_Clientes]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Trigger disable's for table: [dbo].[Cheques]
-- =======================================================
Print 'Trigger disable''s for table: [dbo].[Cheques]'

ALTER TABLE [dbo].[Cheques] DISABLE TRIGGER [ChequesActualizaHistorial]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Foreign key constraint nochecks's for table: [dbo].[Cheques]
-- =======================================================
Print 'Foreign key constraint nochecks''s for table: [dbo].[Cheques]'

ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Proveedores]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Usuarios]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_TiposCheques]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_CuentasBancarias]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Bancos]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Localidades]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Sucursales]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_EstadosCheques]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_EstadosChequesAnt]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_CajasDetalle]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_CajasDetalleEgreso]
ALTER TABLE [dbo].[Cheques] NOCHECK CONSTRAINT [FK_Cheques_Clientes]
ALTER TABLE [dbo].[LibrosBancos] NOCHECK CONSTRAINT [FK_LibrosBancos_Cheques]
ALTER TABLE [dbo].[VentasCheques] NOCHECK CONSTRAINT [FK_VentasCheques_Cheques]
ALTER TABLE [dbo].[VentasChequesRechazados] NOCHECK CONSTRAINT [FK_VentasChequesRechazados_Cheques]
ALTER TABLE [dbo].[DepositosCheques] NOCHECK CONSTRAINT [FK_DepositosCheques_Cheques]
ALTER TABLE [dbo].[CuentasCorrientesProvCheques] NOCHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques]
ALTER TABLE [dbo].[CuentasCorrientesCheques] NOCHECK CONSTRAINT [FK_CuentasCorrientesCheques_Cheques]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Foreign key constraint nochecks's for table: [dbo].[CajasDetalle]
-- =======================================================
Print 'Foreign key constraint nochecks''s for table: [dbo].[CajasDetalle]'

ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_ContabilidadCentrosCostos]
ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_Depositos]
ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_Cajas]
ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_CuentasDeCajas]
ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_ContabilidadAsientosTmp]
ALTER TABLE [dbo].[CajasDetalle] NOCHECK CONSTRAINT [FK_CajasDetalle_Usuarios]
ALTER TABLE [dbo].[RepartosGastos] NOCHECK CONSTRAINT [FK_RepartosGastos_CajasDetalle]
ALTER TABLE [dbo].[CuentasCorrientes] NOCHECK CONSTRAINT [FK_CuentasCorrientes_CajasDetalle]
ALTER TABLE [dbo].[PercepcionVentas] NOCHECK CONSTRAINT [FK_PercepcionVentas_CajasDetalle]
ALTER TABLE [dbo].[Retenciones] NOCHECK CONSTRAINT [FK_Retenciones_CajasDetalle]
ALTER TABLE [dbo].[Ventas] NOCHECK CONSTRAINT [FK_Ventas_CajasDetalle]
ALTER TABLE [dbo].[CuentasCorrientesProv] NOCHECK CONSTRAINT [FK_CuentasCorrientesProv_CajasDetalle]
ALTER TABLE [dbo].[RetencionesCompras] NOCHECK CONSTRAINT [FK_RetencionesCompras_CajasDetalle]
ALTER TABLE [dbo].[Compras] NOCHECK CONSTRAINT [FK_Compras_CajasDetalle]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Deleting 2 row(s) for table [dbo].[ChequesHistorial]
-- =======================================================
Print 'Deleting 2 row(s) for table [dbo].[ChequesHistorial]'

DELETE FROM [dbo].[ChequesHistorial] WHERE [IdSucursal]=1 AND [NumeroCheque]=61 AND [IdBanco]=72 AND [IdBancoSucursal]=237 AND [IdLocalidad]=2000 AND [Orden]=4360
DELETE FROM [dbo].[ChequesHistorial] WHERE [IdSucursal]=3 AND [NumeroCheque]=61 AND [IdBanco]=72 AND [IdBancoSucursal]=237 AND [IdLocalidad]=2000 AND [Orden]=4359
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Deleting 2 row(s) for table [dbo].[CajasDetalle]
-- =======================================================
Print 'Deleting 2 row(s) for table [dbo].[CajasDetalle]'

DELETE FROM [dbo].[CajasDetalle] WHERE [IdSucursal]=1 AND [IdCaja]=8 AND [NumeroPlanilla]=28 AND [NumeroMovimiento]=38
DELETE FROM [dbo].[CajasDetalle] WHERE [IdSucursal]=3 AND [IdCaja]=8 AND [NumeroPlanilla]=26 AND [NumeroMovimiento]=12
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Updating 2 row(s) for table [dbo].[Cheques]
-- =======================================================
Print 'Updating 2 row(s) for table [dbo].[Cheques]'

UPDATE [dbo].[Cheques] SET [IdCajaIngreso]=3, [NroPlanillaIngreso]=104, [NroMovimientoIngreso]=42, [IdEstadoCheque]='DEPOSITADO', [IdEstadoChequeAnt]='ENCARTERA', [IdUsuarioActualizacion]=NULL WHERE [IdSucursal]=1 AND [NumeroCheque]=61 AND [IdBanco]=72 AND [IdBancoSucursal]=237 AND [IdLocalidad]=2000
UPDATE [dbo].[Cheques] SET [IdCajaEgreso]=NULL, [NroPlanillaEgreso]=NULL, [NroMovimientoEgreso]=NULL, [IdEstadoCheque]='ENCARTERA', [IdUsuarioActualizacion]='bbiselli' WHERE [IdSucursal]=3 AND [NumeroCheque]=61 AND [IdBanco]=72 AND [IdBancoSucursal]=237 AND [IdLocalidad]=2000
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Foreign key constraint check's for table: [dbo].[CajasDetalle]
-- =======================================================
Print 'Foreign key constraint check''s for table: [dbo].[CajasDetalle]'

ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_ContabilidadCentrosCostos]
ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_Depositos]
ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_Cajas]
ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_CuentasDeCajas]
ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_ContabilidadAsientosTmp]
ALTER TABLE [dbo].[CajasDetalle]  CHECK CONSTRAINT [FK_CajasDetalle_Usuarios]
ALTER TABLE [dbo].[RepartosGastos]  CHECK CONSTRAINT [FK_RepartosGastos_CajasDetalle]
ALTER TABLE [dbo].[CuentasCorrientes]  CHECK CONSTRAINT [FK_CuentasCorrientes_CajasDetalle]
ALTER TABLE [dbo].[PercepcionVentas]  CHECK CONSTRAINT [FK_PercepcionVentas_CajasDetalle]
ALTER TABLE [dbo].[Retenciones]  CHECK CONSTRAINT [FK_Retenciones_CajasDetalle]
ALTER TABLE [dbo].[Ventas]  CHECK CONSTRAINT [FK_Ventas_CajasDetalle]
ALTER TABLE [dbo].[CuentasCorrientesProv]  CHECK CONSTRAINT [FK_CuentasCorrientesProv_CajasDetalle]
ALTER TABLE [dbo].[RetencionesCompras]  CHECK CONSTRAINT [FK_RetencionesCompras_CajasDetalle]
ALTER TABLE [dbo].[Compras]  CHECK CONSTRAINT [FK_Compras_CajasDetalle]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
-- =======================================================
-- Foreign key constraint check's for table: [dbo].[Cheques]
-- =======================================================
Print 'Foreign key constraint check''s for table: [dbo].[Cheques]'

ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Proveedores]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Usuarios]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_TiposCheques]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_CuentasBancarias]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Bancos]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Localidades]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Sucursales]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_EstadosCheques]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_EstadosChequesAnt]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_CajasDetalle]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_CajasDetalleEgreso]
ALTER TABLE [dbo].[Cheques]  CHECK CONSTRAINT [FK_Cheques_Clientes]
ALTER TABLE [dbo].[LibrosBancos]  CHECK CONSTRAINT [FK_LibrosBancos_Cheques]
ALTER TABLE [dbo].[VentasCheques]  CHECK CONSTRAINT [FK_VentasCheques_Cheques]
ALTER TABLE [dbo].[VentasChequesRechazados]  CHECK CONSTRAINT [FK_VentasChequesRechazados_Cheques]
ALTER TABLE [dbo].[DepositosCheques]  CHECK CONSTRAINT [FK_DepositosCheques_Cheques]
ALTER TABLE [dbo].[CuentasCorrientesProvCheques]  CHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques]
ALTER TABLE [dbo].[CuentasCorrientesCheques]  CHECK CONSTRAINT [FK_CuentasCorrientesCheques_Cheques]
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
-- =======================================================
-- Foreign key constraint check's for table: [dbo].[ChequesHistorial]
-- =======================================================
Print 'Foreign key constraint check''s for table: [dbo].[ChequesHistorial]'

ALTER TABLE [dbo].[ChequesHistorial]  CHECK CONSTRAINT [FK_ChequesHistorial_Proveedores]
ALTER TABLE [dbo].[ChequesHistorial]  CHECK CONSTRAINT [FK_ChequesHistorial_Clientes]
GO
-- TRANSACTION HANDLING
IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
GO
IF @@TRANCOUNT>0
	COMMIT

SET NOEXEC OFF
GO
