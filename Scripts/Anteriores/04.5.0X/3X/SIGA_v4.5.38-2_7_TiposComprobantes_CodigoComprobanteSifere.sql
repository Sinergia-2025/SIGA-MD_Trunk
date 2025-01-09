
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
ALTER TABLE dbo.TiposComprobantes ADD CodigoComprobanteSifere varchar(1) NULL
GO
UPDATE TiposComprobantes SET CodigoComprobanteSifere = ''
UPDATE TiposComprobantes SET CodigoComprobanteSifere = 'F' WHERE IdTipoComprobante = 'FACTCOM'
UPDATE TiposComprobantes SET CodigoComprobanteSifere = 'C' WHERE IdTipoComprobante = 'NCREDCOM'
UPDATE TiposComprobantes SET CodigoComprobanteSifere = 'D' WHERE IdTipoComprobante = 'NDEBCOM'
UPDATE TiposComprobantes SET CodigoComprobanteSifere = 'D' WHERE IdTipoComprobante = 'NDEBCHEQRECHCOM'
GO
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN CodigoComprobanteSifere varchar(1) NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
