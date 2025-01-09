
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('EstadosPedidosProvABM', 'ABM Estados de Pedidos Proveedores', 'ABM Estados de Pedidos Proveedores', 'True', 'False', 'True', 'True', 
          'PedidosProv', 22, 'Eniac.Win', 'EstadosPedidosProvABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosPedidosProvABM' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
