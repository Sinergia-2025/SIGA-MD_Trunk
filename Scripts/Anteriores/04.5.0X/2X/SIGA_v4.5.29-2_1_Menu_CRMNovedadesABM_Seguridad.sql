INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRM-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMCRM', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRM-VerOtrosUsuarios' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECCLTE-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECCLTE', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECCLTE-VerOtrosUsuarios' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('PROSP-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMPROSP', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PROSP-VerOtrosUsuarios' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

