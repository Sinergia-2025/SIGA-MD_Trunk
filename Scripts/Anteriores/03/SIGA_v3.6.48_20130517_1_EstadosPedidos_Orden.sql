
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
ALTER TABLE dbo.EstadosPedidos ADD Orden int NULL
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------- Asigno un Orden Inicial ---------- */ 
   
UPDATE EstadosPedidos SET
   Orden = 
   (CASE IdEstado WHEN 'PENDIENTE' THEN 10
            WHEN 'EN PROCESO' THEN 20
            WHEN 'ANULADO' THEN 30
            WHEN 'FINALIZADO' THEN 40 
            ELSE 0 END)
GO


/* -------------- */

ALTER TABLE dbo.EstadosPedidos ALTER COLUMN Orden int NOT NULL
GO


