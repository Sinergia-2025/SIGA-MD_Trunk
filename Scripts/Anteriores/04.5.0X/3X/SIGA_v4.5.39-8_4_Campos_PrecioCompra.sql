
PRINT '1. Tabla Campos: Genero un lugar en la Posicion 6';

UPDATE Campos SET Orden = Orden + 1 WHERE IdCampo > 6
;

PRINT '';
PRINT '2. Tabla Campos: Inserto el Campo PrecioCompra en la Posicion 6';

INSERT INTO Campos (IdCampo,NombreCampo,Orden)
     VALUES (11, 'PrecioCompra', 7)
;

--UPDATE PlantillasCampos 
--   SET OrdenColumna = OrdenColumna - 1 
-- WHERE IdCampo > 6 
--   AND (IdPlantilla = 1 OR IdPlantilla = 2)
--GO

PRINT '';
PRINT '3. Tabla PlantillasCampos: Genero un registro en cada planilla (sin orden)';

INSERT INTO PlantillasCampos (IdPlantilla ,IdCampo, OrdenColumna)
SELECT DISTINCT IdPlantilla, 11, NULL FROM PlantillasCampos 
GO

--UPDATE PlantillasCampos 
--   SET OrdenColumna = NULL
-- WHERE IdCampo = 11 AND (IdPlantilla = 1 OR IdPlantilla = 2)
--GO

IF EXISTS (SELECT 1 FROM Parametros WHERE IdParametro = 'UTILIZAPRECIODECOMPRA' AND ValorParametro = 'True')
	IF EXISTS (SELECT 1 FROM Plantillas WHERE IdPlantilla > 2)
	BEGIN

		PRINT '';
		PRINT '4. Tabla PlantillasCampos: Reemplazo PrecioCosto por PrecioCompra';

		UPDATE PlantillasCampos
		   SET OrdenColumna =
					(SELECT OrdenColumna FROM PlantillasCampos B
					  WHERE PlantillasCampos.IdPlantilla = B.IdPlantilla
						AND B.IdCampo = 7 )	--'PrecioCosto
		 WHERE IdCampo = 11	--PrecioCompra
		   AND IdPlantilla > 2 --Las Estandares
		 ;

		PRINT '';
		PRINT '5. Tabla PlantillasCampos: Quito PrecioCosto';

		UPDATE PlantillasCampos
		   SET OrdenColumna = NULL
		 WHERE IdCampo = 7	--PrecioCosto
		  AND IdPlantilla > 2 --Las Estandares
		;

	END

