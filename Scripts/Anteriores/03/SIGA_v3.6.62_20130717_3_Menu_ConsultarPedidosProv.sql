
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ConsultarPedidosProv', 'Consultar Pedidos Proveedores', 'Consultar Pedidos Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 15, 'Eniac.Win', 'ConsultarPedidosProv', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPedidosProv' AS Pantalla FROM [dbo].Roles
GO
