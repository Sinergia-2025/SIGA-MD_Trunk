DELETE RolesFunciones WHERE IdFuncion IN ('Estad�sticaDeVentasProducto', 'EstadisticaDeVentasProductos')
GO

DELETE Funciones WHERE Id  IN ('Estad�sticaDeVentasProducto', 'EstadisticaDeVentasProductos')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
  (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
  ('EstadisticaDeVentasProductos', 'Estad�stica de Ventas por Productos', 'Estad�stica de Ventas por Productos', 'True', 'False', 'True', 'True',
  'Estadisticas', 20, 'Eniac.Win', 'EstadisticaDeVentasProductos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaDeVentasProductos' AS Pantalla FROM dbo.Roles
GO
