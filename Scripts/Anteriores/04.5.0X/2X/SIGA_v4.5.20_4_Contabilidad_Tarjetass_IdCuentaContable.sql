
ALTER TABLE dbo.Tarjetas ADD IdCuentaContable bigint NULL
GO

ALTER TABLE dbo.Tarjetas ADD CONSTRAINT	FK_Tarjetas_ContabilidadCuentas FOREIGN KEY (IdCuentaContable)
	REFERENCES dbo.ContabilidadCuentas (IdCuenta) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
GO
