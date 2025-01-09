PRINT ''
PRINT 'A0. Nuevo Menu: Informa Ventas Pirelli'
BEGIN
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A1. Nueva Opcion de Menú: '

	IF dbo.ExisteFuncion('InformaVentasPirelli') = 0 and dbo.BaseConCuit('20085063899') = 1
	BEGIN    
            INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
            VALUES
                ('InformaVentasPirelli', 'Informa Ventas a Pirelli', 'Informa Ventas a Pirelli', 'False', 'False', 'True', 'True'
                ,'Ventas', 76, 'Eniac.Win', 'InformaVentasPirelli', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N', 'True')

            INSERT INTO RolesFunciones (IdRol,IdFuncion)
            SELECT DISTINCT Id AS Rol, 'InformaVentasPirelli' AS Pantalla FROM dbo.Roles
             WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ------------------------------------------------------------------------------------------------------------------------
END
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B0. Inserta parametro tabla de Parametros'
DECLARE @Valor as Varchar(10)
BEGIN
    PRINT ''
    PRINT 'B1. Carga URL Base de Pirelli.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'VENTASPIRELLIURLBASE')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'VENTASPIRELLIURLBASE' AS IdParametro, 
                        'HTTP://152.67.35.38/controller/' ValorParametro, 
                        'Ventas Pirelli' CategoriaParametro, 
                        'VENTASPIRELLIURLBASE' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END
    PRINT ''
    PRINT 'B2. Carga IDMARCA Ventas Pirelli.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'VENTASPIRELLIIDMARCA')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'VENTASPIRELLIIDMARCA' AS IdParametro, 
                        '2' ValorParametro, 
                        'Ventas Pirelli' CategoriaParametro, 
                        'VENTASPIRELLIIDMARCA' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END
    PRINT ''
    PRINT 'B3. Carga Sucursal Ventas Pirelli.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'VENTASPIRELLIIDSUCURSAL')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'VENTASPIRELLIIDSUCURSAL' AS IdParametro, 
                        '1' ValorParametro, 
                        'Ventas Pirelli' CategoriaParametro, 
                        'VENTASPIRELLIIDSUCURSAL' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END
END
GO


/****** Object:  UserDefinedFunction [dbo].[CtaCtePorcDescRecSaldo]    Script Date: 2/8/2021 14:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[CtaCtePorcDescRecSaldo]
(
	@idCategoria int,				-- Categoría del cliente
	@fechaComprobante datetime,		-- Fecha de emisión del comprobante
	@fechaVencimiento datetime,		-- Fecha de vencimiento del comprobante
	@fechaRecibo datetime,			-- Fecha Recibo
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
    -- Return the result of the function
    RETURN ISNULL(@interes, 0)
END