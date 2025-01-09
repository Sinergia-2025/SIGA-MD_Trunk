PRINT '';
PRINT '1. Nueva función de menu: Informe Ordenes de Producción Detallado';
IF dbo.ExisteFuncion('InfProduccionDetallado') = 1
BEGIN
	DELETE Bitacora WHERE IdFuncion = 'InfProduccionDetallado';
	DELETE RolesFunciones WHERE IdFuncion = 'InfProduccionDetallado';
	DELETE Funciones WHERE Id = 'InfProduccionDetallado';

    PRINT '1.1. Crea Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfOrdenesProduccionDetallado', 'Informe Ordenes de Produccion Detallado', 'Informe Ordenes de Produccion Detallado', 'True', 'False', 'True', 'True'
        ,'Produccion', 25, 'Eniac.Win', 'InfOrdenesProduccionDetallado', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');

    PRINT '1.2. Crea RolesFunciones'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfOrdenesProduccionDetallado' FROM RolesFunciones WHERE IdFuncion = 'ConsultarOrdenesProduccion'
END

PRINT '';
PRINT '2. Trunca la tabla SincronizaRegistros';
TRUNCATE TABLE SincronizaRegistros
PRINT '';
PRINT '3. Trunca la tabla SincronizaTablas';
TRUNCATE TABLE SincronizaTablas
