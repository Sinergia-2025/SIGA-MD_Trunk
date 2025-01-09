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
ALTER TABLE dbo.Productos ADD EspPulgadas varchar(30) NULL
GO
UPDATE Productos SET EspPulgadas = EspPies;
ALTER TABLE dbo.Productos DROP COLUMN EspPies
GO
ALTER TABLE dbo.AuditoriaProductos ADD EspPulgadas varchar(30) NULL
GO
UPDATE AuditoriaProductos SET EspPulgadas = EspPies;
ALTER TABLE dbo.AuditoriaProductos DROP COLUMN EspPies
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.PedidosProductos ADD EspPulgadas varchar(30) NULL
GO
UPDATE PedidosProductos SET EspPulgadas = EspPies;
ALTER TABLE dbo.PedidosProductos DROP COLUMN EspPies
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
