PRINT '1. Asociar COTIZACION DE COMPRAS a Tipo de Movimiento'
UPDATE TiposMovimientos SET
     ComprobantesAsociados = ComprobantesAsociados + ',COTIZACIONCOM,COTIZACIONNDCOM'
  WHERE IdTipoMovimiento = 'COMPRA'

UPDATE TiposMovimientos SET
     ComprobantesAsociados = ComprobantesAsociados + ',COTIZACIONNCCOM'
  WHERE IdTipoMovimiento = 'COMPRA-NC'
GO

PRINT '2. Crear campos Sesion Tabla Calendarios'
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Calendarios ADD Sesion bit NULL
GO
UPDATE Calendarios SET Sesion = 0
GO
ALTER TABLE Calendarios ALTER COLUMN Sesion bit NOT NULL
GO
COMMIT

PRINT '3. Crear campos NumeroSesion Tabla TurnosCalendarios'
ALTER TABLE dbo.TurnosCalendarios ADD NumeroSesion integer NULL
GO
