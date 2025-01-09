
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME = 'PedidosEstados')
    BEGIN
		DROP TABLE dbo.PedidosEstados
    END
GO


/****** Object:  Table [dbo].[PedidosEstados]    Script Date: 12/12/2012 16:18:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosEstados](
	[IdSucursal] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaEstado] [datetime] NOT NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[CantEntregada] [decimal](12, 2) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
 CONSTRAINT [PK_PedidosEstados] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdPedido] ASC,
	[IdProducto] ASC,
	[FechaEstado] ASC
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
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT
	FK_PedidosEstados_PedidosProductos FOREIGN KEY
	(
	IdSucursal,
	IdPedido,
	IdProducto
	) REFERENCES dbo.PedidosProductos
	(
	IdSucursal,
	IdPedido,
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT
	FK_PedidosEstados_Ventas FOREIGN KEY
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) REFERENCES dbo.Ventas
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT
	FK_PedidosEstados_Usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
