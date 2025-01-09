
ALTER TABLE Compras ADD CotizacionDolar Decimal(7, 3) NULL
GO

UPDATE Compras 
   SET CotizacionDolar = 1
GO

ALTER TABLE Compras ALTER COLUMN CotizacionDolar Decimal(7, 3) NOT NULL
GO
