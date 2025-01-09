PRINT ''
PRINT '1. Parametro: MRP: Tipo Comprobante Orden de Produccion en Planificacion'
DECLARE @idParametro VARCHAR(MAX) = 'TIPOCOMPROBANTEORDENPRODUCCIONPLANIFICACION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Tipo Comprobante Orden de Produccion en Planificacion '
DECLARE @valorParametro VARCHAR(MAX) = 'ORDENPRODUCCION'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
IF dbo.ExisteCampo('OrdenesProduccionProductos', 'IdProcesoProductivo') = 0
BEGIN
    ALTER TABLE dbo.OrdenesProduccionProductos ADD IdProcesoProductivo bigint NULL
END
GO
IF dbo.ExisteFK('FK_OrdenesProduccionProductos_MRPProcesosProductivos') = 0
BEGIN
    ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_MRPProcesosProductivos
        FOREIGN KEY (IdProcesoProductivo)
        REFERENCES dbo.MRPProcesosProductivos (IdProcesoProductivo)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION
END
GO
IF dbo.ExisteIX('IX_Cheques_IdEstadoCheque') = 1
BEGIN
    DROP INDEX [IX_Cheques_IdEstadoCheque] ON [dbo].[Cheques]
END
GO

ALTER TABLE Cheques ALTER COLUMN Importe DECIMAL(14,2) NOT NULL
ALTER TABLE ChequesHistorial ALTER COLUMN Importe DECIMAL(14,2) NOT NULL

/****** Object:  Index [IX_Cheques_IdEstadoCheque]    Script Date: 17/8/2023 21:47:46 ******/
CREATE NONCLUSTERED INDEX [IX_Cheques_IdEstadoCheque] ON [dbo].[Cheques] ([IdEstadoCheque] ASC)
    INCLUDE([Importe],[IdCliente]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
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
PRINT ''
PRINT 'T1. Tabla OrdenesProduccionMRPProductos: Nuevos campos.'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'IdProductoOP') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdProductoOP varchar(15) NULL
END
GO