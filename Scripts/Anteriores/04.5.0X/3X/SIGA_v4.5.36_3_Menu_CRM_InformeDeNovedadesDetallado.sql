 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovSeguimCRM', 'Informe de CRM Detallado', 'Informe de CRM Detallado', 
      'True', 'False', 'True', 'True', 
      'CRM', 205, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'CRM')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimCRM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO

------------
 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovSeguimPROSP', 'Informe de Seguimiento de Prospectos Detallado', 'Informe de Seguimiento de Prospectos Detallado', 
      'True', 'False', 'True', 'True', 
      'CRM', 225, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'PROSP')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimPROSP' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO

------------
 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovSeguimRECCLTE', 'Informe de Reclamos de Clientes Detallado', 'Informe de Reclamos de Clientes Detallado', 
      'True', 'False', 'True', 'True', 
      'CRM', 215, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'RECCLTE')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimRECCLTE' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO

------------
 
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovSeguimRECPROV', 'Informe de Reclamos a Proveedores Detallado', 'Informe de Reclamos a Proveedores Detallado', 
      'True', 'False', 'True', 'True', 
      'CRM', 235, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'RECPROV')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimRECPROV' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO
