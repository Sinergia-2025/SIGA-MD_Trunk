
PRINT ''
PRINT '1. Nuevas opciones de Menu SiMovil en la Web'
GO
IF EXISTS (SELECT Id FROM Funciones WHERE Id IN ('CobranzasMovil','SiMovil') )
BEGIN

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
        IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('SiMovilWeb', 'SiMovil en la Web', 'SiMovil en la Web', 'True', 'False', 'True', 'True', 
        'CobranzasMovil',900, 'Eniac.Win', NULL, null, null,'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'SiMovilWeb' FROM RolesFunciones
	 WHERE IdFuncion = 'PreventaV3';

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
       IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('InfPedidosSiMovil', 'Informe de Pedidos Web de SiMovil', 'Informe de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True', 
        'SiMovilWeb',10, 'Eniac.Win', 'InfPedidosSiMovil', null, null,'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'InfPedidosSiMovil' FROM RolesFunciones
	 WHERE IdFuncion = 'SiMovilWeb';

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
       IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('AdminPedidosSiMovil', 'Administración de Pedidos Web de SiMovil', 'Administración de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True', 
        'SiMovilWeb',510, 'Eniac.Win', 'InfPedidosSiMovil', null, 'ADMIN','N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'AdminPedidosSiMovil' FROM RolesFunciones
	 WHERE IdFuncion = 'SiMovilWeb';
END
