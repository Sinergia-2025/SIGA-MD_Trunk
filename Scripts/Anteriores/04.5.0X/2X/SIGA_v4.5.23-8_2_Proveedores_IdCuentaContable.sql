
ALTER TABLE dbo.Proveedores ADD IdCuentaContable bigint NULL
GO

ALTER TABLE dbo.Proveedores ADD CONSTRAINT FK_Proveedores_ContabilidadCuentas
    FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
