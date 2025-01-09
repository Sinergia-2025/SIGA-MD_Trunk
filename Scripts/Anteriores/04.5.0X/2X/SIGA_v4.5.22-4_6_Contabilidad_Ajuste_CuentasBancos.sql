
ALTER TABLE CuentasBancos ALTER COLUMN IdCuentaContable bigint NULL
GO

UPDATE dbo.CuentasBancos SET IdCuentaContable = NULL WHERE IdCuentaContable = 0
GO

ALTER TABLE dbo.CuentasBancos ADD CONSTRAINT
    FK_CuentasBancos_ContabilidadCuentas FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
