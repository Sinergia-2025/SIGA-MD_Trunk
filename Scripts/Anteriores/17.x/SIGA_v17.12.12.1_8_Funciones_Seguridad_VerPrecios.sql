
PRINT '1. Seguridad a Consultar Pedidos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'ConsultarPedidosProv')
BEGIN
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ConsultarPedidosProv-VerPre', 'Ver Precios en Consultar Pedidos', 'Ver Precios en Consultar Pedidos', 'False', 'False', 'True', 'True', 
              'ConsultarPedidosProv', 999, 'Eniac.Win', 'ConsultarPedidosProv-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ConsultarPedidosProv-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPedidosProv';
END;

PRINT ''
PRINT '2. Seguridad a Admin Pedidos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosAdminProv')
BEGIN
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PedidosAdminProv-VerPre', 'Ver Precios en Admin Pedidos', 'Ver Precios en Admin Pedidos', 'False', 'False', 'True', 'True', 
              'PedidosAdminProv', 999, 'Eniac.Win', 'PedidosAdminProv-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosAdminProv-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PedidosAdminProv';
END;

PRINT ''
PRINT '3. Seguridad a Impresion Pedidos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Pedidos')
BEGIN
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('ImpresionPedidosProv-VerPre', 'Ver Precios en Impresion Pedidos', 'Ver Precios en Impresion Pedidos', 'False', 'False', 'True', 'True', 
              'Pedidos', 999, 'Eniac.Win', 'ImpresionPedidosProv-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImpresionPedidosProv-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPedidosProv';
END;


PRINT ''
PRINT '4. Seguridad a Inf. Pedidos Suma Por Productos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfPedidosSumaPorProductosProv')
BEGIN
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('InfPedSumaPorProdProv-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True', 
              'InfPedidosSumaPorProductosProv', 999, 'Eniac.Win', 'InfPedidosSumaPorProductosProv-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfPedSumaPorProdProv-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPedidosSumaPorProductosProv';
END;


PRINT ''
PRINT '5. Seguridad a PedidosAdmin - Modificar Precio.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosAdminProv')
BEGIN

    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PedidosAdminProv-Modif', 'Modif. Pedidos', 'Modif. Pedidos', 'False', 'False', 'True', 'True', 
              'PedidosAdminProv', 999, 'Eniac.Win', 'PedidosAdminProv-Modif', NULL, 'PEDIDOSPROV');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosAdminProv-Modif' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PedidosAdminProv';
END;
