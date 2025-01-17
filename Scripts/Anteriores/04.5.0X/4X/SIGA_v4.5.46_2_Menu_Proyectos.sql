
-- Solo lo agrega si utiliza Proyectos (por ahora solo Sinergia).

IF EXISTS (SELECT 1 FROM CRMTiposNovedadesDinamicos WHERE IdNombreDinamico = 'PROYECTOS')

BEGIN

	-- Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	  VALUES
		 ('ProyectosABM', 'ABM de Proyectos', 'ABM de Proyectos', 'True', 'False', 'True', 'True',
		  'CRM', 540, 'Eniac.Win', 'ProyectosABM', NULL);


	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProyectosABM' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm');

END;
