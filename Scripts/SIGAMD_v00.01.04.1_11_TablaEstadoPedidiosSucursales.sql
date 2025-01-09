PRINT ''
PRINT '1. Nuevo Tabla EstadosPedidosSucursales'
BEGIN
	CREATE TABLE EstadosPedidosSucursales(
		IdEstado varchar(10) NOT NULL,
		TipoEstadoPedido varchar(15) NOT NULL,
		IdSucursal int NOT NULL,
		IdDeposito int NULL,
		IdUbicacion int NULL,
	 CONSTRAINT [PK_EstadosPedidosSucursales] PRIMARY KEY CLUSTERED 
	(
		[IdEstado] ASC,
		[TipoEstadoPedido] ASC,
		[IdSucursal] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[EstadosPedidos]  WITH CHECK ADD  CONSTRAINT [FK_EstadosPedidosSucursales_TiposComprobantes] 
		FOREIGN KEY([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
	ALTER TABLE [dbo].[EstadosPedidos] CHECK CONSTRAINT [FK_EstadosPedidosSucursales_TiposComprobantes]

END
GO

