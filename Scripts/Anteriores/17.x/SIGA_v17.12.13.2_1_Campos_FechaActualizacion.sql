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
PRINT '1. Agrego columna FechaActualizacion en Productos'
ALTER TABLE dbo.Productos ADD FechaActualizacion datetime NULL
GO
PRINT '1.1 Fecha 01-01-1900 en FechaActualizacion de Productos'
UPDATE Productos SET FechaActualizacion = cast(0 as datetime);
PRINT '1.2 NOT NUL a column FechaActualizacion de Productos'
ALTER TABLE dbo.Productos ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '1.3 Agrego columna FechaActualizacion en AuditoriaProductos'
ALTER TABLE dbo.AuditoriaProductos ADD FechaActualizacion datetime NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '2. Agrego columna FechaActualizacion en Localidades'
ALTER TABLE dbo.Localidades ADD FechaActualizacion datetime NULL
GO
PRINT '2.1 Fecha 01-01-1900 en FechaActualizacion de Localidades'
UPDATE Localidades SET FechaActualizacion = cast(0 as datetime);
PRINT '2.2 NOT NUL a column FechaActualizacion de Localidades'
ALTER TABLE dbo.Localidades ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO

PRINT '3. Agrego columna FechaActualizacion en Rubros'
ALTER TABLE dbo.Rubros ADD FechaActualizacion datetime NULL
GO
PRINT '3.1 Fecha 01-01-1900 en FechaActualizacion de Rubros'
UPDATE Rubros SET FechaActualizacion = cast(0 as datetime);
PRINT '3.2 NOT NUL a column FechaActualizacion de Rubros'
ALTER TABLE dbo.Rubros ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '4. Agrego columna FechaActualizacion en SubRubros'
ALTER TABLE dbo.SubRubros ADD FechaActualizacion datetime NULL
GO
PRINT '4.1 Fecha 01-01-1900 en FechaActualizacion de SubRubros'
UPDATE SubRubros SET FechaActualizacion = cast(0 as datetime);
PRINT '4.2 NOT NUL a column FechaActualizacion de SubRubros'
ALTER TABLE dbo.SubRubros ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '5. Agrego columna FechaActualizacion en SubSubRubros'
ALTER TABLE dbo.SubSubRubros ADD FechaActualizacion datetime NULL
GO
PRINT '5.1 Fecha 01-01-1900 en FechaActualizacion de SubSubRubros'
UPDATE SubSubRubros SET FechaActualizacion = cast(0 as datetime);
PRINT '5.2 NOT NUL a column FechaActualizacion de SubSubRubros'
ALTER TABLE dbo.SubSubRubros ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)
GO

PRINT '6. Agrego columna FechaActualizacion en ProductosWeb'
ALTER TABLE dbo.ProductosWeb ADD FechaActualizacion datetime NULL
GO
PRINT '6.1 Fecha 01-01-1900 en FechaActualizacion de ProductosWeb'
UPDATE ProductosWeb SET FechaActualizacion = cast(0 as datetime);
PRINT '6.2 NOT NUL a column FechaActualizacion de ProductosWeb'
ALTER TABLE dbo.ProductosWeb ALTER COLUMN FechaActualizacion datetime NOT NULL
GO
ALTER TABLE dbo.ProductosWeb SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
