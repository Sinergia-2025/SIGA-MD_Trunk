
/****** Object:  Table [dbo].[Textos]    Script Date: 03/10/2015 10:52:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Textos](
	[IdTexto] [int] NOT NULL,
	[Id] [varchar](30) NOT NULL,
	[Asunto] [varchar](100) NULL,
	[Cuerpo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Textos] PRIMARY KEY CLUSTERED 
(
	[IdTexto] ASC,
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Textos]  WITH CHECK ADD  CONSTRAINT [FK_Textos_Funciones] FOREIGN KEY([Id])
REFERENCES [dbo].[Funciones] ([Id])
GO

ALTER TABLE [dbo].[Textos] CHECK CONSTRAINT [FK_Textos_Funciones]
GO



INSERT INTO [Textos]
           ([IdTexto]
           ,[Id]
           ,[Asunto]
           ,[Cuerpo])
     VALUES
           (1
           ,'SolicitarCAE'
           ,''
           ,'')
GO