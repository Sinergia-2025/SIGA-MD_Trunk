 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMRECPROV', 'Reclamos a Proveedores', 'Reclamos a Proveedores', 'True', 'False', 'True', 'True', 
      'CRM', 50, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'RECPROV')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMRECPROV' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesRECPROV', 'Informe de Reclamos a Proveedores', 'Informe de Reclamos a Proveedores', 
      'True', 'False', 'True', 'True', 
      'CRM', 230, 'Eniac.Win', 'InformeDeNovedades', NULL, 'RECPROV')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesRECPROV' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECPROV-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECPROV', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECPROV-PuedeEliminar' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECPROV-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECPROV', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECPROV-VerOtrosUsuarios' AS Pantalla FROM Roles
    WHERE Id IN ('Adm','Supervisor')
GO

