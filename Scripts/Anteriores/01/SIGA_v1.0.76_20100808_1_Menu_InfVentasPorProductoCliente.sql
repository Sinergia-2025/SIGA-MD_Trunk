  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfVentasPorProductoCliente', 'Inf. Ventas por Producto/Cliente', 'Inf. Ventas por Producto/Cliente', 
    'True', 'False', 'True', 'True', 'Ventas', 113, 'Eniac.Win', 'InfVentasPorProductoCliente', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfVentasPorProductoCliente' AS Pantalla FROM dbo.Roles
GO
