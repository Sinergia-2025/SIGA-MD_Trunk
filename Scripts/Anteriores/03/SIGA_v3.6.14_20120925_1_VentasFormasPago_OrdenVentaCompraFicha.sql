
ALTER TABLE VentasFormasPago ADD [OrdenVentas] [int] NULL
ALTER TABLE VentasFormasPago ADD [OrdenCompras] [int] NULL
ALTER TABLE VentasFormasPago ADD [OrdenFichas] [int] NULL
GO

UPDATE VentasFormasPago SET OrdenVentas = 1 
UPDATE VentasFormasPago SET OrdenCompras = 1
UPDATE VentasFormasPago SET OrdenFichas = 1
GO
  
ALTER TABLE VentasFormasPago ALTER COLUMN [OrdenVentas] [int] NOT NULL
ALTER TABLE VentasFormasPago ALTER COLUMN [OrdenCompras] [int] NOT NULL
ALTER TABLE VentasFormasPago ALTER COLUMN [OrdenFichas] [int] NOT NULL
GO

