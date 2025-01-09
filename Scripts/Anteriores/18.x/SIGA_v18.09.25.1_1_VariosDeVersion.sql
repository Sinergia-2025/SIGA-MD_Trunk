
PRINT ''
PRINT '1. Nueva Tabla: VentasProductosFormulas.'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentasProductosFormulas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[IdFormula] [int] NOT NULL,
	[NombreProductoComponente] [varchar](60) NOT NULL,
	[NombreFormula] [varchar](100) NOT NULL,
	[PrecioCosto] [decimal](14, 4) NOT NULL,
	[PrecioVenta] [decimal](14, 4) NOT NULL,
	[Cantidad] [decimal](14, 4) NOT NULL,
	[SegunCalculoForma] [bit] NOT NULL,
 CONSTRAINT [PK_VentasProductosFormula] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdProducto] ASC,
	[Orden] ASC,
	[IdProductoComponente] ASC,
	[IdFormula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormula_VentasProductos] 
FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
REFERENCES [dbo].[VentasProductos] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
GO

ALTER TABLE [dbo].[VentasProductosFormulas] CHECK CONSTRAINT [FK_VentasProductosFormula_VentasProductos]
GO

ALTER TABLE [dbo].[VentasProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormula_ProductosFormulas] FOREIGN KEY([IdProducto], [IdFormula])
REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
GO

ALTER TABLE [dbo].[VentasProductosFormulas] CHECK CONSTRAINT [FK_VentasProductosFormula_ProductosFormulas]
GO


PRINT ''
PRINT '2. Tabla VentasProductos: Agrego campo IdFormula.'
GO

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
ALTER TABLE dbo.ProductosFormulas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductos ADD IdFormula int NULL
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT FK_VentasProductos_ProductosFormulas
    FOREIGN KEY (IdProducto,IdFormula)
    REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla ProductosFormulas: Limpio campo IdFormula en caso de inconsistencias y luego creo FK a ProductosFormulas.'
GO

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
ALTER TABLE dbo.ProductosFormulas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
UPDATE Productos
   SET IdFormula = NULL
  FROM Productos P
  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = P.IdProducto AND PF.IdFormula = P.IdFormula
 WHERE P.IdFormula IS NOT NULL
   AND PF.IdFormula IS NULL
ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_ProductosFormulas
    FOREIGN KEY (IdProducto,IdFormula)
    REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
