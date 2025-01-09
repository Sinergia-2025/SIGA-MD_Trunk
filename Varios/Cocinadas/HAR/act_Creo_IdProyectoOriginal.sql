--Creo el campo y lo actualizo porque lo voy a modificar.

ALTER TABLE dbo.CRMNovedades ADD IdProyectoOriginal int NULL
GO

ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	FK_CRMNovedades_Proyectos2 FOREIGN KEY
	(
	IdProyectoOriginal
	) REFERENCES dbo.Proyectos
	(
	IdProyecto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO

UPDATE dbo.CRMNovedades 
   SET IdProyectoOriginal = IdProyecto
GO

--ALTER TABLE dbo.CRMNovedades DROP CONSTRAINT FK_CRMNovedades_Proyectos2
--GO

--ALTER TABLE dbo.CRMNovedades DROP COLUMN IdProyectoOriginal
--GO
