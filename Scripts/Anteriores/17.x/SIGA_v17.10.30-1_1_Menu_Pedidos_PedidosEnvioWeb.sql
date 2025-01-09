
-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Pedidos')
  AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('PedidosEnvioWeb', 'Enviar Pedidos a la Web', 'Enviar Pedidos a la Web', 'True', 'False', 'True', 'True', 
          'Pedidos', 110, 'Eniac.Win', 'PedidosEnvioWeb', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosEnvioWeb' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
    ;

    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('PreventaV2', 'Preventa', 'Preventa', 'True', 'False', 'True', 'True', 
          'Pedidos', 120, 'Eniac.Win', 'PreventaV2', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PreventaV2' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
    ;
END
