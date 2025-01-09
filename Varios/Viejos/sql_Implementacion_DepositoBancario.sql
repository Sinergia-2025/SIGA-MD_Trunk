/****** Objeto:  Table [dbo].[Depositos]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Depositos](
	[IdSucursal] [int] NOT NULL,
	[NumeroDeposito] [bigint] NOT NULL,
	[IdCuentaBancaria] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UsoFechaCheque] [bit] NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[Observacion] [varchar](100) NULL,
	[ImportePesos] [decimal](10, 2) NOT NULL,
	[ImporteDolares] [decimal](10, 2) NOT NULL,
	[ImporteEuros] [decimal](10, 2) NOT NULL,
	[ImporteCheques] [decimal](10, 2) NOT NULL,
	[ImporteTarjetas] [decimal](10, 2) NOT NULL,
	[ImporteTickets] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Depositos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroDeposito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])
GO
ALTER TABLE [dbo].[Depositos] CHECK CONSTRAINT [FK_Depositos_CuentasBancarias]
GO
ALTER TABLE [dbo].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[Depositos] CHECK CONSTRAINT [FK_Depositos_Sucursales]



/****** Objeto:  Table [dbo].[DepositosCheques]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepositosCheques](
	[IdSucursal] [int] NOT NULL,
	[NumeroDeposito] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_DepositosCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroDeposito] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DepositosCheques]  WITH CHECK ADD  CONSTRAINT [FK_DepositosCheques_Cheques] FOREIGN KEY([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO
ALTER TABLE [dbo].[DepositosCheques] CHECK CONSTRAINT [FK_DepositosCheques_Cheques]
GO
ALTER TABLE [dbo].[DepositosCheques]  WITH CHECK ADD  CONSTRAINT [FK_DepositosCheques_Depositos] FOREIGN KEY([IdSucursal], [NumeroDeposito])
REFERENCES [dbo].[Depositos] ([IdSucursal], [NumeroDeposito])
GO
ALTER TABLE [dbo].[DepositosCheques] CHECK CONSTRAINT [FK_DepositosCheques_Depositos]


