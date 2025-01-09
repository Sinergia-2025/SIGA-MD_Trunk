 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMTAREAS', 'Tareas', 'Tareas', 'True', 'False', 'True', 'True', 
      'CRM', 7, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TAREAS')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMTAREAS' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesTAREAS', 'Informe de Tareas', 'Informe de Tareas', 
      'True', 'False', 'True', 'True', 
      'CRM', 210, 'Eniac.Win', 'InformeDeNovedades', NULL, 'TAREAS')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesTAREAS' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Soporte')
GO