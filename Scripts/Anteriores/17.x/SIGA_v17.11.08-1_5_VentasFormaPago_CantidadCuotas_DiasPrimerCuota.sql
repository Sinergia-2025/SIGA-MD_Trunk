
ALTER TABLE VentasFormasPago ADD CantidadCuotas int NULL
ALTER TABLE VentasFormasPago ADD DiasPrimerCuota int NULL
GO

UPDATE VentasFormasPago SET CantidadCuotas = 0
UPDATE VentasFormasPago SET DiasPrimerCuota = 0
GO
  
ALTER TABLE VentasFormasPago ALTER COLUMN CantidadCuotas int NOT NULL
ALTER TABLE VentasFormasPago ALTER COLUMN DiasPrimerCuota int NOT NULL
GO
