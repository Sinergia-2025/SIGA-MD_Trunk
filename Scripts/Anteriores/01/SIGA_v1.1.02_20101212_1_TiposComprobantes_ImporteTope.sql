ALTER TABLE dbo.TiposComprobantes ADD ImporteTope decimal(10, 2) NULL
GO

UPDATE dbo.TiposComprobantes SET ImporteTope= 0
GO

UPDATE dbo.TiposComprobantes SET ImporteTope = 5000
  WHERE EsFiscal = 'True'
GO

ALTER TABLE dbo.TiposComprobantes ALTER COLUMN ImporteTope decimal(10, 2) NOT NULL
GO
