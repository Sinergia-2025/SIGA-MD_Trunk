  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfVentasPorSubRubroProducto', 'Inf. Ventas por SubRubro/Producto', 'Inf. Ventas por SubRubro/Producto', 
    'True', 'False', 'True', 'True', 'Ventas', 118, 'Eniac.Win', 'InfVentasPorSubRubroProducto', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfVentasPorSubRubroProducto' AS Pantalla FROM dbo.Roles
GO
