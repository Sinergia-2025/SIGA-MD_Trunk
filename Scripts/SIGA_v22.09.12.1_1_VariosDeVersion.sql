PRINT ''
PRINT '1. Creo la Tabla AuditoriaCalidadListasControlProductosItems'

IF OBJECT_ID('AuditoriaCalidadListasControlProductosItems', 'U') IS NULL	-- Si FALTA la tabla
BEGIN
	CREATE TABLE [dbo].[AuditoriaCalidadListasControlProductosItems](
		[FechaAuditoria] [datetime] NOT NULL,
		[OperacionAuditoria] [char](1) NOT NULL,
		[UsuarioAuditoria] [varchar](10) NOT NULL,
		[IdProducto] [varchar](15) NOT NULL,
		[IdListaControl] [int] NOT NULL,
		[Item] [int] NOT NULL,
		[IdListaControlItem] [int] NOT NULL,
		[Ok] [bit] NOT NULL,
		[NoOk] [bit] NOT NULL,
		[Obs] [bit] NOT NULL,
		[Mat] [bit] NOT NULL,
		[NA] [bit] NOT NULL,
		[Observ] [varchar](1000) NULL,
		[Orden] [int] NULL,
		[Usuario] [varchar](50) NULL,
		[FechaMod] [datetime] NULL,
		[OkCalidad] [bit] NOT NULL,
		[NoOkCalidad] [bit] NOT NULL,
		[ObsCalidad] [bit] NOT NULL,
		[MatCalidad] [bit] NOT NULL,
		[NACalidad] [bit] NOT NULL,
		[ObservCalidad] [varchar](1000) NULL,
		[UsuarioCalidad] [varchar](50) NULL,
		[FechaModCalidad] [datetime] NULL,
	 CONSTRAINT [PK_AuditoriaCalidadListasControlProductosItems] PRIMARY KEY CLUSTERED 
	(
		[FechaAuditoria] ASC,
		[IdProducto] ASC,
		[IdListaControl] ASC,
		[Item] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END


PRINT ''
PRINT '2. Nuevo parametro: OCULTARCOMPARTIRVENTASPORMAIL (SI Falta).'
DECLARE @idParametro VARCHAR(MAX) = 'OCULTARCOMPARTIRVENTASPORMAIL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Ocultar Compartir Ventas'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
MERGE INTO Parametros AS DEST
		USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO


PRINT ''
PRINT '3. Creo la Tabla CalidadListasControlProductosItemsProceso.'
IF OBJECT_ID('CalidadListasControlProductosItemsProceso', 'U') IS NULL	-- Si FALTA la tabla
BEGIN
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON
	SET ANSI_PADDING ON

	CREATE TABLE [dbo].[CalidadListasControlProductosItemsProceso](
		[IdProducto] [varchar](15) NOT NULL,
		[IdListaControl] [int] NOT NULL,
		[Item] [int] NOT NULL,
		[OrdenItem] [int] NOT NULL,
		[IdListaControlItem] [int] NOT NULL,
		[Ok] [bit] NOT NULL,
		[NoOk] [bit] NOT NULL,
		[Obs] [bit] NOT NULL,
		[Mat] [bit] NOT NULL,
		[NA] [bit] NOT NULL,
		[Observ] [varchar](1000) NULL,
		[Orden] [int] NULL,
		[Usuario] [varchar](50) NULL,
		[FechaMod] [datetime] NULL,
		[SoyCalidad] [bit] NOT NULL,
		[SoyProduccion] [bit] NOT NULL,
		[RespuestaOtraArea] [varchar](20) NULL,
		[ObservOtraArea] [varchar](1000) NULL,
		[UsuarioOtraArea] [varchar](50) NULL,
		[FechaModOtraArea] [datetime] NULL,
		[Procesado] [bit] NOT NULL,
		[MensajeProcesado] [text] NOT NULL,
	 CONSTRAINT [PK_CalidadListasControlItemsProductosProceso] PRIMARY KEY CLUSTERED 
	([IdProducto] ASC,[IdListaControl] ASC,[Item] ASC,[OrdenItem] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END

