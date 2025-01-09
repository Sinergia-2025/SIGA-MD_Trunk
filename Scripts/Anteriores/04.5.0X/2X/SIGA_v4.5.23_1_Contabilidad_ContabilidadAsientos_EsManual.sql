
ALTER TABLE dbo.ContabilidadAsientos ADD EsManual bit NULL
GO

UPDATE ContabilidadAsientos
   SET EsManual = CASE WHEN (SELECT COUNT(1) FROM ContabilidadAsientosTmp T WHERE T.IdPlanCuenta = ContabilidadAsientos.IdPlanCuenta AND T.IdAsiento = ContabilidadAsientos.IdAsiento) > 0
                       THEN 0 ELSE 1 END
GO

ALTER TABLE dbo.ContabilidadAsientos ALTER COLUMN EsManual bit NOT NULL
GO
