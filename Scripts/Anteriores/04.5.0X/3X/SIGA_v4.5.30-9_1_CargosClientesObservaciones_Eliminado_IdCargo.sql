
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CargosClientesObservaciones_Clientes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CargosClientesObservaciones]'))
ALTER TABLE [dbo].[CargosClientesObservaciones] DROP CONSTRAINT [FK_CargosClientesObservaciones_Clientes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CargosClientesObservaciones_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[CargosClientesObservaciones]'))
ALTER TABLE [dbo].[CargosClientesObservaciones] DROP CONSTRAINT [FK_CargosClientesObservaciones_Sucursales]
GO

/****** Object:  Table [dbo].[CargosClientesObservaciones]    Script Date: 11/29/2016 10:57:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargosClientesObservaciones]') AND type in (N'U'))
DROP TABLE [dbo].[CargosClientesObservaciones]
GO


/****** Object:  Table [dbo].[CargosClientesObservaciones]    Script Date: 11/29/2016 10:57:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CargosClientesObservaciones](
	[IdSucursal] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Linea] [int] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CargosClientesObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdCliente] ASC,
	[Linea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CargosClientesObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_CargosClientesObservaciones_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[CargosClientesObservaciones] CHECK CONSTRAINT [FK_CargosClientesObservaciones_Clientes]
GO

ALTER TABLE [dbo].[CargosClientesObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_CargosClientesObservaciones_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[CargosClientesObservaciones] CHECK CONSTRAINT [FK_CargosClientesObservaciones_Sucursales]
GO
