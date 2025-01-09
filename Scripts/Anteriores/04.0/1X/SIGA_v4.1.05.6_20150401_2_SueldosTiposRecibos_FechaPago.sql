
ALTER TABLE SueldosTiposRecibos ADD FechaPago date null
GO

UPDATE SueldosTiposRecibos SET FechaPago = GetDate()
GO

ALTER TABLE SueldosTiposRecibos ALTER COLUMN FechaPago date not null
GO
