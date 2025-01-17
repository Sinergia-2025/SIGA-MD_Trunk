
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
EXECUTE sp_rename N'dbo.CuentasDeCajas.CuentaContable', N'Tmp_IdGrupoCuenta', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CuentasDeCajas.Tmp_IdGrupoCuenta', N'IdGrupoCuenta', 'COLUMN' 
GO
ALTER TABLE dbo.CuentasDeCajas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/

UPDATE dbo.CuentasDeCajas SET IdGrupoCuenta = 'General'
  WHERE IdGrupoCuenta IS NULL
GO

ALTER TABLE dbo.CuentasDeCajas ALTER COLUMN IdGrupoCuenta varchar(15) NOT NULL
GO
