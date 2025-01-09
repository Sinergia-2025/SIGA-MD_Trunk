
/* ------ TABLA ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Retenciones](
	[idSucursal] [int] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[EmisorRetencion] [int] NOT NULL,
	[NumeroRetencion] [bigint] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[LetraComprobante] [varchar](1) NULL,
	[EmisorComprobante] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
	[FechaComprobante] [datetime] NULL,
	[ImporteComprobante] [decimal](10, 2) NULL,
	[BaseImponible] [decimal](10, 2) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[ImporteTotal] [decimal](10, 2) NOT NULL,
	[NroPlanillaIngreso] [int] NOT NULL,
	[NroMovimientoIngreso] [int] NOT NULL,
	[TipoDocCliente] [varchar](5) NOT NULL,
	[NroDocCliente] [varchar](12) NOT NULL,
	[IdEstado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Retenciones] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [FK_Retenciones_CajasDetalle] FOREIGN KEY([idSucursal], [NroPlanillaIngreso], [NroMovimientoIngreso])
REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [NumeroPlanilla], [NumeroMovimiento])
GO

ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [FK_Retenciones_CajasDetalle]
GO

ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [FK_Retenciones_Clientes] FOREIGN KEY([TipoDocCliente], [NroDocCliente])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [FK_Retenciones_Clientes]
GO

ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [FK_Retenciones_Sucursales] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [FK_Retenciones_Sucursales]
GO

ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [FK_Retenciones_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [FK_Retenciones_TiposImpuestos]
GO

ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [FK_Retenciones_Ventas] FOREIGN KEY([IdTipoComprobante], [LetraComprobante], [EmisorComprobante], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [idSucursal])
GO

ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [FK_Retenciones_Ventas]
GO


/* ------ REGISTROS DE LAS TABLAS RELACIONADAS ------ */


-- Tipos de Impuestos.

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('RGANA', 'Retencion de Ganancias')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('RIIBB', 'Retencion de Ingresos Brutos')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('RIVA', 'Retencion de IVA')
GO


-- Alicuotas.

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RGANA', 2, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RIIBB', 3.5, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('RIVA', 21, 'True')
GO
