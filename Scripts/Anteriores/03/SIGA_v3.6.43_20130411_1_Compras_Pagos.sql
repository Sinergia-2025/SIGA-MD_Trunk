
ALTER TABLE dbo.Compras ADD
	ImportePesos	decimal(14, 4)	NULL,
	ImporteTarjetas	decimal(14, 4)	NULL,
	ImporteCheques	decimal(14, 4)	NULL,
	ImporteTransfBancaria decimal(14, 4) NULL,
	IdCuentaBancaria int NULL

GO

/*-------------------------*/

UPDATE dbo.Compras SET
	ImportePesos = 0,
	ImporteTarjetas = 0,
	ImporteCheques = 0,
	ImporteTransfBancaria = 0
GO

/*-------------------------*/

ALTER TABLE dbo.Compras ALTER COLUMN ImportePesos decimal(14, 4) NOT NULL 
ALTER TABLE dbo.Compras ALTER COLUMN ImporteTarjetas decimal(14, 4) NOT NULL 
ALTER TABLE dbo.Compras ALTER COLUMN ImporteCheques decimal(14, 4) NOT NULL 
ALTER TABLE dbo.Compras ALTER COLUMN ImporteTransfBancaria decimal(14, 4) NOT NULL 

GO


