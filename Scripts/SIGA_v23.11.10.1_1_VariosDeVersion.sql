

IF dbo.ExisteCampo('VentasFormasPago', 'AplicanOfertas') = 0
BEGIN
    ALTER TABLE dbo.VentasFormasPago ADD AplicanOfertas bit NULL
END
GO

UPDATE VentasFormasPago SET AplicanOfertas = 'True' WHERE AplicanOfertas IS NULL
GO

ALTER TABLE dbo.VentasFormasPago ALTER COLUMN AplicanOfertas bit NOT NULL
