
DELETE Regimenes WHERE IdRegimen=1
GO

INSERT INTO Regimenes (IdRegimen, ConceptoRegimen, ARetenerInscripto, ARetenerNoInscripto, MontoAExceder, 
                       ImporteMinimoInscripto, ImporteMinimoNoInscripto, IdTipoImpuesto) 
   VALUES (78, 'Enajenación de Bienes Muebles y Bienes de Cambio', 2, 10, 12000, 20, 100, 'RGANA')
GO


INSERT INTO Regimenes (IdRegimen, ConceptoRegimen, ARetenerInscripto, ARetenerNoInscripto, MontoAExceder,
                       ImporteMinimoInscripto, ImporteMinimoNoInscripto, IdTipoImpuesto)
   VALUES (94, 'Locaciones de obra y/o servicios no ejecutados en relación de dependencia no mencionados expresamente en otros incisos', 
           2, 28, 5000, 20, 100, 'RGANA')
GO
