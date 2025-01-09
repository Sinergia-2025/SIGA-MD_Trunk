
ALTER TABLE SueldosTiposRecibos ADD CantidadLiquid int null
GO

UPDATE SueldosTiposRecibos SET CantidadLiquid = 1
GO

ALTER TABLE SueldosTiposRecibos ALTER COLUMN CantidadLiquid int not null
GO

ALTER TABLE SueldosTiposRecibos ADD CantidadLiquidPeriodo int null
GO

UPDATE SueldosTiposRecibos SET CantidadLiquidPeriodo = 0
GO

ALTER TABLE SueldosTiposRecibos ALTER COLUMN CantidadLiquidPeriodo int NOT null
GO


