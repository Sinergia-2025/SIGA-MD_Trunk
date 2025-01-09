PRINT ''
PRINT '1. Nuevo Formato Etiqueta: 4 x Ancho (5 x 2.5 cm)'
IF NOT EXISTS(SELECT * FROM FormatosEtiquetas WHERE ArchivoAImprimir = 'Eniac.Win.EmisionDeEtiquetasCodBarraF10.rdlc')
BEGIN
	INSERT INTO FormatosEtiquetas (
		IdFormatoEtiqueta,
		NombreFormatoEtiqueta,
		Tipo,
		ArchivoAImprimir,
		ArchivoAImprimirEmbebido,
		NombreImpresora,
		ImprimeLote,
		MaximoColumnas,
		UtilizaCabecera,
		SolicitaListaPrecios2,
		Activo) 
	SELECT (SELECT MAX(IdFormatoEtiqueta)+1 FROM FormatosEtiquetas)
	      ,'4 x Ancho (5 x 2.5 cm)'
	      ,[Tipo]
	      ,'Eniac.Win.EmisionDeEtiquetasCodBarraF10.rdlc'
	      ,[ArchivoAImprimirEmbebido]
	      ,[NombreImpresora]
	      ,[ImprimeLote]
	      ,[MaximoColumnas]
	      ,[UtilizaCabecera]
	      ,[SolicitaListaPrecios2]
	      ,[Activo]
	  FROM [dbo].[FormatosEtiquetas] WHERE IdFormatoEtiqueta = 12
END
GO

PRINT ''
PRINT '2. Actualización de Registros'
ALTER TABLE dbo.TurnosCalendarios ADD IdTurnoUnico varchar(40) NULL
GO
UPDATE TurnosCalendarios SET IdTurnoUnico = NEWID();
ALTER TABLE dbo.TurnosCalendarios ALTER COLUMN IdTurnoUnico varchar(40) NOT NULL
GO
ALTER TABLE dbo.TurnosCalendarios
    ADD CONSTRAINT AK_TurnosCalendarios
    UNIQUE NONCLUSTERED (IdTurnoUnico)
    WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
