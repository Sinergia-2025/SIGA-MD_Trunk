
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfAccesosDeUsuarios', 'Informe de Accesos de Usuarios', 'Informe de Accesos de Usuarios', 
      'True', 'False', 'True', 'True',
      'Seguridad', 100, 'Eniac.Win', 'InfAccesosDeUsuarios', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfAccesosDeUsuarios' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
