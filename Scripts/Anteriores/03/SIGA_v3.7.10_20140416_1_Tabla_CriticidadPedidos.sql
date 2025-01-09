--DROP TABLE [dbo].[CriticidadPedidos]
--GO

BEGIN TRANSACTION
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosCriticidades](
	[IdCriticidad] [varchar](10) NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_PedidosCriticidades] PRIMARY KEY CLUSTERED 
(
	[IdCriticidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

COMMIT

/* ---------------- */

INSERT [dbo].[PedidosCriticidades] (IdCriticidad, Orden) VALUES ('Normal', 1)
GO

INSERT [dbo].[PedidosCriticidades] (IdCriticidad, Orden) VALUES ('Alta', 2)
GO

INSERT [dbo].[PedidosCriticidades] (IdCriticidad, Orden) VALUES ('Muy Alta', 3)
GO

INSERT [dbo].[PedidosCriticidades] (IdCriticidad, Orden) VALUES ('Baja', 4)
GO
