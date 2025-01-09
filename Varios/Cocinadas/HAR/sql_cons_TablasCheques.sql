/*
SELECT *
  FROM INFORMATION_SCHEMA.COLUMNS
 WHERE COLUMN_NAME = 'NumeroCheque'
*/

SELECT * FROM Cheques                      WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM ChequesHistorial             WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM DepositosCheques             WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM CuentasCorrientesCheques     WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBancoCheque=72 AND IdBancoSucursalCheque=237 AND IdLocalidadCheque=2000
SELECT * FROM LibrosBancos                 WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBancoCheque=72 AND IdBancoSucursalCheque=237 AND IdLocalidadCheque=2000

/*
SELECT * FROM ComprasCheques               WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM VentasCheques                WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM VentasChequesRechazados      WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM CuentasCorrientesProvCheques WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
SELECT * FROM RepartosCobranzasCheques     WHERE IdSucursal=1 AND NumeroCheque=61 AND IdBanco=72 AND IdBancoSucursal=237 AND IdLocalidad=2000
*/

--ChequesHistorial            
--ComprasCheques              
--LibrosBancos                
--Cheques                     
--VentasCheques               
--VentasChequesRechazados     
--DepositosCheques            
--CuentasCorrientesProvCheques
--CuentasCorrientesCheques    
--RepartosCobranzasCheques    