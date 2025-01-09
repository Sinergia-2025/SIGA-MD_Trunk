DELETE RolesFunciones WHERE IdFuncion = 'Estad�sticaDeVentasProducto'
GO

DELETE Funciones WHERE Id = 'Estad�sticaDeVentasProducto'
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('EstadisticaDeVentasProducto', 'Estad�stica de Ventas por Producto', 'Estad�stica de Ventas por Producto', 'True', 'False', 'True', 'True',
           'Ventas', 80, 'Eniac.Win', 'EstadisticaDeVentasProducto', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaDeVentasProducto' AS Pantalla FROM dbo.Roles
GO
