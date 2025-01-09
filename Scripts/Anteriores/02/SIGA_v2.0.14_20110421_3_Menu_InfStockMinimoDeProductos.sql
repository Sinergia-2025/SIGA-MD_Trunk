
--Pantallas nuevas de Sueldos

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfStockMinimoDeProductos', 'Inf. Stock Minimo de Productos', 'Inf. Stock Minimo de Productos', 
    'True', 'False', 'True', 'True', 'Stock', 90, 'Eniac.Win', 'InfStockMinimoDeProductos', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfStockMinimoDeProductos' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO

