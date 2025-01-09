
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Stock')

BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
			   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		 VALUES
			   ('GenerarPedidoProvDesdeStocks', 'Generar Pedido a Proveedor desde Stock', 'Generar Pedido a Proveedor desde Stock', 'True', 'False', 'True', 'True',
			   'Stock', 130, 'Eniac.Win', 'GenerarPedidoProveedorDesdeStocks', NULL)
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'GenerarPedidoProvDesdeStocks' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;
