
UPDATE Clientes SET [FechaAlta] = GETDATE()
 WHERE [FechaAlta] IS NULL
GO

ALTER TABLE Clientes ALTER COLUMN [FechaAlta] [datetime] NOT NULL
GO

UPDATE Clientes SET [IdCategoria] = 1
 WHERE [IdCategoria] IS NULL
GO

ALTER TABLE Clientes ALTER COLUMN [IdCategoria] [int] NOT NULL
GO

UPDATE Clientes SET [IdCategoriaFiscal] = 1
 WHERE [IdCategoriaFiscal] IS NULL
GO

ALTER TABLE Clientes ALTER COLUMN [IdCategoriaFiscal] [smallint] NOT NULL
GO

UPDATE Clientes SET [FechaNacimiento] = GETDATE()
 WHERE [FechaNacimiento] IS NULL
GO

ALTER TABLE Clientes ALTER COLUMN [FechaNacimiento] [datetime] NOT NULL
GO
