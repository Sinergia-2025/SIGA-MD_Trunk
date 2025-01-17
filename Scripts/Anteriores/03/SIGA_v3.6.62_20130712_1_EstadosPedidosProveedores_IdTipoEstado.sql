
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
ALTER TABLE dbo.EstadosPedidosProveedores ADD IdTipoEstado varchar(10) NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* --------------- */

UPDATE dbo.EstadosPedidosProveedores
   SET IdTipoEstado = IdEstado
GO

ALTER TABLE dbo.EstadosPedidosProveedores ALTER COLUMN IdTipoEstado varchar(10) NOT NULL
GO

