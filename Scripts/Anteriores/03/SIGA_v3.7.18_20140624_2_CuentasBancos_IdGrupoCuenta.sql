
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasBancos ADD IdGrupoCuenta varchar(15) NULL
GO
ALTER TABLE dbo.CuentasBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------------- */

UPDATE dbo.CuentasBancos 
   SET IdGrupoCuenta = '1'
GO

ALTER TABLE dbo.CuentasBancos ALTER COLUMN IdGrupoCuenta varchar(15) NOT NULL
GO

