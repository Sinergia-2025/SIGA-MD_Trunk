
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'ConsultarPedidos')
BEGIN
	PRINT '1. Seguridad a Consultar Pedidos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ConsultarPedidos-VerPre', 'Ver Precios en Consultar Pedidos', 'Ver Precios en Consultar Pedidos', 'False', 'False', 'True', 'True', 
              'ConsultarPedidos', 999, 'Eniac.Win', 'ConsultarPedidos-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ConsultarPedidos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPedidos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'ConsultarPresupuestos')
BEGIN
	PRINT ''
	PRINT '2. Seguridad a Consultar Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ConsultarPresupuestos-VerPre', 'Ver Precios en Consultar Presupuestos', 'Ver Precios en Consultar Presupuestos', 'False', 'False', 'True', 'True', 
              'ConsultarPresupuestos', 999, 'Eniac.Win', 'ConsultarPresupuestos-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ConsultarPresupuestos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPresupuestos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosAdmin')
BEGIN
	PRINT ''
	PRINT '3. Seguridad a Admin Pedidos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PedidosAdmin-VerPre', 'Ver Precios en Admin Pedidos', 'Ver Precios en Admin Pedidos', 'False', 'False', 'True', 'True', 
              'PedidosAdmin', 999, 'Eniac.Win', 'PedidosAdmin-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosAdmin-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PedidosAdmin';
END;
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PresupuestosAdmin')
BEGIN
	PRINT ''
	PRINT '4. Seguridad a Admin Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PresupuestosAdmin-VerPre', 'Ver Precios en Admin Presupuestos', 'Ver Precios en Admin Presupuestos', 'False', 'False', 'True', 'True', 
              'PresupuestosAdmin', 999, 'Eniac.Win', 'PresupuestosAdmin-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PresupuestosAdmin-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PresupuestosAdmin';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Pedidos')
BEGIN
	PRINT ''
	PRINT '5. Seguridad a Impresion Pedidos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ImpresionPedidos-VerPre', 'Ver Precios en Impresion Pedidos', 'Ver Precios en Impresion Pedidos', 'False', 'False', 'True', 'True', 
              'Pedidos', 999, 'Eniac.Win', 'ImpresionPedidos-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImpresionPedidos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPedidos';
END;
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Presupuestos')
BEGIN
	PRINT ''
	PRINT '6. Seguridad a Impresion Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ImpresionPresupuestos-VerPre', 'Ver Precios en Impresion Presupuestos', 'Ver Precios en Impresion Presupuestos', 'False', 'False', 'True', 'True', 
              'Presupuestos', 999, 'Eniac.Win', 'ImpresionPresupuestos-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImpresionPresupuestos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPresupuestos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfPedidosSumaPorProductos')
BEGIN
	PRINT ''
	PRINT '7. Seguridad a Inf. Pedidos Suma Por Productos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('InfPedSumaPorProductos-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True', 
              'InfPedidosSumaPorProductos', 999, 'Eniac.Win', 'InfPedidosSumaPorProductos-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfPedSumaPorProductos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPedidosSumaPorProductos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfPresupuestosSumaPorProducto')
BEGIN
	PRINT ''
	PRINT '8. Seguridad a Inf. Presupuestos Suma Por Productos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('InfPreSumaPorProducto-VerPre', 'Ver Precios en Inf.Presup.Suma Por Productos', 'Ver Precios en Inf.Presup.Suma Por Productos', 'False', 'False', 'True', 'True', 
              'InfPresupuestosSumaPorProducto', 999, 'Eniac.Win', 'InfPreSumaPorProducto-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfPreSumaPorProducto-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPresupuestosSumaPorProducto';
END;
