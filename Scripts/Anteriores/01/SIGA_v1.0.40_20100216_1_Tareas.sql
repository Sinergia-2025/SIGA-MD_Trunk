

ALTER TABLE dbo.Tareas
	DROP COLUMN Estado, HechoPor
GO


ALTER TABLE dbo.Tareas ADD
	Usuario varchar(50) NULL
GO


ALTER TABLE dbo.Tareas ADD CONSTRAINT
	FK_Tareas_Usuarios FOREIGN KEY
	(
	Usuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO


UPDATE dbo.Tareas 
 SET Usuario ='Admin'
GO


ALTER TABLE dbo.Tareas ALTER COLUMN Usuario varchar(50) NOT NULL 
GO

