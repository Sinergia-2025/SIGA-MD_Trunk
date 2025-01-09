DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (6.5 x 3 cm) c/Atrib', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF15.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False'
           ,'True')
GO

DECLARE @IdBuscador int = (SELECT IdBuscador FROM Buscadores WHERE Titulo = 'Productos')
DECLARE @Orden int = (SELECT TOP 1 Orden FROM BuscadoresCampos WHERE IdBuscador = @IdBuscador ORDER BY Orden DESC)

INSERT INTO BuscadoresCampos
    (IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
    VALUES
    (@IdBuscador,'PrecioVentaSinIVAPesificado', @Orden + 1, 'Pesos Sin IVA', 64,70,'N2',NULL,NULL,NULL),
    (@IdBuscador,'PrecioVentaConIVAPesificado', @Orden + 2, 'Pesos Con IVA', 64,70,'N2',NULL,NULL,NULL)
GO
