
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImportarContribuyentesARBA', 'Importar Padron ARBA', 'Importar Padron ARBA', 
      'True', 'False', 'True', 'True',
      'AFIP', 200, 'Eniac.Win', 'ImportarContribuyentesARBA', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarContribuyentesARBA' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
