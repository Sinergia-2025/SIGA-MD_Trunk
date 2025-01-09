SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO
--DROP TABLE [dbo].[CalidadListasControlProductosItemsProceso]
--GO
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
GO

IF dbo.BaseConCuit('33631312379') = 'True'
BEGIN

    DECLARE @idParametro VARCHAR(MAX)
    DECLARE @descripcionParametro VARCHAR(MAX)
    DECLARE @valorParametro VARCHAR(MAX)
    --IF dbo.BaseConCuit('20170521014') = 1
    --    SET @valor = 'True'

    SET @idParametro = 'LISTASCONTROLESTADOPENDIENTE'
    SET @descripcionParametro = ''
    SET @valorParametro = '1'

    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    SET @idParametro = 'LISTASCONTROLESTADOENPROCESO'
    SET @descripcionParametro = ''
    SET @valorParametro = '2'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    SET @idParametro = 'LISTASCONTROLESTADOTERMINADO'
    SET @descripcionParametro = ''
    SET @valorParametro = '4'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
END
GO

PRINT ''
PRINT '0.- Datos para Turismo'
IF dbo.BaseConCuit('30714374938') = 'True'
BEGIN

	-- PARA EDUVIAJES

	INSERT [dbo].[TiposComprobantesLetras] 
				([IdTipoComprobante], [Letra], 
				 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
				 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
		VALUES  ('FICHAS', 'X', 
				 '357_Cuota.rdlc', 'False', '', 99, 98, 1, 1, 
				 '', 'False', '', 'False')
END
GO


PRINT ''
PRINT '1. Tabla Reservas: Agregar campos Observaciones'
ALTER TABLE Reservas ADD ObservacionesVendedor varchar(2000)  null
GO
UPDATE Reservas SET ObservacionesVendedor = ''
GO
ALTER TABLE Reservas ALTER COLUMN ObservacionesVendedor varchar(2000) not null
GO
ALTER TABLE Reservas ADD ObservacionesInternas varchar(2000)  null
GO
UPDATE Reservas SET ObservacionesInternas = ''
GO
ALTER TABLE Reservas ALTER COLUMN ObservacionesInternas varchar(2000) not null
GO

