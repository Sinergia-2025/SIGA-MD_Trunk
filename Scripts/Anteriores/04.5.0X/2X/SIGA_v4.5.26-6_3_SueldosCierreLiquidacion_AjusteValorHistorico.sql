
UPDATE SueldosCierreLiquidacion
  SET Valor = 
    (
	SELECT Valor FROM SueldosConceptos SC
	 WHERE SueldosCierreLiquidacion.IdTipoConcepto = SC.IdTipoConcepto
       AND SueldosCierreLiquidacion.IdConcepto = SC.IdConcepto
       AND IdQuepide > 0
	   AND Formula LIKE '%CODVALOR%' 
	   AND Formula NOT LIKE '%LIQVALOR%'
	)
  WHERE SueldosCierreLiquidacion.Valor = 0
    AND EXISTS 
    (
	SELECT Valor FROM SueldosConceptos SC
	 WHERE SueldosCierreLiquidacion.IdTipoConcepto = SC.IdTipoConcepto
       AND SueldosCierreLiquidacion.IdConcepto = SC.IdConcepto
       AND IdQuepide > 0
	   AND Formula LIKE '%CODVALOR%' 
	   AND Formula NOT LIKE '%LIQVALOR%'
	)
GO

UPDATE SueldosCierreLiquidacion
  SET Valor = 0
WHERE Valor IS NULL
GO


--SELECT * FROM SueldosCierreLiquidacion
--  WHERE EXISTS 
--    (
--	SELECT Valor FROM SueldosConceptos SC
--	 WHERE SueldosCierreLiquidacion.IdTipoConcepto = SC.IdTipoConcepto
--       AND SueldosCierreLiquidacion.IdConcepto = SC.IdConcepto
--	   AND Formula LIKE '%CODVALOR%' 
--	   AND Formula NOT LIKE '%LIQVALOR%'
--	)
--  AND Valor=0