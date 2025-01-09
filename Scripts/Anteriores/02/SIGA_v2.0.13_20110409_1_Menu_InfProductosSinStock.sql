
--Pantallas nuevas de Sueldos

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfProductosSinStock', 'Inf. Productos Sin Stock', 'Inf. Productos Sin Stock', 
    'False', 'False', 'True', 'False', 'Stock', 70, 'Eniac.Win', 'InfProductosSinStock', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProductosSinStock' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO



