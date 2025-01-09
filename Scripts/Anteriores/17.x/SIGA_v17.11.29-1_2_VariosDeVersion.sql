
PRINT '1. Tabla Parametros: cambio ancho a ValorParametro (200).'

ALTER TABLE Parametros ALTER COLUMN ValorParametro VARCHAR(200) NULL
GO


PRINT ''
PRINT '2. Tabla EstadosPedidos: agrego campo ReservaStock.'


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosPedidos ADD ReservaStock bit NULL
GO
UPDATE EstadosPedidos SET ReservaStock = 0;
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN ReservaStock bit NOT NULL
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla EstadosPedidos: Agrego registro RESERVAR.'


INSERT INTO EstadosPedidos
           (idEstado,IdTipoComprobante,IdTipoEstado,Orden
           ,AfectaPendiente,TipoEstadoPedido,Color,ReservaStock)
     VALUES
           ('RESERVAR',NULL,'EN PROCESO', 15,
            0,'PEDIDOSCLIE',-32640,1)
GO


PRINT ''
PRINT '4. Tabla TiposMovimientos: Seteo CoeficienteStock a RESERVA.'


UPDATE TiposMovimientos
   SET CoeficienteStock = 1
 WHERE IdTipoMovimiento = 'RESERVA'
GO
