
--Elimino los menues anteriores.

DELETE [dbo].Bitacora WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Presupuestos' OR IdPadre='Presupuestos'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Presupuestos' OR IdPadre='Presupuestos'
)
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre='Presupuestos'
GO

DELETE [dbo].[Funciones]
 WHERE id='Presupuestos'
GO


--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
    ('Presupuestos', 'Presupuestos', '', 'True', 'False', 'True', 'True',
     NULL, 3, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Presupuestos' AS Pantalla FROM [dbo].Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('PresupuestosClientesV2', 'Presupuestos de Clientes', 'Presupuestos de Clientes', 'True', 'False', 'True', 'True', 
          'Presupuestos', 10, 'Eniac.Win', 'PedidosClientesV2', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PresupuestosClientesV2' AS Pantalla FROM [dbo].Roles
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('ConsultarPresupuestos', 'Consultar Presupuestos', 'Consultar Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 20, 'Eniac.Win', 'ConsultarPedidos', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPresupuestos' AS Pantalla FROM [dbo].Roles
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('AnularPresupuestos', 'Anular Presupuestos', 'Anular Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 30, 'Eniac.Win', 'AnularPedidos', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularPresupuestos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-----------------

-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('PresupuestosAdmin', 'Administración Presupuestos', 'Administración Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 40, 'Eniac.Win', 'PedidosAdmin', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PresupuestosAdmin' AS Pantalla FROM [dbo].Roles
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('EstadosPresupuestosABM', 'ABM Estados de Presupuestos', 'ABM Estados de Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 50, 'Eniac.Win', 'EstadosPedidosABM', NULL, 'PRESUPCLIE\PEDIDOSCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosPresupuestosABM' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--InfPedidosDetallados

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('InfPresupuestosDetallados', 'Inf. de Presupuestos Detallado', 'Inf. de Presupuestos Detallado', 'True', 'False', 'True', 'True', 
          'Presupuestos', 60, 'Eniac.Win', 'InfPedidosDetallados', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPresupuestosDetallados' AS Pantalla FROM [dbo].Roles
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
     VALUES
         ('InfPresupuestosSumaPorProducto', 'Inf. de Presupuestos Suma por Productos', 'Inf. de Presupuestos Suma por Productos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 70, 'Eniac.Win', 'InfPedidosSumaPorProductos', NULL, 'PRESUPCLIE')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPresupuestosSumaPorProducto' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
