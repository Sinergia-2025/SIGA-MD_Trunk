
ALTER TABLE MovimientosVentas ADD
	TotalImpuestos decimal(12, 2) NULL
GO

UPDATE MovimientosVentas SET
   TotalImpuestos = IvaInscripto + IvaNoInscripto
GO

ALTER TABLE MovimientosVentas ALTER COLUMN
	TotalImpuestos decimal(12, 2) NOT NULL
GO

ALTER TABLE MovimientosVentas DROP COLUMN IvaInscripto
GO

ALTER TABLE MovimientosVentas DROP COLUMN IvaNoInscripto
GO

ALTER TABLE MovimientosVentas DROP COLUMN PorcentajeIVA
GO
