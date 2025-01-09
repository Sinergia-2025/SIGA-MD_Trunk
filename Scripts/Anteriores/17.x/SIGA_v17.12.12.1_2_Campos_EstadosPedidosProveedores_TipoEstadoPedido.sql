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
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
--ALTER TABLE dbo.PedidosEstadosProveedores SET (LOCK_ESCALATION = TABLE)
--GO

PRINT '1. Cambio el Tipo al Tipo de Comprobante PEDIDOPROVEEDOR y le pone PEDIDOSPROV'
UPDATE TiposComprobantes
   SET Tipo = 'PEDIDOSPROV'
 WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'
;

PRINT '2. Agrego el campo nuevo "TipoEstadoPedido" en EstadosPedidosProveedores'
EXECUTE sp_rename N'dbo.EstadosPedidosProveedores.idEstado', N'IdEstado', 'COLUMN' 
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD TipoEstadoPedido varchar(15) NULL
GO
PRINT '2.1. Le pongo valores por defecto a los registros pre-existentes'
UPDATE EstadosPedidosProveedores SET TipoEstadoPedido = 'PEDIDOSPROV';
PRINT '2.2. Lo hago NOT NULL'
ALTER TABLE dbo.EstadosPedidosProveedores ALTER COLUMN TipoEstadoPedido varchar(15) NOT NULL
GO

PRINT '3. Drop de la PK'
ALTER TABLE dbo.EstadosPedidosProveedores DROP CONSTRAINT PK_EstadosPedidosProveedores
GO

PRINT '4. Creo la nueva PK'
ALTER TABLE dbo.EstadosPedidosProveedores ADD CONSTRAINT PK_EstadosPedidosProveedores PRIMARY KEY CLUSTERED 
	(IdEstado,TipoEstadoPedido)
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
