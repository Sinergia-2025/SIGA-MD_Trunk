PRINT ''
PRINT '1. Cambio de nombre en la funci�n de Pantalla'
UPDATE Funciones SET
	Nombre = 'Consultar Dep�sito/Extracci�n/Liquidaci�n/Transferencia',
	Descripcion = 'Consultar Dep�sito/Extracci�n/Liquidaci�n/Transferencia'
		WHERE Id = 'ConsultarDepositos'
GO