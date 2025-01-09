
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('EstadosPedidosABM', 'ABM Estados de Pedidos', 'ABM Estados de Pedidos', 'True', 'False', 'True', 'True', 
          'Pedidos', 22, 'Eniac.Win', 'EstadosPedidosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosPedidosABM' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
