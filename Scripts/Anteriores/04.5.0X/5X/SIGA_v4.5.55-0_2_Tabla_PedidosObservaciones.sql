
/****** Object:  Table [dbo].[PedidosObservaciones]    Script Date: 09/27/2017 15:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PedidosObservaciones](
    [IdSucursal] [int] NOT NULL,
    [IdTipoComprobante] [varchar](15) NOT NULL,
    [Letra] [varchar](1) NOT NULL,
    [CentroEmisor] [int] NOT NULL,
    [NumeroPedido] [int] NOT NULL,
    [Linea] [int] NOT NULL,
    [Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PedidosObservaciones] PRIMARY KEY CLUSTERED 
   ([IdSucursal] ASC,
    [IdTipoComprobante] ASC,
    [Letra] ASC,
    [CentroEmisor] ASC,
    [NumeroPedido] ASC,
    [Linea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PedidosObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_PedidosObservaciones_Pedidos] FOREIGN KEY([IdSucursal], [NumeroPedido], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[Pedidos] ([IdSucursal], [NumeroPedido], [IdTipoComprobante], [Letra], [CentroEmisor])
GO
ALTER TABLE [dbo].[PedidosObservaciones] CHECK CONSTRAINT [FK_PedidosObservaciones_Pedidos]
GO
