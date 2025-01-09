
--27055884175: Servilimp - Sinopoli Maria del Carmen.
--30708748737: Kweb

IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro IN ('27055884175','30708748737'))
BEGIN

		--Inserto el Menu Cargos

		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('Cargos', 'Cargos', '', 'True', 'False', 'True', 'True',NULL
			  , 8, NULL, NULL, NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'Cargos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

		--Inserto la pantalla nueva

		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('CargosABM', 'ABM de Cargos', 'ABM de Cargos', 'True', 'False', 'True', 'True',
			  'Cargos', 200, 'Eniac.Win', 'CargosABM', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'CargosABM' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END
