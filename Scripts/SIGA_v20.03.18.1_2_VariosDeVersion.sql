/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Reservas ADD ErroresSincronizacion text NULL
GO
UPDATE Reservas SET ErroresSincronizacion = '';
ALTER TABLE dbo.Reservas ALTER COLUMN ErroresSincronizacion text NOT NULL
GO
ALTER TABLE dbo.Reservas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

GO

PRINT ''
PRINT '1. Menu: Comando - Turismo Importación automática de Reservas'

IF dbo.BaseConCuit('30714374938') = 'True' OR dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Menu - Nueva Funcion: Comando - Turismo Importación automática de Reservas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdTurismoDescargarReserva', 'Turismo Importación automática de Reservas', 'Turismo Importación automática de Reservas', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdTurismoDescargarReserva', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '1.2. Roles para: Proceso Envio Automatico de Doc A Vencer'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'CmdTurismoDescargarReserva' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaTurismo'
END

PRINT ''
PRINT '2. Tareas Programadas: Comando - Turismo Importación automática de Reservas'

IF dbo.BaseConCuit('30714374938') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Agregar Tareas Programadas: Comando - Turismo Importación automática de Reservas'
    IF NOT EXISTS (SELECT 1 FROM TareasProgramadas WHERE IdFuncion = 'CmdTurismoDescargarReserva')
    BEGIN
        DECLARE @idTareaProgramada INT = ISNULL((SELECT MAX(IdTareaProgramada) FROM TareasProgramadas), 0) + 1
        INSERT TareasProgramadas
               (IdTareaProgramada, IdFuncion, Usuario, Observacion, UltimaFechaEjecucion) 
        VALUES (@idTareaProgramada, 'CmdTurismoDescargarReserva', 'admin', '', NULL)
    END
END