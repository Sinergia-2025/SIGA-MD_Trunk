 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMACTIVIDAD', 'Actividades', 'Actividades', 'True', 'False', 'True', 'True', 
      'CRM', 5, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'ACTIVIDAD')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMACTIVIDAD' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesACTIVIDAD', 'Informe de Actividades', 'Informe de Actividades', 
      'True', 'False', 'True', 'True', 
      'CRM', 190, 'Eniac.Win', 'InformeDeNovedades', NULL, 'ACTIVIDAD')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesACTIVIDAD' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ACTIVIDAD-PuedeEliminar', 'Permitir Eliminar Novedades - Actividades', 'Permitir Eliminar Novedades - Actividades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMACTIVIDAD', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ACTIVIDAD-PuedeEliminar' AS Pantalla FROM Roles
    WHERE Id IN ('Adm')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ACTIVIDAD-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMACTIVIDAD', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ACTIVIDAD-VerOtrosUsuarios' AS Pantalla FROM Roles
    WHERE Id IN ('Adm')
GO
