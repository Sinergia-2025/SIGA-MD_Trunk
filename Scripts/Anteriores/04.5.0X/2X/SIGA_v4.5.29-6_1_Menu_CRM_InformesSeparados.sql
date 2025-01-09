
DECLARE @CUITEMPRESA VARCHAR(12)
SET @CUITEMPRESA = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'CUITEMPRESA')

-- Inserto el Menu Nuevo --

DELETE FROM RolesFunciones WHERE IdFuncion = 'InformeDeNovedades';
DELETE FROM Funciones WHERE Id = 'InformeDeNovedades';

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesCRM', 'Informe de CRM', 'Informe de CRM', 'True', 'False', 'True', 'True', 
      'CRM', 200, 'Eniac.Win', 'InformeDeNovedades', NULL, 'CRM')

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesCRM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

INSERT INTO Funciones
     (Id, 
      Nombre, 
      Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesRECCLTE', 
      CASE WHEN @CUITEMPRESA = '33711345499' THEN 'Informe de Soporte' ELSE 'Informe de Reclamos de Clientes' END, 
      CASE WHEN @CUITEMPRESA = '33711345499' THEN 'Informe de Soporte' ELSE 'Informe de Reclamos de Clientes' END, 
      'True', 'False', 'True', 'True', 
      'CRM', 210, 'Eniac.Win', 'InformeDeNovedades', NULL, 'RECCLTE')

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesRECCLTE' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

INSERT INTO Funciones
     (Id, 
      Nombre, 
      Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovedadesPROSP',
      CASE WHEN @CUITEMPRESA = '33711345499' THEN 'Informe de Seguimiento de Prospectos' ELSE 'Informe de Prospectos' END, 
      CASE WHEN @CUITEMPRESA = '33711345499' THEN 'Informe de Seguimiento de Prospectos' ELSE 'Informe de Prospectos' END, 
      'True', 'False', 'True', 'True', 
      'CRM', 220, 'Eniac.Win', 'InformeDeNovedades', NULL, 'PROSP')

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesPROSP' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

