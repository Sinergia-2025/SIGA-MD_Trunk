
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ConsultarPedidos', 'Consultar Pedidos', 'Consultar Pedidos', 'True', 'False', 'True', 'True', 
          'Pedidos', 15, 'Eniac.Win', 'ConsultarPedidos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPedidos' AS Pantalla FROM [dbo].Roles
GO
