
-- Inserto el Menu Nuevo --

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('CRM', 'CRM', '', 'True', 'False', 'True', 'True',
     NULL, 175, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-- Inserto las Pantallas Nuevas --

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMNovedadesABM', 'Novedades', 'Novedades', 'True', 'False', 'True', 'True', 
      'CRM', 10, 'Eniac.Win', 'CRMNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMCRM', 'CRM', 'CRM', 'True', 'False', 'True', 'True', 
      'CRM', 20, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'CRM')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMCRM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMRECCLTE', 'Reclamos de Clientes', 'Reclamos de Clientes', 'True', 'False', 'True', 'True', 
      'CRM', 30, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'RECCLTE')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMRECCLTE' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('CRMNovedadesABMPROSP', 'Seguimiento de Prospectos', 'Seguimiento de Prospectos', 'True', 'False', 'True', 'True', 
      'CRM', 40, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'PROSP')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMPROSP' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

--INSERT INTO Funciones
--     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
--      IdPadre, Posicion, Archivo, Pantalla, Icono)
--  VALUES
--     ('CRMNovedadesDetalle', 'Nueva Novedades', 'Nueva Novedades', 'True', 'False', 'True', 'True', 
--      'CRM', 50, 'Eniac.Win', 'CRMNovedadesDetalle', NULL)
--GO

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'CRMNovedadesDetalle' AS Pantalla FROM Roles
--    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InformeDeNovedades', 'Informe de Novedades', 'Informe de Novedades', 'True', 'False', 'True', 'True', 
      'CRM', 200, 'Eniac.Win', 'InformeDeNovedades', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedades' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMCategoriasNovedadesABM', 'ABM de Categorias Novedades', 'ABM de Categorias Novedades', 'True', 'False', 'True', 'True', 
      'CRM', 500, 'Eniac.Win', 'CRMCategoriasNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMCategoriasNovedadesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMEstadosNovedadesABM', 'ABM de Estados Novedades', 'ABM de Estados Novedades', 'True', 'False', 'True', 'True', 
      'CRM', 510, 'Eniac.Win', 'CRMEstadosNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMEstadosNovedadesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMMediosComunicacionesABM', 'ABM de Medios Comunicación', 'ABM de Medios Comunicación', 'True', 'False', 'True', 'True', 
      'CRM', 520, 'Eniac.Win', 'CRMMediosComunicacionesNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMMediosComunicacionesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMPrioridadesNovedadesABM', 'ABM de Prioridades', 'ABM de Prioridades', 'True', 'False', 'True', 'True', 
      'CRM', 530, 'Eniac.Win', 'CRMPrioridadesNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMPrioridadesNovedadesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMTiposNovedadesABM', 'ABM de Tipos Novedades', 'ABM de Tipos Novedades', 'True', 'False', 'True', 'True', 
      'CRM', 600, 'Eniac.Win', 'CRMTiposNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMTiposNovedadesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
