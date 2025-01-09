
ALTER TABLE dbo.TiposComprobantes ADD ImporteMinimo decimal(10, 2) NULL
GO

UPDATE dbo.TiposComprobantes SET ImporteMinimo = 0.01
GO

UPDATE dbo.TiposComprobantes SET ImporteMinimo = 0.10
  WHERE GrabaLibro = 'True'
GO

ALTER TABLE dbo.TiposComprobantes ALTER COLUMN ImporteMinimo decimal(10, 2) NOT NULL
GO
