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
ALTER TABLE dbo.Productos ADD EsCambiable bit NULL
ALTER TABLE dbo.Productos ADD EsBonificable bit NULL
GO

UPDATE Productos SET EsCambiable = 0, EsBonificable = 0;

ALTER TABLE dbo.Productos ALTER COLUMN EsCambiable bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN EsBonificable bit NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaProductos ADD EsCambiable bit NULL
ALTER TABLE dbo.AuditoriaProductos ADD EsBonificable bit NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
