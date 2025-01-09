
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('NDEBCHEQRECH', 'COTIZCHEQRECH,NDEBCHEQRECH,ePRE-NDEBCHEQR,eNDEBCHEQRECH', NULL, 'Identificacion de NDeb. por Cheque Rechazado')
GO

DELETE Parametros
 WHERE IdParametro IN ('IDNDEBCHEQRECH', 'IDNDEBCHEQRECH2')
GO


 