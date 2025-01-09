--PRINT ''
--PRINT '1. Nueva Función: ABM  de Tipos Estados Novedades'
--IF dbo.ExisteFuncion('CRM') = 1 OR dbo.ExisteFuncion('CRMABMs') = 1
--BEGIN
--    DECLARE @idPadre VARCHAR(MAX) = 'CRM'
--    IF dbo.ExisteFuncion('CRMABMs') = 1
--        SET @idPadre = 'CRMABMs'
--    INSERT INTO Funciones
--        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
--        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
--    VALUES
--        ('CRMTiposEstadosNovedades', 'ABM  de Tipos Estados Novedades', 'Tipos Estados Novedades', 'True', 'False', 'True', 'True'
--        ,'@idPadre', 595, 'Eniac.Win', 'CRMTiposEstadosNovedadesABM', NULL, NULL
--        ,'True', 'S', 'N', 'N', 'N')
   
   
--	INSERT INTO RolesFunciones (IdRol,IdFuncion)
--	SELECT DISTINCT Id AS Rol, 'CRMTiposEstadosNovedadesABM' AS Pantalla FROM dbo.Roles
--	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
--END

PRINT ''
PRINT '2. Nueva Función: Informe de Servicio Técnico'
IF dbo.ExisteFuncion('CRM') = 1 OR dbo.ExisteFuncion('CRMInformes') = 1 
BEGIN
  DECLARE @Padre VARCHAR(15) = CASE WHEN (SELECT Id FROM Funciones WHERE Id = 'CRMInformes') IS NOT NULL THEN 'CRMInformes' ELSE 'CRM' END
  IF (SELECT IdTipoNovedad FROM CRMTiposNovedades WHERE IdTipoNovedad = 'SERVICE') IS NOT NULL
  BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeDeNovedadesService', 'Informe de Servicio Técnico', 'Informe de Servicio Técnico', 'True', 'False', 'True', 'True'
	    ,@Padre, 240, 'Eniac.Win', 'InformeDeNovedades', NULL, 'SERVICE'
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesService' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
  END

  IF (SELECT IdTipoNovedad FROM CRMTiposNovedades WHERE IdTipoNovedad = 'SERVICE') IS NOT NULL
  BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('InformeDeServiceDetallado', 'Informe de Servicio Técnico Detallado', 'Informe de Servicio Técnico Detallado', 'True', 'False', 'True', 'True'
	    ,@Padre, 245, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'SERVICE'
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeDeServiceDetallado' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
  END
END
GO


PRINT ''
PRINT '3. Nueva Función: Performance de Soporte y Desarrollo'
IF dbo.SoyHAR() = 1
BEGIN
    UPDATE Funciones SET Posicion = 10 WHERE Id = 'TableroDeComando_soporte'
    UPDATE Funciones SET Posicion = 20 WHERE Id = 'TableroDeComando_desarrollo'

    PRINT ''
    PRINT '3.1. Crear Menu: Performance de Soporte desde TableroDeComandox3'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_entregasopo', 'Performance de Soporte', 'Performance de Soporte', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 110, Archivo, Pantalla, Icono, 'Tablero=3'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox3'
    
    PRINT ''
    PRINT '3.2. Roles Menu: Performance de Soporte'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_entregasopo' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComandox3'


    PRINT ''
    PRINT '3.3. Crear Menu: Performance de Desarrollo desde TableroDeComandox3'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_entregadesa', 'Performance de Desarrollo', 'Performance de Desarrollo', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 120, Archivo, Pantalla, Icono, 'Tablero=4'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox3'
    
    PRINT ''
    PRINT '3.4. Roles Menu: Performance de Desarrollo'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_entregadesa' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComandox3'
END


PRINT ''
PRINT '4. Nueva Función: ABM de Tipos Novedades Objetivo'
IF dbo.ExisteFuncion('CRM') = 1 OR dbo.ExisteFuncion('CRMABMs') = 1
BEGIN
    DECLARE @idPadre VARCHAR(MAX) = 'CRM'
    IF dbo.ExisteFuncion('CRMABMs') = 1
    SET @idPadre = 'CRMABMs'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CRMTiposNovedadesObjetivosABM', 'ABM de Tipos Novedades Objetivo', 'ABM de Tipos Novedades Objetivo', 'True', 'False', 'True', 'True'
        ,@idPadre, 610, 'Eniac.Win', 'CRMTiposNovedadesObjetivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMTiposNovedadesObjetivosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '5. Menu: Ajustar funcion Tablero para Técnicos'
UPDATE Funciones
   SET Pantalla = 'TableroDeComandox3'
 WHERE Id = 'TableroDeComando_tecnicos'