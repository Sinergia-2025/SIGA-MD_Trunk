
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRM-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMCRM', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRM-PuedeEliminar' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECCLTE-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECCLTE', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECCLTE-PuedeEliminar' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('PROSP-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMPROSP', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PROSP-PuedeEliminar' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

