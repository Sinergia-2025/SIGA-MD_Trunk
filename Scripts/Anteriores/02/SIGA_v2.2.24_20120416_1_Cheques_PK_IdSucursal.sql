
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesCheques
	DROP CONSTRAINT FK_CuentasCorrientesCheques_Cheques
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques
	DROP CONSTRAINT FK_CuentasCorrientesProvCheques_Cheques
GO
ALTER TABLE dbo.DepositosCheques
	DROP CONSTRAINT FK_DepositosCheques_Cheques
GO
ALTER TABLE dbo.LibrosBancos
	DROP CONSTRAINT FK_LibrosBancos_Cheques
GO
ALTER TABLE dbo.VentasCheques
	DROP CONSTRAINT FK_VentasCheques_Cheques
GO
ALTER TABLE dbo.VentasChequesRechazados
	DROP CONSTRAINT FK_VentasChequesRechazados_Cheques
GO
ALTER TABLE dbo.Cheques
	DROP CONSTRAINT PK_Cheques
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT
	PK_Cheques PRIMARY KEY CLUSTERED 
	(
	idSucursal,
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasChequesRechazados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasCheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LibrosBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.DepositosCheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesCheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*----------------------*/

ALTER TABLE [dbo].[CuentasCorrientesCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesCheques_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[CuentasCorrientesCheques] CHECK CONSTRAINT [FK_CuentasCorrientesCheques_Cheques]
GO


ALTER TABLE [dbo].[CuentasCorrientesProvCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[CuentasCorrientesProvCheques] CHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques]
GO


ALTER TABLE [dbo].[DepositosCheques]  WITH CHECK ADD  CONSTRAINT [FK_DepositosCheques_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[DepositosCheques] CHECK CONSTRAINT [FK_DepositosCheques_Cheques]
GO


ALTER TABLE [dbo].[LibrosBancos]  WITH CHECK ADD  CONSTRAINT [FK_LibrosBancos_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[LibrosBancos] CHECK CONSTRAINT [FK_LibrosBancos_Cheques]
GO


ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Cheques]
GO

ALTER TABLE [dbo].[VentasChequesRechazados]  WITH CHECK ADD  CONSTRAINT [FK_VentasChequesRechazados_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[VentasChequesRechazados] CHECK CONSTRAINT [FK_VentasChequesRechazados_Cheques]
GO

