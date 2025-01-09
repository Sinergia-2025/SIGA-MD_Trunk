
PRINT '1. Tabla VentasProductos: agrego campo PorcImpuestoInterno.'

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
ALTER TABLE dbo.VentasProductos ADD PorcImpuestoInterno decimal(5, 2) NULL
GO
UPDATE VentasProductos SET PorcImpuestoInterno = 0;
ALTER TABLE dbo.VentasProductos ALTER COLUMN PorcImpuestoInterno decimal(5, 2) NOT NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT ''
PRINT '2. Tabla Productos: agrego campo PorcImpuestoInterno.'


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
ALTER TABLE dbo.Productos ADD PorcImpuestoInterno decimal(5, 2) NULL
GO
UPDATE Productos SET PorcImpuestoInterno = 0;
ALTER TABLE dbo.Productos ALTER COLUMN PorcImpuestoInterno decimal(5, 2) NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD PorcImpuestoInterno decimal(5, 2) NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla PedidosProductos: agrego campo PorcImpuestoInterno.'

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
ALTER TABLE dbo.PedidosProductos ADD PorcImpuestoInterno decimal(5, 2) NULL
GO
UPDATE PedidosProductos SET PorcImpuestoInterno = 0;
ALTER TABLE dbo.PedidosProductos ALTER COLUMN PorcImpuestoInterno decimal(5, 2) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla PedidosProveedores: agrego campo NumeroOrdenCompra.'

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.PedidosProveedores ADD
	NumeroOrdenCompra bigint NULL
GO
ALTER TABLE dbo.PedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla Ventas: agrego campo NumeroOrdenCompra.'

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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD NumeroOrdenCompra bigint NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO

COMMIT



PRINT ''
PRINT '6. Tabla OrdenesCompra: agrego campo RespetaPreciosOrdenCompra.'

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.OrdenesCompra ADD
	RespetaPreciosOrdenCompra bit NULL
GO

UPDATE dbo.OrdenesCompra SET RespetaPreciosOrdenCompra = 1;
GO

ALTER TABLE dbo.OrdenesCompra ALTER COLUMN
	RespetaPreciosOrdenCompra bit NOT NULL
GO

ALTER TABLE dbo.OrdenesCompra SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

