
ALTER TABLE CajasDetalle ADD ImporteRetenciones decimal(10, 2) null
GO

UPDATE CajasDetalle 
   SET ImporteRetenciones = 0
GO

ALTER TABLE CajasDetalle ALTER COLUMN ImporteRetenciones decimal(10, 2) not null
GO
