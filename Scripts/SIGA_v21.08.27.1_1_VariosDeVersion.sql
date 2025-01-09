BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

PRINT ''
PRINT '1. Nueva Tabla VentasInvocados'
CREATE TABLE [dbo].[VentasInvocados](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdSucursalInvocado] [int] NOT NULL,
	[IdTipoComprobanteInvocado] [varchar](15) NOT NULL,
	[LetraInvocado] [varchar](1) NOT NULL,
	[CentroEmisorInvocado] [int] NOT NULL,
	[NumeroComprobanteInvocado] [bigint] NOT NULL,
 CONSTRAINT [PK_VentasInvocados] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdSucursalInvocado] ASC,
	[IdTipoComprobanteInvocado] ASC,
	[LetraInvocado] ASC,
	[CentroEmisorInvocado] ASC,
	[NumeroComprobanteInvocado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VentasInvocados]  WITH CHECK ADD  CONSTRAINT [FK_VentasInvocados_Ventas_Invocado] FOREIGN KEY([IdTipoComprobanteInvocado], [LetraInvocado], [CentroEmisorInvocado], [NumeroComprobanteInvocado], [IdSucursalInvocado])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasInvocados] CHECK CONSTRAINT [FK_VentasInvocados_Ventas_Invocado]
GO

ALTER TABLE [dbo].[VentasInvocados]  WITH CHECK ADD  CONSTRAINT [FK_VentasInvocados_Ventas_Invocador] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasInvocados] CHECK CONSTRAINT [FK_VentasInvocados_Ventas_Invocador]
GO

PRINT ''
PRINT '1.1. Tabla VentasInvocados: Nuevo indice IX_VentasInvocados_Invocado'
CREATE NONCLUSTERED INDEX IX_VentasInvocados_Invocado ON dbo.VentasInvocados
    (IdSucursalInvocado, IdTipoComprobanteInvocado, LetraInvocado, CentroEmisorInvocado, NumeroComprobanteInvocado)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.VentasInvocados SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT '1.2: Tabla VentasInvocados: Cargar información con la información de invocación actual'
INSERT INTO VentasInvocados
           (IdSucursal,         IdTipoComprobante,         Letra,         CentroEmisor,         NumeroComprobante,
            IdSucursalInvocado, IdTipoComprobanteInvocado, LetraInvocado, CentroEmisorInvocado, NumeroComprobanteInvocado)
SELECT IdSucursal, IdTipoComprobanteFact, LetraFact, CentroEmisorFact, NumeroComprobanteFact,
       IdSucursal, IdTipoComprobante,     Letra,     CentroEmisor,     NumeroComprobante
  FROM Ventas
 WHERE IdTipoComprobanteFact IS NOT NULL
   AND LetraFact IS NOT NULL

PRINT ''
PRINT '1.2: Tabla Ventas: Renombrar IdTipoComprobanteFact, LetraFact, CentroEmisorFact y NumeroComprobanteFact a *._viejo'
EXECUTE sp_rename N'dbo.Ventas.IdTipoComprobanteFact',  N'IdTipoComprobanteFact_Viejo', 'COLUMN' 
EXECUTE sp_rename N'dbo.Ventas.LetraFact',              N'LetraFact_Viejo', 'COLUMN' 
EXECUTE sp_rename N'dbo.Ventas.CentroEmisorFact',       N'CentroEmisorFact_Viejo', 'COLUMN' 
EXECUTE sp_rename N'dbo.Ventas.NumeroComprobanteFact',  N'NumeroComprobanteFact_Viejo', 'COLUMN' 
GO

PRINT ''
PRINT '2. Tabla Intereses: Nuevos Campos'
ALTER TABLE Intereses ADD FechaVigenciaDesde date
ALTER TABLE Intereses ADD FechaVigenciaHasta date
ALTER TABLE Intereses ADD UtilizaVigencia bit
GO

PRINT '2.1. Tabla Intereses: Actualizar registros pre-existentes para UtilizaVigencia'
UPDATE Intereses SET UtilizaVigencia = 'False'
GO
PRINT '2.2. Tabla Intereses: NOT NULL para UtilizaVigencia'
ALTER TABLE Intereses ALTER COLUMN UtilizaVigencia BIT NOT NULL


PRINT ''
PRINT '3. Tabla Buscadores: Nuevo buscador para Empresas'
INSERT INTO Buscadores
        (IdBuscador, Titulo, AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial)
 VALUES (20, 'Empresas', 1000, 'Grilla', '')

PRINT ''
PRINT '3.1. Tabla BuscadoresCampos: Campos para nuevo buscador para Empresas'
INSERT INTO BuscadoresCampos
        (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila)
 VALUES (20, 'IdEmpresa',             1, 'Código',      64,  70, '', NULL, NULL, NULL),
        (20, 'NombreEmpresa',         2, 'Nombre',      16, 100, '', NULL, NULL, NULL),
        (20, 'CuitEmpresa',           3, 'Cuit',        64,  80, '', NULL, NULL, NULL),
        (20, 'NombreCategoriaFiscal', 4, 'Cat. Fiscal', 16, 100, '', NULL, NULL, NULL)

