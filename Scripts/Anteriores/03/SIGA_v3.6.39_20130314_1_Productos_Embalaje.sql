
ALTER TABLE dbo.Productos ADD
	Embalaje int NULL

GO

/*-------------------------*/

UPDATE dbo.Productos SET
	Embalaje = 1
GO

/*-------------------------*/

ALTER TABLE dbo.Productos ALTER COLUMN Embalaje int NOT NULL
GO


