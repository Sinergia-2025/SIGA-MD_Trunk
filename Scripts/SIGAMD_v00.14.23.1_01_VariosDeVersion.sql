IF dbo.ExisteCampo('PedidosEstadosProveedores', 'IdSucursalOpOperacionTallerExt') = 0
BEGIN
    ALTER TABLE dbo.PedidosEstadosProveedores ADD IdSucursalOpOperacionTallerExt int NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD IdTipoComprobanteOpOperacionTallerExt varchar(15) NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD LetraOpOperacionTallerExt varchar(1) NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD CentroEmisorOpOperacionTallerExt int NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD NumeroOrdenProduccionOpOperacionTallerExt int NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD OrdenOpOperacionTallerExt int NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD IdProductoOpOperacionTallerExt varchar(15) NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD IdProcesoProductivoOpOperacionTallerExt bigint NULL
    ALTER TABLE dbo.PedidosEstadosProveedores ADD IdOperacionOpOperacionTallerExt int NULL
END
GO

IF dbo.ExisteFK('FK_PedidosEstadosProveedores_OrdenesProduccionMRPOperaciones') = 0
BEGIN
    ALTER TABLE dbo.PedidosEstadosProveedores ADD CONSTRAINT
        FK_PedidosEstadosProveedores_OrdenesProduccionMRPOperaciones FOREIGN KEY (
        IdSucursalOpOperacionTallerExt, NumeroOrdenProduccionOpOperacionTallerExt, IdTipoComprobanteOpOperacionTallerExt,
        LetraOpOperacionTallerExt, CentroEmisorOpOperacionTallerExt, OrdenOpOperacionTallerExt, IdProductoOpOperacionTallerExt,
        IdProcesoProductivoOpOperacionTallerExt, IdOperacionOpOperacionTallerExt) 
        REFERENCES dbo.OrdenesProduccionMRPOperaciones (
        IdSucursal, NumeroOrdenProduccion, IdTipoComprobante,
        LetraComprobante, CentroEmisor, Orden, IdProducto,
        IdProcesoProductivo, IdOperacion) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
