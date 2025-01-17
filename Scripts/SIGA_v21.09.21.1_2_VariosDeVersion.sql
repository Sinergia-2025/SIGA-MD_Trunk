/****** Object:  UserDefinedFunction [dbo].[CtaCtePorcDescRecSaldo]    Script Date: 21/09/2021 09:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[CtaCtePorcDescRecSaldo]
(
    @idCategoria int,                -- Categoría del cliente
    @fechaComprobante datetime,        -- Fecha de emisión del comprobante
    @fechaVencimiento datetime,        -- Fecha de vencimiento del comprobante
    @fechaRecibo datetime,            -- Fecha Recibo
    @importeTotal decimal,          -- Importe del comprobante
    @saldo decimal                  -- Saldo del comprobante
)
    RETURNS decimal(12, 2)
AS
BEGIN
    DECLARE @interes decimal(10,2) = 0
    --VARIABLES
    DECLARE @idInteres int = (SELECT MAX(IdInteres) FROM Categorias WHERE IdCategoria = @idCategoria)
    DECLARE @interesSoloPrimerPago bit
    SELECT @interesSoloPrimerPago = ValorParametro FROM Parametros WHERE IdParametro = 'INTERESESCALCULOCOMPLETOPRIMERPAGO'

    DECLARE @interesAdicional decimal(7,2) = ISNULL((SELECT AdicionalProporcinalDias FROM Intereses WHERE IdInteres = @idInteres), 0)

    DECLARE @utilizaVigencia bit
    SELECT @utilizaVigencia = UtilizaVigencia FROM Intereses WHERE IdInteres = @idInteres
    DECLARE @fechaVigenciaDesde datetime
    SELECT @fechaVigenciaDesde = FechaVigenciaDesde FROM Intereses WHERE IdInteres = @idInteres
    DECLARE @fechaVigenciaHasta datetime
    SELECT @fechaVigenciaHasta = FechaVigenciaHasta FROM Intereses WHERE IdInteres = @idInteres

    IF @utilizaVigencia = 0 OR CONVERT(DATE, @fechaComprobante) BETWEEN CONVERT(DATE, @fechaVigenciaDesde) AND CONVERT(DATE, @fechaVigenciaHasta)
    BEGIN
        IF @saldo > 0 AND CONVERT(DATE, @fechaComprobante) <> CONVERT(DATE, @fechaRecibo) AND (Not @interesSoloPrimerPago = 1 Or @importeTotal = @saldo)
        BEGIN
            DECLARE @tipoMetodo nvarchar(30)
            SELECT @tipoMetodo = MetodoParaDeterminarRango FROM Intereses WHERE IdInteres = @idInteres

            --Para los casos de DIAMES y DIAMESVENCIMIENTO tengo una lógica
            IF @tipoMetodo = 'DIAMES' OR @tipoMetodo = 'DIAMESVENCIMIENTO'
            BEGIN
                --Si el método es DIAMESVENCIMIENTO tomo la fecha de vencimiento como valor de referencia
                IF @tipoMetodo = 'DIAMESVENCIMIENTO'
                    SET @fechaComprobante = @fechaVencimiento
                DECLARE @diaUltimoInteres datetime
                SET @diaUltimoInteres = ISNULL((SELECT TOP 1 MAX(DateAdd(yyyy, YEAR(@fechaComprobante) - 1900,DateAdd(m,  MONTH(@fechaComprobante) - 1, DiasHasta - 1))) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC),
                                               @fechaComprobante)
                IF @diaUltimoInteres < @fechaRecibo
                BEGIN
                    DECLARE @diasTranscurridos int = DATEDIFF(D, @diaUltimoInteres, @fechaRecibo)
                    SET @interes = ISNULL((SELECT TOP 1 MAX(Interes) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC), 0) +
                                   (@interesAdicional * @diasTranscurridos / 30)
                END
                ELSE
                BEGIN
                    SET @interes = (SELECT Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DiasDesde <= DAY(@fechaRecibo) AND DiasHasta >= DAY(@fechaRecibo))
                END
            END
            --Para los casos de DIASCORRIDOSEMISION y DIASCORRIDOSVENCIMIENTO tengo otra lógica
            ELSE
            BEGIN
                --Si el método es DIASCORRIDOSVENCIMIENTO tomo la fecha de vencimiento como valor de referencia
                IF @tipoMetodo = 'DIASCORRIDOSVENCIMIENTO'
                    SET @fechaComprobante = @fechaVencimiento
                SET @interes = (SELECT TOP 1 Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DATEADD(d, DiasDesde, @fechaComprobante) <= @fechaRecibo AND DATEADD(d, DiasHasta + 1, @fechaComprobante) > @fechaRecibo)
            
                IF @interes IS NULL
                BEGIN
                    SET @diaUltimoInteres = ISNULL((SELECT TOP 1 DATEADD(D, DiasHasta, @fechaComprobante) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC),
                                                   @fechaComprobante)
                    IF @diaUltimoInteres < @fechaRecibo
                    BEGIN
                        SET @diasTranscurridos = DATEDIFF(D, @diaUltimoInteres, @fechaRecibo)
                        SET @interes = ISNULL((SELECT TOP 1 MAX(Interes) FROM InteresesDias WHERE IdInteres = @idInteres GROUP BY DiasHasta ORDER BY DiasHasta DESC), 0) +
                                       (@interesAdicional * @diasTranscurridos / 30)
                    END
                END
            END
        END
    END
    -- Return the result of the function
    RETURN ISNULL(@interes, 0)
END