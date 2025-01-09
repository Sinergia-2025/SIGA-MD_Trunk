
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
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO


PRINT '1. Agrego el campo nuevo "TipoEstadoPedido" en EstadosPedidos'
ALTER TABLE dbo.EstadosPedidos ADD TipoEstadoPedido varchar(15) NULL
GO
PRINT '1.1. Le pongo valores por defecto a los registros pre-existentes'
UPDATE EstadosPedidos SET TipoEstadoPedido = 'PEDIDOSCLIE';
PRINT '1.2. Lo hago NOT NULL'
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN TipoEstadoPedido varchar(15) NOT NULL
GO

PRINT '2. Drop de la FK entre EstadosPedidos y PedidosEstados'
ALTER TABLE dbo.PedidosEstados DROP CONSTRAINT FK_PedidosEstados_EstadosPedidos
GO
PRINT '3. Drop de la PK'
ALTER TABLE dbo.EstadosPedidos DROP CONSTRAINT PK_EstadosPedidos
GO

PRINT '4. Creo la nueva PK'
ALTER TABLE dbo.EstadosPedidos ADD CONSTRAINT PK_EstadosPedidos PRIMARY KEY CLUSTERED 
	(idEstado,TipoEstadoPedido)
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT '5. Agrego el campo nuevo "TipoEstadoPedido" en PedidosEstados'
ALTER TABLE dbo.PedidosEstados ADD TipoEstadoPedido varchar(15) NULL
GO
PRINT '5.1. Le pongo valores por defecto a los registros pre-existentes'
UPDATE PedidosEstados SET TipoEstadoPedido = 'PEDIDOSCLIE';
ALTER TABLE dbo.PedidosEstados ALTER COLUMN TipoEstadoPedido varchar(15) NOT NULL
GO
PRINT '5.2. Lo hago NOT NULL'
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO

PRINT '6. Creo la FK entre EstadosPedidos y PedidosEstados nuevamente'
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_EstadosPedidos
    FOREIGN KEY (IdEstado,TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidos (idEstado,TipoEstadoPedido) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '7. Inserto Datos en tabla EstadosPedidos.'

INSERT EstadosPedidos 
   (idEstado, IdTipoComprobante, IdTipoEstado, Orden, AfectaPendiente, TipoEstadoPedido) 
VALUES ('ANULADO', NULL, 'ANULADO', 40, 'True', 'PRESUPCLIE'),
       ('APROBADO', 'PEDIDO', 'ENTREGADO', 30, 'True', 'PRESUPCLIE'),
       ('NEGOCIANDO', NULL, 'EN PROCESO', 20, 'False', 'PRESUPCLIE'),
       ('PENDIENTE', NULL, 'PENDIENTE', 10, 'False', 'PRESUPCLIE')
GO
