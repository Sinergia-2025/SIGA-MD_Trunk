
ALTER TABLE Productos ADD PrecioPorEmbalaje bit null
GO

UPDATE Productos SET PrecioPorEmbalaje = 'False'
GO

ALTER TABLE Productos ALTER COLUMN PrecioPorEmbalaje bit not null
GO

--Asigno el default para otros sistemas / Importar Productos desde Excel.

ALTER TABLE Productos ADD DEFAULT 'False' FOR PrecioPorEmbalaje 
GO

/* --------- */

ALTER TABLE AuditoriaProductos ADD PrecioPorEmbalaje bit null
GO

UPDATE AuditoriaProductos SET PrecioPorEmbalaje = 'False'
GO

