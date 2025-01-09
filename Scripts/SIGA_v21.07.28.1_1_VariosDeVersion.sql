

PRINT ''
PRINT '1. Tabla Productos: Nuevo campo Calidad Nro de Remito'
ALTER TABLE Productos ADD CalidadNroRemito bigint null
GO

ALTER TABLE AuditoriaProductos ADD CalidadNroRemito bigint null
GO

