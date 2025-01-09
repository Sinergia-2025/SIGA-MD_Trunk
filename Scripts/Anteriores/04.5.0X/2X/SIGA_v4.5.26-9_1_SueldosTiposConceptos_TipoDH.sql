
ALTER TABLE SueldosTiposConceptos ADD Tipo char(1) null
GO

UPDATE SueldosTiposConceptos 
   SET Tipo = 'H' 
 WHERE IdTipoConcepto IN (1, 4, 6, 7, 8)
GO

UPDATE SueldosTiposConceptos 
   SET Tipo = 'D' 
 WHERE IdTipoConcepto IN (2, 3, 5, 9, 10)
GO

SELECT * FROM SueldosTiposConceptos
GO
