
ALTER TABLE dbo.Proveedores ADD
	IdRegimenGan int NULL
GO

ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_Regimenes_Gan2 FOREIGN KEY (IdRegimenGan) REFERENCES dbo.Regimenes (IdRegimen) 
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
