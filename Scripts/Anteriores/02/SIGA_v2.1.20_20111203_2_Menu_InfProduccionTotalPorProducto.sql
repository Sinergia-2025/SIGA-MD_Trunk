
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('InfProduccionTotalPorProducto', 'Informe de Produccion Total por Producto', 'Informe de Produccion Total por Producto', 'True', 'False', 'True', 'True', 
     'Produccion', 25, 'Eniac.Win', 'InfProduccionTotalPorProducto', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProduccionTotalPorProducto' AS Pantalla FROM Roles
GO
