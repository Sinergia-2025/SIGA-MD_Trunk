
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesDescuentosMarcas](
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[DescuentoRecargo] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_ClientesDescuentosMarcas] PRIMARY KEY CLUSTERED 
(
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesDescuentosMarcas]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosMarcas_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[ClientesDescuentosMarcas] CHECK CONSTRAINT [FK_ClientesDescuentosMarcas_Clientes]
GO

ALTER TABLE [dbo].[ClientesDescuentosMarcas]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosMarcas_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO

ALTER TABLE [dbo].[ClientesDescuentosMarcas] CHECK CONSTRAINT [FK_ClientesDescuentosMarcas_Marcas]
GO


