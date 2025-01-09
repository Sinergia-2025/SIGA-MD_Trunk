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
PRINT '1 NUL a column FechaActualizacion de Productos'
ALTER TABLE dbo.Productos ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '2 NUL a column FechaActualizacion de Localidades'
ALTER TABLE dbo.Localidades ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO

PRINT '3 NUL a column FechaActualizacion de Rubros'
ALTER TABLE dbo.Rubros ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '4 NUL a column FechaActualizacion de SubRubros'
ALTER TABLE dbo.SubRubros ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '5 NUL a column FechaActualizacion de SubSubRubros'
ALTER TABLE dbo.SubSubRubros ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '6 NUL a column FechaActualizacion de ProductosWeb'
ALTER TABLE dbo.ProductosWeb ALTER COLUMN FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.ProductosWeb SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
