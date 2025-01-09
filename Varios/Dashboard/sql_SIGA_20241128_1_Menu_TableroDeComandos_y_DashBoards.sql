PRINT ''
PRINT 'Nuevos Menues: Tableros de Comando Graficos'
PRINT ''
IF dbo.ExisteFuncion('Ventas') = 1
BEGIN
	PRINT '1. Verifica Tablero de Comando'
	PRINT ''
	IF dbo.ExisteFuncion('TablerosDeComando') = 0
	BEGIN
			INSERT INTO Funciones
					(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
					,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
					,PermiteMultiplesInstancias, Plus, Express, Basica, PV, EsMDIChild)
			VALUES
			('TablerosDeComando', 'Tableros de Comando', 'Tableros de Comando', 'True', 'False', 'True', 'True',
			 NULL, 40, 'Eniac.Win', 'TablerosDeComando', null, null,
					'True', 'S', 'N', 'N', 'N', 'True')

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TablerosDeComando' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END

	PRINT ''
	PRINT '2. Nuevo Menu: DashBoard - Graficos'
	IF dbo.ExisteFuncion('TablerosGraficos') = 0
	BEGIN
			INSERT INTO Funciones
					(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
					,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
					,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
			VALUES
			('TablerosGraficos', 'Tableros Graficos', 'Tableros Graficos', 
			'True', 'False', 'True', 'True', 'TablerosDeComando', 50, 'Eniac.Win', '', null, null,
					'True', 'S', 'N', 'N', 'N', 'True')

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TablerosGraficos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END

	PRINT ''
	PRINT '3. Nuevo Menu: DashBoard - Principal'
	IF dbo.ExisteFuncion('TableroComandosGraficos') = 0
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('TableroComandosGraficos', 'Tablero de Comandos Graficos', 'Tablero de Comandos Graficos', 'True', 'False', 'True', 'True'
			, 'TablerosGraficos', 10, 'Eniac.Win', 'DashBoardTablero', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TableroComandosGraficos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END

	PRINT ''
	PRINT '4. Nuevo Menu: DashBoard - Paneles - ABM'
	IF dbo.ExisteFuncion('ABMPanelesGraficos') = 0
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('ABMPanelesGraficos', 'ABM de Paneles Graficos', 'ABM de Paneles Graficos', 'True', 'False', 'True', 'True'
			, 'TablerosGraficos', 30, 'Eniac.Win', 'DashBoardABMPaneles', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ABMPanelesGraficos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
END
GO
