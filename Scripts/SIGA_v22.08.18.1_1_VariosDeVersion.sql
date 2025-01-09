 DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (10 x 6 cm)', 'BULTOS', 'Eniac.Win.EmisionEtiquetasParaBultos.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False'
           ,'True')
GO

 DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (10,5 x 14,8 cm)', 'BULTOS', 'Eniac.Win.EmisionEtiquetasParaBultos2.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False'
           ,'True')
GO

UPDATE Funciones
   SET Parametros = 'ModoFechas=PORVENCIMIENTO;ReportesCtaCte=CTACTEDET'
 WHERE Id = 'EnvioMasivoDeCompVenc'
   AND Parametros LIKE '%ReportesCtaCte=CTACTE'
UPDATE Funciones
   SET Parametros = 'ReportesCtaCte=CTACTEDET'
 WHERE Id = 'EnvioMasivoDeComprobantes'
   AND Parametros LIKE '%ReportesCtaCte=CTACTE'
GO