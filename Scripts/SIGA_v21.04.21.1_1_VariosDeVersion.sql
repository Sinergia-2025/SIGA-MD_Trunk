
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	
	PRINT ''
    PRINT '1. Nueva función menú Calidad: Informe de Listas de Control de Modelos de Productos'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('InformeListasControlModelos', 'Informe de Listas de Control de Modelos de Productos', 'Informe de Listas de Control de Modelos de Productos', 'True', 'False', 'True', 'True'
        ,'Calidad', 52, 'Eniac.Win', 'InformeListasControlModelos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '1.1. Roles menú: Informe de Listas de Control de Modelos de Productos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeListasControlModelos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


	IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN

	PRINT ''
    PRINT '2. Nueva función menú Calidad: Asignar Listas de Control a Modelos de Productos'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('ModelosProductosListasControl', 'Asignar Listas de Control a Modelos de Productos', 'Asignar Listas de Control a Modelos de Productos', 'True', 'False', 'True', 'True'
        ,'Calidad', 51, 'Eniac.Win', 'ModelosProductosListasControl', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '2.1. Roles menú: Asignar Listas de Control a Modelos de Productos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ModelosProductosListasControl' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
 END

	 PRINT ''
    PRINT '3. Corrige nombre de Columna CalidadFechaEgreso'
	UPDATE BuscadoresCampos SET Titulo = 'Fecha Egreso' where IdBuscador = 2 and IdBuscadorNombreCampo = 'CalidadFechaEgreso'
GO