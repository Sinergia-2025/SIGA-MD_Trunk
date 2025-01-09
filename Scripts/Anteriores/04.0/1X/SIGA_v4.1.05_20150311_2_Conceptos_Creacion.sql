/****** Object:  Table [dbo].[RubrosConceptos]    Script Date: 03/11/2015 16:01:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RubrosConceptos](
	[IdRubroConcepto] [int] NOT NULL,
	[NombreRubroConcepto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RubrosConceptos] PRIMARY KEY CLUSTERED 
(
	[IdRubroConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Conceptos]    Script Date: 03/11/2015 16:04:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Conceptos](
	[IdConcepto] [int] NOT NULL,
	[NombreConcepto] [varchar](70) NOT NULL,
	[IdRubroConcepto] [int] NOT NULL,
	[EsNogravado] [bit] NOT NULL,
	[ImprimeProveedor] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Conceptos] PRIMARY KEY CLUSTERED 
(
	[IdConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Conceptos]  WITH CHECK ADD  CONSTRAINT [FK_Conceptos_RubrosConceptos] FOREIGN KEY([IdRubroConcepto])
REFERENCES [dbo].[RubrosConceptos] ([IdRubroConcepto])
GO

ALTER TABLE [dbo].[Conceptos] CHECK CONSTRAINT [FK_Conceptos_RubrosConceptos]
GO
