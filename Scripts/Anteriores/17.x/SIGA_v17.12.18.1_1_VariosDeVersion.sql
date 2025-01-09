
PRINT '1. Tabla CRMEstadosNovedades: agregp campo "Color".'

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
ALTER TABLE dbo.CRMEstadosNovedades ADD Color int NULL
GO
ALTER TABLE dbo.CRMEstadosNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tablas PedidosProductos/VentasProductos: Agro campo "TipoOperacion" y Actualizo a "NORMAL".'

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
ALTER TABLE dbo.PedidosProductos ADD TipoOperacion varchar(15) NULL
ALTER TABLE dbo.PedidosProductos ADD Nota varchar(100) NULL
GO
UPDATE PedidosProductos SET TipoOperacion = 'NORMAL';
ALTER TABLE dbo.PedidosProductos ALTER COLUMN TipoOperacion varchar(15) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.VentasProductos ADD TipoOperacion varchar(15) NULL
ALTER TABLE dbo.VentasProductos ADD Nota varchar(100) NULL
GO
UPDATE VentasProductos SET TipoOperacion = 'NORMAL';
ALTER TABLE dbo.VentasProductos ALTER COLUMN TipoOperacion varchar(15) NOT NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
