
PRINT '1. Rubros: amplio los decimales de los campos UHPorc1 a UHPorc5.'

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
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc1 decimal(10, 5) NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc2 decimal(10, 5) NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc3 decimal(10, 5) NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc4 decimal(10, 5) NULL
ALTER TABLE dbo.Rubros ALTER COLUMN UHPorc5 decimal(10, 5) NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '2. VentasProductos: amplio los decimales de campos DescuentoRecargoPorc y DescuentoRecargoPorc2.'

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
ALTER TABLE dbo.VentasProductos ALTER COLUMN DescuentoRecargoPorc2 decimal(10, 5) NULL
ALTER TABLE dbo.VentasProductos ALTER COLUMN DescuentoRecargoPorc decimal(10, 5) NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
