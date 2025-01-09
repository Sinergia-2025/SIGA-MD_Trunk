
ALTER TABLE TiposComprobantesLetras ADD	Imprime bit NULL
GO

UPDATE TiposComprobantesLetras SET
	Imprime = 'True'
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN Imprime bit NOT NULL
GO
