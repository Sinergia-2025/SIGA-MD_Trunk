
DROP TABLE dbo.SueldosCierrePuntero
GO

DROP TABLE dbo.SueldosCierreLiquidacion
GO

DROP TABLE dbo.SueldosCierreLiqDatos
GO

DROP TABLE dbo.SueldosLiquidacionActual
GO

DROP TABLE dbo.SueldosPersonalHijos
GO

DROP TABLE dbo.SueldosPersonalCodigos
GO

DROP TABLE dbo.SueldosPersonal
GO

DROP TABLE dbo.SueldosLugaresActividad
GO

DROP TABLE dbo.SueldosMotivosBaja
GO

DROP TABLE dbo.SueldosTiposRecibos
GO

DROP TABLE dbo.SueldosConceptos
GO

DROP TABLE dbo.SueldosTiposConceptos
GO

DROP TABLE dbo.SueldosQuePideConcepto
GO

DROP TABLE dbo.SueldosCategorias
GO

DROP TABLE dbo.SueldosEstadoCivil
GO

DROP TABLE dbo.SueldosObraSocial
GO


/****** Object:  Table [dbo].[SueldosTiposRecibos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosTiposRecibos](
	[IdTipoRecibo] [int] NOT NULL,
	[NombreTipoRecibo] [varchar](50) NOT NULL,
	[PeriodoLiquidacion] [int] NOT NULL,
	[NumeroLiquidacion] [int] NOT NULL,
	[ImprimeRecibo] [bit] NOT NULL,
 CONSTRAINT [PK_SueldosTiposRecibos] PRIMARY KEY CLUSTERED 
(
	[IdTipoRecibo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosTiposConceptos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosTiposConceptos](
	[IdTipoConcepto] [int] NOT NULL,
	[NombreTipoConcepto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SueldosRubrosConceptos] PRIMARY KEY CLUSTERED 
(
	[IdTipoConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosQuePideConcepto]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldosQuePideConcepto](
	[IdQuePide] [int] NOT NULL,
	[NombreQuePide] [varchar](25) NOT NULL,
 CONSTRAINT [PK_SueldosQuePideConcepto] PRIMARY KEY CLUSTERED 
(
	[IdQuePide] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SueldosPersonalHijos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosPersonalHijos](
	[IdLegajo] [int] NOT NULL,
	[CuilHijo] [bigint] NOT NULL,
	[NombreHijo] [varchar](50) NOT NULL,
	[FechaNacimientoHijo] [date] NOT NULL,
 CONSTRAINT [PK_SueldosPersonalHijos] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[CuilHijo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosObraSocial]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldosObraSocial](
	[IdObraSocial] [int] NOT NULL,
	[NombreObraSocial] [varchar](25) NOT NULL,
 CONSTRAINT [PK_SueldosObraSocial] PRIMARY KEY CLUSTERED 
(
	[IdObraSocial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SueldosMotivosBaja]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosMotivosBaja](
	[IdMotivoBaja] [int] NOT NULL,
	[NombreMotivoBaja] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SueldosMotivosBaja] PRIMARY KEY CLUSTERED 
(
	[IdMotivoBaja] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosLugaresActividad]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosLugaresActividad](
	[IdLugarActividad] [int] NOT NULL,
	[NombreLugarActividad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SueldosLugaresActividad] PRIMARY KEY CLUSTERED 
(
	[IdLugarActividad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosEstadoCivil]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosEstadoCivil](
	[IdEstadoCivil] [int] NOT NULL,
	[NombreEstadoCivil] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SueldosEstadoCivil] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCivil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosConceptos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosConceptos](
	[IdTipoConcepto] [int] NOT NULL,
	[IdConcepto] [int] NOT NULL,
	[NombreConcepto] [varchar](30) NOT NULL,
	[Valor] [decimal](8, 2) NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Aguinaldo] [char](1) NOT NULL,
	[IdQuepide] [int] NULL,
	[Calculo1] [varchar](114) NULL,
	[Formula] [varchar](200) NULL,
	[LiquidacionAnual] [bit] NULL,
	[LiquidacionMeses] [varchar](12) NULL,
 CONSTRAINT [PK_SueldosConceptos] PRIMARY KEY CLUSTERED 
(
	[IdTipoConcepto] ASC,
	[IdConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCierrePuntero]    Script Date: 09/23/2011 15:55:18 ******/
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

/****** Object:  Table [dbo].[SueldosCierreLiqDatos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosCierreLiqDatos](
	[IdLegajo] [int] NOT NULL,
	[IdTipoRecibo] [int] NOT NULL,
	[NroLiquidacion] [int] NOT NULL,
	[FechaPago] [date] NOT NULL,
	[LugarPago] [varchar](100) NOT NULL,
	[DomicilioEmpresa] [varchar](150) NOT NULL,
	[IdBancoCtaBancaria] [int] NULL,
	[IdCuentasBancariasClaseCtaBancaria] [int] NULL,
	[NumeroCuentaBancaria] [varchar](30) NULL,
	[CBU] [decimal](22, 0) NULL,
 CONSTRAINT [PK_SueldosCierreLiqDatos] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoRecibo] ASC,
	[NroLiquidacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCategorias]    Script Date: 09/23/2011 15:55:18 ******/
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

/****** Object:  Table [dbo].[SueldosPersonal]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosPersonal](
	[IdLegajo] [int] NOT NULL,
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
	[IdObraSocial] [int] NULL,
	[CodObraSocial] [int] NULL,
	[FechaNacimiento] [date] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[FechaBaja] [date] NULL,
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
	[IdMotivoBaja] [int] NULL,
	[IdLugarActividad] [int] NULL,
	[DatosFamiliares] [varchar](300) NULL,
	[IdBancoCtaBancaria] [int] NULL,
	[IdCuentasBancariasClaseCtaBancaria] [int] NULL,
	[NumeroCuentaBancaria] [varchar](30) NULL,
	[CBU] [decimal](22, 0) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosPersonalCodigos]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosPersonalCodigos](
	[IdLegajo] [int] NOT NULL,
	[IdTipoRecibo] [int] NOT NULL,
	[IdTipoConcepto] [int] NOT NULL,
	[IdConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Aguinaldo] [varchar](1) NULL,
	[Periodos] [int] NULL,
 CONSTRAINT [PK_SueldosPersonalCodigos] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoConcepto] ASC,
	[IdConcepto] ASC,
	[IdTipoRecibo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosLiquidacionActual]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosLiquidacionActual](
	[IdLegajo] [int] NOT NULL,
	[IdTipoRecibo] [int] NOT NULL,
	[IdTipoConcepto] [int] NOT NULL,
	[IdConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Importe] [decimal](10, 2) NULL,
	[NroLiquidacion] [int] NULL,
	[Aguinaldo] [varchar](1) NULL,
 CONSTRAINT [PK_SueldosLiquidacionActual] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoRecibo] ASC,
	[IdTipoConcepto] ASC,
	[IdConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SueldosCierreLiquidacion]    Script Date: 09/23/2011 15:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SueldosCierreLiquidacion](
	[IdLegajo] [int] NOT NULL,
	[IdTipoRecibo] [int] NOT NULL,
	[NroLiquidacion] [int] NOT NULL,
	[IdTipoConcepto] [int] NOT NULL,
	[IdConcepto] [int] NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Importe] [decimal](10, 2) NULL,
	[Aguinaldo] [varchar](1) NULL,
 CONSTRAINT [PK_SueldosCierreLiquidacion_1] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoConcepto] ASC,
	[IdConcepto] ASC,
	[IdTipoRecibo] ASC,
	[NroLiquidacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_SueldosCierreLiquidacion_SueldosConceptos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosCierreLiquidacion]  WITH CHECK ADD  CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosConceptos] FOREIGN KEY([IdTipoConcepto], [IdConcepto])
REFERENCES [dbo].[SueldosConceptos] ([IdTipoConcepto], [IdConcepto])
GO
ALTER TABLE [dbo].[SueldosCierreLiquidacion] CHECK CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosConceptos]
GO
/****** Object:  ForeignKey [FK_SueldosCierreLiquidacion_SueldosPersonal]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosCierreLiquidacion]  WITH CHECK ADD  CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosPersonal] FOREIGN KEY([IdLegajo])
REFERENCES [dbo].[SueldosPersonal] ([IdLegajo])
GO
ALTER TABLE [dbo].[SueldosCierreLiquidacion] CHECK CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosPersonal]
GO
/****** Object:  ForeignKey [FK_SueldosCierreLiquidacion_SueldosTiposRecibos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosCierreLiquidacion]  WITH CHECK ADD  CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosTiposRecibos] FOREIGN KEY([IdTipoRecibo])
REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
GO
ALTER TABLE [dbo].[SueldosCierreLiquidacion] CHECK CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosTiposRecibos]
GO
/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosConceptos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosConceptos] FOREIGN KEY([IdTipoConcepto], [IdConcepto])
REFERENCES [dbo].[SueldosConceptos] ([IdTipoConcepto], [IdConcepto])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosConceptos]
GO
/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosPersonal]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosPersonal] FOREIGN KEY([IdLegajo])
REFERENCES [dbo].[SueldosPersonal] ([IdLegajo])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosPersonal]
GO
/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosRubrosConceptos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosRubrosConceptos] FOREIGN KEY([IdTipoConcepto])
REFERENCES [dbo].[SueldosTiposConceptos] ([IdTipoConcepto])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosRubrosConceptos]
GO
/****** Object:  ForeignKey [FK_SueldosLiquidacionActual_SueldosTiposRecibos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosLiquidacionActual]  WITH CHECK ADD  CONSTRAINT [FK_SueldosLiquidacionActual_SueldosTiposRecibos] FOREIGN KEY([IdTipoRecibo])
REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
GO
ALTER TABLE [dbo].[SueldosLiquidacionActual] CHECK CONSTRAINT [FK_SueldosLiquidacionActual_SueldosTiposRecibos]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_Bancos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_Bancos] FOREIGN KEY([IdBancoCtaBancaria])
REFERENCES [dbo].[Bancos] ([IdBanco])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_Bancos]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_CuentasBancariasClase]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_CuentasBancariasClase] FOREIGN KEY([IdCuentasBancariasClaseCtaBancaria])
REFERENCES [dbo].[CuentasBancariasClase] ([IdCuentaBancariaClase])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_CuentasBancariasClase]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_Localidades]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_Localidades]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosCategorias]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosCategorias] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[SueldosCategorias] ([idCategoria])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosCategorias]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosEstadoCivil]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosEstadoCivil] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[SueldosEstadoCivil] ([IdEstadoCivil])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosEstadoCivil]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosLugaresActividad]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosLugaresActividad] FOREIGN KEY([IdLugarActividad])
REFERENCES [dbo].[SueldosLugaresActividad] ([IdLugarActividad])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosLugaresActividad]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosMotivosBaja]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosMotivosBaja] FOREIGN KEY([IdMotivoBaja])
REFERENCES [dbo].[SueldosMotivosBaja] ([IdMotivoBaja])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosMotivosBaja]
GO
/****** Object:  ForeignKey [FK_SueldosPersonal_SueldosObraSocial]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonal]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_SueldosObraSocial] FOREIGN KEY([IdObraSocial])
REFERENCES [dbo].[SueldosObraSocial] ([IdObraSocial])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_SueldosObraSocial]
GO
/****** Object:  ForeignKey [FK_SueldosPersonalCodigos_SueldosPersonal]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonalCodigos]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonalCodigos_SueldosPersonal] FOREIGN KEY([IdLegajo])
REFERENCES [dbo].[SueldosPersonal] ([IdLegajo])
GO
ALTER TABLE [dbo].[SueldosPersonalCodigos] CHECK CONSTRAINT [FK_SueldosPersonalCodigos_SueldosPersonal]
GO
/****** Object:  ForeignKey [FK_SueldosPersonalCodigos_SueldosRubrosConceptos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonalCodigos]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonalCodigos_SueldosRubrosConceptos] FOREIGN KEY([IdTipoConcepto])
REFERENCES [dbo].[SueldosTiposConceptos] ([IdTipoConcepto])
GO
ALTER TABLE [dbo].[SueldosPersonalCodigos] CHECK CONSTRAINT [FK_SueldosPersonalCodigos_SueldosRubrosConceptos]
GO
/****** Object:  ForeignKey [FK_SueldosPersonalCodigos_SueldosTiposRecibos]    Script Date: 09/23/2011 15:55:18 ******/
ALTER TABLE [dbo].[SueldosPersonalCodigos]  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonalCodigos_SueldosTiposRecibos] FOREIGN KEY([IdTipoRecibo])
REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
GO
ALTER TABLE [dbo].[SueldosPersonalCodigos] CHECK CONSTRAINT [FK_SueldosPersonalCodigos_SueldosTiposRecibos]
GO
