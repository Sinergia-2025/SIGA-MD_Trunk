
ALTER TABLE dbo.Proveedores ADD
	EsPasibleRetencionIIBB bit NOT NULL CONSTRAINT DF_Proveedores_EsPasibleRetencionIIBB DEFAULT 0,
	IdRegimenIIBB int NULL
GO

ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_Regimenes_IIBB FOREIGN KEY (IdRegimenIIBB) REFERENCES dbo.Regimenes (IdRegimen) 
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
