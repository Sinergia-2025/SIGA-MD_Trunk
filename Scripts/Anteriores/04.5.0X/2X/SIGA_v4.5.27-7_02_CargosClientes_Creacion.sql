
/****** Object:  Table [dbo].[CargosClientes]    Script Date: 22/9/2016 14:34:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CargosClientes](
	[IdCliente] [bigint] NOT NULL,
	[IdCargo] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[Monto] [decimal](12, 2) NOT NULL,
	[Cantidad] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_CargosClientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdCargo] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CargosClientes]  WITH CHECK ADD  CONSTRAINT [FK_CargosClientes_Cargos] FOREIGN KEY([IdCargo], [IdSucursal])
REFERENCES [dbo].[Cargos] ([IdCargo], [IdSucursal])
GO

ALTER TABLE [dbo].[CargosClientes] CHECK CONSTRAINT [FK_CargosClientes_Cargos]
GO

ALTER TABLE [dbo].[CargosClientes]  WITH CHECK ADD  CONSTRAINT [FK_CargosClientes_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[CargosClientes] CHECK CONSTRAINT [FK_CargosClientes_Clientes]
GO


