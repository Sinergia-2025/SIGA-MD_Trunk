
-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Procesos')
  AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('SincronizacionSubida', 'Sincronización - Subir a la Web', 'Sincronización - Subir a la Web', 'True', 'False', 'True', 'True', 
          'Procesos', 300, 'Eniac.Win', 'SincronizacionSubida', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SincronizacionSubida' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;
END


-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Procesos')
  AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('SincronizacionBajada', 'Sincronización - Bajar de la Web', 'Sincronización - Bajar de la Web', 'True', 'False', 'True', 'True', 
          'Procesos', 310, 'Eniac.Win', 'SincronizacionBajada', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SincronizacionBajada' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;
END

