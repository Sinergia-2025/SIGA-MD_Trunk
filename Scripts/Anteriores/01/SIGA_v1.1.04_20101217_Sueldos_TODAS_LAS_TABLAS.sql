

/****** Object:  Table [dbo].[SueldosTiposConceptos]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosTiposConceptos](
	[idTipoConcepto] [int] NOT NULL,
	[NombreTipoConcepto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SueldosRubrosConceptos] PRIMARY KEY CLUSTERED 
(
	[idTipoConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosQuePideConcepto]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldosQuePideConcepto](
	[idQuePide] [int] NOT NULL,
	[NombreQuePide] [nchar](25) NOT NULL,
 CONSTRAINT [PK_SueldosQuePideConcepto] PRIMARY KEY CLUSTERED 
(
	[idQuePide] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SueldosObraSocial]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldosObraSocial](
	[idObraSocial] [int] NOT NULL,
	[NombreObraSocial] [nchar](25) NOT NULL,
 CONSTRAINT [PK_SueldosObraSocial] PRIMARY KEY CLUSTERED 
(
	[idObraSocial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SueldosEstadoCivil]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosEstadoCivil](
	[idEstadoCivil] [int] NOT NULL,
	[NombreEstadoCivil] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SueldosEstadoCivil] PRIMARY KEY CLUSTERED 
(
	[idEstadoCivil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosConceptos]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosConceptos](
	[idTipoConcepto] [int] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[NombreConcepto] [varchar](30) NOT NULL,
	[Valor] [decimal](8, 2) NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Aguinaldo] [char](1) NOT NULL,
	[idQuepide] [int] NULL,
	[Calculo1] [varchar](114) NULL,
	[Formula] [varchar](200) NULL,
	[LiquidacionAnual] [int] NULL,
	[LiquidacionMeses] [varchar](12) NULL,
 CONSTRAINT [PK_SueldosConceptos] PRIMARY KEY CLUSTERED 
(
	[idTipoConcepto] ASC,
	[idConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCierrePuntero]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosCierrePuntero](
	[NroPerson] [int] NOT NULL,
	[Caja] [varchar](15) NULL,
	[Inscripcion] [varchar](12) NULL,
	[NroLiqui] [int] NULL,
	[LiqQuincela] [int] NULL,
	[LiqMes] [int] NULL,
	[LiqAno] [int] NULL,
	[FechaPago] [date] NULL,
	[FechaDeposito] [date] NULL,
	[DepositoLapso] [varchar](5) NULL,
	[DepositoBano] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCierreLiquidacion]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosCierreLiquidacion](
	[idLegajo] [int] NOT NULL,
	[idTipoConcepto] [int] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Importe] [decimal](10, 2) NULL,
	[NroLiquidacion] [int] NOT NULL,
	[Aguinaldo] [varchar](1) NULL,
 CONSTRAINT [PK_SueldosCierreLiquidacion] PRIMARY KEY CLUSTERED 
(
	[idLegajo] ASC,
	[idTipoConcepto] ASC,
	[idConcepto] ASC,
	[NroLiquidacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCategorias]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosCategorias](
	[idCategoria] [int] NOT NULL,
	[NombreCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SueldosCategorias] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosPersonal]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosPersonal](
	[idLegajo] [int] NOT NULL,
	[NombrePersonal] [varchar](50) NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[TipoDocPersonal] [varchar](5) NOT NULL,
	[NroDocPersonal] [bigint] NOT NULL,
	[idNacionalidad] [int] NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[IdEstadoCivil] [int] NOT NULL,
	[Cuil] [bigint] NULL,
	[LegajoMinTrabajo] [bigint] NULL,
	[idObraSocial] [int] NULL,
	[CodObraSocial] [int] NULL,
	[FechaNacimiento] [date] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[FechaEgreso] [date] NULL,
	[idCategoria] [int] NOT NULL,
	[CentroCosto] [int] NOT NULL,
	[SueldoBasico] [decimal](8, 2) NOT NULL,
	[MejorSueldo] [decimal](8, 2) NOT NULL,
	[AcumuladoAnual] [decimal](8, 2) NOT NULL,
	[AcumuladoSalarioFamiliar] [decimal](8, 2) NOT NULL,
	[SueldoActual] [decimal](8, 2) NOT NULL,
	[SalarioFamiliarActual] [decimal](8, 2) NOT NULL,
	[AFJP] [varchar](15) NULL,
	[AnteriorAcumuladoAnual] [decimal](8, 2) NOT NULL,
	[AnteriorMejorSueldo] [decimal](8, 2) NOT NULL,
	[AnteriorSalarioFamiliar] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[idLegajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosPersonalCodigos]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosPersonalCodigos](
	[idLegajo] [int] NOT NULL,
	[idTipoConcepto] [int] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Aguinaldo] [varchar](1) NULL,
	[Periodos] [int] NULL,
 CONSTRAINT [PK_SueldosPersonalCodigos] PRIMARY KEY CLUSTERED 
(
	[idLegajo] ASC,
	[idTipoConcepto] ASC,
	[idConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosLiquidacionActual]    Script Date: 10/31/2010 10:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosLiquidacionActual](
	[idLegajo] [int] NOT NULL,
	[idTipoConcepto] [int] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Importe] [decimal](10, 2) NULL,
	[NroLiquidacion] [int] NULL,
	[Aguinaldo] [varchar](1) NULL,
 CONSTRAINT [PK_SueldosLiquidacionActual] PRIMARY KEY CLUSTERED 
(
	[idLegajo] ASC,
	[idTipoConcepto] ASC,
	[idConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosConceptos]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosConceptos] FOREIGN KEY([idTipoConcepto], [idConcepto])
REFERENCES [dbo].[SueldosConceptos] ([idTipoConcepto], [idConcepto])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosConceptos]
GO

/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosPersonal]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosPersonal] FOREIGN KEY([idLegajo])
REFERENCES [dbo].[SueldosPersonal] ([idLegajo])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosPersonal]
GO

/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosRubrosConceptos]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosRubrosConceptos] FOREIGN KEY([idTipoConcepto])
REFERENCES [dbo].[SueldosTiposConceptos] ([idTipoConcepto])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosRubrosConceptos]
GO

/****** Object:  ForeignKey [FK_SueldosPersonal_Localidades]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_Localidades]
GO

/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosCategorias]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosCategorias] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[SueldosCategorias] ([idCategoria])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosCategorias]
GO

/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosEstadoCivil]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosEstadoCivil] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[SueldosEstadoCivil] ([idEstadoCivil])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosEstadoCivil]
GO

/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosObraSocial]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosObraSocial] FOREIGN KEY([idObraSocial])
REFERENCES [dbo].[SueldosObraSocial] ([idObraSocial])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosObraSocial]
GO

/****** Object:  ForeignKey [FK_SueldosPersonalCodigos_SueldosPersonal]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonalCodigos]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonalCodigos_SueldosPersonal] FOREIGN KEY([idLegajo])
REFERENCES [dbo].[SueldosPersonal] ([idLegajo])
GO
ALTER TABLE [dbo].[SueldosPersonalCodigos] CHECK CONSTRAINT [FK_SueldosPersonalCodigos_SueldosPersonal]
GO

/****** Object:  ForeignKey [FK_SueldosPersonalCodigos_SueldosRubrosConceptos]    Script Date: 10/31/2010 10:06:29 ******/
ALTER TABLE [dbo].[SueldosPersonalCodigos]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonalCodigos_SueldosRubrosConceptos] FOREIGN KEY([idTipoConcepto])
REFERENCES [dbo].[SueldosTiposConceptos] ([idTipoConcepto])
GO
ALTER TABLE [dbo].[SueldosPersonalCodigos] CHECK CONSTRAINT [FK_SueldosPersonalCodigos_SueldosRubrosConceptos]
GO
