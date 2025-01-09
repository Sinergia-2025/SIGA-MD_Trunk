
ALTER TABLE SueldosConceptos ADD EsContempladoAguinaldo bit null
GO

UPDATE SueldosConceptos
   SET SueldosConceptos.EsContempladoAguinaldo 
        =   CASE
                WHEN SueldosConceptos.IdTipoConcepto IN
		              (SELECT SueldosTiposConceptos.IdTipoConcepto
			             FROM SueldosTiposConceptos
			             WHERE SueldosTiposConceptos.NombreTipoConcepto = 'HABERES')
                THEN 'True'
                ELSE 'False'
            END;
GO

ALTER TABLE SueldosConceptos ALTER COLUMN EsContempladoAguinaldo bit not null
GO
