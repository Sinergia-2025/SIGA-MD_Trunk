
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarPreciosPorProducto', 'Consultar Precios por Producto', 'Consultar Precios por Producto', 
    'True', 'False', 'True', 'True', 'Precios', 21, 'Eniac.Win', 'ConsultarPreciosPorProducto', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPreciosPorProducto' AS Pantalla FROM dbo.Roles
GO
