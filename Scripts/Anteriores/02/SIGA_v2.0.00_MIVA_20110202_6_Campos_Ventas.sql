
ALTER TABLE Ventas ADD
	TotalImpuestos decimal(12, 2) NULL
GO

UPDATE Ventas SET
   TotalImpuestos = IvaInscripto + IvaNoInscripto
GO

ALTER TABLE Ventas ALTER COLUMN
	TotalImpuestos decimal(12, 2) NOT NULL
GO

UPDATE Ventas SET
  SubTotal = NoGravado + SubTotal
GO


ALTER TABLE Ventas DROP COLUMN NoGravado
GO

ALTER TABLE Ventas DROP COLUMN PorcentajeIVA
GO

ALTER TABLE Ventas DROP COLUMN IvaInscripto
GO

ALTER TABLE Ventas DROP COLUMN IvaNoInscripto
GO
