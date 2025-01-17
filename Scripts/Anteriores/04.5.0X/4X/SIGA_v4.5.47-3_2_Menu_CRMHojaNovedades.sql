
-- Solo lo agrega si utiliza Proyectos (por ahora solo Sinergia).
-- No pregunto por CUIT porque algunas bases podrian tenerlo.

IF EXISTS (SELECT 1 FROM CRMTiposNovedadesDinamicos WHERE IdNombreDinamico = 'PROYECTOS')

BEGIN

	-- Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	  VALUES
		 ('CRMHojaNovedades', 'Hoja de Novedades', 'Hoja de Novedades', 'True', 'False', 'True', 'True',
		  'CRM', 570, 'Eniac.Win', 'CRMHojaNovedades', NULL);


	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMHojaNovedades' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Soporte', 'Funciones');

END;
