
ALTER TABLE dbo.Provincias 
   ADD EsAgentePercepcion bit NULL, IngBrutos nvarchar(20) NULL, AgenteIngBrutos nvarchar(20) NULL
GO

UPDATE dbo.Provincias 
  SET EsAgentePercepcion = 0 
GO

ALTER TABLE dbo.Provincias ALTER COLUMN EsAgentePercepcion bit NOT NULL
GO
