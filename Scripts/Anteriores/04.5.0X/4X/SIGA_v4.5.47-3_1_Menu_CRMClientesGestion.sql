
-- Solo lo agrega si utiliza CRM

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CRM')

BEGIN

	-- Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	  VALUES
		 ('CRMClientesGestion', 'Gestion de Clientes', 'Gestion de Clientes', 'True', 'False', 'True', 'True',
		  'CRM', 60, 'Eniac.Win', 'CRMClientesGestion', NULL);

	-- Se Agrega a quien puede hacer Reclamos de Clientes
	
	INSERT INTO RolesFunciones 
		  (IdRol, IdFuncion)
	SELECT DISTINCT IdRol, 'CRMClientesGestion' AS Pantalla FROM dbo.RolesFunciones
		WHERE IdFuncion = 'CRMNovedadesABMRECCLTE';

END;
