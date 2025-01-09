DELETE RolesFunciones WHERE IdFuncion IN ('Estad�sticaDeVentasClientes', 'EstadisticaDeVentasClientes')
GO

DELETE Funciones WHERE Id IN ('Estad�sticaDeVentasClientes', 'EstadisticaDeVentasClientes')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
  (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
  ,IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
  ('EstadisticaDeVentasClientes', 'Estad�stica de Ventas por Clientes', 'Estad�stica de Ventas por Clientes', 'True', 'False', 'True', 'True',
  'Estadisticas', 30, 'Eniac.Win', 'EstadisticaDeVentasClientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadisticaDeVentasClientes' AS Pantalla FROM dbo.Roles
GO
