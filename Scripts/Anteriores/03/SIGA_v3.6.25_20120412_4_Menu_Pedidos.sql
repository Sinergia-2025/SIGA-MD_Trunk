--Elimino los menues anteriores.

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Pedidos' OR IdPadre='Pedidos'
)
GO

DELETE [dbo].[Funciones]
 WHERE id='Pedidos' OR IdPadre='Pedidos'
GO

--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Pedidos', 'Pedidos', '', 'True', 'False', 'True', 'True',
     NULL, 160, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Pedidos' AS Pantalla FROM [dbo].Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('PedidosClientesV2', 'Pedidos Clientes', 'Pedidos Clientes', 'True', 'False', 'True', 'True', 
          'Pedidos', 10, 'Eniac.Win', 'PedidosClientesV2', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PedidosClientesV2' AS Pantalla FROM [dbo].Roles
GO

-----------------

-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('PedidosAdmin', 'Administración Pedidos', 'Administración Pedidos', 'True', 'False', 'True', 'True', 
          'Pedidos', 20, 'Eniac.Win', 'PedidosAdmin', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PedidosAdmin' AS Pantalla FROM [dbo].Roles
GO

--InfPedidosDetallados

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfPedidosDetallados', 'Inf. de Pedidos Detallado', 'Inf. de Pedidos Detallado', 'True', 'False', 'True', 'True', 
          'Pedidos', 30, 'Eniac.Win', 'InfPedidosDetallados', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPedidosDetallados' AS Pantalla FROM [dbo].Roles
GO