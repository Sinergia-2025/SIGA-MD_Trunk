
--Pantallas nuevas de Sueldos

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfVentasSumaPorProductos', 'Inf. Ventas Suma por Producto', 'Inf. Ventas Suma por Producto', 
    'True', 'False', 'True', 'True', 'Ventas', 116, 'Eniac.Win', 'InfVentasSumaPorProductos', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfVentasSumaPorProductos' AS Pantalla FROM dbo.Roles
GO
