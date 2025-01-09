
ALTER TABLE ListasDePrecios ADD DescuentoRecargoPorc decimal(6, 2) null
GO

UPDATE ListasDePrecios SET DescuentoRecargoPorc = 0
GO

ALTER TABLE ListasDePrecios ALTER COLUMN DescuentoRecargoPorc decimal(6, 2) not null
GO
