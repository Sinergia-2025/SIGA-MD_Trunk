/* Scrip que agrega el Estado en ALTA y lo setea como Predeterminado para ALCORTA MAQUINARIAS*/

PRINT ''
IF dbo.BaseConCuit('30701513890') = 1
BEGIN
    PRINT ''
    IF (NOT EXISTS(SELECT * FROM EstadosVehiculos where NombreEstadoVehiculo = 'Alta'))
        BEGIN
        DECLARE @IdAgregar INT = (Select MAX(IdEstadoVehiculo) from EstadosVehiculos) + 1
        UPDATE EstadosVehiculos SET Predeterminado = 0
        INSERT INTO EstadosVehiculos VALUES(@IdAgregar,'Alta',0,0,NULL,1)
        UPDATE Vehiculos SET IdEstadoVehiculo = @IdAgregar WHERE IdMarcaOperacionIngreso IS NULL AND AnioOperacionIngreso IS NULL AND NumeroOperacionIngreso IS NULL AND SecuenciaOperacionIngreso IS NULL
        PRINT 'Se agregó el Estado "Alta" y se seteó como Estado Predeterminado'
        PRINT ''
        PRINT 'Se setearon como "Alta" a los Vehículos que no tienen datos en: IdMarcaOperacionIngreso, AnioOperacionIngreso, NumeroOperacionIngreso y SecuenciaOperacionIngreso'
    END
    ELSE
    BEGIN
        IF (NOT EXISTS(Select * From EstadosVehiculos where NombreEstadoVehiculo = 'Alta' AND Predeterminado = 1))
        BEGIN
        UPDATE EstadosVehiculos SET Predeterminado = 1 where NombreEstadoVehiculo = 'Alta'
        UPDATE Vehiculos SET IdEstadoVehiculo = (Select IdEstadoVehiculo from EstadosVehiculos where NombreEstadoVehiculo = 'Alta') WHERE IdMarcaOperacionIngreso IS NULL AND AnioOperacionIngreso IS NULL AND NumeroOperacionIngreso IS NULL AND SecuenciaOperacionIngreso IS NULL
        PRINT 'Ya existía el Estado "Alta", se seteó como Estado Predeterminado'
        PRINT ''
        PRINT 'Se setearon como "Alta" a los Vehículos que no tienen datos en: IdMarcaOperacionIngreso, AnioOperacionIngreso, NumeroOperacionIngreso y SecuenciaOperacionIngreso'
        END
        ELSE
        BEGIN
        UPDATE Vehiculos SET IdEstadoVehiculo = (Select IdEstadoVehiculo from EstadosVehiculos where NombreEstadoVehiculo = 'Alta') WHERE IdMarcaOperacionIngreso IS NULL AND AnioOperacionIngreso IS NULL AND NumeroOperacionIngreso IS NULL AND SecuenciaOperacionIngreso IS NULL
        PRINT 'Ya existía el Estado "ALTA" y está configurado como Predeterminado'
        PRINT ''
        PRINT 'Se setearon como "Alta" a los Vehículos que no tienen datos en: IdMarcaOperacionIngreso, AnioOperacionIngreso, NumeroOperacionIngreso y SecuenciaOperacionIngreso'
        END
    END
END
ELSE
BEGIN
PRINT 'Script corrido sobre un Cliente que no es Alcorta Maquinarias (CUIT: 30701513890)'
END