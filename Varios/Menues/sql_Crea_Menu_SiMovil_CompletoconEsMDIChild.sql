--Inserto el Menú del Módulo
INSERT INTO Funciones
    (Id, Nombre, Descripcion
    ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
  VALUES
    ('SiMovil', 'SiMovil', 'SiMovil', 
    'True', 'False', 'True', 'True', NULL, 5, 'Eniac.Win', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones 
                (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SiMovil' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('MovilRutasABM', 'Rutas', 'Rutas', 'True', 'False', 'True', 'True',
        'SiMovil', 10, 'Eniac.Win', 'MovilRutasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovilRutasABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('MovilRutasClientes', 'Asignar Clientes a Rutas', 'Rutas', 'True', 'False', 'True', 'True',
        'SiMovil', 20, 'Eniac.Win', 'MovilRutasClientes', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovilRutasClientes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
    IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)

VALUES
    ('SincronizacionSubidaMovil', 'Sincronización - Subir a la Web', 'Sincronización - Subir a la Web', 'True', 'False', 'True', 'True', 
    'SiMovil', 50, 'Eniac.Win', 'SincronizacionSubidaMovil', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaMovil' AS Pantalla FROM Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


--INSERT INTO Funciones
--    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
--    IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
--VALUES
--    ('SincronizacionBajadaCobranzas', 'Sincronización - Bajar Cobranzas', 'Sincronización - Bajar Cobranzas', 'True', 'False', 'True', 'True', 
--    'SiMovil', 60, 'Eniac.Win', 'SincronizacionBajadaCobranzas', NULL, NULL)
--;

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaCobranzas' AS Pantalla FROM Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--;



--QUE ES ESTO???
--INSERT INTO Funciones
--    (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
--    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
--VALUES
--	('GenerarArchivos', 'Pedidos - Generar Archivos', 'Pedidos - Generar Archivos', 'True', 'False', 'True', 'True', 
--    'SiMovil', 110, 'Eniac.Win', 'GenerarArchivos', null, null,
--    'True', 'S', 'N', 'N', 'N');

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--    SELECT IdRol, 'GenerarArchivos' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaMovil'


INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
VALUES
	('PreventaV2', 'Pedidos - Preventa (v2 - Archivo)', 'Pedidos - Preventa (v2 - Archivo)', 'True', 'False', 'True', 'True', 
    'SiMovil', 120, 'Eniac.Win', 'PreventaV2', null, null,
    'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PreventaV2' AS Pantalla FROM Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
VALUES
	('PreventaV3', 'Pedidos - Preventa (v3 - Web)', 'Pedidos - Preventa (v3 - Web)', 'True', 'False', 'True', 'True', 
    'SiMovil', 130, 'Eniac.Win', 'PreventaV3', null, null,
    'True', 'S', 'N', 'N', 'N',NULL,'True');

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PreventaV3' AS Pantalla FROM Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina');



INSERT INTO Funciones
(Id, Nombre, Descripcion
,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, IdModulo,EsMDIChild)
VALUES
('InfClientesRuta', 'Informe de Clientes en Rutas', 'Informe de Clientes en Rutas', 
'True', 'False', 'True', 'True', 'SiMovil', 75, 'Eniac.Win', 'InfClientesRuta', null, null,'N','S','N','N',NULL,'True')
;

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfClientesRuta' AS Pantalla FROM dbo.Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
;
