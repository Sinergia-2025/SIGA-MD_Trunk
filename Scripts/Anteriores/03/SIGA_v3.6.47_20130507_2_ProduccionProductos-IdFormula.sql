
ALTER TABLE ProduccionProductos ADD
	IdFormula int NULL	
GO

UPDATE ProduccionProductos 
   SET IdFormula = 1
GO

ALTER TABLE ProduccionProductos ALTER COLUMN IdFormula int NOT NULL
GO

