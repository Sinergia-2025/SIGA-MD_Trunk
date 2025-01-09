
EXEC sp_rename 'SueldosCierreLiquidacion.NroLiquidacion', 'PeriodoLiquidacion', 'COLUMN'
GO

EXEC sp_rename 'SueldosCierreLiqDatos.NroLiquidacion', 'PeriodoLiquidacion', 'COLUMN'
GO

/*
SELECT * FROM SueldosCierreLiquidacion
*/
