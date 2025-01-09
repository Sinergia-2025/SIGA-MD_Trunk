
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasBancos ADD [IdCuentaContable] [int] NULL
GO
ALTER TABLE dbo.CuentasBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO
UPDATE CuentasBancos SET [IdCuentaContable] = 0 WHERE [IdCuentaContable] is null
GO

IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
                             WHERE TABLE_NAME = 'CuentasBancos' AND COLUMN_NAME = 'IdCuentaDebe')
    BEGIN
	ALTER TABLE CuentasBancos DROP COLUMN IdCuentaDebe
	ALTER TABLE CuentasBancos DROP COLUMN IdCuentaHaber
    END
GO


BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasBancarias ADD [IdPlanCuenta] [int] NULL
GO
COMMIT
GO
UPDATE CuentasBancarias SET [IdPlanCuenta] = 0 WHERE [IdPlanCuenta] is null
GO

BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasBancarias ADD [IdCuentaContable] [int] NULL
GO
COMMIT
GO
UPDATE CuentasBancarias SET [IdCuentaContable] = 0 WHERE [IdCuentaContable] is null
GO

ALTER TABLE CuentasBancarias DROP COLUMN IdCuentaDebe
GO
ALTER TABLE CuentasBancarias DROP COLUMN IdCuentaHaber
GO
