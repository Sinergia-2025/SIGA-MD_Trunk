
ALTER TABLE dbo.Regimenes ADD
	MinimoNoImponible Decimal(14, 2) NULL
GO

UPDATE Regimenes
   SET MinimoNoImponible = MontoAExceder
 --WHERE IdTipoImpuesto = 'RGANA'
GO

ALTER TABLE dbo.Regimenes ALTER COLUMN
	MinimoNoImponible Decimal(14, 2) NOT NULL
GO
