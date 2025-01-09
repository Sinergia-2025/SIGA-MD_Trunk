
/****** Object:  Table [dbo].[ClientesDescuentosProductos]    Script Date: 04/09/2015 16:34:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientesDescuentosProductos](
	[IdCliente] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[DescuentoRecargoPorc1] [decimal](5, 2) NOT NULL,
	[DescuentoRecargoPorc2] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_ClientesDescuentosProductos] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ClientesDescuentosProductos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosProductos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesDescuentosProductos] CHECK CONSTRAINT [FK_ClientesDescuentosProductos_Clientes] 
GO

ALTER TABLE [dbo].[ClientesDescuentosProductos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosProductos_Productos]  FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ClientesDescuentosProductos] CHECK CONSTRAINT [FK_ClientesDescuentosProductos_Productos]
GO
