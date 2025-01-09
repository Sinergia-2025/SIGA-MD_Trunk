
-- 
--ALTER TABLE dbo.CartasAClientes ALTER COLUMN TipoCarta [varchar](20) NOT NULL
--GO

--ALTER TABLE dbo.CartasAClientes ALTER COLUMN Usuario [varchar](10) NOT NULL
--GO



/****** Object:  Table [dbo].[CartasAClientes]    Script Date: 06/14/2012 10:00:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CartasAClientes](
	[IdSucursal] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[NroOperacion] [int] NOT NULL,
	[FechaEnvio] [datetime] NOT NULL,
	[TipoCarta] [varchar](20) NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
	[TipoDocumentoGarante] [varchar](5) NULL,
	[NroDocumentoGarante] [varchar](12) NULL,
 CONSTRAINT [PK_CartasAClientes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[NroOperacion] ASC,
	[FechaEnvio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CartasAClientes]  WITH CHECK ADD  CONSTRAINT [FK_CartasAClientes_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[CartasAClientes] CHECK CONSTRAINT [FK_CartasAClientes_Clientes]
GO

ALTER TABLE [dbo].[CartasAClientes]  WITH CHECK ADD  CONSTRAINT [FK_CartasAClientes_ClientesGarante] FOREIGN KEY([TipoDocumentoGarante], [NroDocumentoGarante])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[CartasAClientes] CHECK CONSTRAINT [FK_CartasAClientes_ClientesGarante]
GO

ALTER TABLE [dbo].[CartasAClientes]  WITH CHECK ADD  CONSTRAINT [FK_CartasAClientes_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[CartasAClientes] CHECK CONSTRAINT [FK_CartasAClientes_Sucursales]
GO

ALTER TABLE [dbo].[CartasAClientes]  WITH CHECK ADD  CONSTRAINT [FK_CartasAClientes_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CartasAClientes] CHECK CONSTRAINT [FK_CartasAClientes_Usuarios]
GO


