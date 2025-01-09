
UPDATE CuentasCorrientes SET 
 ImporteTransfBancaria = 0
 WHERE ImporteTransfBancaria IS NULL
GO

ALTER TABLE dbo.CuentasCorrientes ALTER COLUMN ImporteTransfBancaria decimal(10,2) NOT NULL
GO
