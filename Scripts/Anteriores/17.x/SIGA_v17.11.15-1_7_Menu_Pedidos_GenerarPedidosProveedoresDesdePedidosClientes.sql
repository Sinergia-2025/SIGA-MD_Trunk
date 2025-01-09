
-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Pedidos')

BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('GeneraPedidoProvDesdeClie', 'Generar Pedido Proveedores desde Pedidos Clientes', 'Generar Pedido Proveedores desde Pedidos Clientes', 'True', 'False', 'True', 'True', 
          'Pedidos', 120, 'Eniac.Win', 'GenerarPedidoProvDesdePedCliente', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'GeneraPedidoProvDesdeClie' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
    ;
        
END

update Funciones set Pantalla = 'GenerarPedidoProvDesdePedCliente' where id = 'GeneraPedidoProvDesdeClie'
