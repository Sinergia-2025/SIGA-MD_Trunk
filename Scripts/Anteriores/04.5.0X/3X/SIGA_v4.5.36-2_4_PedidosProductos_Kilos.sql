
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
ALTER TABLE dbo.PedidosProductos ADD Kilos decimal(10, 3) NULL
GO
UPDATE PedidosProductos SET Kilos = 0
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN Kilos decimal(10, 3) NOT NULL
GO

ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
