-- Cambiar estado de TarjetasCupones duplicados a 'DUPLICADO'
WITH Duplicados AS (
    SELECT
        Monto,
        IdTarjeta,
        IdBanco,
        Cuotas,
        COUNT(*) AS Conteo
    FROM
        TarjetasCupones
    GROUP BY
        Monto,
        IdTarjeta,
        IdBanco,
        Cuotas
    HAVING
        COUNT(*) > 1
)

Update TarjetasCupones Set IdEstadoTarjeta = 'DUPLICADO'
WHERE
    EXISTS (
        SELECT 1
        FROM Duplicados d
        WHERE
            TarjetasCupones.Monto = d.Monto
            AND TarjetasCupones.IdTarjeta = d.IdTarjeta
            AND TarjetasCupones.IdBanco = d.IdBanco
            AND TarjetasCupones.Cuotas = d.Cuotas
    )
    AND IdCajaIngreso IS NULL
    AND NroPlanillaIngreso IS NULL
    AND NroMovimientoIngreso IS NULL;
