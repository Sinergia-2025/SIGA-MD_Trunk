
UPDATE Funciones SET Posicion = 90
 WHERE Id = 'RegistrarMovCtaCteClientes'
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EliminarMovCtaCteClientes', 'Eliminar Movimientos de Cta. Cte. Clientes', 'Eliminar Movimientos de Cta. Cte. Clientes', 
    'True', 'False', 'True', 'True', 'CuentasCorrientes', 100, 'Eniac.Win', 'EliminarMovCtaCteClientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EliminarMovCtaCteClientes' AS Pantalla FROM dbo.Roles
GO
