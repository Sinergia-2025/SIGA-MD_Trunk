
ALTER TABLE dbo.Categorias ADD IdCuenta bigint NULL
GO
ALTER TABLE dbo.Categorias ADD CONSTRAINT
	FK_Categorias_ContabilidadCuentas FOREIGN KEY(IdCuenta) REFERENCES dbo.ContabilidadCuentas
	(IdCuenta) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
