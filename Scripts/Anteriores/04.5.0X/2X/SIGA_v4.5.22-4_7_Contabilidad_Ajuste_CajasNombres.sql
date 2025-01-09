
ALTER TABLE CajasNombres ALTER COLUMN IdCuentaContable bigint NULL
GO

UPDATE dbo.CajasNombres SET IdCuentaContable = NULL WHERE IdCuentaContable = 0
GO

ALTER TABLE dbo.CajasNombres ADD CONSTRAINT
    FK_CajasNombres_ContabilidadCuentas FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
