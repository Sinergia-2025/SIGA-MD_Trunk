----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Nueva funcion Contabilidad Generar Asiento Ajuste por Inflación'
IF dbo.ExisteFuncion('Contabilidad') = 1 AND dbo.ExisteFuncion('ContabilidadAsientoXInflacion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, 
		Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo, EsMDIChild)
    VALUES
        ('ContabilidadAsientoXInflacion', 'Generar Asiento Ajuste por Inflación', 
		'Generar Asiento Ajuste por Inflación', 'True', 'False', 'True', 'True'
        ,'Contabilidad', 205, 'Eniac.Win', 'ContabilidadGeneraAsientoAjustePorInflacion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL, 1)
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContabilidadAsientoXInflacion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'AdmSinergia')
END
GO
----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Nueva funcion Contabilidad Generar Asiento de Refundición de Resultado'
IF dbo.ExisteFuncion('Contabilidad') = 1 AND dbo.ExisteFuncion('ContabilidadAsientoReundicion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, 
		Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo, EsMDIChild)
    VALUES
        ('ContabilidadAsientoReundicion', 'Generar Asiento Refundión de Resultado', 
		'Generar Asiento Refundión de Resultado', 'True', 'False', 'True', 'True'
        ,'Contabilidad', 210, 'Eniac.Win', 'ContabilidadGeneraAsientoRefundicion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL, 1)
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContabilidadAsientoReundicion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'AdmSinergia')
END
GO
-----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Nuevo buscador de Categorías'
DECLARE @idBuscador int = 16
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'CRMCategorias' Titulo, 1000 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'IdCategoriaNovedad'        IdBuscadorNombreCampo,  1 Orden, 'Código'       Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreCategoriaNovedad'    IdBuscadorNombreCampo,  2 Orden, 'Nombre'       Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;
----------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'Script Listas de Precios con Orden 0'
BEGIN
	UPDATE ListasDePrecios SET Orden = 1 where Orden = 0
END
----------------------------------------------------------------------------------------------------------------------------------
