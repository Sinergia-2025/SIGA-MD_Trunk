
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME = 'PedidosProductos')
    BEGIN
		DROP TABLE dbo.PedidosProductos
    END
GO


/****** Object:  Table [dbo].[PedidosProductos]    Script Date: 12/12/2012 16:18:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosProductos](
	[IdSucursal] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [decimal](12, 4) NOT NULL,
	[Precio] [decimal](12, 4) NOT NULL,
	[Costo] [decimal](12, 4) NOT NULL,
	[ImporteTotal] [decimal](12, 4) NOT NULL,
	[NombreProducto] [varchar](60) NOT NULL,
	[CantEntregada] [decimal](12, 4) NOT NULL,
 CONSTRAINT [PK_PedidosProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdPedido] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
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
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT
	FK_PedidosProductos_Pedidos FOREIGN KEY
	(
	IdSucursal,
	IdPedido
	) REFERENCES dbo.Pedidos
	(
	IdSucursal,
	IdPedido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT
	FK_PedidosProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
