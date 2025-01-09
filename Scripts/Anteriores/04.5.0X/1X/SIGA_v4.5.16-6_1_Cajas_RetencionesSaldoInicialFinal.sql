
ALTER TABLE Cajas ADD RetencionesSaldoInicial decimal(10, 2) null
GO
ALTER TABLE Cajas ADD RetencionesSaldoFinal decimal(10, 2) null
GO
ALTER TABLE Cajas ADD RetencionesSaldoFinalDigit decimal(10, 2) null
GO

UPDATE Cajas 
   SET RetencionesSaldoInicial = 0 
     , RetencionesSaldoFinal = 0
     , RetencionesSaldoFinalDigit = 0
GO

ALTER TABLE Cajas ALTER COLUMN RetencionesSaldoInicial decimal(10, 2) not null
GO
ALTER TABLE Cajas ALTER COLUMN RetencionesSaldoFinal decimal(10, 2) not null
GO
ALTER TABLE Cajas ALTER COLUMN RetencionesSaldoFinalDigit decimal(10, 2) not null
GO
