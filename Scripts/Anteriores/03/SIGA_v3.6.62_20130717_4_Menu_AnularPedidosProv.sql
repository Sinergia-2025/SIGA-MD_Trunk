
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('AnularPedidosProv', 'Anular Pedidos Proveedores', 'Anular Pedidos Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 16, 'Eniac.Win', 'AnularPedidosProv', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularPedidosProv' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
