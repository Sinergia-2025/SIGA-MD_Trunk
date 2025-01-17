
ALTER TABLE [dbo].[CuentasDeCajas] ADD [IdCuentaDebe] [int] NULL
GO

ALTER TABLE [dbo].[CuentasDeCajas] ADD [IdCuentaHaber] [int] NULL
GO

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001
      ,IdCuentaHaber = 10301001
  WHERE IdCuentaCaja = 1
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001
      ,IdCuentaHaber = 10301001
  WHERE IdCuentaCaja = 2
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001
      ,IdCuentaHaber = 10301002
  WHERE IdCuentaCaja = 3
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001
      ,IdCuentaHaber = 10301002
  WHERE IdCuentaCaja = 4
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001 
      ,IdCuentaHaber = 10301001
  WHERE IdCuentaCaja = 5
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001
      ,IdCuentaHaber = 10301001
  WHERE IdCuentaCaja = 6
GO 

UPDATE CuentasDeCajas
   SET IdCuentaDebe = 10101001 
      ,IdCuentaHaber = 10301002
  WHERE IdCuentaCaja = 7
GO 

/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentasDeCajas](
	[IdCuentaCaja] [int] NOT NULL,
	[NombreCuentaCaja] [varchar](40) NOT NULL,
	[IdTipoCuenta] [char](1) NOT NULL,
	[EsPosdatado] [bit] NOT NULL,
	[PideCheque] [bit] NOT NULL,
	[IdGrupoCuenta] [varchar](15) NOT NULL,
	[idCuentaDebe] [int] NULL,
	[idcuentaHaber] [int] NULL,
 CONSTRAINT [PK_CuentasDeCajas] PRIMARY KEY CLUSTERED 
(
	[IdCuentaCaja] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (1, N'Ventas', N'I', 0, 0, N'1', 10101001, 10301001)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (2, N'Recibo a Cliente', N'I', 0, 0, N'1', 10101001, 10301001)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (3, N'Compra', N'E', 0, 0, N'1', 10101001, 10301002)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (4, N'Pago a Proveedor', N'E', 0, 0, N'1', 10101001, 10301002)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (5, N'Transferencia Bancaria', N'E', 0, 0, N'1', 10101001, 10301001)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (6, N'Deposito Bancario', N'E', 0, 0, N'1', 10101001, 10301001)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (7, N'Mov. Cheques entre sucursales', N'E', 0, 0, N'1', 10101001, 10301002)
INSERT [dbo].[CuentasDeCajas] ([IdCuentaCaja], [NombreCuentaCaja], [IdTipoCuenta], [EsPosdatado], [PideCheque], [IdGrupoCuenta], [idCuentaDebe], [idcuentaHaber]) VALUES (10, N'Gastos Varios', N'E', 0, 0, N'1', 10101001, 10301002)
*/