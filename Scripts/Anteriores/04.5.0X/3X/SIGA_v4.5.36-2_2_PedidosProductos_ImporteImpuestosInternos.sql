
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
ALTER TABLE dbo.PedidosProductos ADD ImporteImpuestoInterno decimal(14, 2) NULL
GO
UPDATE PedidosProductos
   SET ImporteImpuestoInterno = P.ImporteImpuestoInterno
  FROM PedidosProductos PP
 INNER JOIN Productos P ON P.IdProducto = PP.IdProducto
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN ImporteImpuestoInterno decimal(14, 2) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
