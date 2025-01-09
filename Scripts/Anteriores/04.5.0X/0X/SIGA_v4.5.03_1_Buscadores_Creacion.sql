
/****** Object:  Table [dbo].[Buscadores]    Script Date: 23/12/2015 14:09:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Buscadores](
	[IdBuscador] [int] NOT NULL,
	[Titulo] [nchar](50) NULL,
	[AnchoAyuda] [int] NULL
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[BuscadoresCampos]    Script Date: 23/12/2015 14:09:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BuscadoresCampos](
	[IdBuscador] [int] NOT NULL,
	[IdBuscadorNombreCampo] [varchar](50) NOT NULL,
	[Orden] [int] NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Alineacion] [int] NOT NULL,
	[Ancho] [int] NOT NULL,
	[Formato] [varchar](50) NULL,
 CONSTRAINT [PK_BuscadoresCampos] PRIMARY KEY CLUSTERED 
(
	[IdBuscador] ASC,
	[IdBuscadorNombreCampo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
