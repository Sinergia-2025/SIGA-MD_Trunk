/****** Object:  Table dbo.PedidosProductosProveedores    Script Date: 11/29/2017 15:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.PedidosProductosProveedores(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroPedido bigint NOT NULL,
	IdProducto varchar(15) NOT NULL,
	Orden int NOT NULL,

	IdProveedor bigint NULL,
	Cantidad decimal(12, 4) NOT NULL,
	CostoLista decimal(12, 4) NOT NULL,
	Costo decimal(12, 4) NOT NULL,
	CostoNeto decimal(14, 4) NOT NULL,

	DescuentoRecargoPorc decimal(10, 5) NULL,
	DescuentoRecargoPorc2 decimal(10, 5) NULL,
	DescuentoRecargoProducto decimal(14, 4) NOT NULL,

	DescRecGeneral decimal(14, 4) NOT NULL,
	DescRecGeneralProducto decimal(14, 4) NOT NULL,

	AlicuotaImpuesto decimal(6, 2) NOT NULL,
	ImporteImpuesto decimal(14, 4) NOT NULL,
	ImpuestoInterno decimal(14, 2) NOT NULL,
	ImporteImpuestoInterno decimal(14, 2) NOT NULL,
	PorcImpuestoInterno decimal(5, 2) NOT NULL,

	ImporteTotal decimal(12, 4) NOT NULL,
	ImporteTotalNeto decimal(14, 4) NOT NULL,

	NombreProducto varchar(60) NOT NULL,
	CantEntregada decimal(12, 4) NOT NULL,
	CantEnProceso decimal(12, 4) NOT NULL,
	IdTipoImpuesto varchar(5) NOT NULL,
	FechaActualizacion datetime NULL,
	Kilos decimal(10, 3) NOT NULL,
	IdCriticidad varchar(10) NULL,
	FechaEntrega date NULL,
	CantAnulada decimal(12, 4) NOT NULL,
	CantPendiente decimal(12, 4) NOT NULL,

	CostoConImpuestos decimal(14, 4) NOT NULL,
	CostoNetoConImpuestos decimal(14, 4) NOT NULL,
	ImporteTotalConImpuestos decimal(14, 4) NOT NULL,
	ImporteTotalNetoConImpuestos decimal(14, 4) NOT NULL,

	--IdListaPrecios int NOT NULL,
	--NombreListaPrecios varchar(50) NOT NULL,
	--Precio decimal(12, 4) NOT NULL,
	--PrecioLista decimal(12, 4) NOT NULL,
 CONSTRAINT PK_PedidosProductosProveedores PRIMARY KEY CLUSTERED 
(
	IdSucursal ASC,
	IdTipoComprobante ASC,
	Letra ASC,
	CentroEmisor ASC,
	NumeroPedido ASC,
	IdProducto ASC,
	Orden ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.PedidosProductosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProductosProveedores_Proveedores FOREIGN KEY(IdProveedor)
REFERENCES dbo.Proveedores (IdProveedor)
GO
ALTER TABLE dbo.PedidosProductosProveedores CHECK CONSTRAINT FK_PedidosProductosProveedores_Proveedores
GO

ALTER TABLE dbo.PedidosProductosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProductosProveedores_PedidosProveedores FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
    REFERENCES dbo.PedidosProveedores (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
GO
ALTER TABLE dbo.PedidosProductosProveedores CHECK CONSTRAINT FK_PedidosProductosProveedores_PedidosProveedores
GO

ALTER TABLE dbo.PedidosProductosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProductosProveedores_PedidosCriticidades FOREIGN KEY(IdCriticidad)
    REFERENCES dbo.PedidosCriticidades (IdCriticidad)
GO
ALTER TABLE dbo.PedidosProductosProveedores CHECK CONSTRAINT FK_PedidosProductosProveedores_PedidosCriticidades
GO

ALTER TABLE dbo.PedidosProductosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProductosProveedores_Productos FOREIGN KEY(IdProducto)
REFERENCES dbo.Productos (IdProducto)
GO
ALTER TABLE dbo.PedidosProductosProveedores CHECK CONSTRAINT FK_PedidosProductosProveedores_Productos
GO

ALTER TABLE dbo.PedidosProductosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProductosProveedores_TiposComprobantes FOREIGN KEY(IdTipoComprobante)
REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
GO
ALTER TABLE dbo.PedidosProductosProveedores CHECK CONSTRAINT FK_PedidosProductosProveedores_TiposComprobantes
GO
