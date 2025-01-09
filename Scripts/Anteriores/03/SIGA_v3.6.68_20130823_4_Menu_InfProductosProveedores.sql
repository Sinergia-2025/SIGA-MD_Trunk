
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfProductosProveedores', 'Informe de Productos por Proveedores', 'Informe de Productos por Proveedores', 'True', 'False', 'True', 'True', 
          'Compras', 60, 'Eniac.Win', 'InfProductosProveedores', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT IdRol, 'InfProductosProveedores' AS Pantalla FROM [dbo].RolesFunciones
    WHERE IdFuncion = 'ProductosProveedores'
GO
