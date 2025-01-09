

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosProveedores', 'Productos del Proveedor', 'Productos del Proveedor', 
    'True', 'False', 'True', 'True', 'Compras', 50, 'Eniac.Win', 'ProductosProveedores', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosProveedores' AS Pantalla FROM dbo.Roles
GO
