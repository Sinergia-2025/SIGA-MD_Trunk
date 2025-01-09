
ALTER TABLE CuentasCorrientesProvPagos ADD DescuentoRecargo	decimal(12, 2) null
GO
ALTER TABLE CuentasCorrientesProvPagos ADD DescuentoRecargoPorc	decimal(6, 2) null
GO

UPDATE CuentasCorrientesProvPagos SET DescuentoRecargo = 0
GO
UPDATE CuentasCorrientesProvPagos SET DescuentoRecargoPorc = 0
GO

ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN DescuentoRecargo decimal(12, 2) not null
GO
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN DescuentoRecargoPorc decimal(6, 2) not null
GO
