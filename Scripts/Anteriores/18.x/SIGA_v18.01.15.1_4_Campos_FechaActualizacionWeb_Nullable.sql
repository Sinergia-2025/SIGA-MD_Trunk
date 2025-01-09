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
PRINT '1 NUL a column FechaActualizacionWeb de Productos'
ALTER TABLE dbo.Productos ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '2 NUL a column FechaActualizacionWeb de Localidades'
ALTER TABLE dbo.Localidades ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO

PRINT '3 NUL a column FechaActualizacionWeb de Rubros'
ALTER TABLE dbo.Rubros ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '4 NUL a column FechaActualizacionWeb de SubRubros'
ALTER TABLE dbo.SubRubros ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '5 NUL a column FechaActualizacionWeb de SubSubRubros'
ALTER TABLE dbo.SubSubRubros ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '6 NUL a column FechaActualizacionWeb de ProductosWeb'
ALTER TABLE dbo.ProductosWeb ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.ProductosWeb SET (LOCK_ESCALATION = TABLE)
GO

PRINT '7 NUL a column FechaActualizacionWeb de ProductosSucursales'
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.ProductosSucursales SET (LOCK_ESCALATION = TABLE)
GO

PRINT '8 NUL a column FechaActualizacionWeb de ProductosSucursalesPrecios'
ALTER TABLE dbo.ProductosSucursalesPrecios ALTER COLUMN FechaActualizacionWeb datetime NULL
GO
ALTER TABLE dbo.ProductosSucursalesPrecios SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
