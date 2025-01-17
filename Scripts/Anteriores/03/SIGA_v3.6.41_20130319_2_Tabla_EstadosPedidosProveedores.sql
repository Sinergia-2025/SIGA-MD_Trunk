
/****** Object:  Table [dbo].[EstadosPedidosProveedores]    Script Date: 01/04/2013 19:32:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstadosPedidosProveedores](
	[idEstado] [varchar](10) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
 CONSTRAINT [PK_EstadosPedidosProveedores] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstadosPedidosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_EstadosPedidosProveedores_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[EstadosPedidosProveedores] CHECK CONSTRAINT [FK_EstadosPedidosProveedores_TiposComprobantes]
GO


/* ---------------------------------- */

INSERT [dbo].[EstadosPedidosProveedores] ([idEstado], [IdTipoComprobante]) VALUES ('PENDIENTE', NULL)
GO
INSERT [dbo].[EstadosPedidosProveedores] ([idEstado], [IdTipoComprobante]) VALUES ('EN PROCESO', NULL)
GO
INSERT [dbo].[EstadosPedidosProveedores] ([idEstado], [IdTipoComprobante]) VALUES ('CANCELADO', NULL)
GO
INSERT [dbo].[EstadosPedidosProveedores] ([idEstado], [IdTipoComprobante]) VALUES ('FINALIZADO', NULL)
GO
