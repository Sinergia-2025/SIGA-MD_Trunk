PRINT ''
PRINT '1. Nuevo Campo en Proyectos: HsRealEstimadas'
ALTER TABLE Proyectos ADD HsRealEstimadas DECIMAL(12,2) NULL
GO

PRINT ''
PRINT '2. Nuevo Campo en Proyectos: FechaFinReal'
ALTER TABLE Proyectos ADD FechaFinReal DATETIME NULL
GO

PRINT ''
PRINT '3. Actualización de Datos históricos'
UPDATE P SET P.HsRealEstimadas = 0 FROM Proyectos P
GO
UPDATE P SET P.FechaFinReal = (C.FechaInicioReal) FROM Proyectos P
 INNER JOIN Clientes C ON P.IdCliente = C.IdCliente
GO

PRINT ''
PRINT '4. Actualizo los campos a NOT NULL'
ALTER TABLE Proyectos ALTER COLUMN HsRealEstimadas DECIMAL(12,2) NOT NULL
GO

PRINT ''
PRINT '5. Nuevo Campo en CRMTiposNovedades: RequierePadre'
ALTER TABLE CRMTiposNovedades ADD RequierePadre BIT NULL
GO

PRINT ''
PRINT '5.1. Actualización de datos pre-existentes'
UPDATE CTN SET CTN.RequierePadre = 0 FROM CRMTiposNovedades CTN
GO

PRINT ''
PRINT '5.2. Cambio el campo a NOT NULL'
ALTER TABLE CRMTiposNovedades ALTER COLUMN RequierePadre BIT NOT NULL
GO
