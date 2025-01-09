
ALTER TABLE CuentasDeCajas ALTER COLUMN IdCuentaContable bigint NULL
GO

UPDATE dbo.CuentasDeCajas SET IdCuentaContable = NULL WHERE IdCuentaContable = 0
GO

ALTER TABLE dbo.CuentasDeCajas ADD CONSTRAINT
    FK_CuentasDeCajas_ContabilidadCuentas FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
