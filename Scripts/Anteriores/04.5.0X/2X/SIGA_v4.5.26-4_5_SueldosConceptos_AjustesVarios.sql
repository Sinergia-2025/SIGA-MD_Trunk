
UPDATE SueldosConceptos
   SET Valor = 0 
 WHERE IdQuepide = 0
   AND Valor > 0
GO

UPDATE SueldosConceptos
   SET Valor = 0 
 WHERE IdQuepide > 0
   AND Formula NOT LIKE '%CODVALOR%' 
   AND Valor > 0
GO

UPDATE SueldosPersonalCodigos
  SET Valor = 
    (
	SELECT Valor FROM SueldosConceptos SC
	 WHERE SueldosPersonalCodigos.IdTipoConcepto = SC.IdTipoConcepto
       AND SueldosPersonalCodigos.IdConcepto = SC.IdConcepto
       AND IdQuepide > 0
	   AND Formula LIKE '%CODVALOR%' 
	   AND Formula NOT LIKE '%LIQVALOR%'
	)
  WHERE EXISTS 
    (
	SELECT Valor FROM SueldosConceptos SC
	 WHERE SueldosPersonalCodigos.IdTipoConcepto = SC.IdTipoConcepto
       AND SueldosPersonalCodigos.IdConcepto = SC.IdConcepto
       AND IdQuepide > 0
	   AND Formula LIKE '%CODVALOR%' 
	   AND Formula NOT LIKE '%LIQVALOR%'
	)
GO

UPDATE SueldosPersonalCodigos
  SET Valor = 0
WHERE Valor IS NULL
GO

-- Quito Posibilidad de NULLs
ALTER TABLE dbo.SueldosPersonalCodigos ALTER COLUMN Valor decimal (10, 2) NOT NULL
GO
ALTER TABLE dbo.SueldosPersonalCodigos ALTER COLUMN Aguinaldo char(1) NOT NULL
GO
ALTER TABLE dbo.SueldosPersonalCodigos ALTER COLUMN Periodos int NOT NULL
GO


--SELECT * FROM SueldosPersonalCodigos
--  WHERE EXISTS 
--    (
--	SELECT Valor FROM SueldosConceptos SC
--	 WHERE SueldosPersonalCodigos.IdTipoConcepto = SC.IdTipoConcepto
--       AND SueldosPersonalCodigos.IdConcepto = SC.IdConcepto
--	   AND Formula LIKE '%CODVALOR%' 
--	   AND Formula NOT LIKE '%LIQVALOR%'
--	)
--GO
