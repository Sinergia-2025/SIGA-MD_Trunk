
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasNombres ADD [IdCuentaContable] [int] NULL
GO
COMMIT
GO

UPDATE CajasNombres SET [IdCuentaContable] = 0 WHERE [IdCuentaContable] is null
GO

/* ------------ */

BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasDeCajas ADD [IdCuentaContable] [int] NULL
GO
ALTER TABLE dbo.CuentasDeCajas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO

UPDATE CuentasDeCajas SET [IdCuentaContable] = 0 WHERE [IdCuentaContable] is null
GO

ALTER TABLE CuentasDeCajas DROP COLUMN IdCuentaDebe
GO

ALTER TABLE CuentasDeCajas DROP COLUMN IdCuentaHaber
GO


/* ------------ */

ALTER TABLE dbo.ContabilidadAsientos ADD [SubsiAsiento] char(15) NULL
GO

UPDATE ContabilidadAsientos set [SubsiAsiento] = '' where [SubsiAsiento] is null
GO

/* ---------- */

ALTER TABLE dbo.ContabilidadAsientosTmp ADD	[SubsiAsiento] char(15) NULL
GO

UPDATE ContabilidadAsientosTmp set [SubsiAsiento] = '' where [SubsiAsiento] is null
GO

ALTER TABLE ContabilidadAsientosTmp DROP COLUMN TipoAsiento
GO

ALTER TABLE dbo.ContabilidadAsientosTmp ADD	IdPlanCuentaDefinitivo int NULL
GO

UPDATE ContabilidadAsientosTmp set IdPlanCuentaDefinitivo = 0 where IdPlanCuentaDefinitivo is null
GO

ALTER TABLE dbo.ContabilidadAsientosTmp ADD	IdAsientoDefinitivo int NULL
GO

UPDATE ContabilidadAsientosTmp set IdAsientoDefinitivo = 0 where IdAsientoDefinitivo is null
GO
