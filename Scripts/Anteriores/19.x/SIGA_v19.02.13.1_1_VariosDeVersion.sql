
PRINT ''
PRINT '1. Tabla TurnosCalendariosProductos: Agrego Campo ValorFluencia.'
GO
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TurnosCalendariosProductos ADD ValorFluencia int NULL
GO
UPDATE dbo.TurnosCalendariosProductos SET ValorFluencia = 0
GO
ALTER TABLE dbo.TurnosCalendariosProductos ALTER COLUMN ValorFluencia int NOT NULL
GO
COMMIT


PRINT ''
PRINT '2. Funciones: Creo Menu SiMovil de Logistica/Cobranza Movil.'
GO
DECLARE @posicionSiMovil int 
IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'Logistica') AND NOT EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro IN ('33711345499'))
BEGIN
    SET @posicionSiMovil = 4

    UPDATE Funciones
       SET IdPadre = NULL, Nombre = 'SiMovil', Descripcion = 'SiMovil', Posicion = @posicionSiMovil
     WHERE Id = 'CobranzasMovil'

    IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'GenerarArchivos')
        UPDATE Funciones
           SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Generar Archivos', Descripcion = 'Pedidos - Generar Archivos', Posicion = 110, Archivo = 'Eniac.Win'
         WHERE Id = 'GenerarArchivos'
    ELSE
    BEGIN
        INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	    VALUES
	       ('GenerarArchivos', 'Pedidos - Generar Archivos', 'Pedidos - Generar Archivos', 'True', 'False', 'True', 'True', 
            'CobranzasMovil', 110, 'Eniac.Win', 'GenerarArchivos', null, null,
            'True', 'S', 'N', 'N', 'N');

	    INSERT INTO RolesFunciones (IdRol, IdFuncion)
            SELECT IdRol, 'GenerarArchivos' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaMovil'
    END

    IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'PreventaV2')
        UPDATE Funciones
           SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Preventa (v2 - Archivo)', Descripcion = 'Pedidos - Preventa (v2 - Archivo)', Posicion = 120, Archivo = 'Eniac.Win'
         WHERE Id = 'PreventaV2'
    ELSE
    BEGIN
        INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	    VALUES
	       ('PreventaV2', 'Pedidos - Preventa (v2 - Archivo)', 'Pedidos - Preventa (v2 - Archivo)', 'True', 'False', 'True', 'True', 
            'CobranzasMovil', 120, 'Eniac.Win', 'PreventaV2', null, null,
            'True', 'S', 'N', 'N', 'N');
    	INSERT INTO RolesFunciones (IdRol, IdFuncion)
            SELECT IdRol, 'PreventaV2' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
    END

    IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'PreventaV3')
        UPDATE Funciones
           SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Preventa (v3 - Web)', Descripcion = 'Pedidos - Preventa (v3 - Web)', Posicion = 130, Archivo = 'Eniac.Win'
         WHERE Id = 'PreventaV3'
    ELSE
    BEGIN
        INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	    VALUES
	       ('PreventaV3', 'Pedidos - Preventa (v3 - Web)', 'Pedidos - Preventa (v3 - Web)', 'True', 'False', 'True', 'True', 
            'CobranzasMovil', 130, 'Eniac.Win', 'PreventaV3', null, null,
            'True', 'S', 'N', 'N', 'N');
    	INSERT INTO RolesFunciones (IdRol, IdFuncion)
            SELECT IdRol, 'PreventaV3' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
    END

    UPDATE Funciones
       SET Nombre = 'Cobranza - Bajar Recibos', Descripcion = 'Cobranza - Bajar Recibos'
     WHERE Id = 'SincronizacionBajadaCobranzas'

    DELETE FROM Bitacora WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
    DELETE FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
    DELETE FROM Funciones WHERE Id = 'SincronizacionBajadaCobranzas'

END
ELSE
BEGIN
    IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'CobranzasMovil')
    BEGIN
        SET @posicionSiMovil = 85

        UPDATE Funciones
           SET IdPadre = NULL, Nombre = 'SiMovil', Descripcion = 'SiMovil', Posicion = @posicionSiMovil
         WHERE Id = 'CobranzasMovil'

        IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'GenerarArchivos')
            UPDATE Funciones
               SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Generar Archivos', Descripcion = 'Pedidos - Generar Archivos', Posicion = 110, Archivo = 'Eniac.Win'
             WHERE Id = 'GenerarArchivos'
        ELSE
        BEGIN
            INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                     ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	        VALUES
	           ('GenerarArchivos', 'Pedidos - Generar Archivos', 'Pedidos - Generar Archivos', 'True', 'False', 'True', 'True', 
                'CobranzasMovil', 110, 'Eniac.Win', 'GenerarArchivos', null, null,
                'True', 'S', 'N', 'N', 'N');

	        INSERT INTO RolesFunciones (IdRol, IdFuncion)
                SELECT IdRol, 'GenerarArchivos' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaMovil'
        END

        IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'PreventaV2')
            UPDATE Funciones
               SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Preventa (v2 - Archivo)', Descripcion = 'Pedidos - Preventa (v2 - Archivo)', Posicion = 120, Archivo = 'Eniac.Win'
             WHERE Id = 'PreventaV2'
        ELSE
        BEGIN
            INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                     ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	        VALUES
	           ('PreventaV2', 'Pedidos - Preventa (v2 - Archivo)', 'Pedidos - Preventa (v2 - Archivo)', 'True', 'False', 'True', 'True', 
                'CobranzasMovil', 120, 'Eniac.Win', 'PreventaV2', null, null,
                'True', 'S', 'N', 'N', 'N');
    	    INSERT INTO RolesFunciones (IdRol, IdFuncion)
                SELECT IdRol, 'PreventaV2' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
        END

        IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'PreventaV3')
        BEGIN
            --UPDATE Funciones
            --   SET IdPadre = 'CobranzasMovil', Nombre = 'Pedidos - Preventa (v3 - Web)', Descripcion = 'Pedidos - Preventa (v3 - Web)', Posicion = 130, Archivo = 'Eniac.Win'
            -- WHERE Id = 'PreventaV3'
            INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                     ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	        VALUES
	           ('PreventaV3SiMovil', 'Pedidos - Preventa (v3 - Web)', 'Pedidos - Preventa (v3 - Web)', 'True', 'False', 'True', 'True', 
                'CobranzasMovil', 130, 'Eniac.Win', 'PreventaV3', null, null,
                'True', 'S', 'N', 'N', 'N');
    	    INSERT INTO RolesFunciones (IdRol, IdFuncion)
                SELECT IdRol, 'PreventaV3SiMovil' FROM RolesFunciones WHERE IdFuncion = 'PreventaV3'
        END
        ELSE
        BEGIN
            INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                     ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	        VALUES
	           ('PreventaV3', 'Pedidos - Preventa (v3 - Web)', 'Pedidos - Preventa (v3 - Web)', 'True', 'False', 'True', 'True', 
                'CobranzasMovil', 130, 'Eniac.Win', 'PreventaV3', null, null,
                'True', 'S', 'N', 'N', 'N');
    	    INSERT INTO RolesFunciones (IdRol, IdFuncion)
                SELECT IdRol, 'PreventaV3' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas'
        END

        UPDATE Funciones
           SET Nombre = 'Cobranza - Bajar Recibos', Descripcion = 'Cobranza - Bajar Recibos'
         WHERE Id = 'SincronizacionBajadaCobranzas'
    END
END


PRINT ''
PRINT '3. Funciones: Creo Menu Cobranza Movil\Informe de Clientes en Rutas.'
GO
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CobranzasMovil')
--Inserto la Pantalla Nueva
BEGIN
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('InfClientesRuta', 'Informe de Clientes en Rutas', 'Informe de Clientes en Rutas', 
		'True', 'False', 'True', 'True', 'CobranzasMovil', 75, 'Eniac.Win', 'InfClientesRuta', null, null,'N','S','N','N')
;

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfClientesRuta' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;
	
END;
GO
