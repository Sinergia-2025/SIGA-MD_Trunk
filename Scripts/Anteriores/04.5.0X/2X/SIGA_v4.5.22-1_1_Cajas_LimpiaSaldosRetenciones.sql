
UPDATE Cajas
  SET RetencionesSaldoInicial = 0
     ,RetencionesSaldoFinal = 0
     ,RetencionesSaldoFinalDigit = 0
WHERE RetencionesSaldoInicial<>0 OR RetencionesSaldoFinal<>0 OR RetencionesSaldoFinalDigit<>0
GO
