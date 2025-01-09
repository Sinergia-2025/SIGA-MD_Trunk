-- ¡¡¡¡ SISEN NO NIVELAR !!!!


-- SIGA: Inserta // SICAP: Ajusta --

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'RevertirPasajeMovimientos')
    BEGIN
		UPDATE Funciones
		   SET Archivo = 'Eniac.Win'
		 WHERE Id = 'RevertirPasajeMovimientos';
    END;
ELSE

	IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Expensas')
		BEGIN
			--Inserto la pantalla nueva
			INSERT INTO Funciones
				 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
			  VALUES
				 ('RevertirPasajeMovimientos', 'Revertir Pasaje de Movimientos', 'Revertir Pasaje de Movimientos', 'True', 'False', 'True', 'True',
				  'Expensas', 25, 'Eniac.Win', 'RevertirPasajeMovimientos', NULL);

			INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'RevertirPasajeMovimientos' AS Pantalla FROM dbo.Roles
				WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

		END;

/* -- Verifico -- */

SELECT Archivo FROM Funciones
  WHERE Id = 'RevertirPasajeMovimientos';
