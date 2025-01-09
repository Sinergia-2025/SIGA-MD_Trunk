

CREATE TABLE [dbo].[HistorialConsultaProductos](
	[IdSucursal] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HistorialConsultaProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProducto] ASC,
	[FechaHora] ASC
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
ALTER TABLE dbo.ProductosSucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.HistorialConsultaProductos ADD CONSTRAINT
	FK_HistorialConsultaProductos_ProductosSucursales FOREIGN KEY
	(
	IdProducto,
	IdSucursal
	) REFERENCES dbo.ProductosSucursales
	(
	IdProducto,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.HistorialConsultaProductos SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE dbo.HistorialConsultaProductos ADD CONSTRAINT
	FK_HistorialConsultaProductos_Usuarios FOREIGN KEY
	(
	Usuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.HistorialConsultaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
