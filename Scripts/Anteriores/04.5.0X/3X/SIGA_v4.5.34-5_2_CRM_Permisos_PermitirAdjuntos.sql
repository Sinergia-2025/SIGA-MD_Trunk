
--		  CREAR LOS PERMISOS PARA VER Y ADJUNTAR ARCHIVOS

-- Proveedores
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECPROV-PuedeAdjuntar', 'Permitir Adjuntar archivos a Novedades', 'Permitir Adjuntar archivos a Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECPROV', 999, 'Eniac.Win', 'Novedades-PuedeAdjuntar', NULL)
GO

-- Clientes
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RECCLTE-PuedeAdjuntar', 'Permitir Adjuntar archivos a Novedades', 'Permitir Adjuntar archivos a Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMRECCLTE', 999, 'Eniac.Win', 'Novedades-PuedeAdjuntar', NULL)
GO

-- CRM
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRM-PuedeAdjuntar', 'Permitir Adjuntar archivos a Novedades', 'Permitir Adjuntar archivos a Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMCRM', 999, 'Eniac.Win', 'Novedades-PuedeAdjuntar', NULL)
GO

-- Prospectos
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('PROSP-PuedeAdjuntar', 'Permitir Adjuntar archivos a Novedades', 'Permitir Adjuntar archivos a Novedades', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMPROSP', 999, 'Eniac.Win', 'Novedades-PuedeAdjuntar', NULL)
GO

-- Permisos ---

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECPROV-PuedeAdjuntar' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'RECCLTE-PuedeAdjuntar' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRM-PuedeAdjuntar' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PROSP-PuedeAdjuntar' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
