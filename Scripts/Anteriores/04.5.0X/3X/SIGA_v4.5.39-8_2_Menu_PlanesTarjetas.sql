 
--Inserto la pantalla nueva

PRINT 'Inserto el Menu si Existe el Padre: Archivos.';

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Archivos')

BEGIN

	PRINT '1. Inserto el Menu en Tabla Funciones.';

	INSERT INTO Funciones
			   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		 VALUES
			   ('PlanesTarjetasABM', 'Tarjetas - Planes', 'Tarjetas - Planes', 'True', 'False', 'True', 'True',
			   'Archivos', 174, 'Eniac.Win', 'PlanesTarjetasABM', NULL);

	PRINT '2. Inserto las Permisos en Tabla RolesFunciones.';
	
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PlanesTarjetasABM' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END

