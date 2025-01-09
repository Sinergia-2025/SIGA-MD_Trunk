
ALTER TABLE dbo.PedidosEstados ADD IdCriticidad varchar(10) NULL
GO

ALTER TABLE dbo.PedidosEstados ADD FechaEntrega date NULL
GO

/* ---------------- */

UPDATE PedidosEstados
   SET IdCriticidad = 'Normal'
      ,FechaEntrega =  ( SELECT FechaPedido FROM Pedidos P
                         WHERE PedidosEstados.IdSucursal = P.IdSucursal
                           AND PedidosEstados.IdPedido = P.IdPedido)

 WHERE IdCriticidad IS NULL
GO

ALTER TABLE dbo.PedidosEstados ALTER COLUMN IdCriticidad varchar(10) NOT NULL
GO

ALTER TABLE dbo.PedidosEstados ALTER COLUMN FechaEntrega date NOT NULL
GO


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
ALTER TABLE dbo.PedidosCriticidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT
	FK_PedidosEstados_PedidosCriticidades FOREIGN KEY
	(
	IdCriticidad
	) REFERENCES dbo.PedidosCriticidades
	(
	IdCriticidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
