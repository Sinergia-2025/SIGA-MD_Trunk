
-- Si tiene el menu de Fichas
IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Fichas')
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('FichasABM2', 'Fichas (de Clientes) (v2)', 'Fichas (de Clientes) (v2)', 'True', 'False', 'True', 'True', 
          'Fichas', 11, 'Eniac.Win', 'FichasABM2', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'FichasABM2' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
    ;
END
