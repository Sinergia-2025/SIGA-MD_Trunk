
ALTER TABLE Monedas ADD	Simbolo varchar(15) NULL	
GO

UPDATE Monedas 
  SET Simbolo = (CASE WHEN NombreMoneda = 'Pesos' THEN '$' ELSE 'U$D' END)
GO

ALTER TABLE Monedas ALTER COLUMN Simbolo varchar(15) NOT NULL	
GO
