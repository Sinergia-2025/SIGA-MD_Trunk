
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
ALTER TABLE dbo.EstadosPedidosProveedores ADD Orden int NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------------*/

INSERT INTO EstadosPedidosProveedores
   (IdEstado, IdTipoComprobante, IdTipoEstado, Orden)
  VALUES
   ('ANULADO', NULL, 'ANULADO', 0)
GO


/* ------- Asigno un Orden Inicial ---------- */ 
   
UPDATE EstadosPedidosProveedores SET
   Orden = 
   (CASE IdEstado WHEN 'PENDIENTE' THEN 10
            WHEN 'EN PROCESO' THEN 20
            WHEN 'ANULADO' THEN 30
            WHEN 'FINALIZADO' THEN 40 
            ELSE 0 END)
GO


/* -------------- */

ALTER TABLE dbo.EstadosPedidosProveedores ALTER COLUMN Orden int NOT NULL
GO


