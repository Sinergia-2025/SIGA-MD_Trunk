
ALTER TABLE dbo.Ventas ADD
	CantidadInvocados int NULL,
	CantidadLotes int NULL
GO

UPDATE dbo.Ventas  SET
	CantidadInvocados = (SELECT COUNT(*) AS Invoco FROM Ventas V2 
	                       WHERE V2.IdSucursal = Ventas.IdSucursal 
	                         AND V2.IdTipoComprobanteFact = Ventas.IdTipoComprobante 
	                         AND V2.LetraFact = Ventas.Letra
	                         AND V2.CentroEmisorFact = Ventas.CentroEmisor
	                         AND V2.NumeroComprobanteFact = Ventas.NumeroComprobante
	                     ), 
	CantidadLotes = 0
GO

ALTER TABLE dbo.Ventas ALTER COLUMN
	CantidadInvocados int NOT NULL
GO

ALTER TABLE dbo.Ventas ALTER COLUMN
	CantidadLotes int NOT NULL
GO
