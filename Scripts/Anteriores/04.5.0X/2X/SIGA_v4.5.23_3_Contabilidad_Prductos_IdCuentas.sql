
ALTER TABLE dbo.Productos ADD IdCuentaCompras bigint NULL
GO

ALTER TABLE dbo.Productos ADD IdCuentaVentas bigint NULL
GO

ALTER TABLE dbo.Productos ADD CONSTRAINT
    FK_Productos_ContabilidadCuentas_Compras FOREIGN KEY(IdCuentaCompras)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.Productos ADD CONSTRAINT
    FK_Productos_ContabilidadCuentas_Ventas FOREIGN KEY (IdCuentaVentas)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

/* ----------- */

ALTER TABLE dbo.AuditoriaProductos ADD IdCuentaCompras bigint NULL
GO

ALTER TABLE dbo.AuditoriaProductos ADD IdCuentaVentas bigint NULL
GO
