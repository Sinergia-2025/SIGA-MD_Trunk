
/****** Object:  Table [dbo].[FichasFormasPago]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FichasFormasPago](
	[IdFormasPago] [int] NOT NULL,
	[DescripcionFormasPago] [varchar](50) NULL,
	[Dias] [int] NULL,
 CONSTRAINT [PK_FormaPago] PRIMARY KEY CLUSTERED 
(
	[IdFormasPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

---------- REGISTROS -----------------

INSERT INTO FichasFormasPago
   (IdFormasPago, DescripcionFormasPago, Dias)
  VALUES
   (1, 'Mensual', 30),
   (2, 'Quincenal', 15),
   (3, 'Semanal', 7),
   (4, 'Diario', 1),
   (5, 'Contado', 0)
GO

/****** Object:  Table [dbo].[FichasPagosAjustes]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FichasPagosAjustes](
	[NroOperacion] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Importe] [decimal](10, 2) NULL,
	[Concepto] [varchar](50) NULL,
	[IdCaja] [int] NOT NULL,
	[NumeroPlanilla] [int] NOT NULL,
	[NumeroMovimiento] [int] NOT NULL,
 CONSTRAINT [PK_FichasPagosAjustes] PRIMARY KEY CLUSTERED 
(
	[NroOperacion] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdSucursal] ASC,
	[FechaPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Fichas]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fichas](
	[NroOperacion] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[MontoTotalBruto] [decimal](10, 2) NULL,
	[Anticipo] [decimal](10, 2) NULL,
	[Cuotas] [int] NULL,
	[IdFormasPago] [int] NULL,
	[Interes] [decimal](10, 2) NULL,
	[TotalNeto] [decimal](10, 2) NULL,
	[Saldo] [decimal](10, 2) NULL,
	[TipoDocCobrador] [varchar](5) NULL,
	[NroDocCobrador] [varchar](12) NULL,
	[IdEstado] [varchar](10) NULL,
	[NroFactura] [int] NULL,
	[Comentario] [varchar](500) NULL,
	[TipoDocVendedor] [varchar](5) NULL,
	[NroDocVendedor] [varchar](12) NULL,
	[Usuario] [varchar](50) NULL,
	[Revisar] [char](1) NULL,
 CONSTRAINT [PK_Fichas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroOperacion] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FichasPagos]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FichasPagos](
	[NroOperacion] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[NroCuota] [int] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Importe] [decimal](10, 2) NULL,
	[Saldo] [decimal](10, 2) NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_FichasPagos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroOperacion] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[NroCuota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FichasProductos]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FichasProductos](
	[NroOperacion] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](10, 2) NULL,
	[FechaEntrega] [datetime] NULL,
	[Garantia] [int] NULL,
	[IdSucursal] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NULL,
	[NroDocProveedor] [bigint] NULL,
 CONSTRAINT [PK_FichasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroOperacion] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FichasPagosDetalle]    Script Date: 06/02/2012 23:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FichasPagosDetalle](
	[NroOperacion] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[NroCuota] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Importe] [decimal](10, 2) NOT NULL,
	[TipoDocCobrador] [varchar](5) NULL,
	[NroDocCobrador] [varchar](12) NULL,
	[IdSucursal] [int] NOT NULL,
	[IdCaja] [int] NULL,
	[NumeroPlanilla] [int] NOT NULL,
	[NumeroMovimiento] [int] NOT NULL,
 CONSTRAINT [PK_FichasPagosDetalle_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroOperacion] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[NroCuota] ASC,
	[FechaPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Default [DF_FichasPagosAjustes_IdCaja]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasPagosAjustes] ADD  CONSTRAINT [DF_FichasPagosAjustes_IdCaja]  DEFAULT ((1)) FOR [IdCaja]
GO
/****** Object:  Default [DF_FichasPagosDetalle_IdCaja]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasPagosDetalle] ADD  CONSTRAINT [DF_FichasPagosDetalle_IdCaja]  DEFAULT ((1)) FOR [IdCaja]
GO
/****** Object:  ForeignKey [FK_Fichas_Clientes]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[Fichas]  WITH CHECK ADD  CONSTRAINT [FK_Fichas_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO
ALTER TABLE [dbo].[Fichas] CHECK CONSTRAINT [FK_Fichas_Clientes]
GO
/****** Object:  ForeignKey [FK_Fichas_Estados]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[Fichas]  WITH CHECK ADD  CONSTRAINT [FK_Fichas_Estados] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([IdEstado])
GO
ALTER TABLE [dbo].[Fichas] CHECK CONSTRAINT [FK_Fichas_Estados]
GO
/****** Object:  ForeignKey [FK_Fichas_FormasPago]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[Fichas]  WITH CHECK ADD  CONSTRAINT [FK_Fichas_FormasPago] FOREIGN KEY([IdFormasPago])
REFERENCES [dbo].[FichasFormasPago] ([IdFormasPago])
GO
ALTER TABLE [dbo].[Fichas] CHECK CONSTRAINT [FK_Fichas_FormasPago]
GO
/****** Object:  ForeignKey [FK_FichasPagos_Fichas]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasPagos]  WITH CHECK ADD  CONSTRAINT [FK_FichasPagos_Fichas] FOREIGN KEY([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Fichas] ([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
GO
ALTER TABLE [dbo].[FichasPagos] CHECK CONSTRAINT [FK_FichasPagos_Fichas]
GO
/****** Object:  ForeignKey [FK_FichasPagosDetalle_FichasPagos]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasPagosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FichasPagosDetalle_FichasPagos] FOREIGN KEY([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento], [NroCuota])
REFERENCES [dbo].[FichasPagos] ([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento], [NroCuota])
GO
ALTER TABLE [dbo].[FichasPagosDetalle] CHECK CONSTRAINT [FK_FichasPagosDetalle_FichasPagos]
GO
/****** Object:  ForeignKey [FK_FichasProductos_Fichas]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasProductos]  WITH CHECK ADD  CONSTRAINT [FK_FichasProductos_Fichas] FOREIGN KEY([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Fichas] ([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
GO
ALTER TABLE [dbo].[FichasProductos] CHECK CONSTRAINT [FK_FichasProductos_Fichas]
GO
/****** Object:  ForeignKey [FK_FichasProductos_FichasProductos]    Script Date: 06/02/2012 23:50:38 ******/
ALTER TABLE [dbo].[FichasProductos]  WITH CHECK ADD  CONSTRAINT [FK_FichasProductos_FichasProductos] FOREIGN KEY([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento], [IdProducto])
REFERENCES [dbo].[FichasProductos] ([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento], [IdProducto])
GO
ALTER TABLE [dbo].[FichasProductos] CHECK CONSTRAINT [FK_FichasProductos_FichasProductos]
GO
