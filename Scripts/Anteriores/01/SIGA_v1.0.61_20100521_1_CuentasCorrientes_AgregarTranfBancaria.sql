
ALTER TABLE [dbo].[CuentasCorrientes]
	ADD [ImporteTransfBancaria] [decimal](10, 2)  NULL
GO

ALTER TABLE [dbo].[CuentasCorrientes]
	ADD [IdCuentaBancaria] [int] NULL
GO
	

ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])
GO

ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_CuentasBancarias]
GO

UPDATE [dbo].[CuentasCorrientes]
    SET ImporteTransfBancaria =0
GO

