ALTER TABLE dbo.ProductosSucursales	ALTER COLUMN  PrecioFabrica decimal(12,4) Not null
ALTER TABLE dbo.ProductosSucursales	ALTER COLUMN  PrecioCosto decimal(12,4) Not null
ALTER TABLE dbo.ProductosSucursales	ALTER COLUMN  PrecioVenta decimal(12,4) Not null

ALTER TABLE dbo.ProductosSucursalesPrecios	ALTER COLUMN  PrecioVenta decimal(12,4) Not null