
ALTER TABLE Regimenes ADD RetienePorEscala bit null
GO

UPDATE Regimenes SET RetienePorEscala = 'False'
GO

ALTER TABLE Regimenes ALTER COLUMN RetienePorEscala bit not null
GO
