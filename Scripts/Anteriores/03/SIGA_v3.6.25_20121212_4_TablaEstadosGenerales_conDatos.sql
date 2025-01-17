
/****** Object:  Table [dbo].[EstadosGenerales]    Script Date: 12/12/2012 16:21:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadosGenerales](
	[idUso] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
	[NomnreUso] [varchar](50) NULL,
	[NombreEstado] [varchar](50) NULL,
 CONSTRAINT [PK_EstadosGenerales] PRIMARY KEY CLUSTERED 
(
	[idUso] ASC,
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EstadosGenerales] ([idUso], [idEstado], [NomnreUso], [NombreEstado]) VALUES (1, 1, N'Pedidos', N'PENDIENTE')
INSERT [dbo].[EstadosGenerales] ([idUso], [idEstado], [NomnreUso], [NombreEstado]) VALUES (1, 2, N'Pedidos', N'PARCIAL')
INSERT [dbo].[EstadosGenerales] ([idUso], [idEstado], [NomnreUso], [NombreEstado]) VALUES (1, 3, N'Pedidos', N'CANCELADO')
INSERT [dbo].[EstadosGenerales] ([idUso], [idEstado], [NomnreUso], [NombreEstado]) VALUES (1, 4, N'Pedidos', N'FINALIZADO')
