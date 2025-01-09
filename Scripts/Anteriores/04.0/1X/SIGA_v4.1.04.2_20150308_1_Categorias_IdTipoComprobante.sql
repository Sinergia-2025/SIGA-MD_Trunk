
ALTER TABLE Categorias ADD IdTipoComprobante varchar(15) NULL
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
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Categorias ADD CONSTRAINT
	FK_Categorias_TiposComprobantes FOREIGN KEY
	(
	IdTipoComprobante
	) REFERENCES dbo.TiposComprobantes
	(
	IdTipoComprobante
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
