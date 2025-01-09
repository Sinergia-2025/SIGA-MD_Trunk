PRINT ''
PRINT '1. Nueva función menú Importar Stock de Lotes desde Excel'
IF dbo.ExisteFuncion('Stock')=1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ImportarStockLotesExcel', 'Importar Stock de Lotes desde Excel', 'Importar Stock de Lotes desde Excel', 'True', 'False', 'True', 'True'
        ,'Stock', 140, 'Eniac.Win', 'ImportarStockLotesExcel', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Roles menú Importación Stock de Lotes desde Excel'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarStockLotesExcel' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nuevo Formato Etiqueta: 1 x Ancho(6.5 x 3 cm)'
IF NOT EXISTS(SELECT * FROM FormatosEtiquetas WHERE ArchivoAImprimir = 'Eniac.Win.EmisionDeEtiquetasCodBarraF9.rdlc')
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
	      ,'1 x Ancho (6.5 x 3 cm)'
	      ,[Tipo]
	      ,'Eniac.Win.EmisionDeEtiquetasCodBarraF9.rdlc'
	      ,[ArchivoAImprimirEmbebido]
	      ,[NombreImpresora]
	      ,[ImprimeLote]
	      ,[MaximoColumnas]
	      ,[UtilizaCabecera]
	      ,[SolicitaListaPrecios2]
	      ,[Activo]
	  FROM [dbo].[FormatosEtiquetas] WHERE IdFormatoEtiqueta = 13 --# El formato que el cliente solicitó.
END
GO