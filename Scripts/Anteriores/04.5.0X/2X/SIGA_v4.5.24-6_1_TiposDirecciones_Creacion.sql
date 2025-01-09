
/****** Object:  Table [dbo].[TiposDirecciones]    Script Date: 1/8/2016 15:29:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposDirecciones](
	[IdTipoDireccion] [int] NOT NULL,
	[NombreTipoDireccion] [varchar](200) NULL,
	[NombreAbrevTipoDireccion] [varchar](2) NULL,
 CONSTRAINT [PK_TiposDirecciones] PRIMARY KEY CLUSTERED 
(
	[IdTipoDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* ------*/ 

INSERT INTO [dbo].[TiposDirecciones]
           ([IdTipoDireccion], [NombreTipoDireccion], [NombreAbrevTipoDireccion])
     VALUES
           (1, 'Fiscal','F'),
           (2, 'Comercial','C'),
           (3, 'Particular','P')
GO
