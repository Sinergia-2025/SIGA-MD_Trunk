
DROP TABLE CuentasCorrientesPagos;

DROP TABLE CuentasCorrientesCheques;

DROP TABLE CuentasCorrientesMonedas;

DROP TABLE CuentasCorrientes;


--Tiene 89 movimientos, el ultimo el 20/01, y tanto que insistieron.

DROP TABLE ChequesPropios;


DROP TABLE CajasDetalle;

DROP TABLE Cajas;

DROP TABLE Cheques;


/****** Objeto:  Table [dbo].[Cajas]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cajas](
	[IdSucursal] [int] NOT NULL,
	[NumeroPlanilla] [int] NOT NULL,
	[FechaPlanilla] [datetime] NOT NULL,
	[PesosSaldoInicial] [decimal](10, 2) NOT NULL,
	[PesosSaldoFinal] [decimal](10, 2) NOT NULL,
	[DolaresSaldoInicial] [decimal](10, 2) NOT NULL,
	[DolaresSaldoFinal] [decimal](10, 2) NOT NULL,
	[EurosSaldoInicial] [decimal](10, 2) NOT NULL,
	[EurosSaldoFinal] [decimal](10, 2) NOT NULL,
	[ChequesSaldoInicial] [decimal](10, 2) NOT NULL,
	[ChequesSaldoFinal] [decimal](10, 2) NOT NULL,
	[TarjetasSaldoInicial] [decimal](10, 2) NOT NULL,
	[TarjetasSaldoFinal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Cajas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroPlanilla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



/****** Objeto:  Table [dbo].[CajasDetalle]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CajasDetalle](
	[IdSucursal] [int] NOT NULL,
	[NumeroPlanilla] [int] NOT NULL,
	[NumeroMovimiento] [int] NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
	[IdCuentaCaja] [int] NOT NULL,
	[IdTipoMovimiento] [char](1) NOT NULL,
	[ImportePesos] [decimal](10, 2) NOT NULL,
	[ImporteDolares] [decimal](10, 2) NOT NULL,
	[ImporteEuros] [decimal](10, 2) NOT NULL,
	[ImporteCheques] [decimal](10, 2) NOT NULL,
	[ImporteTarjetas] [decimal](10, 2) NOT NULL,
	[Observacion] [varchar](70) NULL,
	[EsModificable] [bit] NOT NULL,
 CONSTRAINT [PK_CajasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroPlanilla] ASC,
	[NumeroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CajasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CajasDetalle_CuentasDeCajas] FOREIGN KEY([IdCuentaCaja])
REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja])
GO
ALTER TABLE [dbo].[CajasDetalle] CHECK CONSTRAINT [FK_CajasDetalle_CuentasDeCajas]
GO
ALTER TABLE [dbo].[CajasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CajasDetalle_IdSucursal] FOREIGN KEY([IdSucursal], [NumeroPlanilla])
REFERENCES [dbo].[Cajas] ([IdSucursal], [NumeroPlanilla])
GO
ALTER TABLE [dbo].[CajasDetalle] CHECK CONSTRAINT [FK_CajasDetalle_IdSucursal]



/**************************/

ALTER TABLE dbo.CategoriasFiscales ADD
	NombreCategoriaFiscalAbrev varchar(10) NULL;


/* Cons.Final, Resp.Insc., Resp.NO.I., Exento, Exe S/IVA, Monotrib. */


/**************************/

DROP TABLE Monedas;



/****** Objeto:  Table [dbo].[Monedas]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Monedas](
	[IdMoneda] [int] NOT NULL,
	[NombreMoneda] [varchar](30) NOT NULL,
	[IdTipoMoneda] [varchar](15) NOT NULL,
	[OperadorConversion] [char](1) NOT NULL,
	[FactorConversion] [decimal](5, 3) NOT NULL,
	[IdBanco] [int] NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/*
1	Pesos	1	1	1.000	1
2	Dolares	2	1	3.500	1
*/


/****** Objeto:  Table [dbo].[CuentasBancariasClase]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasBancariasClase](
	[IdCuentaBancariaClase] [int] NOT NULL,
	[NombreCuentaBancariaClase] [varchar](50) NULL,
 CONSTRAINT [PK_CuentasBancariasClase] PRIMARY KEY CLUSTERED 
(
	[IdCuentaBancariaClase] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/****** Objeto:  Table [dbo].[CuentasBancarias]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasBancarias](
	[IdCuentaBancaria] [int] NOT NULL,
	[CodigoBancario] [varchar](20) NOT NULL,
	[IdCuentaBancariaClase] [int] NOT NULL,
	[TieneChequera] [bit] NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Saldo] [decimal](10, 2) NULL,
	[SaldoConfirmado] [decimal](10, 2) NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[NombreCuenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CuentasBancarias] PRIMARY KEY CLUSTERED 
(
	[IdCuentaBancaria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasBancarias]  WITH CHECK ADD  CONSTRAINT [FK_CuentasBancarias_Bancos] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([IdBanco])
GO
ALTER TABLE [dbo].[CuentasBancarias] CHECK CONSTRAINT [FK_CuentasBancarias_Bancos]
GO
ALTER TABLE [dbo].[CuentasBancarias]  WITH CHECK ADD  CONSTRAINT [FK_CuentasBancarias_CuentasBancosClase] FOREIGN KEY([IdCuentaBancariaClase])
REFERENCES [dbo].[CuentasBancariasClase] ([IdCuentaBancariaClase])
GO
ALTER TABLE [dbo].[CuentasBancarias] CHECK CONSTRAINT [FK_CuentasBancarias_CuentasBancosClase]
GO
ALTER TABLE [dbo].[CuentasBancarias]  WITH CHECK ADD  CONSTRAINT [FK_IdLocalidad] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[CuentasBancarias] CHECK CONSTRAINT [FK_IdLocalidad]
GO
ALTER TABLE [dbo].[CuentasBancarias]  WITH CHECK ADD  CONSTRAINT [FK_IdMoneda] FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Monedas] ([IdMoneda])
GO
ALTER TABLE [dbo].[CuentasBancarias] CHECK CONSTRAINT [FK_IdMoneda]



/****** Objeto:  Table [dbo].[Cheques]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cheques](
	[idSucursal] [int] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaCobro] [datetime] NOT NULL,
	[Titular] [varchar](40) NULL,
	[Importe] [decimal](10, 2) NOT NULL,
	[NroPlanillaIngreso] [int] NOT NULL,
	[NroMovimientoIngreso] [int] NOT NULL,
	[NroPlanillaEgreso] [int] NOT NULL,
	[NroMovimientoEgreso] [int] NOT NULL,
	[EsPropio] [bit] NOT NULL,
	[IdCuentaBancaria] [int] NULL,
 CONSTRAINT [PK_Cheques] PRIMARY KEY CLUSTERED 
(
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_Cheques_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])
GO
ALTER TABLE [dbo].[Cheques] CHECK CONSTRAINT [FK_Cheques_CuentasBancarias]
GO
ALTER TABLE [dbo].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_Cheques_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Cheques] CHECK CONSTRAINT [FK_Cheques_Localidades]
GO
ALTER TABLE [dbo].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_IdBanco] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Bancos] ([IdBanco])
GO
ALTER TABLE [dbo].[Cheques] CHECK CONSTRAINT [FK_IdBanco]


/*******************************************/

ALTER TABLE Compras ADD
	Neto210 decimal(12, 2) NULL,
	Neto105 decimal(12, 2) NULL,
	Neto270 decimal(12, 2) NULL,
	NetoNoGravado decimal(12, 2) NULL,
	IVA210 decimal(12, 2) NULL,
	IVA105 decimal(12, 2) NULL,
	IVA270 decimal(12, 2) NULL,
	Bruto210 decimal(12, 2) NULL,
	Bruto105 decimal(12, 2) NULL,
	Bruto270 decimal(12, 2) NULL,
	BrutoNoGravado decimal(12, 2) NULL,
	PercepcionIVA decimal(12, 2) NULL,
	PercepcionIB decimal(12, 2) NULL,
	PercepcionGanancias decimal(12, 2) NULL,
	PercepcionVarias decimal(12, 2) NULL
GO

UPDATE Compras SET
   Bruto210=ImporteBruto, 
   IVA210=IvaInscripto, 
   Neto210=SubTotal --- Correcto? SubTotal ?
GO


ALTER TABLE Compras DROP COLUMN ImporteBruto
GO

ALTER TABLE Compras DROP COLUMN IvaInscripto
GO

ALTER TABLE Compras DROP COLUMN IvaNoInscripto
GO

ALTER TABLE Compras DROP COLUMN SubTotal
GO


/*******************************************/

ALTER TABLE ComprasProductos ADD
	PorcentajeIVA decimal(12, 2) NULL,
	IVA decimal(12, 2) NULL
GO

/*******************************************/


ALTER TABLE MovimientosCompras ADD
	Neto210 decimal(12, 2) NULL,
	Neto105 decimal(12, 2) NULL,
	Neto270 decimal(12, 2) NULL,
	NetoNoGravado decimal(12, 2) NULL,
	IVA210 decimal(12, 2) NULL,
	IVA105 decimal(12, 2) NULL,
	IVA270 decimal(12, 2) NULL,
	PercepcionIVA decimal(12, 2) NULL,
	PercepcionIB decimal(12, 2) NULL,
	PercepcionGanancias decimal(12, 2) NULL,
	PercepcionVarias decimal(12, 2) NULL
GO


UPDATE MovimientosCompras SET
   IVA210=IvaInscripto, 
   Neto210=Neto
GO


ALTER TABLE MovimientosCompras DROP COLUMN Neto
GO

ALTER TABLE MovimientosCompras DROP COLUMN IvaInscripto
GO

ALTER TABLE MovimientosCompras DROP COLUMN IvaNoInscripto
GO




/****** Objeto:  Table [dbo].[ComprasNumeros]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ComprasNumeros](
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[LetraFiscal] [char](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[Numero] [int] NULL,
	[IdTipoComprobanteRelacionado] [varchar](10) NULL,
 CONSTRAINT [PK_ComprasNumeros] PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC,
	[LetraFiscal] ASC,
	[CentroEmisor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ComprasNumeros]  WITH CHECK ADD  CONSTRAINT [FK_ComprasNumeros_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[ComprasNumeros] CHECK CONSTRAINT [FK_ComprasNumeros_TiposComprobantes]


/*******************************************/

DROP TABLE CuentasBancosClase;

DROP TABLE CuentasBancos;


/****** Objeto:  Table [dbo].[CuentasBancos]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasBancos](
	[IdCuentaBanco] [int] NOT NULL,
	[NombreCuentaBanco] [varchar](30) NOT NULL,
	[IdTipoCuenta] [char](1) NOT NULL,
	[EsPosdatado] [bit] NULL,
	[PideCheque] [bit] NULL,
 CONSTRAINT [PK_CuentasBancos_1] PRIMARY KEY CLUSTERED 
(
	[IdCuentaBanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/****** Objeto:  Table [dbo].[CuentasCorrientes]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientes](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[Fecha] [datetime] NULL,
	[FechaVencimiento] [datetime] NULL,
	[ImporteTotal] [decimal](12, 2) NULL,
	[TipoDocCliente] [varchar](5) NOT NULL,
	[NroDocCliente] [varchar](12) NOT NULL,
	[IdFormasPago] [int] NOT NULL,
	[Observacion] [varchar](100) NULL,
	[Saldo] [decimal](12, 2) NULL,
	[CantidadCuotas] [int] NULL,
	[ImportePesos] [decimal](10, 2) NOT NULL,
	[ImporteDolares] [decimal](10, 2) NOT NULL,
	[ImporteEuros] [decimal](10, 2) NOT NULL,
	[ImporteCheques] [decimal](10, 2) NOT NULL,
	[ImporteTarjetas] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_CuentasCorrientes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_Clientes] FOREIGN KEY([TipoDocCliente], [NroDocCliente])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_Clientes]
GO
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_Sucursales]
GO
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_TiposComprobantes]



/****** Objeto:  Table [dbo].[CuentasCorrientesCheques]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientesCheques](
	[NumeroCheque] [int] NOT NULL,
	[IdBancoCheque] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdLocalidadCheque] [int] NOT NULL,
	[IdBancoSucursalCheque] [int] NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesCheques] PRIMARY KEY CLUSTERED 
(
	[NumeroCheque] ASC,
	[IdBancoCheque] ASC,
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdLocalidadCheque] ASC,
	[IdBancoSucursalCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasCorrientesCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesCheques_CuentasCorrientes] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO
ALTER TABLE [dbo].[CuentasCorrientesCheques] CHECK CONSTRAINT [FK_CuentasCorrientesCheques_CuentasCorrientes]



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesCheques ADD CONSTRAINT
	FK_CuentasCorrientesCheques_Cheques FOREIGN KEY
	(
	NumeroCheque,
	IdBancoCheque,
	IdBancoSucursalCheque,
	IdLocalidadCheque
	) REFERENCES dbo.Cheques
	(
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/****** Objeto:  Table [dbo].[CuentasCorrientesPagos]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientesPagos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[CuotaNumero] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[FechaVencimiento] [datetime] NULL,
	[ImporteCuota] [decimal](12, 2) NULL,
	[SaldoCuota] [decimal](12, 2) NULL,
	[IdFormasPago] [int] NOT NULL,
	[Observacion] [varchar](100) NULL,
	[IdTipoComprobante2] [varchar](15) NULL,
	[NumeroComprobante2] [bigint] NULL,
	[CentroEmisor2] [int] NULL,
	[CuotaNumero2] [int] NULL,
	[Letra2] [varchar](1) NULL,
 CONSTRAINT [PK_CuentasCorrientesPagos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[CuotaNumero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasCorrientesPagos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesPagos_CuentasCorrientesPagos] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO
ALTER TABLE [dbo].[CuentasCorrientesPagos] CHECK CONSTRAINT [FK_CuentasCorrientesPagos_CuentasCorrientesPagos]


/****** Objeto:  Table [dbo].[CuentasCorrientesProv]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientesProv](
	[IdSucursal] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[IdFormasPago] [int] NOT NULL,
	[Observacion] [varchar](100) NULL,
	[Saldo] [decimal](12, 2) NOT NULL,
	[CantidadCuotas] [int] NOT NULL,
	[ImportePesos] [decimal](10, 2) NOT NULL,
	[ImporteDolares] [decimal](10, 2) NOT NULL,
	[ImporteEuros] [decimal](10, 2) NOT NULL,
	[ImporteCheques] [decimal](10, 2) NOT NULL,
	[ImporteTarjetas] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesProv] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasCorrientesProv]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProv_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO
ALTER TABLE [dbo].[CuentasCorrientesProv] CHECK CONSTRAINT [FK_CuentasCorrientesProv_Proveedores]
GO
ALTER TABLE [dbo].[CuentasCorrientesProv]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProv_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[CuentasCorrientesProv] CHECK CONSTRAINT [FK_CuentasCorrientesProv_Sucursales]
GO
ALTER TABLE [dbo].[CuentasCorrientesProv]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProv_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[CuentasCorrientesProv] CHECK CONSTRAINT [FK_CuentasCorrientesProv_TiposComprobantes]

/****** Objeto:  Table [dbo].[CuentasCorrientesProvCheques]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientesProvCheques](
	[IdSucursal] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesProvCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CuentasCorrientesProvCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvCheques_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[CuentasCorrientesProvCheques] CHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_Localidades]



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques ADD CONSTRAINT
	FK_CuentasCorrientesProvCheques_Cheques FOREIGN KEY
	(
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad
	) REFERENCES dbo.Cheques
	(
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/****** Objeto:  Table [dbo].[CuentasCorrientesProvPagos]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasCorrientesProvPagos](
	[IdSucursal] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[CuotaNumero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[ImporteCuota] [decimal](12, 2) NOT NULL,
	[SaldoCuota] [decimal](12, 2) NOT NULL,
	[IdFormasPago] [int] NOT NULL,
	[Observacion] [varchar](100) NULL,
	[IdTipoComprobante2] [varchar](15) NULL,
	[NumeroComprobante2] [bigint] NULL,
	[CentroEmisor2] [int] NULL,
	[CuotaNumero2] [int] NULL,
	[Letra2] [varchar](1) NULL,
 CONSTRAINT [PK_CuentasCorrientesProvPagos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[CuotaNumero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/*******************************************/


ALTER TABLE CuentasDeCajas ADD
	CuentaContable varchar(6) NULL;


/****** Objeto:  Table [dbo].[LibrosBancos]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LibrosBancos](
	[IdSucursal] [int] NOT NULL,
	[IdCuentaBancaria] [int] NOT NULL,
	[NumeroMovimiento] [int] NOT NULL,
	[IdCuentaBanco] [int] NOT NULL,
	[IdTipoMovimiento] [char](1) NOT NULL,
	[Importe] [decimal](10, 2) NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
	[NumeroCheque] [int] NULL,
	[FechaAplicado] [datetime] NULL,
	[Observacion] [varchar](50) NULL,
	[Conciliado] [bit] NULL,
 CONSTRAINT [PK_LibroBanco] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdCuentaBancaria] ASC,
	[NumeroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[LibrosBancos]  WITH CHECK ADD  CONSTRAINT [FK_LibrosBancos_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])
GO
ALTER TABLE [dbo].[LibrosBancos] CHECK CONSTRAINT [FK_LibrosBancos_CuentasBancarias]
GO
ALTER TABLE [dbo].[LibrosBancos]  WITH CHECK ADD  CONSTRAINT [FK_LibrosBancos_CuentasBancos] FOREIGN KEY([IdCuentaBanco])
REFERENCES [dbo].[CuentasBancos] ([IdCuentaBanco])
GO
ALTER TABLE [dbo].[LibrosBancos] CHECK CONSTRAINT [FK_LibrosBancos_CuentasBancos]


/*******************************************/


ALTER TABLE dbo.TiposComprobantes ADD
	DescripcionAbrev varchar(10) NULL;

/*

CANCELA-REMITO	Canc.Rem.
DESHACE-REMITO	Desh.Rem.
DEV-PROFORMA	Dev.Prof.
FACT		Factura
FACTCOM		Fact.Comp.
FACT-F		Fact.Fisc.
NCRED		Nota Cred.
NCRED-F		Nota Cr.F.
NDEB		Nota Deb.
NDEB-F		Nota Db.F.
PAGO		Pago
PRESUP		Presup.
PROFORMA	Proforma
RECIBOS		Recibo
REMITO		Remito
REMITOCOM	Remito Com
TCK-FACT-F	Tick-Fact.
TICKET-F	Ticket

*/


/*******************************************/


ALTER TABLE VentasFormasPago ADD
	EsTarjeta bit NULL;


/* Actualizar Datos */


/*******************************************/

ALTER TABLE dbo.LibrosBancos ADD
	IdBancoCheque int NULL,
	IdBancoSucursalCheque int NULL,
	IdLocalidadCheque int NULL
GO



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LibrosBancos ADD CONSTRAINT
	FK_LibrosBancos_Cheques FOREIGN KEY
	(
	NumeroCheque,
	IdBancoCheque,
	IdBancoSucursalCheque,
	IdLocalidadCheque
	) REFERENCES dbo.Cheques
	(
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

/*******************************************/


ALTER TABLE dbo.Cajas ADD
	TicketsSaldoInicial decimal(10, 2) NOT NULL,
	TicketsSaldoFinal decimal(10, 2) NOT NULL
GO


ALTER TABLE dbo.CajasDetalle ADD
	ImporteTickets decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientes ADD
	ImporteTickets decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImportePesos decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImporteDolares decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImporteEuros decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImporteCheques decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImporteTarjetas decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD
	ImporteTickets decimal(10, 2) NOT NULL
GO



/*******************************************/


ALTER TABLE dbo.Impresoras ALTER COLUMN ComprobantesHabilitados VARCHAR(150) ;


ALTER TABLE dbo.CuentasDeCajas ALTER COLUMN CuentaContable VARCHAR(15);



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



/****** Objeto:  Table [dbo].[TiposComprobantesLetras]   ******/

CREATE TABLE [dbo].[TiposComprobantesLetras](
[IdTipoComprobante] [varchar](15) NOT NULL,
[Letra] [varchar](1) NOT NULL,
[ArchivoAImprimir] [varchar](100) NOT NULL,
[ArchivoAImprimirEmbebido] [bit] NOT NULL,
[NombreImpresora] [varchar](100) NULL,
CONSTRAINT [PK_TiposComprobantesLetras] PRIMARY KEY CLUSTERED 
(
[IdTipoComprobante] ASC,
[Letra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TiposComprobantesLetras] WITH CHECK ADD CONSTRAINT [FK_TiposComprobantesLetras_TiposComprobantesLetras] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[TiposComprobantesLetras] CHECK CONSTRAINT [FK_TiposComprobantesLetras_TiposComprobantesLetras]
GO

/*******************************************/

ALTER TABLE dbo.TiposDocumento ADD
    EsAutoincremental bit NULL
GO


/*******************************************/

ALTER TABLE dbo.TiposComprobantes ADD
			PuedeSerBorrado bit NULL
		GO

/*******************************************/


ALTER TABLE dbo.Ventas ADD
	NumeroPlanilla int NULL,
	NumeroMovimiento int NULL
GO

ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_CajasDetalle FOREIGN KEY
	(
	IdSucursal,
	NumeroPlanilla,
	NumeroMovimiento
	) REFERENCES dbo.CajasDetalle
	(
	IdSucursal,
	NumeroPlanilla,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO



/*******************************************/


ALTER TABLE Ventas ADD ImportePesos decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteTickets decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteTarjetas decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteCheques decimal(12, 2) NULL

CREATE TABLE [dbo].[VentasCheques](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_VentasCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Cheques] FOREIGN KEY([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Cheques]
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_TiposComprobantes]
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Ventas]
GO


/*******************************************/

CREATE TABLE [dbo].[ListasDePrecios](
      [IdListaPrecios] [int] NOT NULL,
      [NombreListaPrecios] [varchar](50) NULL,
      [FechaVigencia] [datetime] NULL,
 CONSTRAINT [PK_ListasDePrecios] PRIMARY KEY CLUSTERED 
(
      [IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ProductosSucursalesPrecios](
      [IdProducto] [varchar](20) NOT NULL,
      [IdSucursal] [int] NOT NULL,
      [IdListaPrecios] [int] NOT NULL,
      [PrecioVenta] [decimal](12, 2) NULL,
      [FechaActualizacion] [datetime] NULL,
      [Usuario] [varchar](50) NULL,
 CONSTRAINT [PK_ProductosSucursalesPrecios] PRIMARY KEY CLUSTERED 
(
      [IdProducto] ASC,
      [IdSucursal] ASC,
      [IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios]  WITH CHECK ADD  CONSTRAINT [FK_ProductosSucursalesPrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios] CHECK CONSTRAINT [FK_ProductosSucursalesPrecios_ListasDePrecios]
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios]  WITH CHECK ADD  CONSTRAINT [FK_ProductosSucursalesPrecios_ProductosSucursales] FOREIGN KEY([IdProducto], [IdSucursal])
REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal])
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios] CHECK CONSTRAINT [FK_ProductosSucursalesPrecios_ProductosSucursales]
GO



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.CuentasCorrientesProv.ImporteTarjetas', N'Tmp_ImporteTransfBancaria', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CuentasCorrientesProv.Tmp_ImporteTransfBancaria', N'ImporteTransfBancaria', 'COLUMN' 
GO
COMMIT




