
ALTER TABLE dbo.Ventas ADD
	ImporteTransfBancaria decimal(14, 4) NULL,
	IdCuentaBancaria int NULL

GO

/*-------------------------*/

UPDATE dbo.Ventas SET
	ImporteTransfBancaria = 0
GO

/*-------------------------*/

ALTER TABLE dbo.Ventas ALTER COLUMN ImporteTransfBancaria decimal(14, 4) NOT NULL 
GO


