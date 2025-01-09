
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Traducciones_Funciones]') AND parent_object_id = OBJECT_ID(N'[dbo].[Traducciones]'))
ALTER TABLE [dbo].[Traducciones] DROP CONSTRAINT [FK_Traducciones_Funciones]
GO

/****** Object:  Table [dbo].[Traducciones]    Script Date: 09/01/2017 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Traducciones]') AND type in (N'U'))
DROP TABLE [dbo].[Traducciones]
GO

/****** Object:  Table [dbo].[Traducciones]    Script Date: 09/01/2017 15:05:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Traducciones](
	[IdFuncion] [varchar](30) NOT NULL,
	[Pantalla] [varchar](90) NOT NULL,
	[Control] [varchar](90) NOT NULL,
	[IdIdioma] [varchar](10) NOT NULL,
	[Texto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Traducciones] PRIMARY KEY CLUSTERED 
(
	[IdFuncion] ASC,
	[Pantalla] ASC,
	[Control] ASC,
	[IdIdioma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Traducciones_Funciones] FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[Traducciones] CHECK CONSTRAINT [FK_Traducciones_Funciones]
GO
