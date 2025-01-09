

PRINT ''
PRINT '1. Tabla Productos: Nuevo campo Observacion Certificado Entregado'
ALTER TABLE Productos ADD CalidadNroCertEObs varchar(50) null
GO

ALTER TABLE AuditoriaProductos ADD CalidadNroCertEObs varchar(50) null
GO

