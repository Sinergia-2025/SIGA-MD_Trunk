PRINT ''
PRINT '1. Tabla Ventas: Nuevos campos NumeroComprobanteFiscal y CantidadReintentosImpresion'
ALTER TABLE Ventas ADD NumeroComprobanteFiscal bigint null
ALTER TABLE Ventas ADD CantidadReintentosImpresion int null
GO

PRINT ''
PRINT '2. Buscador para Productos.'
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
	VALUES  (2, 'Ubicacion',   21,'Ubicacion', 16, 80,'')
;

PRINT ''
PRINT '3. Ajusta configuracion de servidores sinergia.'
UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, 'w1021701', 'wi531792')
 WHERE ValorParametro LIKE '%w1021701%'
