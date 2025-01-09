
ALTER TABLE dbo.Pedidos ADD TipoDocVendedor varchar(5) NULL
GO
ALTER TABLE dbo.Pedidos ADD NroDocVendedor varchar(12) NULL
GO
ALTER TABLE dbo.Pedidos ADD IdFormasPago int NULL
GO
ALTER TABLE dbo.Pedidos ADD IdTransportista int NULL
GO
ALTER TABLE dbo.Pedidos ADD CotizacionDolar decimal(7, 3) NULL
GO
ALTER TABLE dbo.Pedidos ADD IdTipoComprobanteFact varchar(15) NULL
GO
ALTER TABLE dbo.PedidosProductos ADD FechaActualizacion datetime NULL
GO

ALTER TABLE dbo.Pedidos DROP COLUMN IdPeriodo
GO

ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_Empleados 
    FOREIGN KEY (TipoDocVendedor, NroDocVendedor)
    REFERENCES dbo.Empleados (TipoDocEmpleado, NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_VentasFormasPago
    FOREIGN KEY (IdFormasPago)
    REFERENCES dbo.VentasFormasPago (IdFormasPago)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_Transportistas
    FOREIGN KEY (IdTransportista)
    REFERENCES dbo.Transportistas (IdTransportista)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_TiposComprobantesFact
    FOREIGN KEY (IdTipoComprobanteFact)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
