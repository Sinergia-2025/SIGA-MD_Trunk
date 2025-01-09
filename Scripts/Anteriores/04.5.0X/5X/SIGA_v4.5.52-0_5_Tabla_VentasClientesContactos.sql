
/****** Object:  Table [dbo].[VentasClientesContactos]    Script Date: 09/07/2017 09:49:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasClientesContactos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdContacto] [int] NOT NULL,
 CONSTRAINT [PK_VentasClientesContactos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdCliente] ASC,
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_VentasClientesContactos_ClientesContactos] FOREIGN KEY([IdCliente], [IdContacto])
REFERENCES [dbo].[ClientesContactos] ([IdCliente], [IdContacto])
GO

ALTER TABLE [dbo].[VentasClientesContactos] CHECK CONSTRAINT [FK_VentasClientesContactos_ClientesContactos]
GO

ALTER TABLE [dbo].[VentasClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_VentasClientesContactos_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[VentasClientesContactos] CHECK CONSTRAINT [FK_VentasClientesContactos_Ventas]
GO
