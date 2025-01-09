PRINT ''
PRINT '1. Tabla FormatoEtiquetas: Agrega formato 2 x Ancho por Volumen 3'
IF NOT EXISTS (SELECT 1 FROM FormatosEtiquetas WHERE ArchivoAImprimir = 'Reportes\191_EtiquetaPorVolumen.rdlc')
BEGIN
	DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

	INSERT INTO [dbo].[FormatosEtiquetas]
			   ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
			   ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
			   ,[Activo])
		 VALUES
			   (@maxId, '2 x Ancho por Volumen 3 ', 'PRECIOS', 'Reportes\191_EtiquetaPorVolumen.rdlc', 'False'
			   ,'', 'False', 2, 'False', 'False','True');
END
GO

ALTER TABLE AlertasSistemaCondiciones ALTER COLUMN CondicionCount VARCHAR(15) NOT NULL
