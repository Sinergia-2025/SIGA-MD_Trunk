 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMREQUER', 'Requerimientos', 'Requerimientos', 'True', 'False', 'True', 'True', 
      'CRM', 6, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'REQUER')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMREQUER' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesREQUER', 'Informe de Requerimientos', 'Informe de Requerimientos', 
      'True', 'False', 'True', 'True', 
      'CRM', 200, 'Eniac.Win', 'InformeDeNovedades', NULL, 'REQUER')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesREQUER' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO