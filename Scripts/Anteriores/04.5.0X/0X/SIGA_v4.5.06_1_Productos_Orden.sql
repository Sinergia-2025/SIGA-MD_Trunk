
ALTER TABLE Productos ADD Orden int null
GO
UPDATE Productos SET Orden = 1 
GO
ALTER TABLE Productos ALTER COLUMN Orden int null
GO
ALTER TABLE Productos ADD DEFAULT 1 FOR Orden --Asigno el default para otros sistemas.
GO


ALTER TABLE AuditoriaProductos ADD Orden bit null
GO
UPDATE AuditoriaProductos SET Orden = 1
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN Orden int null
GO
