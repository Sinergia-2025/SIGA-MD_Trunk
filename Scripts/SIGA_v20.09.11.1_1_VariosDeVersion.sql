/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

PRINT ''
PRINT '1. Tabla CuentasCorrientes: Agrega campo FechaEnvioCorreo '
ALTER TABLE CuentasCorrientes ADD FechaEnvioCorreo datetime null
GO

PRINT ''
PRINT '2. Tabla Proveedores: Nuevo Campo CodigoProveedorLetras'
ALTER TABLE Proveedores ADD CodigoProveedorLetras varchar(50) null
GO
PRINT ''
PRINT '2.1. Tabla Proveedores: Valor por defecto a CodigoProveedorLetras'
UPDATE Proveedores SET  CodigoProveedorLetras = CodigoProveedor 
PRINT ''
PRINT '2.2. Tabla Proveedores: NOT NULL para CodigoProveedorLetras'
ALTER TABLE Proveedores ALTER COLUMN CodigoProveedorLetras varchar(50) not null
GO

PRINT ''
PRINT '3. Tabla PedidosEstadosProveedores: Agrega campo IdEstado* y FechaEstado*'
ALTER TABLE dbo.PedidosEstadosProveedores ADD IdEstadoProducto varchar(10) NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD IdEstadoCantidad varchar(10) NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD IdEstadoPrecio varchar(10) NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD IdEstadoFechaEntrega varchar(10) NULL

ALTER TABLE dbo.PedidosEstadosProveedores ADD FechaEstadoProducto datetime NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD FechaEstadoCantidad datetime NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD FechaEstadoPrecio datetime NULL
ALTER TABLE dbo.PedidosEstadosProveedores ADD FechaEstadoFechaEntrega datetime NULL
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoProducto] FOREIGN KEY([IdEstadoProducto], [TipoEstadoPedido])
REFERENCES [dbo].[EstadosPedidosProveedores] ([IdEstado], [TipoEstadoPedido])
ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoProducto]
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoCantidad] FOREIGN KEY([IdEstadoCantidad], [TipoEstadoPedido])
REFERENCES [dbo].[EstadosPedidosProveedores] ([IdEstado], [TipoEstadoPedido])
ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoCantidad]
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoPrecio] FOREIGN KEY([IdEstadoPrecio], [TipoEstadoPedido])
REFERENCES [dbo].[EstadosPedidosProveedores] ([IdEstado], [TipoEstadoPedido])
ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoPrecio]
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoFechaEntrega] FOREIGN KEY([IdEstadoFechaEntrega], [TipoEstadoPedido])
REFERENCES [dbo].[EstadosPedidosProveedores] ([IdEstado], [TipoEstadoPedido])
ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores_IdEstadoFechaEntrega]
GO

ALTER TABLE dbo.PedidosEstadosProveedores SET (LOCK_ESCALATION = TABLE)
GO
