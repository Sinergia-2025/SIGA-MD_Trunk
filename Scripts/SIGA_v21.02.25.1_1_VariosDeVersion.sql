PRINT ''
PRINT '1. Nuevo Campo en Provincias: IdAFIPProvincia'
ALTER TABLE Provincias ADD IdAFIPProvincia INT NULL
GO

PRINT ''
PRINT '1.1. Asignación de códigos a las provincias según tabla de AFIP'
UPDATE Provincias SET IdAFIPProvincia = 00 WHERE IdProvincia = 'CF'
UPDATE Provincias SET IdAFIPProvincia = 01 WHERE IdProvincia = 'BS'
UPDATE Provincias SET IdAFIPProvincia = 02 WHERE IdProvincia = 'CA'
UPDATE Provincias SET IdAFIPProvincia = 03 WHERE IdProvincia = 'CB'
UPDATE Provincias SET IdAFIPProvincia = 04 WHERE IdProvincia = 'CR'
UPDATE Provincias SET IdAFIPProvincia = 05 WHERE IdProvincia = 'ER'
UPDATE Provincias SET IdAFIPProvincia = 06 WHERE IdProvincia = 'JU'
UPDATE Provincias SET IdAFIPProvincia = 07 WHERE IdProvincia = 'MZ'
UPDATE Provincias SET IdAFIPProvincia = 08 WHERE IdProvincia = 'LR'
UPDATE Provincias SET IdAFIPProvincia = 09 WHERE IdProvincia = 'SA'
UPDATE Provincias SET IdAFIPProvincia = 10 WHERE IdProvincia = 'SJ'
UPDATE Provincias SET IdAFIPProvincia = 11 WHERE IdProvincia = 'SL'
UPDATE Provincias SET IdAFIPProvincia = 12 WHERE IdProvincia = 'SF'
UPDATE Provincias SET IdAFIPProvincia = 13 WHERE IdProvincia = 'SE'
UPDATE Provincias SET IdAFIPProvincia = 14 WHERE IdProvincia = 'TC'
UPDATE Provincias SET IdAFIPProvincia = 16 WHERE IdProvincia = 'CH'
UPDATE Provincias SET IdAFIPProvincia = 17 WHERE IdProvincia = 'CU'
UPDATE Provincias SET IdAFIPProvincia = 18 WHERE IdProvincia = 'FO'
UPDATE Provincias SET IdAFIPProvincia = 19 WHERE IdProvincia = 'MI'
UPDATE Provincias SET IdAFIPProvincia = 20 WHERE IdProvincia = 'NE'
UPDATE Provincias SET IdAFIPProvincia = 21 WHERE IdProvincia = 'LP'
UPDATE Provincias SET IdAFIPProvincia = 22 WHERE IdProvincia = 'RN'
UPDATE Provincias SET IdAFIPProvincia = 23 WHERE IdProvincia = 'SC'
UPDATE Provincias SET IdAFIPProvincia = 24 WHERE IdProvincia = 'TF'
UPDATE Provincias SET IdAFIPProvincia = '' WHERE IdAFIPProvincia IS NULL

PRINT ''
PRINT '1.2. Cambio el IdAFIPProvincia a NOT NULL'
ALTER TABLE Provincias ALTER COLUMN IdAFIPProvincia INT NOT NULL
GO

PRINT ''
PRINT '2. Tabla Rubros: Nuevo campo CodigoExportacion'
ALTER TABLE Rubros ADD CodigoExportacion VARCHAR(5)
PRINT ''
PRINT '3. Tabla SubRubros: Nuevo campo CodigoExportacion'
ALTER TABLE SubRubros ADD CodigoExportacion VARCHAR(5)
PRINT ''
PRINT '4. Tabla CategoriasFiscales: Nuevo campo CodigoExportacion'
ALTER TABLE CategoriasFiscales ADD CodigoExportacion VARCHAR(10) NULL
GO

