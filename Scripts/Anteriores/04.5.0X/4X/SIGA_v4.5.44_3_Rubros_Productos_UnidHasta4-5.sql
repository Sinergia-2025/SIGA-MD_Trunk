
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
ALTER TABLE dbo.Rubros ADD UnidHasta4 decimal(14, 4) NULL
ALTER TABLE dbo.Rubros ADD UnidHasta5 decimal(14, 4) NULL
ALTER TABLE dbo.Rubros ADD UHPorc4 decimal(5, 2) NULL
ALTER TABLE dbo.Rubros ADD UHPorc5 decimal(5, 2) NULL
GO
UPDATE Rubros SET UnidHasta4 = 0, UnidHasta5 = 0, UHPorc4 = 0, UHPorc5 = 0
GO
ALTER TABLE dbo.Rubros ALTER COLUMN UnidHasta4 decimal(14, 4) NOT NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UnidHasta5 decimal(14, 4) NOT NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc4 decimal(5, 2) NOT NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc5 decimal(5, 2) NOT NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Productos ADD UnidHasta4 decimal(14, 4) NULL
ALTER TABLE dbo.Productos ADD UnidHasta5 decimal(14, 4) NULL
ALTER TABLE dbo.Productos ADD UHPorc4 decimal(5, 2) NULL
ALTER TABLE dbo.Productos ADD UHPorc5 decimal(5, 2) NULL
GO
UPDATE Productos SET UnidHasta4 = 0, UnidHasta5 = 0, UHPorc4 = 0, UHPorc5 = 0
GO
ALTER TABLE dbo.Productos ALTER COLUMN UnidHasta4 decimal(14, 4) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN UnidHasta5 decimal(14, 4) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN UHPorc4 decimal(5, 2) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN UHPorc5 decimal(5, 2) NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD UnidHasta4 decimal(14, 4) NULL
ALTER TABLE dbo.AuditoriaProductos ADD UnidHasta5 decimal(14, 4) NULL
ALTER TABLE dbo.AuditoriaProductos ADD UHPorc4 decimal(5, 2) NULL
ALTER TABLE dbo.AuditoriaProductos ADD UHPorc5 decimal(5, 2) NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
