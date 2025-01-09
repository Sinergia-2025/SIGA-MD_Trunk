
ALTER TABLE SueldosTiposRecibos ADD LiquidacionEventual bit null
GO

UPDATE SueldosTiposRecibos 
   SET LiquidacionEventual = 0
GO

ALTER TABLE SueldosTiposRecibos ALTER COLUMN LiquidacionEventual bit not null
GO

SELECT * FROM SueldosTiposRecibos
GO
