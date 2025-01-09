
-- Solo cambia en Marinzaldi que lo usa.
IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro = '20175798162')
BEGIN

	DELETE RolesFunciones 
     WHERE IdFuncion IN
	      (SELECT id FROM Funciones
   		    WHERE id = 'ServiceF' or IdPadre = 'ServiceF');

	DELETE Funciones
	 WHERE id = 'ServiceF' or IdPadre = 'ServiceF';
	 
	 INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Service', 'Service', '', 'True', 'False', 'True', 'True',
     NULL, 60, NULL, NULL, NULL);

--Inserto el Menu nuevo

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Service' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


--- Inserto las pantallas nuevas ---

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosEnReparacion', 'Administración de Productos en Reparación', 'Administración de Productos en Reparación', 
    'True', 'False', 'True', 'True', 'Service', 10,'Eniac.Service.Win', 'ProductosEnReparacion', null);

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosEnReparacion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosRecepcion', 'Recepción de productos para reparación', 'Recepción de productos para reparación', 
    'True', 'False', 'True', 'True', 'Service', 20,'Eniac.Service.Win', 'ProductosRecepcion', null);


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosRecepcion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AdministracionNotasRecepcion', 'Administración de Notas de Recepción', 'Administración de Notas de Recepción', 
    'True', 'False', 'True', 'True', 'Service', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcion', null);


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END

