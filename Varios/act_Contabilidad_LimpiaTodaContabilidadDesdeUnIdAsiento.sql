DECLARE @idAsiento int = 0;
DECLARE @idAsientoHasta int = 999999;
DECLARE @idPlanCuenta int = 0;
DECLARE @conEsManual bit = 'False';
DECLARE @conNoEsManual bit = 'True';

SELECT * FROM ContabilidadAsientosTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT * FROM ContabilidadAsientosCuentasTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT CA.* FROM ContabilidadAsientos CA WHERE CA.IdAsiento >= @idAsiento AND CA.IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR CA.IdPlanCuenta = @idPlanCuenta) AND ((CA.EsManual = 1 AND @conEsManual = 1) OR (CA.EsManual = 0 AND @conNoEsManual = 1));
SELECT CAC.* FROM ContabilidadAsientosCuentas CAC INNER JOIN ContabilidadAsientos CA ON CA.IdPlanCuenta = CAC.IdPlanCuenta AND CA.IdAsiento = CAC.IdAsiento WHERE CAC.IdAsiento >= @idAsiento AND CAC.IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR CAC.IdPlanCuenta = @idPlanCuenta)  AND ((CA.EsManual = 1 AND @conEsManual = 1) OR (CA.EsManual = 0 AND @conNoEsManual = 1));
SELECT IdAsiento, * FROM Ventas WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM CuentasCorrientes WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM Compras WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM CuentasCorrientesProv WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM CajasDetalle WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM Depositos WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
SELECT IdAsiento, * FROM LibrosBancos WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);

/*
DECLARE @idAsiento int = 0;
DECLARE @idAsientoHasta int = 999999;
DECLARE @idPlanCuenta int = 0;
DECLARE @conEsManual bit = 'False';
DECLARE @conNoEsManual bit = 'True';

UPDATE Ventas SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE CuentasCorrientes SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE Compras SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE CuentasCorrientesProv SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE CajasDetalle SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE LibrosBancos SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
UPDATE Depositos SET IdAsiento = NULL, IdPlanCuenta = NULL, IdEjercicio = NULL WHERE IdAsiento IS NOT NULL AND IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);

DELETE FROM ContabilidadAsientosCuentasTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
DELETE FROM ContabilidadAsientosTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
DELETE ContabilidadAsientosCuentas FROM ContabilidadAsientosCuentas CAC INNER JOIN ContabilidadAsientos CA ON CA.IdPlanCuenta = CAC.IdPlanCuenta AND CA.IdAsiento = CAC.IdAsiento WHERE CAC.IdAsiento >= @idAsiento AND CAC.IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR CAC.IdPlanCuenta = @idPlanCuenta)  AND ((CA.EsManual = 1 AND @conEsManual = 1) OR (CA.EsManual = 0 AND @conNoEsManual = 1));
DELETE ContabilidadAsientos FROM ContabilidadAsientos CA WHERE CA.IdAsiento >= @idAsiento AND CA.IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR CA.IdPlanCuenta = @idPlanCuenta) AND ((CA.EsManual = 1 AND @conEsManual = 1) OR (CA.EsManual = 0 AND @conNoEsManual = 1));
*/

--SELECT COUNT(1) "ASIENTOS EN TEMPORAL" FROM ContabilidadAsientosTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
--SELECT COUNT(1) "ASI/CTA EN TEMPORAL" FROM ContabilidadAsientosCuentasTmp WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
--SELECT COUNT(1) "ASIENTOS EN DEFINITIVO" FROM ContabilidadAsientos WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);
--SELECT COUNT(1) "ASI/CTA EN DEFINITIVO" FROM ContabilidadAsientosCuentas WHERE IdAsiento >= @idAsiento AND IdAsiento <= @idAsientoHasta AND (@idPlanCuenta = 0 OR IdPlanCuenta = @idPlanCuenta);

