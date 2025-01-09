
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfPedidosSumaPorProductosProv', 'Inf. de Pedidos Suma por Productos Proveedores', 'Inf. de Pedidos Suma por Productos Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 40, 'Eniac.Win', 'InfPedidosSumaPorProductosProv', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPedidosSumaPorProductosProv' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
