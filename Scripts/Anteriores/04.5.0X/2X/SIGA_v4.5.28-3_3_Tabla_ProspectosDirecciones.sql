
/****** Object:  Table [dbo].[ProspectosDirecciones]    Script Date: 10/13/2016 14:20:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProspectosDirecciones](
	[IdProspecto] [bigint] NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[IdTipoDireccion] [int] NOT NULL,
 CONSTRAINT [PK_ProspectosDirecciones] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC,
	[IdDireccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProspectosDirecciones]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosDirecciones_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO

ALTER TABLE [dbo].[ProspectosDirecciones] CHECK CONSTRAINT [FK_ProspectosDirecciones_Localidades]
GO

ALTER TABLE [dbo].[ProspectosDirecciones]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosDirecciones_TiposDirecciones] FOREIGN KEY([IdTipoDireccion])
REFERENCES [dbo].[TiposDirecciones] ([IdTipoDireccion])
GO

ALTER TABLE [dbo].[ProspectosDirecciones] CHECK CONSTRAINT [FK_ProspectosDirecciones_TiposDirecciones]
GO
