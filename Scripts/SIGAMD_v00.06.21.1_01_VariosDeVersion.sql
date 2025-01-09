PRINT ''
PRINT '1. Tabla MRPProcesosProductivosProductos: Ajustar tipo de dato de CantidadSolicitada y PrecioCostoProducto'
BEGIN
    ALTER TABLE MRPProcesosProductivosProductos ALTER COLUMN CantidadSolicitada decimal(16,4) NOT NULL
    ALTER TABLE MRPProcesosProductivosProductos ALTER COLUMN PrecioCostoProducto decimal(16,4) NOT NULL
END
GO

PRINT ''
PRINT '2. Tabla OrdenesProduccionMRPProductos: Ajustar tipo de dato de CantidadSolicitada y PrecioCostoProducto'
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ALTER COLUMN CantidadSolicitada decimal(16,4) NOT NULL
    ALTER TABLE OrdenesProduccionMRPProductos ALTER COLUMN PrecioCostoProducto decimal(16,4) NOT NULL
END
GO

PRINT ''
PRINT '3. Tabla MRPProcesosProductivosOperaciones: Nuevo campo DescripcionProceso'
IF dbo.ExisteCampo('OrdenesProduccionMRP', 'DescripcionProceso') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRP ALTER COLUMN DescripcionProceso varchar(MAX) NOT NULL
END
GO

PRINT ''
PRINT '4.1. Tabla OrdenesProduccionMRP: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRP', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRP.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT '4.2. Tabla OrdenesProduccionMRPOperacion: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPOperaciones.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT '4.3. Tabla OrdenesProduccionMRPProductos: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPProductos.Letra', 'LetraComprobante', 'COLUMN'  
END
GO
PRINT ''
PRINT '4.4. Tabla OrdenesProduccionMRPCategoriasEmpleados: cambia Nombre Campos Letra'
IF dbo.ExisteCampo('OrdenesProduccionMRPCategoriasEmpleados', 'Letra') = 1
BEGIN
	EXEC SP_RENAME 'OrdenesProduccionMRPCategoriasEmpleados.Letra', 'LetraComprobante', 'COLUMN'  
END
GO

PRINT ''
PRINT '5. Tabla MRPProcesosProductivosOperaciones: Cambiar tamaño del campo DescripcionProceso'
BEGIN
    ALTER TABLE MRPProcesosProductivos ALTER COLUMN DescripcionProceso varchar(MAX) NOT NULL
END
GO

