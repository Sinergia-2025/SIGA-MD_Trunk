
ALTER TABLE Productos ADD EsObservacion bit NULL
GO

UPDATE Productos SET EsObservacion = 'False'
GO

ALTER TABLE Productos ALTER COLUMN EsObservacion bit NOT NULL
GO

--Asigno el default para otros sistemas.
ALTER TABLE Productos ADD DEFAULT 'False' FOR EsObservacion 
GO

/* -----------------*/

ALTER TABLE AuditoriaProductos ADD EsObservacion bit NULL
GO

UPDATE AuditoriaProductos SET EsObservacion = 0
GO
