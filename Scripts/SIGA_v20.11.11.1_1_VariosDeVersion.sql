PRINT ''
PRINT '1. Nuevos Campos: Imprime / Reporte / Embebido en CRMTiposNovedades'
ALTER TABLE CRMTiposNovedades ADD Reporte VARCHAR(150) NULL
ALTER TABLE CRMTiposNovedades ADD Embebido BIT NULL
GO

PRINT ''
PRINT '2. Actualizacion de registros pre-existentes'
UPDATE TN SET TN.Embebido = 0 FROM CRMTiposNovedades TN
GO

PRINT ''
PRINT '3. Cambio los campos a NOT NULL'
ALTER TABLE CRMTiposNovedades ALTER COLUMN Embebido BIT NOT NULL
GO

PRINT ''
PRINT '4. Configuración de impresión para tablero SERVICE'
UPDATE CRMTiposNovedades SET Reporte = 'Eniac.Win.CRMServiceRecepcion.rdlc', Embebido = 'True' WHERE IdTipoNovedad = 'SERVICE'
GO