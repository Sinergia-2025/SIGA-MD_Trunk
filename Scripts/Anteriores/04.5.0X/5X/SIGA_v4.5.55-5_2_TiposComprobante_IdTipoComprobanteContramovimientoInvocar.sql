
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
ALTER TABLE dbo.TiposComprobantes ADD IdTipoComprobanteContraMovInvocar varchar(15) NULL
GO
ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT FK_TiposComprobantes_TiposComprobantes_ContraMovInvocar
    FOREIGN KEY (IdTipoComprobanteContraMovInvocar)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
