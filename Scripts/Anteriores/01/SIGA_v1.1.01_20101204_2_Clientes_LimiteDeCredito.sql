ALTER TABLE dbo.Clientes ADD LimiteDeCredito decimal(10, 2) NULL
GO

UPDATE dbo.Clientes SET LimiteDeCredito = 0
GO

ALTER TABLE dbo.Clientes ALTER COLUMN LimiteDeCredito decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.AuditoriaClientes ADD LimiteDeCredito decimal(10, 2) NULL
GO
