PRINT ''
PRINT '1. Cambio de nombre en la función de Pantalla'
UPDATE Funciones SET
	Nombre = 'Consultar Depósito/Extracción/Liquidación/Transferencia',
	Descripcion = 'Consultar Depósito/Extracción/Liquidación/Transferencia'
		WHERE Id = 'ConsultarDepositos'
GO