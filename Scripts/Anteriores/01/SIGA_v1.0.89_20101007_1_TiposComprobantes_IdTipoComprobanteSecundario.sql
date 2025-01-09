
ALTER TABLE dbo.TiposComprobantes ADD
	IdTipoComprobanteSecundario varchar(15) NULL
GO

ALTER TABLE dbo.TiposComprobantes ADD CONSTRAINT
	FK_TiposComprobantes_TiposComprobantes FOREIGN KEY
	(
	IdTipoComprobanteSecundario
	) REFERENCES dbo.TiposComprobantes
	(
	IdTipoComprobante
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
