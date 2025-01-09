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
ALTER TABLE dbo.Productos ADD DescRecProducto decimal(10, 5) NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT DF_Productos_DescRecProducto DEFAULT 0 FOR DescRecProducto
UPDATE Productos SET DescRecProducto = 0;
ALTER TABLE dbo.Productos ALTER COLUMN DescRecProducto decimal(10, 5) NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD DescRecProducto decimal(10, 5) NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
