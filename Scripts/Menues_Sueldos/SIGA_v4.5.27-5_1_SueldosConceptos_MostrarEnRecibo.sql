
ALTER TABLE SueldosConceptos ADD MostrarEnRecibo bit null
GO

UPDATE SueldosConceptos SET MostrarEnRecibo = 'True'
GO

UPDATE SueldosConceptos SET MostrarEnRecibo = 'False'
 WHERE idTipoConcepto = 3	--Aportes
GO

ALTER TABLE SueldosConceptos ALTER COLUMN MostrarEnRecibo bit not null
GO
