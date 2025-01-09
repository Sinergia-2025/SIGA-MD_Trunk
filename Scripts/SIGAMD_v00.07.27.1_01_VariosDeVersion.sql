PRINT ''
PRINT 'T1. Tabla OrdenesProduccionEstados: Nuevos campos Vinculacion'
IF dbo.ExisteCampo('OrdenesProduccionEstados', 'PlanMaestroNumero') = 0
BEGIN
    ALTER TABLE OrdenesProduccionEstados ADD PlanMaestroNumero int NULL
    ALTER TABLE OrdenesProduccionEstados ADD PlanMaestroFecha Datetime NULL
END
GO

PRINT ''
PRINT 'T1. Tabla OrdenesProduccionMRPOperaciones: Nuevos campos.'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'IdEstadoTarea') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD IdEstadoTarea varchar(15) NULL
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD FechaComienzo datetime NULL
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD IdEmpleado int NULL
END
GO

PRINT ''
PRINT 'T2. Tabla OrdenesProduccionMRPProductos: Nuevos campos.'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'EstadoCompra') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD EstadoCompra varchar(15) NULL

END
GO

IF dbo.ExisteCampo('PedidosProductos', 'IdProcesoProductivo') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductos ADD IdProcesoProductivo bigint NULL
END
GO
IF dbo.ExisteFK('FK_PedidosProductos_MRPProcesosProductivos') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_MRPProcesosProductivos
        FOREIGN KEY (IdProcesoProductivo)
        REFERENCES dbo.MRPProcesosProductivos (IdProcesoProductivo)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION
END
GO

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
