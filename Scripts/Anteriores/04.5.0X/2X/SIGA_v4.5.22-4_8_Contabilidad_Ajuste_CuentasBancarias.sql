
ALTER TABLE CuentasBancarias ALTER COLUMN IdCuentaContable bigint NULL
GO

UPDATE dbo.CuentasBancarias SET IdCuentaContable = NULL WHERE IdCuentaContable = 0
GO

ALTER TABLE dbo.CuentasBancarias ADD CONSTRAINT
    FK_CuentasBancarias_ContabilidadCuentas FOREIGN KEY (IdCuentaContable)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

UPDATE dbo.CuentasBancarias SET IdPlanCuenta = NULL WHERE IdPlanCuenta = 0
GO

ALTER TABLE dbo.CuentasBancarias ADD CONSTRAINT
    FK_CuentasBancarias_ContabilidadPlanes FOREIGN KEY (IdPlanCuenta)
    REFERENCES dbo.ContabilidadPlanes (IdPlanCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
