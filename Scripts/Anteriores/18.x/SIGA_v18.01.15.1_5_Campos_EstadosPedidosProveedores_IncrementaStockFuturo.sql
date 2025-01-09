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
ALTER TABLE dbo.EstadosPedidosProveedores ADD IncrementaStockFuturo bit NULL
GO
UPDATE EstadosPedidosProveedores SET IncrementaStockFuturo = 0;
ALTER TABLE dbo.EstadosPedidosProveedores ALTER COLUMN IncrementaStockFuturo bit NOT NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
