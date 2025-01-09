PRINT ''
PRINT '2. Tabla FormatosEtiquetas: Nuevo formato 2 x Descuento por Volumen (7 x 7 cm)'
DECLARE @maxId INT = (SELECT max(IdFormatoEtiqueta) FROM FormatosEtiquetas)
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta],[NombreFormatoEtiqueta],[Tipo],[ArchivoAImprimir],[ArchivoAImprimirEmbebido]
           ,[NombreImpresora],[ImprimeLote],[MaximoColumnas],[UtilizaCabecera],[SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId + 1, '2 x Descuento por Volumen(7x7) ', 'PRECIOS', 'Eniac.Win.EmisionDeEtiquetasDePreciosF8.rdlc', 1, '', 0, 2, 0, 0, 1)
GO