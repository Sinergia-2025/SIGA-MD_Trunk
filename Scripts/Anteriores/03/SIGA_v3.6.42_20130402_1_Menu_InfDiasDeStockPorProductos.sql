
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfDiasDeStockPorProductos', 'Inf. Dias de Stock por Productos', 'Inf. Dias de Stock por Productos', 'True', 'False', 'True', 'True', 
      'Stock', 100, 'Eniac.Win', 'InfDiasDeStockPorProductos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfDiasDeStockPorProductos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
