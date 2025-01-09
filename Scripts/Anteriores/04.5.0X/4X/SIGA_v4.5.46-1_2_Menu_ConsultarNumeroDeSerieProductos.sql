
-- Solo lo agrega si utiliza STOCK.

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Stock')

BEGIN

	INSERT INTO Funciones
			   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		 VALUES
			   ('ConsultarNroSerieProductos', 'Consultar Número de Serie de Productos', 'Consultar Número de Serie de Productos', 'True', 'False', 'True', 'True',
			   'Stock', 65, 'Eniac.Win', 'ConsultarNroSerieProductos', NULL);


	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConsultarNroSerieProductos' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


END;
