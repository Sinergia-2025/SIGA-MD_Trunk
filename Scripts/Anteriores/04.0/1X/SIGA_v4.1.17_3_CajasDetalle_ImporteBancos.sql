
ALTER TABLE CajasDetalle ADD ImporteBancos decimal(10, 2) null
GO

UPDATE CajasDetalle 
   SET ImporteBancos = 0
GO

ALTER TABLE CajasDetalle ALTER COLUMN ImporteBancos decimal(10, 2) not null
GO
