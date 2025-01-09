
ALTER TABLE Productos ADD EsOferta varchar(2) null
GO

UPDATE Productos SET EsOferta = 'NO'
GO

ALTER TABLE Productos ALTER COLUMN EsOferta varchar(2) not null
GO

ALTER TABLE AuditoriaProductos ADD EsOferta varchar(2)  null
GO

UPDATE AuditoriaProductos SET EsOferta = 'NO'
GO
