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
PRINT 'A.-    *******  RENAME DE CAMPOS  *******'
--   *******  PRODUCTOS  *******
PRINT '1. Renombro columna FechaActualizacion como FechaActualizacionWeb en Productos'
EXECUTE sp_rename N'dbo.Productos.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '1.1 Renombro columna FechaActualizacion como FechaActualizacionWeb en AuditoriaProductos'
EXECUTE sp_rename N'dbo.AuditoriaProductos.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO

--   *******  LOCALIDADES  *******
PRINT '2. Renombro columna FechaActualizacion como FechaActualizacionWeb en Localidades'
EXECUTE sp_rename N'dbo.Localidades.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO

--   *******  RUBROS  *******
PRINT '3. Renombro columna FechaActualizacion como FechaActualizacionWeb en Rubros'
EXECUTE sp_rename N'dbo.Rubros.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO

--   *******  SUBRUBROS  *******
PRINT '4. Renombro columna FechaActualizacion como FechaActualizacionWeb en SubRubros'
EXECUTE sp_rename N'dbo.SubRubros.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO

--   *******  SUBSUBRUBROS  *******
PRINT '5. Renombro columna FechaActualizacion como FechaActualizacionWeb en SubSubRubros'
EXECUTE sp_rename N'dbo.SubSubRubros.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)
GO

--   *******  PRODUCTOSWEB  *******
PRINT '6. Renombro columna FechaActualizacion como FechaActualizacionWeb en ProductosWeb'
EXECUTE sp_rename N'dbo.ProductosWeb.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.ProductosWeb SET (LOCK_ESCALATION = TABLE)
GO

--   *******  CLIENTES  *******
PRINT '7. Renombro columna FechaActualizacion como FechaActualizacionWeb en Clientes'
EXECUTE sp_rename N'dbo.Clientes.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO

PRINT '7.1 Renombro columna FechaActualizacion como FechaActualizacionWeb en AuditoriaClientes'
EXECUTE sp_rename N'dbo.AuditoriaClientes.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO


PRINT 'B.-    *******  NUEVOS CAMPOS  *******'
--   *******  PRODUCTOSSUCURSALES  *******
PRINT '8. Agrego columna FechaActualizacionWeb en ProductosSucursales'
ALTER TABLE dbo.ProductosSucursales ADD FechaActualizacionWeb datetime NULL
GO
PRINT '8.1 Actualiza FechaActualizacionWeb con FechaActualizacion de ProductosSucursales'
UPDATE ProductosSucursales SET FechaActualizacionWeb = FechaActualizacion;
PRINT '8.2 NOT NUL a column FechaActualizacionWeb de ProductosSucursales'
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN FechaActualizacionWeb datetime NOT NULL
GO
ALTER TABLE dbo.ProductosSucursales SET (LOCK_ESCALATION = TABLE)
GO

--   *******  PRODUCTOSSUCURSALESPRECIOS  *******
PRINT '9. Agrego columna FechaActualizacionWeb en ProductosSucursalesPrecios'
ALTER TABLE dbo.ProductosSucursalesPrecios ADD FechaActualizacionWeb datetime NULL
GO
PRINT '9.1 Actualiza FechaActualizacionWeb con FechaActualizacion de ProductosSucursalesPrecios'
UPDATE ProductosSucursalesPrecios SET FechaActualizacionWeb = FechaActualizacion;
PRINT '9.2 NOT NUL a column FechaActualizacionWeb de ProductosSucursalesPrecios'
ALTER TABLE dbo.ProductosSucursalesPrecios ALTER COLUMN FechaActualizacionWeb datetime NOT NULL
GO
ALTER TABLE dbo.ProductosSucursalesPrecios SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
