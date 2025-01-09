/****** Object:  Table dbo.PedidosProveedores    Script Date: 11/29/2017 15:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.PedidosProveedores(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroPedido bigint NOT NULL,

	IdProveedor bigint NOT NULL,
	FechaPedido datetime NOT NULL,
	Observacion varchar(100) NOT NULL,
	IdUsuario varchar(10) NOT NULL,
	DescuentoRecargo decimal(14, 4) NOT NULL,
	DescuentoRecargoPorc decimal(6, 2) NOT NULL,
	TipoDocComprador varchar(5) NULL,
	NroDocComprador varchar(12) NULL,
	IdFormasPago int NULL,
	IdTransportista int NULL,
	CotizacionDolar decimal(7, 3) NULL,
	IdTipoComprobanteFact varchar(15) NULL,
	ImporteBruto decimal(12, 2) NOT NULL,
	SubTotal decimal(12, 2) NOT NULL,
	TotalImpuestos decimal(12, 2) NOT NULL,
	TotalImpuestoInterno decimal(14, 2) NOT NULL,
	ImporteTotal decimal(12, 2) NOT NULL,
	IdEstadoVisita int NOT NULL,
	NumeroOrdenCompra bigint NULL,
	Kilos decimal(10, 3) NOT NULL,
 CONSTRAINT PK_PedidosProveedores PRIMARY KEY CLUSTERED 
(
	IdSucursal ASC,
	IdTipoComprobante ASC,
	Letra ASC,
	CentroEmisor ASC,
	NumeroPedido ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_Proveedores FOREIGN KEY(IdProveedor)
REFERENCES dbo.Proveedores (IdProveedor)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_Proveedores
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_Empleados FOREIGN KEY(TipoDocComprador, NroDocComprador)
REFERENCES dbo.Empleados (TipoDocEmpleado, NroDocEmpleado)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_Empleados
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_EstadosVisitas FOREIGN KEY(IdEstadoVisita)
REFERENCES dbo.EstadosVisitas (IdEstadoVisita)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_EstadosVisitas
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_Sucursales FOREIGN KEY(IdSucursal)
REFERENCES dbo.Sucursales (IdSucursal)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_Sucursales
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_TiposComprobantes FOREIGN KEY(IdTipoComprobante)
REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_TiposComprobantes
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_TiposComprobantesFact FOREIGN KEY(IdTipoComprobanteFact)
REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_TiposComprobantesFact
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_Transportistas FOREIGN KEY(IdTransportista)
REFERENCES dbo.Transportistas (IdTransportista)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_Transportistas
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_Usuarios FOREIGN KEY(IdUsuario)
REFERENCES dbo.Usuarios (Id)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_Usuarios
GO

ALTER TABLE dbo.PedidosProveedores  WITH CHECK ADD  CONSTRAINT FK_PedidosProveedores_VentasFormasPago FOREIGN KEY(IdFormasPago)
REFERENCES dbo.VentasFormasPago (IdFormasPago)
GO
ALTER TABLE dbo.PedidosProveedores CHECK CONSTRAINT FK_PedidosProveedores_VentasFormasPago
GO
