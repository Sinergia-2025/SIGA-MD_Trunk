
ALTER TABLE dbo.Depositos ADD IdPlanCuenta int NULL
GO

ALTER TABLE dbo.Depositos ADD IdAsiento int NULL
GO

ALTER TABLE dbo.Depositos DROP COLUMN PeriodoContable
GO
