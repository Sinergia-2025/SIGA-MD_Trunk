


ALTER TABLE ClientesDeudas ADD Activo bit null
GO

UPDATE ClientesDeudas SET Activo = 'True'
GO

ALTER TABLE ClientesDeudas ALTER COLUMN Activo bit not null
GO
