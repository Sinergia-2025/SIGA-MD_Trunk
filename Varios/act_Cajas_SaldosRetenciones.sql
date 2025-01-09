
UPDATE Cajas 
   SET RetencionesSaldoInicial = 0 
 WHERE RetencionesSaldoInicial <> 0
GO

UPDATE Cajas 
   SET RetencionesSaldoFinal = 0 
 WHERE RetencionesSaldoFinal <> 0
GO

UPDATE Cajas 
   SET RetencionesSaldoFinalDigit = 0 
 WHERE RetencionesSaldoFinalDigit <> 0
GO
