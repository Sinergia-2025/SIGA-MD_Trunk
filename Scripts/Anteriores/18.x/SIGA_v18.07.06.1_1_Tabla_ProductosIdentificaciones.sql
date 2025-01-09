/****** Object:  Table [dbo].[ProductosIdentificaciones]    Script Date: 06/07/2018 10:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductosIdentificaciones](
	[IdProducto] [varchar](15) NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductosIdentificaciones] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosIdentificaciones]  WITH CHECK ADD  CONSTRAINT [FK_ProductosIdentificaciones_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosIdentificaciones] CHECK CONSTRAINT [FK_ProductosIdentificaciones_Productos]
GO
