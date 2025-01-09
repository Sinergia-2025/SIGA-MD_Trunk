
PRINT '1. Borro: FK - ProduccionProductos.FK_ProduccionProductos_ProductosLotes'
;
ALTER TABLE dbo.ProduccionProductos	DROP CONSTRAINT FK_ProduccionProductos_ProductosLotes
;

PRINT '2. Borro: FK - VentasProductosLotes.FK_VentasProductosLotes_ProductosLotes'
;
ALTER TABLE dbo.VentasProductosLotes DROP CONSTRAINT FK_VentasProductosLotes_ProductosLotes
;

PRINT '3. Borro: FK - ProductosLotes.FK_ProductosLotes_ComprasProductos'
;
ALTER TABLE dbo.ProductosLotes DROP CONSTRAINT FK_ProductosLotes_ComprasProductos
;

PRINT '4. Borro: FK - ProductosLotes.FK_ProductosLotes_ProductosSucursales'
;
ALTER TABLE dbo.ProductosLotes DROP CONSTRAINT FK_ProductosLotes_ProductosSucursales
;

PRINT '5.a) Borro: PK - ProductosLotes.PK_ProductosLotes (Si Existe)'
;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE WHERE TABLE_NAME = 'ProductosLotes' AND CONSTRAINT_NAME = 'PK_ProductosLotes')
ALTER TABLE ProductosLotes DROP CONSTRAINT PK_ProductosLotes
;

PRINT '5.b) Borro: PK - ProductosLotes.PK_ProductosLotes_1 (Si Existe)'
;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE WHERE TABLE_NAME = 'ProductosLotes' AND CONSTRAINT_NAME = 'PK_ProductosLotes_1')
ALTER TABLE ProductosLotes DROP CONSTRAINT PK_ProductosLotes_1
;

PRINT '6) Cambio: ProductosLotes.IdLote de 15 a 30'
;
ALTER TABLE dbo.ProductosLotes ALTER COLUMN IdLote varchar(30) NOT NULL
;

PRINT '7) Creo: PK ProductosLotes.PK_ProductosLotes'
;
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
ALTER TABLE dbo.ProductosLotes ADD CONSTRAINT
	PK_ProductosLotes PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdProducto,
	IdLote
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ProductosLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '8) Cambio: MovimientosComprasProductos.IdLote de 15 a 30'
;
ALTER TABLE dbo.MovimientosComprasProductos ALTER COLUMN IdLote varchar(30) NULL
GO

PRINT '9) Creo: FK MovimientosComprasProductos.FK_MovimientosComprasProductos_ProductosLotes'
;
ALTER TABLE dbo.MovimientosComprasProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosComprasProductos_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote)
REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
GO

ALTER TABLE dbo.MovimientosComprasProductos CHECK CONSTRAINT FK_MovimientosComprasProductos_ProductosLotes
GO

PRINT '10) Cambio: MovimientosVentasProductos.IdLote de 15 a 30'
;
ALTER TABLE dbo.MovimientosVentasProductos ALTER COLUMN IdLote varchar(30) NULL
GO

PRINT '11) Creo: FK MovimientosVentasProductos.FK_MovimientosVentasProductos_ProductosLotes'
;
ALTER TABLE dbo.MovimientosVentasProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosVentasProductos_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote)
REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
GO

ALTER TABLE dbo.MovimientosComprasProductos CHECK CONSTRAINT FK_MovimientosComprasProductos_ProductosLotes
GO

PRINT '12) Cambio: ProduccionProductos.IdLote de 15 a 30'
;
ALTER TABLE dbo.ProduccionProductos ALTER COLUMN IdLote varchar(30) NULL
GO

PRINT '13) Creo: FK ProduccionProductos.FK_ProduccionProductos_ProductosLotes'
;
ALTER TABLE dbo.ProduccionProductos  WITH CHECK ADD  CONSTRAINT FK_ProduccionProductos_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote)
REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
GO

ALTER TABLE dbo.MovimientosComprasProductos CHECK CONSTRAINT FK_MovimientosComprasProductos_ProductosLotes
GO

PRINT '14) Cambio: VentasProductosLotes.IdLote de 15 a 30'
;
ALTER TABLE dbo.VentasProductosLotes ALTER COLUMN IdLote varchar(30) NOT NULL
GO

PRINT '15) Creo: FK VentasProductosLotes.FK_VentasProductosLotes_ProductosLotes'
;
ALTER TABLE dbo.VentasProductosLotes  WITH CHECK ADD  CONSTRAINT FK_VentasProductosLotes_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote)
REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
GO

ALTER TABLE dbo.VentasProductosLotes CHECK CONSTRAINT FK_VentasProductosLotes_ProductosLotes
GO
