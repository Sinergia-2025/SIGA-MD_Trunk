
ALTER TABLE Depositos ADD FechaAplicado datetime NULL
GO

UPDATE Depositos SET
	FechaAplicado = Fecha
GO

ALTER TABLE Depositos ALTER COLUMN FechaAplicado datetime  NOT NULL
GO
