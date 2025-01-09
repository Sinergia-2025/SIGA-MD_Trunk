
--Pantallas nuevas de Sueldos

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfPuntoDePedidoDeProductos', 'Inf. Punto de Pedido de Productos', 'Inf. Punto de Pedido de Productos', 
    'True', 'False', 'True', 'True', 'Stock', 80, 'Eniac.Win', 'InfPuntoDePedidoDeProductos', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPuntoDePedidoDeProductos' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO

