DELETE RolesFunciones WHERE IdFuncion IN ('EstadísticaDeVentasProducto', 'EstadisticaDeVentasProductos')
GO

DELETE Funciones WHERE Id  IN ('EstadísticaDeVentasProducto', 'EstadisticaDeVentasProductos')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
  (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
  ('EstadisticaDeVentasProductos', 'Estadística de Ventas por Productos', 'Estadística de Ventas por Productos', 'True', 'False', 'True', 'True',
  'Estadisticas', 20, 'Eniac.Win', 'EstadisticaDeVentasProductos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaDeVentasProductos' AS Pantalla FROM dbo.Roles
GO
