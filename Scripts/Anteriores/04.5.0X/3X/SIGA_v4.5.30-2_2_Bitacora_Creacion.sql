
/****** Object:  Table [dbo].[Bitacora]    Script Date: 10/11/2016 10:06:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Bitacora](
	[IdSucursal] [int] NOT NULL,
	[IdBitacora] [int] NOT NULL,
	[FechaBitacora] [datetime] NOT NULL,
	[IdFuncion] [varchar](30) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[NombrePC] [varchar](20) NOT NULL,
	[Tipo] [varchar](50) NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Funciones]
GO

ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuarios]
GO
