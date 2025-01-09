
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('CategoriasProveedoresABM', 'Categorias Proveedores', 'Categorias Proveedores', 'True', 'False', 'True', 'True', 
     'Archivos', 15, 'Eniac.Win', 'CategoriasProveedoresABM', NULL)
GO


INSERT INTO RolesFunciones 
     (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CategoriasProveedoresABM' AS Pantalla FROM Roles
GO
