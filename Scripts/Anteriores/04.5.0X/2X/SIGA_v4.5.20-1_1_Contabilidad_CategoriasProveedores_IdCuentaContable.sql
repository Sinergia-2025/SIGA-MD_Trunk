
ALTER TABLE dbo.CategoriasProveedores ADD
	IdCuentaContable bigint NULL
GO
ALTER TABLE dbo.CategoriasProveedores ADD CONSTRAINT
	FK_CategoriasProveedores_ContabilidadCuentas FOREIGN KEY
	(
	IdCuentaContable
	) REFERENCES dbo.ContabilidadCuentas
	(
	IdCuenta
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
