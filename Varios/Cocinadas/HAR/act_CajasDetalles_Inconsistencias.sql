
SELECT * FROM CajasDetalle
  WHERE IdSucursal = 1
    AND IdCaja = 3
    AND NumeroPlanilla = 171
    AND IdCuentaCaja = 4
GO


UPDATE CajasDetalle
   SET IdCuentaCaja = 76
  WHERE IdSucursal = 1
    AND IdCaja = 3
    AND NumeroPlanilla = 171
    AND IdCuentaCaja = 4
GO

SELECT * FROM CajasDetalle
  WHERE IdSucursal = 1
    AND IdCaja = 3
    AND NumeroPlanilla = 171
GO


SELECT * FROM CajasDetalle
  WHERE IdSucursal = 1
    AND IdCaja = 3
    AND NumeroPlanilla = 171
	AND ImporteBancos <> 0 
	AND IdMonedaImporteBancos IS NULL
GO

UPDATE CajasDetalle
   SET IdMonedaImporteBancos = 1
  WHERE IdSucursal = 1
    AND IdCaja = 8
    AND NumeroPlanilla = 40
	AND ImporteBancos <> 0 
	AND IdMonedaImporteBancos IS NULL
GO
