
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
ALTER TABLE dbo.EstadosPedidos ADD AfectaPendiente bit NULL
GO
UPDATE dbo.EstadosPedidos SET AfectaPendiente = 0
GO
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN AfectaPendiente bit NOT NULL
GO
UPDATE dbo.EstadosPedidos 
   SET AfectaPendiente = 1 
 WHERE IdTipoEstado IN ('ENTREGADO', 'CANCELADO', 'ANULADO','FINALIZADO')
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* --------------------------- */

SELECT * FROM dbo.EstadosPedidos
 ORDER BY AfectaPendiente, IdTipoEstado
GO
