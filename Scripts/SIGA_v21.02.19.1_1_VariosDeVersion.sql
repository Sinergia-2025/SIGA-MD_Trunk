PRINT ''
PRINT '1. FK_CRMEstadosNovedades_CRMEstadosNovedades'
ALTER TABLE CRMEstadosNovedades 
	ADD CONSTRAINT FK_CRMEstadosNovedades_CRMEstadosNovedades
	FOREIGN KEY (IdEstadoFacturado) REFERENCES CRMEstadosNovedades (IdEstadoNovedad)
GO

PRINT ''
PRINT '2. Nuevo Formato de Etiqueta CODIGOBARRA: 1 x Ancho (6.2 x 3 cm)'
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta]
           ,[NombreFormatoEtiqueta]
           ,[Tipo]
           ,[ArchivoAImprimir]
           ,[ArchivoAImprimirEmbebido]
           ,[NombreImpresora]
           ,[ImprimeLote]
           ,[MaximoColumnas]
           ,[UtilizaCabecera]
           ,[SolicitaListaPrecios2]
           ,[Activo])
SELECT (SELECT MAX(IdFormatoEtiqueta) + 1 FROM FormatosEtiquetas)
      ,'1 x Ancho (6.2 x 3 cm)'
      ,[Tipo]
      ,'Eniac.Win.EmisionDeEtiquetasCodBarraF11.rdlc'
      ,[ArchivoAImprimirEmbebido]
      ,[NombreImpresora]
      ,[ImprimeLote]
      ,[MaximoColumnas]
      ,[UtilizaCabecera]
      ,[SolicitaListaPrecios2]
      ,[Activo]
FROM [dbo].[FormatosEtiquetas]
WHERE IdFormatoEtiqueta = 15
GO
