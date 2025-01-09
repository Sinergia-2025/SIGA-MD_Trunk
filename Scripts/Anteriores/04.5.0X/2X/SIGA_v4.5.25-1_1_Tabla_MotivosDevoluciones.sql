
/****** Object:  Table [dbo].[MotivosDevoluciones]    Script Date: 08/03/2016 16:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MotivosDevoluciones](
	[IdMotivoDevolucion] [int] NOT NULL,
	[NombreMotivoDevolucion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_MotivosDevoluciones] PRIMARY KEY CLUSTERED 
(
	[IdMotivoDevolucion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
