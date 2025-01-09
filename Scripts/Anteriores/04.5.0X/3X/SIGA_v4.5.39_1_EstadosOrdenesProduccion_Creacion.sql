
/****** Object:  Table [dbo].[EstadosOrdenesProduccion]    Script Date: 18/4/2017 16:16:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstadosOrdenesProduccion](
	[idEstado] [varchar](10) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[IdTipoEstado] [varchar](10) NOT NULL,
	[Orden] [int] NOT NULL,
	[AfectaPendiente] [bit] NOT NULL,
 CONSTRAINT [PK_EstadosOrdenesProduccion] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstadosOrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_EstadosOrdenesProduccion_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[EstadosOrdenesProduccion] CHECK CONSTRAINT [FK_EstadosOrdenesProduccion_TiposComprobantes]
GO



/* ---------- */

INSERT INTO EstadosOrdenesProduccion
           (IdEstado, IdTipoComprobante, IdTipoEstado, Orden, AfectaPendiente)
     VALUES
           ('PENDIENTE', NULL, 'PENDIENTE', 10, 'False'),
           ('EN PROCESO', NULL, 'EN PROCESO', 20, 'False'),
           ('ANULADO', NULL, 'ANULADO', 30, 'True'),
           ('FINALIZADO', NULL, 'FINALIZADO', 40, 'True')
GO
