

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
PRINT ''
PRINT '1.1. Sincronizar OC Bejerman: Configuraciones'
INSERT INTO [dbo].[Parametros]
           ([IdParametro]
           ,[ValorParametro]
           ,[CategoriaParametro]
           ,[DescripcionParametro]
           ,[IdEmpresa])
     VALUES
           ('BEJERMANFECHAMODIFOCAUTORIZADAS',	'2021-12-21 09:32:38.000',	'WEB-ARCHIVOS',	'', 	1)
END;