IF dbo.ExisteFuncion('CRM') = 1
BEGIN
	IF(SELECT IdTipoNovedad FROM CRMTiposNovedades WHERE IdTipoNovedad = 'SERVICE') IS NOT NULL
	BEGIN
		PRINT ''
        PRINT '1. Nuevo Tipos de Comentarios: OBSERVACIÓN, ACTIVIDAD y ULTIMO CONTACTO para módulo SERVICE'
        INSERT INTO CRMTiposComentariosNovedades (
        	IdTipoComentarioNovedad,
        	NombreTipoComentarioNovedad,
        	Posicion,
        	PorDefecto,
        	Color,
        	IdTipoNovedad,
        	VisibleParaCliente,
        	VisibleParaRepresentante)
        	VALUES(102,'ACTIVIDAD',20,'False',NULL,'SERVICE', 'False', 'False'),
        	      (103,'ULTIMO CONTACTO',30,'False',NULL,'SERVICE', 'False', 'False'),
        	      (104,'OBSERVACIÓN',40,'False',NULL,'SERVICE', 'False', 'False')
    END
END

PRINT ''
PRINT '2. Nuevo Campo en CRMNovedades: NroDeSerie'
ALTER TABLE CRMNovedades
	ADD NroDeSerie VARCHAR(50) NULL
GO

PRINT ''
PRINT '3. Cambio en el orden de los dinámicos'
UPDATE CRMTiposNovedadesDinamicos SET Orden = 15 WHERE IdTipoNovedad = 'SERVICE' AND IdNombreDinamico = 'SERVICE'
GO

PRINT ''
PRINT '4. Nuevo Campo: TieneGarantiaService en CRMNovedades'
ALTER TABLE CRMNovedades
	ADD TieneGarantiaService BIT NULL
GO

PRINT ''
PRINT '5. Nuevo Campo: TieneGarantiaService en CRMNovedades'
ALTER TABLE CRMNovedades
	ADD UbicacionService VARCHAR(30) NULL
GO