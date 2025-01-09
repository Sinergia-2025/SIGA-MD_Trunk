
ALTER TABLE Impresoras ADD
	TamanioLetra smallint NULL
GO

UPDATE Impresoras SET
	TamanioLetra = (CASE WHEN TipoImpresora = 'FISCAL' THEN 10 ELSE 0 END)
GO


ALTER TABLE Impresoras ALTER COLUMN
	TamanioLetra smallint NOT NULL
GO

