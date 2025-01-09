
--Inserto la Funcion para Modificar el Dolar.

IF NOT EXISTS (SELECT Id FROM Funciones WHERE Id = 'ActualizaValorDolar' )
	BEGIN

		--Inserto la Pantalla Nueva
		
		INSERT INTO Funciones
				   (Id, Nombre, Descripcion
				   ,EsMenu, EsBoton, [Enabled], Visible
				   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
			 VALUES
				   ('ActualizaValorDolar', 'Permiso para Modificar el valor del Dolar', 'Permiso para Modificar el valor del Dolar'
				   ,'False', 'False', 'True', 'True'
				   ,'Configuraciones', 999, 'Eniac.Win', NULL, NULL)
		;

		INSERT INTO RolesFunciones 
					  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ActualizaValorDolar' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor') 
		;

	END;
