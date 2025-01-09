
ALTER TABLE Cajas ADD BancosSaldoInicial decimal(10, 2) null
GO
ALTER TABLE Cajas ADD BancosSaldoFinal decimal(10, 2) null
GO
ALTER TABLE Cajas ADD BancosSaldoFinalDigit decimal(10, 2) null
GO

UPDATE Cajas 
   SET BancosSaldoInicial = 0 
     , BancosSaldoFinal = 0
     , BancosSaldoFinalDigit = 0
GO

ALTER TABLE Cajas ALTER COLUMN BancosSaldoInicial decimal(10, 2) not null
GO
ALTER TABLE Cajas ALTER COLUMN BancosSaldoFinal decimal(10, 2) not null
GO
ALTER TABLE Cajas ALTER COLUMN BancosSaldoFinalDigit decimal(10, 2) not null
GO
