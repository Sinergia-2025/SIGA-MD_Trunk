
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('EliminarVentas', 'Eliminar Ventas', 'Eliminar Ventas', 'True', 'False', 'True', 'True',
           'Ventas', 155, 'Eniac.Win', 'EliminarVentas', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EliminarVentas' AS Pantalla FROM dbo.Roles
GO
