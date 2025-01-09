
ALTER TABLE dbo.Productos ADD IdProveedor bigint NULL
GO

ALTER TABLE dbo.AuditoriaProductos ADD IdProveedor bigint NULL
GO

/* --------------- */

ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
