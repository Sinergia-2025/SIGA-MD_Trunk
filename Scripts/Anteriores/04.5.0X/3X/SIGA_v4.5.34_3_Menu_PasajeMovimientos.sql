
-- SIGA: Inserta // SICAP o SISEN: Ajusta --

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PasajeMovimientos')
    BEGIN
		UPDATE Funciones
		   SET Archivo = 'Eniac.Win'
		 WHERE Id = 'PasajeMovimientos';
    END;
ELSE
    BEGIN
		--Inserto la pantalla nueva
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('PasajeMovimientos', 'Pasaje de Movimientos', 'Pasaje de Movimientos', 'True', 'False', 'True', 'True',
			  'Expensas', 20, 'Eniac.Win', 'PasajeMovimientos', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'PasajeMovimientos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    END;

/* -- Verifico -- */

SELECT Archivo FROM Funciones
  WHERE Id = 'PasajeMovimientos';
