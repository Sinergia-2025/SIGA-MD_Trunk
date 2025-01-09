
ALTER TABLE Productos ADD EsRetornable bit null
GO
UPDATE Productos SET EsRetornable = 'False'
GO
ALTER TABLE Productos ALTER COLUMN EsRetornable bit not null
GO

ALTER TABLE AuditoriaProductos ADD EsRetornable bit null
GO
UPDATE AuditoriaProductos SET EsRetornable = 'False'
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN EsRetornable bit not null
GO
