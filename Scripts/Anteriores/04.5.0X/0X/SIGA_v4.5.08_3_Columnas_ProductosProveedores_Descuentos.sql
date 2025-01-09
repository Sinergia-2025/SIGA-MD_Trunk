
ALTER TABLE dbo.ProductosProveedores ADD
	UltimoPrecioFabrica decimal(14, 4) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc1 decimal(5, 2) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc2 decimal(5, 2) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc3 decimal(5, 2) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc4 decimal(5, 2) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc5 decimal(5, 2) NOT NULL DEFAULT 0,
	DescuentoRecargoPorc6 decimal(5, 2) NOT NULL DEFAULT 0 --,
--	ProveedorHabitual bit NOT NULL DEFAULT 0
GO
