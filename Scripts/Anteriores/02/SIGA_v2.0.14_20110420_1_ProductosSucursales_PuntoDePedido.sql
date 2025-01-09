
ALTER TABLE dbo.ProductosSucursales ADD
	PuntoDePedido decimal(10, 2) NULL,
	StockMinimo decimal(10, 2) NULL
GO


UPDATE dbo.ProductosSucursales SET
	PuntoDePedido = 0,
	StockMinimo = 0
GO


ALTER TABLE dbo.ProductosSucursales ALTER COLUMN
	PuntoDePedido decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.ProductosSucursales ALTER COLUMN
	StockMinimo decimal(10, 2) NOT NULL
GO



