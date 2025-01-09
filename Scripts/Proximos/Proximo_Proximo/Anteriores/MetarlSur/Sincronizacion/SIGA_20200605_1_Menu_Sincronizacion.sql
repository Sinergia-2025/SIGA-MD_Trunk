/*
DELETE FROM Bitacora WHERE IdFuncion IN (SELECT Id FROM Funciones WHERE IdPadre = 'Procesos')
DELETE FROM Bitacora WHERE IdFuncion IN (SELECT Id FROM Funciones WHERE Id = 'Procesos')
DELETE FROM RolesFunciones WHERE IdFuncion IN (SELECT Id FROM Funciones WHERE IdPadre = 'Procesos')
DELETE FROM RolesFunciones WHERE IdFuncion IN (SELECT Id FROM Funciones WHERE Id = 'Procesos')
DELETE FROM Funciones WHERE Id IN (SELECT Id FROM Funciones WHERE IdPadre = 'Procesos')
DELETE FROM Funciones WHERE Id IN (SELECT Id FROM Funciones WHERE Id = 'Procesos')
*/

PRINT ''
PRINT '0. Habilitar Ticket a Metalsur.'
--IF dbo.BaseConCuit('33631312379') = 'True'
BEGIN
    
    PRINT ''
    PRINT '1. Menu: Crear opciones de menú necesarias (se inicializar marcadas con una Y en Plus'
    MERGE INTO Funciones AS DEST
            USING (SELECT 'Procesos'                      Id, NULL  IdPadre, 170 Posicion, 'True' EsMenu, 'Procesos' AS Nombre, 'Procesos' Descripcion, NULL Archivo, NULL Pantalla, NULL Parametros UNION ALL

                   SELECT 'SincronizacionSubida'          Id, 'Procesos' IdPadre, 300 Posicion, 'True' EsMenu, 'Sincronización - Subir a la Web'      AS Nombre, 'Sincronización - Subir a la Web'  Descripcion, 'Eniac.Win' Archivo, 'SincronizacionSubida' Pantalla, NULL Parametros UNION ALL
                   SELECT 'SincronizacionSubidaV2'        Id, 'Procesos' IdPadre, 300 Posicion, 'True' EsMenu, 'Sincronización - Subir a la Web (v2)' AS Nombre, 'Sincronización - Subir a la Web (v2)'  Descripcion, 'Eniac.Win' Archivo, 'SincronizacionSubidaV2' Pantalla, NULL Parametros UNION ALL
                   SELECT 'SincronizacionBajada'          Id, 'Procesos' IdPadre, 310 Posicion, 'True' EsMenu, 'Sincronización - Bajar de la Web'     AS Nombre, 'Sincronización - Bajar de la Web' Descripcion, 'Eniac.Win' Archivo, 'SincronizacionBajada' Pantalla, NULL Parametros

                  ) AS ORIG ON DEST.Id = ORIG.Id
        WHEN NOT MATCHED THEN 
            INSERT (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
                   ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                   ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUEs (ORIG.Id, ORIG.Nombre, ORIG.Descripcion, ORIG.EsMenu, 'False', 'True', 'True'
                   ,ORIG.IdPadre, ORIG.Posicion, ORIG.Archivo, ORIG.Pantalla, NULL, ORIG.Parametros
                   ,'True', 'Y', 'N', 'N', 'N')
    ;

    PRINT ''
    PRINT '1.1. Menu: Asignar todas las funciones marcadas con Y a los roles'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT R.Id, F.Id FROM Funciones F CROSS JOIN Roles R 
        WHERE F.Plus = 'Y' AND R.Id IN ('Adm', 'Supervisor', 'Oficina');

    PRINT ''
    PRINT '1.2. Menu: Desmarcar las funciones marcadas con Y'
    UPDATE Funciones SET Plus = 'S' WHERE Plus = 'Y';

END
