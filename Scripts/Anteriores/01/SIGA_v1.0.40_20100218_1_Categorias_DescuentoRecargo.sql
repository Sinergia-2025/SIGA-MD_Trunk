
ALTER TABLE dbo.Categorias ADD
	DescuentoRecargo decimal(5, 2) NULL
GO

/*-------------------------*/

UPDATE dbo.Categorias 
 SET DescuentoRecargo = 0
GO

/*-------------------------*/

ALTER TABLE dbo.Categorias ALTER COLUMN DescuentoRecargo decimal(5, 2) NOT NULL 
GO
