
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
     Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ParametrosDelUsuario', 'Parametros del Sistema', 'Parametros del Sistema', 'True', 'False', 'True',
      'True', 'Configuraciones', 25, 'Eniac.Win', 'ParametrosDelUsuario', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
  VALUES ('Adm', 'ParametrosDelUsuario')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
  VALUES ('Supervisor', 'ParametrosDelUsuario')
GO
