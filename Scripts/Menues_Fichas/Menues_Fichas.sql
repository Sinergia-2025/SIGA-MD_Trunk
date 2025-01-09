
DELETE RolesFunciones 
WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id='Fichas' OR IdPadre='Fichas' OR IdPadre='FichasABM' OR IdPadre='FichasABM2'
)
GO

DELETE Bitacora
WHERE idFuncion like '%Fichas%'
GO

DELETE [Funciones]
 WHERE id='Fichas' OR IdPadre='Fichas' OR IdPadre='FichasABM' OR IdPadre='FichasABM2'
GO


----Inserto el Menu nuevo

--INSERT INTO Funciones
--    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
--    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
--  VALUES
--    ('Fichas', 'Fichas', '', 'True', 'False', 'True', 'True',
--     NULL, 5, NULL, NULL, NULL, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--    (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'Fichas' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO


----- Inserto las pantallas nuevas ---

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('FichasABM', 'Fichas (de Cliente)', 'Fichas (de Cliente)', 
--    'True', 'True', 'True', 'True', 'Fichas', 10,'Eniac.Fichas.Win', 'FichasABM', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'FichasABM' AS Pantalla FROM dbo.Roles
--  WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('FichasClienteAct', 'Intercambiar Fichas entre Clientes', 'Intercambiar Fichas entre Clientes', 
--    'True', 'False', 'True', 'True', 'Fichas', 20,'Eniac.Fichas.Win', 'FichasClienteAct', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'FichasClienteAct' AS Pantalla FROM dbo.Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('FichasEmitidas', 'Fichas Emitidas', 'Fichas Emitidas', 
--    'True', 'False', 'True', 'True', 'Fichas', 30,'Eniac.Fichas.Win', 'FichasEmitidas', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'FichasEmitidas' AS Pantalla FROM dbo.Roles
-- WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('IngresosPorFichas', 'Ingresos por Fichas', 'Ingresos por Fichas', 
--    'True', 'False', 'True', 'True', 'Fichas', 40,'Eniac.Fichas.Win', 'IngresosPorFichas', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'IngresosPorFichas' AS Pantalla FROM dbo.Roles
-- WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('CartasPendientes', 'Envio de Cartas para CLientes Deudores', 'Envio de Cartas para CLientes Deudores', 
--    'True', 'False', 'True', 'True', 'Fichas', 50,'Eniac.Fichas.Win', 'CartasPendientes', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'CartasPendientes' AS Pantalla FROM dbo.Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('PagosPendientes', 'Pagos Pendientes', 'Pagos Pendientes', 
--    'True', 'False', 'True', 'True', 'Fichas', 60,'Eniac.Fichas.Win', 'PagosPendientes', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'PagosPendientes' AS Pantalla FROM dbo.Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('FichasCtaCte', 'Fichas - Cuenta Corriente', 'Fichas - Cuenta Corriente', 
--    'True', 'False', 'True', 'True', 'Fichas', 70,'Eniac.Fichas.Win', 'FichasCtaCte', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'FichasCtaCte' AS Pantalla FROM dbo.Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          


------ Boton Devolver Pago ---

--INSERT INTO Funciones
--   (Id, Nombre, Descripcion
--   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
-- VALUES
--   ('DevolverPago', 'Devolver Pago', 'Devolver Pago', 
--    'False', 'False', 'True', 'True', 'FichasABM', 10,'Eniac.Fichas.Win', 'DevolverPago', null, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')
--GO

--INSERT INTO RolesFunciones 
--              (IdRol,IdFuncion)
--SELECT DISTINCT Id AS Rol, 'DevolverPago' AS Pantalla FROM dbo.Roles
--WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--GO                          

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Fichas')
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
      VALUES
         ('FichasABM2', 'Fichas (de Clientes) (v2)', 'Fichas (de Clientes) (v2)', 'True', 'False', 'True', 'True', 
          'Fichas', 11, 'Eniac.Win', 'FichasABM2', NULL, NULL
		  ,'True', 'S', 'N', 'N', 'N', 'True')
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'FichasABM2' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
    ;
END

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'FichasABM2')
BEGIN
    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (5, 'Mensual', 30, 'False', 0, 0, 1);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (6, 'Quincenal', 15, 'False', 0, 0, 2);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (7, 'Semanal', 7, 'False', 0, 0, 3);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (8, 'Diario', 1, 'False', 0, 0, 4);

    UPDATE VentasFormasPago SET OrdenFichas = 5 WHERE Dias = 0;
END

DECLARE @idPadre varchar(MAX)
DECLARE @posicion int
SELECT @idPadre = IdPadre, @posicion = Posicion FROM Funciones WHERE Id = 'FichasABM2';
-- Si tiene el menu de CRM

IF @idPadre IS NOT NULL
BEGIN

    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
      VALUES
         ('ImportarFichas', 'Importar Fichas desde Excel', 'Importar Fichas desde Excel', 'True', 'False', 'True', 'True', 
          @idPadre, @posicion + 5, 'Eniac.Win', 'ImportarFichas', NULL, NULL
		  ,'True', 'S', 'N', 'N', 'N', 'True')
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImportarFichas' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;

 END

 PRINT '' 
PRINT '3. Tabla Funciones: Ajusto Padre y Posicion de Fichas (V2).' 
GO

UPDATE Funciones
  SET IdPadre = 'Ventas'
    , Posicion = 5
 WHERE Id =  'FichasABM2'
   AND IdPadre <> 'Ventas'
GO

IF dbo.ExisteFuncion('FichasABM2') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Fichas-BuscarTodasSucursales', 'Fichas - Permite seleccionar otras sucursales', 'Fichas - Permite seleccionar otras sucursales', 'True', 'False', 'True', 'True'
        ,'FichasABM2', 999, 'Eniac.Win', 'Fichas-BuscarTodasSucursales', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')


    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Fichas-BuscarTodasSucursales' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END