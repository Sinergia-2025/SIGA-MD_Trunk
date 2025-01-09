
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosAdmin')
BEGIN

	PRINT '1. Pedidos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PedidosAdmin-Modif', 'Modif. Pedidos', 'Modif. Pedidos', 'False', 'False', 'True', 'True', 
              'PedidosAdmin', 999, 'Eniac.Win', 'PedidosAdmin-Modif', NULL, 'PEDIDOSCLIE');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosAdmin-Modif' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PedidosAdmin';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PresupuestosAdmin')
BEGIN

	PRINT ''
	PRINT '2. Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PresupuestosAdmin-Modif', 'Modif. Presupuestos', 'Modif. Presupuestos', 'False', 'False', 'True', 'True', 
              'PresupuestosAdmin', 999, 'Eniac.Win', 'PresupuestosAdmin-Modif', NULL, 'PRESUPCLIE');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PresupuestosAdmin-Modif' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PresupuestosAdmin';
END;
