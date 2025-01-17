
CREATE TABLE [dbo].[CuentasBancosClase](
	[IdClaseCuentaBanco] [int] NOT NULL,
	[NombreClaseCuentaBanco] [varchar](50) NULL,
 CONSTRAINT [PK_CuentasBancosClase] PRIMARY KEY CLUSTERED 
(
	[IdClaseCuentaBanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[CuentasBancos](
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[NumeroCuenta] [int] NOT NULL,
	[NombreCuenta] [varchar](50) NULL,
	[IdClaseCuenta] [int] NULL,
 CONSTRAINT [PK_CuentasBancos] PRIMARY KEY CLUSTERED 
(
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC,
	[NumeroCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[CuentasBancos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasBancos_Bancos] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([IdBanco])

ALTER TABLE [dbo].[CuentasBancos] CHECK CONSTRAINT [FK_CuentasBancos_Bancos]

ALTER TABLE [dbo].[CuentasBancos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasBancos_CuentasBancosClase] FOREIGN KEY([IdClaseCuenta])
REFERENCES [dbo].[CuentasBancosClase] ([IdClaseCuentaBanco])

ALTER TABLE [dbo].[CuentasBancos] CHECK CONSTRAINT [FK_CuentasBancos_CuentasBancosClase]

ALTER TABLE [dbo].[CuentasBancos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasBancos_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])

ALTER TABLE [dbo].[CuentasBancos] CHECK CONSTRAINT [FK_CuentasBancos_Localidades]

CREATE TABLE [dbo].[ChequesPropios](
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[NumeroCuenta] [int] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[idSucursal] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaCobro] [datetime] NOT NULL,
	[Importe] [decimal](10, 2) NOT NULL,
	[NroPlanillaEgreso] [int] NULL,
	[NroMovimientoEgreso] [int] NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
 CONSTRAINT [PK_ChequesPropios_1] PRIMARY KEY CLUSTERED 
(
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC,
	[NumeroCuenta] ASC,
	[NumeroCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[ChequesPropios]  WITH CHECK ADD  CONSTRAINT [FK_ChequesPropios_Bancos] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([IdBanco])

ALTER TABLE [dbo].[ChequesPropios] CHECK CONSTRAINT [FK_ChequesPropios_Bancos]

ALTER TABLE [dbo].[ChequesPropios]  WITH CHECK ADD  CONSTRAINT [FK_ChequesPropios_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])

ALTER TABLE [dbo].[ChequesPropios] CHECK CONSTRAINT [FK_ChequesPropios_Proveedores]




-----
--Estos son los registros de las tablas

--[CuentasBancosClase]
--1	Cuenta Corriente
--2	Caja de Ahorro

--[CuentasBancos]
--11	1	2000	2323	Mia	1
--11	1	2000	3344	Mi caja	2

--En la tabla de Bancos, carga el Nro. 11 que es el Banco Nacion.