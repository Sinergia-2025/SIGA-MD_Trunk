
ALTER TABLE ListasDePrecios ADD Orden int null
GO

UPDATE ListasDePrecios SET Orden = 1 
GO

ALTER TABLE ListasDePrecios ADD Activa bit null
GO

UPDATE ListasDePrecios SET Activa = 'True'
GO

ALTER TABLE ListasDePrecios ALTER COLUMN Activa bit  not null
GO





