
--ALTER TABLE dbo.Productos DROP CONSTRAINT DF_Productos_EsOferta
--GO

ALTER TABLE dbo.Productos 
  ADD CONSTRAINT DF_Productos_EsOferta DEFAULT 'NO' FOR EsOferta
GO
