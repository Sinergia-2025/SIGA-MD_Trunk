/****** Object:  Table dbo.PedidosEstadosProveedores    Script Date: 11/29/2017 16:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.PedidosEstadosProveedores(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroPedido bigint NOT NULL,
	IdProducto varchar(15) NOT NULL,
	Orden int NOT NULL,
	FechaEstado datetime NOT NULL,
	
	IdProveedor bigint NULL,
	IdEstado varchar(10) NOT NULL,
	IdUsuario varchar(10) NOT NULL,
	Observacion varchar(100) NOT NULL,
	IdCriticidad varchar(10) NOT NULL,
	FechaEntrega date NOT NULL,
	NumeroReparto int NULL,
	CantEstado decimal(12, 2) NOT NULL,
	TipoEstadoPedido varchar(15) NOT NULL,

	--FK a Factura
	IdTipoComprobanteFact varchar(15) NULL,
	LetraFact varchar(1) NULL,
	CentroEmisorFact int NULL,
	NumeroComprobanteFact bigint NULL,

	--FK a Pedido Generado
	IdSucursalGenerado int NULL,
	IdTipoComprobanteGenerado varchar(15) NULL,
	LetraGenerado varchar(1) NULL,
	CentroEmisorGenerado int NULL,
	NumeroPedidoGenerado bigint NULL,

	--FK a Remito
	IdSucursalRemito int NULL,
	IdTipoComprobanteRemito varchar(15) NULL,
	LetraRemito varchar(1) NULL,
	CentroEmisorRemito int NULL,
	NumeroComprobanteRemito bigint NULL,
 CONSTRAINT PK_PedidosEstadosProveedores PRIMARY KEY CLUSTERED 
(
	IdSucursal ASC,
	IdTipoComprobante ASC,
	Letra ASC,
	CentroEmisor ASC,
	NumeroPedido ASC,
	IdProducto ASC,
	Orden ASC,
	FechaEstado ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_EstadosPedidosProveedores FOREIGN KEY(IdEstado, TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidosProveedores (idEstado, TipoEstadoPedido)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_EstadosPedidosProveedores
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_PedidosCriticidades FOREIGN KEY(IdCriticidad)
    REFERENCES dbo.PedidosCriticidades (IdCriticidad)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_PedidosCriticidades
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_PedidosProveedoresGenerado FOREIGN KEY(IdSucursalGenerado, IdTipoComprobanteGenerado, LetraGenerado, CentroEmisorGenerado, NumeroPedidoGenerado)
    REFERENCES dbo.PedidosProveedores (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_PedidosProveedoresGenerado
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_PedidosProductosProveedores FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden)
    REFERENCES dbo.PedidosProductosProveedores (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_PedidosProductosProveedores
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_TiposComprobantes FOREIGN KEY(IdTipoComprobante)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_TiposComprobantes
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_Usuarios FOREIGN KEY(IdUsuario)
    REFERENCES dbo.Usuarios (Id)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_Usuarios
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_Proveedores FOREIGN KEY(IdProveedor)
REFERENCES dbo.Proveedores (IdProveedor)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_Proveedores
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_Compras FOREIGN KEY(IdSucursal, IdTipoComprobanteFact, LetraFact, CentroEmisorFact, NumeroComprobanteFact, IdProveedor)
    REFERENCES dbo.Compras (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_Compras
GO

ALTER TABLE dbo.PedidosEstadosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_ComprasRemito FOREIGN KEY(IdSucursalRemito, IdTipoComprobanteRemito, LetraRemito, CentroEmisorRemito, NumeroComprobanteRemito, IdProveedor)
    REFERENCES dbo.Compras (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
GO
ALTER TABLE dbo.PedidosEstadosProveedores CHECK CONSTRAINT FK_PedidosEstadosProveedores_ComprasRemito
GO
