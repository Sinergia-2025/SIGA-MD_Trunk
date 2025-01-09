ALTER TABLE dbo.Productos ADD PublicarEnGestion bit NULL
ALTER TABLE dbo.Productos ADD PublicarEnEmpresarial bit NULL
ALTER TABLE dbo.Productos ADD PublicarEnBalanza bit NULL
ALTER TABLE dbo.Productos ADD PublicarEnSincronizacionSucursal bit NULL
GO

ALTER TABLE dbo.Productos ADD CONSTRAINT DF_Productos_PublicarEnGestion DEFAULT 1 FOR PublicarEnGestion
ALTER TABLE dbo.Productos ADD CONSTRAINT DF_Productos_PublicarEnEmpresarial DEFAULT 1 FOR PublicarEnEmpresarial
ALTER TABLE dbo.Productos ADD CONSTRAINT DF_Productos_PublicarEnBalanza DEFAULT 1 FOR PublicarEnBalanza
ALTER TABLE dbo.Productos ADD CONSTRAINT DF_Productos_PublicarEnSincronizacionSucursal DEFAULT 1 FOR PublicarEnSincronizacionSucursal
GO

UPDATE Productos
   SET PublicarEnGestion = PublicarEnWeb
     , PublicarEnEmpresarial = PublicarEnWeb
     , PublicarEnBalanza = PublicarEnWeb
     , PublicarEnSincronizacionSucursal = PublicarEnWeb

ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnGestion bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnEmpresarial bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnBalanza bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnSincronizacionSucursal bit NOT NULL
GO

ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnGestion bit NULL
ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnEmpresarial bit NULL
ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnBalanza bit NULL
ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnSincronizacionSucursal bit NULL
GO
