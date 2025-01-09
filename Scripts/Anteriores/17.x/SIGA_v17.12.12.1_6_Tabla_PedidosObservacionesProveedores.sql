/****** Object:  Table dbo.PedidosObservacionesProveedores    Script Date: 11/30/2017 15:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE dbo.PedidosObservacionesProveedores(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroPedido bigint NOT NULL,
	Linea int NOT NULL,
	Observacion varchar(100) NOT NULL,
 CONSTRAINT PK_PedidosObservacionesProveedores PRIMARY KEY CLUSTERED 
(
	IdSucursal ASC,
	IdTipoComprobante ASC,
	Letra ASC,
	CentroEmisor ASC,
	NumeroPedido ASC,
	Linea ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.PedidosObservacionesProveedores WITH CHECK ADD  CONSTRAINT FK_PedidosObservacionesProveedores_PedidosProveedores FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
REFERENCES dbo.PedidosProveedores (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
GO

ALTER TABLE dbo.PedidosObservacionesProveedores CHECK CONSTRAINT FK_PedidosObservacionesProveedores_PedidosProveedores
GO


