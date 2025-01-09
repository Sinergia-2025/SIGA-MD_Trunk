IF dbo.ExisteCampo('ProduccionFormas', 'FormulaCalculoKilaje') = 0
BEGIN
    ALTER TABLE ProduccionFormas ALTER COLUMN FormulaCalculoKilaje VARCHAR(MAX) NOT NULL
END
