
-- Agregar columna nueva
ALTER TABLE dbo.CategoriasFiscales ADD EsPasiblePercIIBB bit Null
GO

-- Establecer Columna nueva con los mismos valores que SolicitaCUIT
UPDATE dbo.CategoriasFiscales set EsPasiblePercIIBB = (select SolicitaCUIT)
GO

ALTER TABLE dbo.CategoriasFiscales ALTER COLUMN EsPasiblePercIIBB bit NOT Null
GO
