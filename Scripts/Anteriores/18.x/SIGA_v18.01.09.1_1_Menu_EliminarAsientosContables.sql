
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Contabilidad')
	BEGIN
		--Inserto la pantalla nueva
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('ContabilidadEliminarAsientos', 'Eliminar Asientos de la Gestion', 'Eliminar Asientos de la Gestion', 'True', 'False', 'True', 'True',
			  'Contabilidad', 215, 'Eniac.Win', 'ContabilidadEliminarAsientos', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ContabilidadEliminarAsientos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

	END;
