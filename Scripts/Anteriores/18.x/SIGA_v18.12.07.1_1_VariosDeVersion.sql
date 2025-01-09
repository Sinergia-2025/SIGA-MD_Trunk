PRINT ''
PRINT '1. Función: Permitir Ocultar Contabilidad'
GO

DECLARE @ValorParametro varchar(max) = 'False'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('20129223333'))
BEGIN
    SET @ValorParametro = 'True'
END

MERGE INTO Parametros AS P
        USING (SELECT 'PEDIDOCULTARENTABILIDAD' AS IdParametro, @ValorParametro ValorParametro, 'Permite Ocultar Rentabilidad en Pedido Cliente'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
GO
PRINT ''
PRINT '1. Función: Permitir crear Destinatiario FTP Actualizacion Masiva'
GO
DECLARE @ValorParametroAsunto varchar(max) = ''
DECLARE @ValorParametroPara varchar(max) = ''
DECLARE @ValorParametroBCC varchar(max) = ''

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN
    SET @ValorParametroAsunto = '{0} - Versión {1} generada'
    SET @ValorParametroPara = 'soporte@sinergiass.com.ar'
    SET @ValorParametroBCC = 'augusto.rolla@sinergiass.com.ar;sebastian.carrozzo@sinergiass.com.ar'
END

MERGE INTO Parametros AS P
        USING (SELECT 'CRMASUNTOGENERARVERSION' AS IdParametro, @ValorParametroAsunto ValorParametro, 'Asunto envio masivo novedades email'  AS DescripcionParametro UNION ALL
               SELECT 'CRMGENERARVERSIONPARA' AS IdParametro, @ValorParametroPara ValorParametro, 'Email para envio de nueva versión'  AS DescripcionParametro UNION ALL
               SELECT 'CRMGENERARVERSIONCOPIAOCULTA' AS IdParametro, @ValorParametroBCC ValorParametro, 'Email copia oculta para envio de nueva versión'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro, P.DescripcionParametro = PT.DescripcionParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
go
PRINT ''
PRINT '1. Función: Crear campos CodigoAfip Tabla Regimen'
go
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Regimenes ADD CodigoAfip int NULL
GO
UPDATE       Regimenes
SET                CodigoAfip = IdRegimen  

GO
COMMIT

ALTER TABLE Regimenes ALTER COLUMN CodigoAfip INTEGER NOT NULL
GO