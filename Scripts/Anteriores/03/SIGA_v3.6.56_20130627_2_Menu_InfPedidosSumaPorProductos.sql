
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfPedidosSumaPorProductos', 'Inf. de Pedidos Suma por Productos', 'Inf. de Pedidos Suma por Productos', 'True', 'False', 'True', 'True', 
          'Pedidos', 40, 'Eniac.Win', 'InfPedidosSumaPorProductos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPedidosSumaPorProductos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
