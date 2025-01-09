PRINT ''
PRINT '1. Campo_Intereses_MetodoParaDeterminarRango.'
GO

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
ALTER TABLE dbo.Intereses ADD MetodoParaDeterminarRango varchar(30) NULL
GO
UPDATE Intereses
   SET MetodoParaDeterminarRango = P.ValorParametro
  FROM Intereses I 
 CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'INTERESESMETODOPARADETERMINARRANGO') P
ALTER TABLE dbo.Intereses ALTER COLUMN MetodoParaDeterminarRango varchar(30) NOT NULL
GO
ALTER TABLE dbo.Intereses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

--------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. FN_CtaCtePorcDescRecSaldo.'
GO
IF EXISTS ( SELECT  * FROM sys.objects WHERE object_id = OBJECT_ID(N'CtaCtePorcDescRecSaldo')
									     AND type IN ( 'FN', 'IF', 'TF', 'FS', 'FT' ) ) 
	/****** Object:  UserDefinedFunction [dbo].[CtaCtePorcDescRecSaldo]    Script Date: 19/04/2018 11:27:49 ******/
	DROP FUNCTION [dbo].[CtaCtePorcDescRecSaldo]
	GO

/****** Object:  UserDefinedFunction [dbo].[CtaCtePorcDescRecSaldo]    Script Date: 19/04/2018 11:27:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CtaCtePorcDescRecSaldo]
(
	@idCategoria int,				-- Categoría del cliente
	@fechaComprobante datetime,		-- Fecha de emisión del comprobante
	@fechaVencimiento datetime,		-- Fecha de vencimiento del comprobante
	@fechaRecibo datetime,			-- Fecha Recibo
	@importeTotal decimal(12,2),	-- Importe del comprobante
	@saldo decimal(12,2)			-- Saldo del comprobante
)
	RETURNS decimal(7,2)
AS
BEGIN
    DECLARE @interes decimal(7,2) = 0
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
            SET @interes = (SELECT Interes FROM InteresesDias WHERE IdInteres = @idInteres AND DATEADD(d, DiasDesde, @fechaComprobante) <= @fechaRecibo AND DATEADD(d, DiasHasta + 1, @fechaComprobante) > @fechaRecibo)
            
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

GO

--------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Menu_Clientes-PuedeExtraerInfo.'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Clientes-PuedeExtraerInfo', 'Clientes - Puede Extraer Información', 'Clientes - Puede Extraer Información', 
    'False', 'False', 'True', 'True', 'Clientes', 10, 'Eniac.Win', 'Clientes-PuedeExtraerInfo', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT IdRol, 'Clientes-PuedeExtraerInfo' AS Pantalla FROM dbo.RolesFunciones
    WHERE IdFuncion = 'Clientes'
GO


--------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '4. Config_Aloe_WebMarcas.'
GO

MERGE INTO Parametros AS P
     USING (SELECT 'WEBARCHIVOSMARCASURLGETMAXFECHA'  AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsonmax/CuitEmpresa/23238857449/'  ValorParametro, 'URL GET MAX FECHA' AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLDELETE'       AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajson/CuitEmpresa/23238857449/'     ValorParametro, 'URL DELETE'        AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLPOST'         AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajson/'                             ValorParametro, 'URL POST'          AS DescripcionParametro UNION

            SELECT 'WEBARCHIVOSMARCASURLGETCOUNT'     AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsoncount/CuitEmpresa/23238857449/FechaActualizacion/{0}'                              ValorParametro, 'URL GET COUNT'     AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASURLGET'          AS IdParametro, 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigamarcajsondesdehasta/CuitEmpresa/23238857449/FechaActualizacion/{2}/Desde/{0}/Cantidad/{1}'  ValorParametro, 'URL GET'           AS DescripcionParametro UNION

            SELECT 'WEBARCHIVOSMARCASTAMANOPAGINAGET'         AS IdParametro, '99999999'      ValorParametro, 'Tamaño Página GET'     AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASTAMANOPAGINAPOST'        AS IdParametro, '500'           ValorParametro, 'Tamaño Página POST'    AS DescripcionParametro UNION
            SELECT 'WEBARCHIVOSMARCASARCHIVOEXPORTACION'      AS IdParametro, ''              ValorParametro, 'Archivo Exportación'   AS DescripcionParametro
            ) AS PT ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro, P.CategoriaParametro = 'WEB-ARCHIVOS'
 WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, 'WEB-ARCHIVOS' , PT.DescripcionParametro)
;
