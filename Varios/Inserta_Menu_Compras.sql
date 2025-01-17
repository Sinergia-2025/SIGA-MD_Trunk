
INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'Compras', N'Compras', N'', 1, 0, 1, 1, NULL, 30, NULL, NULL, NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'ConsultarCompras', N'Consultar Compras', N'Consultar Compras', 1, 1, 1, 1, N'Compras', 30, N'Eniac.Win', N'ConsultarCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'EliminarCompras', N'Eliminar Compras', N'Eliminar Compras', 1, 0, 1, 1, N'Compras', 38, N'Eniac.Win', N'EliminarCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'InfComprasDetallePorProductos', N'Informe de Compras detalle por Productos', N'Informe de Compras detalle por Productos', 1, 0, 1, 1, N'Compras', 32, N'Eniac.Win', N'InfComprasDetallePorProductos', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'InfProductosProveedores', N'Informe de Productos por Proveedores', N'Informe de Productos por Proveedores', 1, 0, 1, 1, N'Compras', 60, N'Eniac.Win', N'InfProductosProveedores', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'LibrodeIvaCompras', N'Libro de IVA Compras', N'Libro de IVA Compras', 1, 0, 1, 1, N'Compras', 10, N'Eniac.Win', N'LibrodeIvaCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'ModificarCompras', N'Modificar Compras', N'Modificar Compras', 1, 0, 1, 1, N'Compras', 35, N'Eniac.Win', N'ModificarCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'MovimientosDeCompras', N'Movimientos de Compras', N'Movimientos de Compras', 1, 1, 1, 1, N'Compras', 5, N'Eniac.Win', N'MovimientosDeCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'ProductosProveedores', N'Productos del Proveedor', N'Productos del Proveedor', 1, 0, 1, 1, N'Compras', 50, N'Eniac.Win', N'ProductosProveedores', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'ResumenPorComprobanteCompras', N'Resumen por Comprobantes Compras', N'Resumen por Comprobantes Compras', 1, 0, 1, 1, N'Compras', 20, N'Eniac.Win', N'ResumenPorComprobanteCompras', NULL, NULL)

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros]) 
VALUES (N'RubrosCompras', N'ABM de Rubros de Compras', N'ABM de Rubros de Compras', 1, 0, 1, 1, N'Compras', 40, N'Eniac.Win', N'RubrosComprasABM', NULL, NULL)


INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Compras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EliminarCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComprasDetallePorProductos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProductosProveedores' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'LibrodeIvaCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ModificarCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovimientosDeCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosProveedores' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ResumenPorComprobanteCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RubrosCompras' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO



--- Si diera error por no tener version actualizada: Quitar columna PARAMETROS Y valor NULL asignado.