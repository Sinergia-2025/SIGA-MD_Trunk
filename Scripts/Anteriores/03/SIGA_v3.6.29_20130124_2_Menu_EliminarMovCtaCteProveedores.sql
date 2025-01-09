

UPDATE Funciones SET Posicion = 90
 WHERE Id = 'RegistrarMovCtaCteProveedores'
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EliminarMovCtaCteProveedores', 'Eliminar Movimientos de Cta. Cte. Proveedores', 'Eliminar Movimientos de Cta. Cte. Proveedores', 
    'True', 'False', 'True', 'True', 'CuentasCorrientesProveedores', 100, 'Eniac.Win', 'EliminarMovCtaCteProveedores', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EliminarMovCtaCteProveedores' AS Pantalla FROM dbo.Roles
GO
