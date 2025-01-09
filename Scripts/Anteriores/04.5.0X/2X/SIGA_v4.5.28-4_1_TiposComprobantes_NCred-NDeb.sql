
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
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposComprobantes ADD IdTipoComprobanteNCred varchar(15) NULL
ALTER TABLE dbo.TiposComprobantes ADD IdTipoComprobanteNDeb varchar(15) NULL
ALTER TABLE dbo.TiposComprobantes ADD IdProductoNCred varchar(15) NULL
ALTER TABLE dbo.TiposComprobantes ADD IdProductoNDeb varchar(15) NULL
GO
ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT
    FK_TiposComprobantes_TiposComprobantes_NCred FOREIGN KEY (IdTipoComprobanteNCred)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT
    FK_TiposComprobantes_TiposComprobantes_NDeb FOREIGN KEY (IdTipoComprobanteNDeb)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT
    FK_TiposComprobantes_Productos_NCred FOREIGN KEY (IdProductoNCred)
    REFERENCES dbo.Productos (IdProducto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT
    FK_TiposComprobantes_Productos_NDeb FOREIGN KEY (IdProductoNDeb)
    REFERENCES dbo.Productos (IdProducto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
