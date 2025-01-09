--Elimino los menues anteriores.

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'PedidosProv' OR IdPadre='PedidosProv'
)
GO

DELETE [dbo].[Funciones]
 WHERE id='PedidosProv' OR IdPadre='PedidosProv'
GO

--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('PedidosProv', 'Pedidos Prov.', '', 'True', 'False', 'True', 'True',
     NULL, 25, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PedidosProv' AS Pantalla FROM [dbo].Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('PedidosProveedores', 'Pedidos de Proveedores', 'Pedidos de Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 10, 'Eniac.Win', 'PedidosProveedores', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PedidosProveedores' AS Pantalla FROM [dbo].Roles
GO

------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('PedidosAdminProv', 'Administración de Pedidos de Proveedores', 'Administración de Pedidos de Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 20, 'Eniac.Win', 'PedidosAdminProv', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PedidosAdminProv' AS Pantalla FROM [dbo].Roles
GO

------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfPedidosDetalladosProv', 'Inf. de Pedidos Detallado de Proveedores', 'Inf. de Pedidos Detallado de Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 30, 'Eniac.Win', 'InfPedidosDetalladosProv', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPedidosDetalladosProv' AS Pantalla FROM [dbo].Roles
GO
