PRINT ''
PRINT '4. Tabla OrdenesProduccionMRPProductos: Nuevos campos Vinculacion'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'IdRequerimiento') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdRequerimiento bigint NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdProductoRQ Varchar(15) NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD OrdenRQ int NULL
END
GO

PRINT ''
PRINT '1.2. Tabla OrdenesProduccionMRPProductos: FK_Requerimiento_OrdenesProduccion'
IF dbo.ExisteFK('FK_Requerimiento_OrdenesProduccion') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos  WITH CHECK ADD  CONSTRAINT FK_Requerimiento_OrdenesProduccion FOREIGN KEY(IdRequerimiento, IdProductoRQ, OrdenRQ)
    REFERENCES RequerimientosComprasProductos (IdRequerimientoCompra, IdProducto, Orden)
    ALTER TABLE OrdenesProduccionMRPProductos CHECK CONSTRAINT FK_Requerimiento_OrdenesProduccion
END
GO