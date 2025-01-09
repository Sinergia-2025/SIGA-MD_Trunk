PRINT ''
PRINT '1.1 Nuevo Campo en TiposComprobantesLetras: DesplazamientoX y DesplazamientoY ArchivoAImprimir'
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoXArchivoAImprimir INT NULL
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoYArchivoAImprimir INT NULL
GO

PRINT ''
PRINT '1.2 Nuevo Campo en TiposComprobantesLetras: DesplazamientoX y DesplazamientoY ArchivoAImprimir2'
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoXArchivoAImprimir2 INT NULL
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoYArchivoAImprimir2 INT NULL
GO

PRINT ''
PRINT '1.3 Nuevo Campo en TiposComprobantesLetras: DesplazamientoX y DesplazamientoY ArchivoAImprimirComplementario'
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoXArchivoAImprimirComplementario INT NULL
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoYArchivoAImprimirComplementario INT NULL
GO

PRINT ''
PRINT '1.4 Nuevo Campo en TiposComprobantesLetras: DesplazamientoX y DesplazamientoY ArchivoAExportar'
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoXArchivoAExportar INT NULL
ALTER TABLE TiposComprobantesLetras
	ADD DesplazamientoYArchivoAExportar INT NULL
GO

PRINT ''
PRINT '2. Actualizo los valores de X e Y'
UPDATE TiposComprobantesLetras SET
	DesplazamientoXArchivoAImprimir = 0,
	DesplazamientoYArchivoAImprimir = 0,
	DesplazamientoXArchivoAImprimir2 = 0,
	DesplazamientoYArchivoAImprimir2 = 0,
	DesplazamientoXArchivoAImprimirComplementario = 0,
	DesplazamientoYArchivoAImprimirComplementario = 0,
	DesplazamientoXArchivoAExportar = 0,
	DesplazamientoYArchivoAExportar = 0
GO

PRINT ''
PRINT '3. Actualizo los campos a NOT NULL'
ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoXArchivoAImprimir INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoYArchivoAImprimir INT NOT NULL
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoXArchivoAImprimir2 INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoYArchivoAImprimir2 INT NOT NULL
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoXArchivoAImprimirComplementario INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoYArchivoAImprimirComplementario INT NOT NULL
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoXArchivoAExportar INT NOT NULL
ALTER TABLE TiposComprobantesLetras ALTER COLUMN DesplazamientoYArchivoAExportar INT NOT NULL
GO
