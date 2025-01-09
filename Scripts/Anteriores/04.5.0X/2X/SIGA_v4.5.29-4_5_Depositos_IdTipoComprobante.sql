
ALTER TABLE DepositosCheques DROP  CONSTRAINT [PK_DepositosCheques]
GO

ALTER TABLE DepositosCheques DROP  CONSTRAINT [FK_DepositosCheques_Cheques]
GO

ALTER TABLE DepositosCheques DROP  CONSTRAINT [FK_DepositosCheques_Depositos] 
GO

ALTER TABLE Depositos DROP  CONSTRAINT [PK_Depositos]
GO

ALTER TABLE Depositos ADD IdTipoComprobante varchar(15) Null
GO

ALTER TABLE DepositosCheques ADD IdTipoComprobante varchar(15) Null
GO

UPDATE Depositos SET IdTipoComprobante = 'DEPOSITO'
GO

UPDATE DepositosCheques SET IdTipoComprobante = 'DEPOSITO'
GO

ALTER TABLE Depositos ALTER COLUMN IdTipoComprobante varchar(15) not Null
GO

ALTER TABLE DepositosCheques ALTER COLUMN IdTipoComprobante varchar(15) not Null
GO

ALTER TABLE Depositos ADD CONSTRAINT [PK_Depositos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroDeposito] ASC,
	[IdTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE DepositosCheques ADD CONSTRAINT [PK_DepositosCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroDeposito] ASC,
	[IdTipoComprobante] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DepositosCheques]  WITH CHECK ADD  CONSTRAINT [FK_DepositosCheques_Cheques] FOREIGN KEY([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[DepositosCheques] CHECK CONSTRAINT [FK_DepositosCheques_Cheques]
GO

ALTER TABLE [dbo].[DepositosCheques]  WITH CHECK ADD  CONSTRAINT [FK_DepositosCheques_Depositos] FOREIGN KEY([IdSucursal], [NumeroDeposito], [IdTipoComprobante])
REFERENCES [dbo].[Depositos] ([IdSucursal], [NumeroDeposito], [IdTipoComprobante])
GO

ALTER TABLE [dbo].[DepositosCheques] CHECK CONSTRAINT [FK_DepositosCheques_Depositos]
GO