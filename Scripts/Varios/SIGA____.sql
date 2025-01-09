--PARAMETROS
DECLARE @interes decimal(7,2) = 0
--DECLARE @tipoRecibo nvarchar(15) = 'RECIBOCYO'
DECLARE @idCategoria int = 1
DECLARE @fechaComprobante datetime = '20160830'
DECLARE @fechaVencimiento datetime = '20160929'
DECLARE @fechaRecibo datetime = getdate()
DECLARE @importeTotal decimal(12,2) = 600.01
DECLARE @saldo decimal(12,2) = 600.01


--VARIABLES
DECLARE @interesAdicional decimal(7,2)
DECLARE @idInteres int = (SELECT MAX(IdInteres) FROM Categorias WHERE IdCategoria = @idCategoria)
DECLARE @interesSoloPrimerPago bit
SELECT @interesSoloPrimerPago = ValorParametro FROM Parametros WHERE IdParametro = 'INTERESESCALCULOCOMPLETOPRIMERPAGO'

SET @interesAdicional = ISNULL((SELECT AdicionalProporcinalDias
                                  FROM Intereses 
                                 WHERE IdInteres = @idInteres), 0)

IF @saldo > 0 AND CONVERT(DATE, @fechaComprobante) <> CONVERT(DATE, @fechaRecibo) AND (Not @interesSoloPrimerPago = 1 Or @importeTotal = @saldo)
BEGIN
    DECLARE @tipoMetodo nvarchar(30)
    SELECT @tipoMetodo = ValorParametro FROM Parametros WHERE IdParametro = 'INTERESESMETODOPARADETERMINARRANGO'

    IF @tipoMetodo = 'DIAMES'
    BEGIN
        DECLARE @diaUltimoInteres datetime --= @fechaComprobante
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
    ELSE
    BEGIN
        IF @tipoMetodo = 'DIASCORRIDOSVENCIMIENTO'
            SET @fechaComprobante = @fechaVencimiento
        SET @interes = ISNULL((SELECT Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DATEADD(d, DiasDesde, @fechaComprobante) <= @fechaRecibo AND DATEADD(d, DiasHasta + 1, @fechaComprobante) > @fechaRecibo), 0)
        
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

SELECT @tipoMetodo TipoMetodo
      ,@interes AS Interes
      ,@interesAdicional InteresAdicional
      ,@diaUltimoInteres DiaUltimoInteres
      ,@fechaRecibo FechaRecibo
      ,@interesSoloPrimerPago InteresSoloPrimerPago
