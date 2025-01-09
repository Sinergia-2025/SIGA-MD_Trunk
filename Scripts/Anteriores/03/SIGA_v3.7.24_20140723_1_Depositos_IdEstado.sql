
ALTER TABLE Depositos ADD IdEstado varchar(10) null
GO

UPDATE Depositos SET IdEstado = 'NORMAL' 
GO

ALTER TABLE Depositos ALTER COLUMN IdEstado varchar(10) not null
GO
