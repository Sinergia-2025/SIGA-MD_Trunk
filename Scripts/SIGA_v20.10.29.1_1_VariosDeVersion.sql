ALTER TABLE dbo.Impresoras ADD MaximoCaracteresItem int NULL
GO
UPDATE Impresoras 
   SET MaximoCaracteresItem = CASE WHEN Marca = 'EPSON' THEN CASE WHEN Modelo = 'TM-900AF' THEN 999 ELSE 20 END ELSE 999 END;
ALTER TABLE dbo.Impresoras ALTER COLUMN MaximoCaracteresItem int NOT NULL
GO
