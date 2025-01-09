ALTER TABLE ClientesDescuentosRubros ADD DescuentoRecargoPorc1 decimal(5, 2) NULL
GO
ALTER TABLE ClientesDescuentosRubros ADD DescuentoRecargoPorc2 decimal(5, 2) NULL
GO
UPDATE ClientesDescuentosRubros
   SET DescuentoRecargoPorc1 = PorcentajeDescuento
GO
ALTER TABLE ClientesDescuentosRubros DROP COLUMN PorcentajeDescuento
GO
