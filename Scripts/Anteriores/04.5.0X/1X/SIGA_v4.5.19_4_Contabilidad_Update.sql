
--Ventas---------------------------------------------------------------
sp_rename 'dbo.Ventas.PeriodoContable', 'IdAsiento', 'Column';
GO

UPDATE Ventas SET IdAsiento = null
GO

ALTER TABLE dbo.Ventas ALTER COLUMN IdAsiento integer
GO

ALTER TABLE dbo.Ventas	ADD IdPlanCuenta integer
GO

--Compras---------------------------------------------------------------
sp_rename 'dbo.Compras.PeriodoContable', 'IdAsiento', 'Column';
GO

UPDATE Compras SET IdAsiento = null
GO

ALTER TABLE dbo.Compras ALTER COLUMN IdAsiento integer
GO

ALTER TABLE dbo.Compras	ADD IdPlanCuenta integer
GO

-- REPETIDO !!
--Compras---------------------------------------------------------------
--sp_rename 'dbo.Compras.PeriodoContable', 'IdAsiento', 'Column';
--GO

--UPDATE Compras SET IdAsiento = null
--GO

--ALTER TABLE dbo.Compras ALTER COLUMN IdAsiento integer
--GO

--ALTER TABLE dbo.Compras	ADD IdPlanCuenta integer
--GO

--Caja Detalles---------------------------------------------------------------
sp_rename 'dbo.CajasDetalle.PeriodoContable', 'IdAsiento', 'Column';
GO

UPDATE CajasDetalle SET IdAsiento = null
GO

ALTER TABLE dbo.CajasDetalle ALTER COLUMN IdAsiento integer
GO

ALTER TABLE dbo.CajasDetalle	ADD IdPlanCuenta integer
GO

--Libro Bancos---------------------------------------------------------------
ALTER TABLE dbo.LibrosBancos ADD IdAsiento integer
GO

ALTER TABLE dbo.LibrosBancos ADD IdPlanCuenta integer
GO
