
ALTER TABLE dbo.Productos ADD Kilos Decimal(10,3) NULL
GO

/*-------------------------*/

UPDATE dbo.Productos SET Kilos = 0
GO

/*-------------------------*/

ALTER TABLE dbo.Productos ALTER COLUMN Kilos Decimal(10,3) NOT NULL
GO



