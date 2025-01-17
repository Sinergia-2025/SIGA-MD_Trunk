
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
EXECUTE sp_rename N'dbo.ClientesDescuentosMarcas.DescuentoRecargo', N'Tmp_DescuentoRecargoPorc1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.ClientesDescuentosMarcas.Tmp_DescuentoRecargoPorc1', N'DescuentoRecargoPorc1', 'COLUMN' 
GO
ALTER TABLE dbo.ClientesDescuentosMarcas ADD DescuentoRecargoPorc2 decimal(5, 2) NULL
GO
ALTER TABLE dbo.ClientesDescuentosMarcas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* ----------- */

UPDATE dbo.ClientesDescuentosMarcas SET DescuentoRecargoPorc2 = 0
GO

ALTER TABLE dbo.ClientesDescuentosMarcas ALTER COLUMN DescuentoRecargoPorc2 decimal(5, 2) NOT NULL
GO
