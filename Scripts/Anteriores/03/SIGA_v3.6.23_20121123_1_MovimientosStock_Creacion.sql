
/****** Object:  Table [dbo].[MovimientosStock]    Script Date: 11/23/2012 16:48:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovimientosStock](
	[IdSucursal] [int] NOT NULL,
	[IdTipoMovimiento] [varchar](15) NOT NULL,
	[NumeroMovimiento] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[Cantidad] [decimal](14, 4) NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_MovimientosStock] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoMovimiento] ASC,
	[NumeroMovimiento] ASC,
	[IdProducto] ASC,
	[Orden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
