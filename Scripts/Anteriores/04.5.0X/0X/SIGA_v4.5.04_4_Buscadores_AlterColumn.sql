
ALTER TABLE Buscadores ALTER COLUMN Titulo varchar(50) NOT NULL
GO

UPDATE Buscadores 
  SET Titulo = RTRIM(Titulo)
GO

ALTER TABLE Buscadores ALTER COLUMN AnchoAyuda int NOT NULL
GO
