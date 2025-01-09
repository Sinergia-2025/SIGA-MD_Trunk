
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
ALTER TABLE dbo.PedidosEstados DROP CONSTRAINT FK_PedidosEstados_PedidosProductos
GO
ALTER TABLE dbo.PedidosEstados DROP CONSTRAINT PK_PedidosEstados
GO

EXECUTE sp_rename N'dbo.PedidosEstados.IdPedido', N'NumeroPedido', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidosEstados.IdTipoComprobante', N'IdTipoComprobanteFact', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidosEstados.Letra', N'LetraFact', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidosEstados.CentroEmisor', N'CentroEmisorFact', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidosEstados.NumeroComprobante', N'NumeroComprobanteFact', 'COLUMN' 
GO
ALTER TABLE dbo.PedidosEstados ADD IdTipoComprobante varchar(15) NULL
GO
ALTER TABLE dbo.PedidosEstados ADD Letra varchar(1) NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CentroEmisor int NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_TiposComprobantes 
    FOREIGN KEY (IdTipoComprobante) 
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
UPDATE PedidosEstados
   SET IdTipoComprobante = 'PEDIDO'
      ,Letra = 'X'
      ,CentroEmisor = 1
GO
ALTER TABLE dbo.PedidosEstados ALTER COLUMN IdTipoComprobante varchar(15) NOT NULL
GO
ALTER TABLE dbo.PedidosEstados ALTER COLUMN Letra varchar(1) NOT NULL
GO
ALTER TABLE dbo.PedidosEstados ALTER COLUMN CentroEmisor int NOT NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT
	PK_PedidosEstados PRIMARY KEY CLUSTERED 
	(IdSucursal,NumeroPedido,IdProducto,FechaEstado,Orden,IdTipoComprobante,Letra,CentroEmisor) 
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



ALTER TABLE dbo.PedidosProductos DROP CONSTRAINT FK_PedidosProductos_Pedidos
GO
ALTER TABLE dbo.PedidosProductos DROP CONSTRAINT PK_PedidosProductos
GO
EXECUTE sp_rename N'dbo.PedidosProductos.IdPedido', N'NumeroPedido', 'COLUMN' 
GO

ALTER TABLE dbo.PedidosProductos ADD IdTipoComprobante varchar(15) NULL
GO
ALTER TABLE dbo.PedidosProductos ADD Letra varchar(1) NULL
GO
ALTER TABLE dbo.PedidosProductos ADD CentroEmisor int NULL
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_TiposComprobantes 
    FOREIGN KEY (IdTipoComprobante) 
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
UPDATE PedidosProductos
   SET IdTipoComprobante = 'PEDIDO'
      ,Letra = 'X'
      ,CentroEmisor = 1
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN IdTipoComprobante varchar(15) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN Letra varchar(1) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN CentroEmisor int NOT NULL
GO

ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT
	PK_PedidosProductos PRIMARY KEY CLUSTERED 
	(IdSucursal,NumeroPedido,IdProducto,Orden,IdTipoComprobante,Letra,CentroEmisor) 
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_PedidosProductos 
    FOREIGN KEY (IdSucursal,NumeroPedido,IdProducto,Orden,IdTipoComprobante,Letra,CentroEmisor) 
    REFERENCES dbo.PedidosProductos
    (IdSucursal,NumeroPedido,IdProducto,Orden,IdTipoComprobante,Letra,CentroEmisor)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


ALTER TABLE dbo.Pedidos DROP CONSTRAINT PK_Pedidos
GO

EXECUTE sp_rename N'dbo.Pedidos.IdPedido', N'NumeroPedido', 'COLUMN' 
GO

ALTER TABLE dbo.Pedidos ADD IdTipoComprobante varchar(15) NULL
GO
ALTER TABLE dbo.Pedidos ADD Letra varchar(1) NULL
GO
ALTER TABLE dbo.Pedidos ADD CentroEmisor int NULL
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_TiposComprobantes 
    FOREIGN KEY (IdTipoComprobante) 
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
UPDATE Pedidos
   SET IdTipoComprobante = 'PEDIDO'
      ,Letra = 'X'
      ,CentroEmisor = 1
GO
ALTER TABLE dbo.Pedidos ALTER COLUMN IdTipoComprobante varchar(15) NOT NULL
GO
ALTER TABLE dbo.Pedidos ALTER COLUMN Letra varchar(1) NOT NULL
GO
ALTER TABLE dbo.Pedidos ALTER COLUMN CentroEmisor int NOT NULL
GO

ALTER TABLE dbo.Pedidos ADD CONSTRAINT
	PK_Pedidos PRIMARY KEY CLUSTERED 
	(IdSucursal,NumeroPedido,IdTipoComprobante,Letra,CentroEmisor) 
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT
    FK_PedidosProductos_Pedidos FOREIGN KEY
    (IdSucursal,NumeroPedido,IdTipoComprobante,Letra,CentroEmisor)
    REFERENCES dbo.Pedidos
    (IdSucursal,NumeroPedido,IdTipoComprobante,Letra,CentroEmisor)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
