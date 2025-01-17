DROP TABLE dbo.ContabilidadAsientosCuentas
GO

DROP TABLE dbo.ContabilidadAsientos
GO

DROP TABLE dbo.ContabilidadPlanesCuentas
GO

DROP TABLE dbo.ContabilidadCuentas
GO

DROP TABLE dbo.ContabilidadCentrosCostos
GO

DROP TABLE dbo.ContabilidadTiposCuentas
GO

DROP TABLE dbo.ContabilidadPlanes
GO

DROP TABLE dbo.ContabilidadPeriodosEjercicios
GO

DROP TABLE dbo.ContabilidadEjercicios
GO

/****** Object:  Table [dbo].[ContabilidadTiposCuentas]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadTiposCuentas](
	[IdTipoCuenta] [int] NOT NULL,
	[NombreTipoCuenta] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ContabilidadTiposCuentas] PRIMARY KEY CLUSTERED 
(
	[IdTipoCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ContabilidadTiposCuentas] ([IdTipoCuenta], [NombreTipoCuenta]) VALUES (10000000, N'Activo')
INSERT [dbo].[ContabilidadTiposCuentas] ([IdTipoCuenta], [NombreTipoCuenta]) VALUES (20000000, N'Pasivo')
INSERT [dbo].[ContabilidadTiposCuentas] ([IdTipoCuenta], [NombreTipoCuenta]) VALUES (30000000, N'Patrimonio Neto')
INSERT [dbo].[ContabilidadTiposCuentas] ([IdTipoCuenta], [NombreTipoCuenta]) VALUES (40000000, N'Resultados')
/****** Object:  Table [dbo].[ContabilidadPlanes]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadPlanes](
	[IdPlanCuenta] [int] NOT NULL,
	[NombrePlanCuenta] [varchar](25) NOT NULL,
 CONSTRAINT [PK_ContabilidadPlanes] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ContabilidadPlanes] ([IdPlanCuenta], [NombrePlanCuenta]) VALUES (1, N'Plan Principal')
INSERT [dbo].[ContabilidadPlanes] ([IdPlanCuenta], [NombrePlanCuenta]) VALUES (2, N'Plan Secundario')
/****** Object:  Table [dbo].[ContabilidadCentrosCostos]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadCentrosCostos](
	[IdCentroCosto] [int] NOT NULL,
	[NombreCentroCosto] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ContabilidadCentrosCostos] PRIMARY KEY CLUSTERED 
(
	[IdCentroCosto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ContabilidadCentrosCostos] ([IdCentroCosto], [NombreCentroCosto]) VALUES (1, N'Principal')
INSERT [dbo].[ContabilidadCentrosCostos] ([IdCentroCosto], [NombreCentroCosto]) VALUES (2, N'Secundario')
/****** Object:  Table [dbo].[ContabilidadEjercicios]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContabilidadEjercicios](
	[IdEjercicio] [int] NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[Cerrado] [bit] NOT NULL,
 CONSTRAINT [PK_ContabilidadEjercicios] PRIMARY KEY CLUSTERED 
(
	[IdEjercicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ContabilidadEjercicios] ([IdEjercicio], [FechaDesde], [FechaHasta], [Cerrado]) VALUES (1, CAST(0x26350B00 AS Date), CAST(0x93360B00 AS Date), 0)
/****** Object:  Table [dbo].[ContabilidadCuentas]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadCuentas](
	[IdCuenta] [int] NOT NULL,
	[NombreCuenta] [varchar](50) NOT NULL,
	[Nivel] [int] NOT NULL,
	[IdCentroCosto] [int] NOT NULL,
	[EsImputable] [bit] NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_ContabilidadCuentas] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10100000, N'Caja y Bancos', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10101000, N'Caja', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10101001, N'Caja en pesos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10101002, N'Caja en dólares', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102000, N'Banco', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102001, N'Banco Francés c/c', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102002, N'Banco Galicia c/c', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102003, N'Banco HSBC c/c', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102004, N'Banco Santander RIO', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10102005, N'Banco MACRO', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10103000, N'Recaudaciones a depositar', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10200000, N'Inversiones Temporarias', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10201000, N'Plazo Fijo', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10202000, N'Fondo Común de Inversión', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10202001, N'FCI Bco Francés', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10300000, N'Créditos por Ventas Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10301000, N'Deudores Comunes', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10301001, N'Deudores de materiales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10301002, N'Deudores de repuestos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10302000, N'Deudores del Exterior', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10303000, N'Deudores Morosos', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10304000, N'Deudores en Gestión Judicial', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10305000, N'Previsión para Deudores Incobrables', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10400000, N'Otros Créditos Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401000, N'Créditos Impositivos', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401001, N'Saldo a favor impuesto a las ganancias', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401002, N'Saldo a favor ingresos brutos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401003, N'Impuesto a los débitos y créditos bancarios', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401004, N'Saldo a Favor IVA', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401005, N'IVA CF 10.5%', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401006, N'IVA DF', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401007, N'IVA CF 21%', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10401008, N'IVA CF 27%', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10402000, N'Diversos', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10500000, N'Bienes de Cambio Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10501000, N'Insumos de producción', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10501001, N'Materiales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10501002, N'Repuestos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10600000, N'Otros Activos Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10700000, N'Créditos por Ventas No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10800000, N'Otros Créditos No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (10900000, N'Bienes de Cambio No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11000000, N'Bienes de Uso', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11100000, N'Participaciones Permanentes en Sociedades', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11200000, N'Otras Inversiones No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11300000, N'Activos Intangibles', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11400000, N'Otros Activos No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (11500000, N'Llave de Negocio ', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20100000, N'Deudas Comerciales Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20101000, N'Proveedores', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20101001, N'Materiales a pagar', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20101002, N'Repuestos a pagar', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20102000, N'Provisión para Gastos', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20200000, N'Préstamos Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20201000, N'Préstamos Bancarios', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20202000, N'Adelantos en Cuenta Corriente', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20300000, N'Remuneraciones y Cargas Sociales Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20400000, N'Cargas Fiscales Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20401000, N'Impuesto a las ganancias a pagar', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20401001, N'Impuesto a las ganancias a pagar', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20402000, N'Ingresos Brutos a Pagar', 3, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20500000, N'Anticipos de Clientes Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20600000, N'Dividendos a Pagar Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20700000, N'Otras Deudas Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20800000, N'Previsiones Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (20900000, N'Deudas Comerciales No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21000000, N'Préstamos No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21100000, N'Remuneraciones y Cargas Sociales No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21200000, N'Cargas Fiscales No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21300000, N'Anticipos de Clientes No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21400000, N'Dividendos a Pagar No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21500000, N'Otras Deudas No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (21600000, N'Previsiones No Corrientes', 2, 1, 0, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30100000, N'Aportes de los Propietarios', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30101000, N'Capital Suscripto', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30102000, N'Ajustes de Capital', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30103000, N'Aportes Irrevocables', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30104000, N'Prima de Emisión', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30200000, N'Resultados Acumulados', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30201000, N'Reserva Legal', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30202000, N'Reserva Facultativa', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30203000, N'Otras Reservas', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30204000, N'Resultados no Asignados', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30204001, N'Resultados No Asignados (Automática)', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (30204002, N'Resultados No Asignados', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40100000, N'Resultados de las Operaciones que Continúan', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40101000, N'Ventas netas de bienes y servicios', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40101001, N'Ventas locales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40101002, N'Ventas al mercado externo', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40102000, N'Costo de los bienes vendidos y servicios prestados', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40102001, N'Materiales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40102002, N'Repuestos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40103000, N'Resultados por valuación de bs de cambio al VNR', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104000, N'Gastos de Comercialización', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104001, N'Sueldos y jornales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104002, N'Cargas sociales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104003, N'Honorarios por servicios', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104004, N'Fletes', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104005, N'Depreciaciones de bienes de uso', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104006, N'Gastos de mantenimiento', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40104007, N'Seguros', 4, 1, 1, 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40105000, N'Gastos de Administración', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40105001, N'Sueldos y jornales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40105002, N'Cargas sociales', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40105003, N'Honorarios por servicios', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40106000, N'Otros Gastos', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40107000, N'Resultados de inversiones en entes relacionados', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40108000, N'Depreciación de la llave de negocio', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40109000, N'Resultados financieros y por tenencia', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40109001, N'Intereses perdidos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40109002, N'Intereses ganados', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40109003, N'Diferencia de cambio', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40109004, N'Rdo FCI Bco Francés', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40110000, N'Otros ingresos y egresos', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40110001, N'Resultado por venta de bienes de uso', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40110002, N'Previsión para Juicios', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40110003, N'Diversos', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40111000, N'Impuesto a las ganancias', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40111001, N'Impuesto corriente', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40111002, N'Impuesto diferido', 4, 1, 1, 1)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40200000, N'Resultados de las Operaciones en Discontinuación', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40201000, N'Resultados de las operaciones', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40202000, N'Rdos.disposición de activos y liquid. de deudas', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40300000, N'Participación de Terceros en Soc. Controladas', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40301000, N'Participación de terceros en soc. controladas', 3, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40400000, N'Resultados de las Operaciones Extraordinarias', 2, 1, 0, 0)
INSERT [dbo].[ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa]) VALUES (40401000, N'Resultados de las operaciones extraordinarias', 3, 1, 0, 0)
/****** Object:  Table [dbo].[ContabilidadPeriodosEjercicios]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadPeriodosEjercicios](
	[IdEjercicio] [int] NOT NULL,
	[IdPeriodo] [varchar](7) NOT NULL,
	[Cerrado] [bit] NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_ContabilidadPeriodosEjercicios] PRIMARY KEY CLUSTERED 
(
	[IdEjercicio] ASC,
	[IdPeriodo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'01/2012', 0, 1)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'02/2012', 0, 2)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'03/2012', 0, 3)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'04/2012', 0, 4)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'05/2012', 0, 5)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'06/2012', 0, 6)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'07/2012', 0, 7)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'08/2012', 0, 8)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'09/2012', 0, 9)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'10/2012', 0, 10)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'11/2012', 0, 11)
INSERT [dbo].[ContabilidadPeriodosEjercicios] ([IdEjercicio], [IdPeriodo], [Cerrado], [Orden]) VALUES (1, N'12/2012', 0, 12)
/****** Object:  Table [dbo].[ContabilidadPlanesCuentas]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContabilidadPlanesCuentas](
	[IdPlanCuenta] [int] NOT NULL,
	[IdCuenta] [int] NOT NULL,
 CONSTRAINT [PK_ContabilidadPlanesCuentas] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10102005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10202001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10301000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10301001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10301002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10302000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10303000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10304000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10305000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401006)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401007)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10401008)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10402000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10501000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10501001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10501002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10700000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10800000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 10900000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11000000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 11500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20401000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20402000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20700000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20800000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 20900000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21000000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 21600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30104000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30203000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30204000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30204001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 30204002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40102001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40102002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104006)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40104007)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40105000)
GO
print 'Processed 100 total records'
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40105001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40105002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40105003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40106000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40107000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40108000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40109000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40109001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40109002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40109003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40109004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40110000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40110001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40110002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40110003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40111000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40111001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40111002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40301000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (1, 40401000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10102005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10202001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10301000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10301001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10301002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10302000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10303000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10304000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10305000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401006)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401007)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10401008)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10402000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10501000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10501001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10501002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10700000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10800000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 10900000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11000000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 11500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20401000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20401001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20402000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20700000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20800000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 20900000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21000000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21500000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 21600000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30102000)
GO
print 'Processed 200 total records'
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30104000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30203000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30204000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30204001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 30204002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40100000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40101000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40101001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40101002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40102000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40102001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40102002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40103000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104005)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104006)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40104007)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40105000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40105001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40105002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40105003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40106000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40107000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40108000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40109000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40109001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40109002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40109003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40109004)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40110000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40110001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40110002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40110003)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40111000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40111001)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40111002)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40200000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40201000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40202000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40300000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40301000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40400000)
INSERT [dbo].[ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta]) VALUES (2, 40401000)
/****** Object:  Table [dbo].[ContabilidadAsientos]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadAsientos](
	[IdPlanCuenta] [int] NOT NULL,
	[IdAsiento] [int] NOT NULL,
	[NombreAsiento] [varchar](50) NOT NULL,
	[FechaAsiento] [date] NOT NULL,
	[IdTipoDoc] [int] NOT NULL,
	[IdEjercicio] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientos] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdAsiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContabilidadAsientosCuentas]    Script Date: 07/02/2012 18:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContabilidadAsientosCuentas](
	[IdPlanCuenta] [int] NOT NULL,
	[IdAsiento] [int] NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[IdRenglon] [int] NOT NULL,
	[Debe] [decimal](12, 2) NOT NULL,
	[Haber] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientosCuentas] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdAsiento] ASC,
	[IdCuenta] ASC,
	[IdRenglon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ContabilidadEjercicios_cerrado]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadEjercicios] ADD  CONSTRAINT [DF_ContabilidadEjercicios_cerrado]  DEFAULT ((0)) FOR [Cerrado]
GO
/****** Object:  ForeignKey [FK_ContabilidadAsientos_ContabilidadEjercicios]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_ContabilidadEjercicios] FOREIGN KEY([IdEjercicio])
REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio])
GO
ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_ContabilidadEjercicios]
GO
/****** Object:  ForeignKey [FK_ContabilidadAsientos_ContabilidadPlanes]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_ContabilidadPlanes] FOREIGN KEY([IdPlanCuenta])
REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta])
GO
ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_ContabilidadPlanes]
GO
/****** Object:  ForeignKey [FK_ContabilidadAsientos_Sucursales]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_Sucursales]
GO
/****** Object:  ForeignKey [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadAsientosCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos] FOREIGN KEY([IdPlanCuenta], [IdAsiento])
REFERENCES [dbo].[ContabilidadAsientos] ([IdPlanCuenta], [IdAsiento])
GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]
GO
/****** Object:  ForeignKey [FK_ContabilidadAsientosCuentas_ContabilidadCuentas]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadAsientosCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadCuentas] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadCuentas]
GO
/****** Object:  ForeignKey [FK_ContabilidadCuentas_ContabilidadCentrosCostos]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCentrosCostos] FOREIGN KEY([IdCentroCosto])
REFERENCES [dbo].[ContabilidadCentrosCostos] ([IdCentroCosto])
GO
ALTER TABLE [dbo].[ContabilidadCuentas] CHECK CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCentrosCostos]
GO
/****** Object:  ForeignKey [FK_ContabilidadPeriodosEjercicios_ContabilidadEjercicios]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadPeriodosEjercicios]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadPeriodosEjercicios_ContabilidadEjercicios] FOREIGN KEY([IdEjercicio])
REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio])
GO
ALTER TABLE [dbo].[ContabilidadPeriodosEjercicios] CHECK CONSTRAINT [FK_ContabilidadPeriodosEjercicios_ContabilidadEjercicios]
GO
/****** Object:  ForeignKey [FK_ContabilidadPlanesCuentas_ContabilidadCuentas]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadPlanesCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadCuentas] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
GO
ALTER TABLE [dbo].[ContabilidadPlanesCuentas] CHECK CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadCuentas]
GO
/****** Object:  ForeignKey [FK_ContabilidadPlanesCuentas_ContabilidadPlanes]    Script Date: 07/02/2012 18:46:05 ******/
ALTER TABLE [dbo].[ContabilidadPlanesCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadPlanes] FOREIGN KEY([IdPlanCuenta])
REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta])
GO
ALTER TABLE [dbo].[ContabilidadPlanesCuentas] CHECK CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadPlanes]
GO
