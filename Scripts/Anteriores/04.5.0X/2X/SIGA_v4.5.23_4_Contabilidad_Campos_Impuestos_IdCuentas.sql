
ALTER TABLE dbo.Impuestos ADD IdCuentaCompras bigint NULL
GO
ALTER TABLE dbo.Impuestos ADD IdCuentaVentas bigint NULL
GO

ALTER TABLE dbo.Impuestos ADD CONSTRAINT
    FK_Impuestos_ContabilidadCuentas_Compras FOREIGN KEY(IdCuentaCompras)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.Impuestos ADD CONSTRAINT
    FK_Impuestos_ContabilidadCuentas_Ventas FOREIGN KEY (IdCuentaVentas)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
