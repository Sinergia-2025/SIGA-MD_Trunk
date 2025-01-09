ALTER TABLE dbo.Clientes ADD IdCuentaContable bigint NULL
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT FK_Clientes_ContabilidadCuentas
    FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Prospectos ADD IdCuentaContable bigint NULL
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT FK_Prospectos_ContabilidadCuentas
    FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.AuditoriaClientes ADD IdCuentaContable bigint NULL
GO
ALTER TABLE dbo.AuditoriaProspectos ADD IdCuentaContable bigint NULL
GO
