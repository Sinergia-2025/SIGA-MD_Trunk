
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CRM')

BEGIN

	-- Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	  VALUES
		 ('ImportarCRM', 'Importar Novedades de CRM desde Excel', 'Importar Novedades de CRM desde Excel', 'True', 'False', 'True', 'True',
		  'CRM', 900, 'Eniac.Win', 'ImportarCRM', NULL);


	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarCRM' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END;
