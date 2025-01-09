
PRINT ''
PRINT '1.1. Tabla CalidadOCActivaciones: Agrega campos'

ALTER TABLE CalidadOCActivaciones ADD FechaReprogEntrega datetime null
GO

ALTER TABLE CalidadOCActivaciones ADD Criticidad varchar(30) null
GO

ALTER TABLE CalidadOCActivaciones ADD Items bit null
GO
UPDATE CalidadOCActivaciones SET Items = 'False'
GO
ALTER TABLE CalidadOCActivaciones ALTER COLUMN Items bit not null
GO

ALTER TABLE CalidadOCActivaciones ADD Cantidades bit null
GO
UPDATE CalidadOCActivaciones SET Cantidades = 'False'
GO
ALTER TABLE CalidadOCActivaciones ALTER COLUMN Cantidades bit not null
GO

ALTER TABLE CalidadOCActivaciones ADD Precio bit null
GO
UPDATE CalidadOCActivaciones SET Precio = 'False'
GO
ALTER TABLE CalidadOCActivaciones ALTER COLUMN Precio bit not null
GO

ALTER TABLE CalidadOCActivaciones ADD FechaE bit null
GO
UPDATE CalidadOCActivaciones SET FechaE = 'False'
GO
ALTER TABLE CalidadOCActivaciones ALTER COLUMN FechaE bit not null
GO

ALTER TABLE CalidadOCActivaciones ADD TelefonoProveedor varchar(100) null
GO

ALTER TABLE CalidadOCActivaciones ADD CorreoElectronico varchar(200) null
GO

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
PRINT ''
PRINT '1.1. Sincronizar OC Bejerman: Configuraciones'


INSERT INTO [dbo].[Parametros]
           ([IdParametro]
           ,[ValorParametro]
           ,[CategoriaParametro]
           ,[DescripcionParametro]
           ,[IdEmpresa])
     VALUES
           ('BEJERMANFECHAMODIFICACIONORDENCOMPRA',	'2021-12-21 09:32:38.000',	'WEB-ARCHIVOS',	'', 	1)


INSERT INTO [dbo].[Parametros]
           ([IdParametro]
           ,[ValorParametro]
           ,[CategoriaParametro]
           ,[DescripcionParametro]
           ,[IdEmpresa])
     VALUES
	 ('BEJERMANFECHAMODIFICACIONPROVEEDOR',	'2021-12-10 14:36:05.000',	'WEB-ARCHIVOS', '',		1)

INSERT INTO [dbo].[CalidadProductosTiposServicios]
           ([IdProductoTipoServicio]
           ,[NombreProductoTipoServicio]
           ,[Prefijo])
     VALUES
           (3,	'CHASIS', '')

INSERT INTO [dbo].[CalidadProductosTiposServicios]
           ([IdProductoTipoServicio]
           ,[NombreProductoTipoServicio]
           ,[Prefijo])
     VALUES
           (4,	'COMPRAS', '')

INSERT INTO [dbo].[EstadosPedidosProveedores]
           ([IdEstado]
           ,[IdTipoComprobante]
           ,[IdTipoEstado]
           ,[Orden]
           ,[TipoEstadoPedido]
           ,[Color]
           ,[TipoEstadoPedidoCliente]
           ,[IdEstadoPedidoCliente]
           ,[IdTipoMovimiento]
           ,[StockAfectado]
           ,[IdEstadoDestino])
     VALUES
           ('OBSERVAC.',	NULL,	'OBSERVAC.',	60,	'PEDIDOSPROV',	-16776961,	NULL,	NULL,	NULL,	NULL,	NULL)

END;

