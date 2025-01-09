PRINT ''
PRINT '1. Nuevo Campo IdDeposito: IdDepositoAnterior - IdUbicacionAnterior.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdDepositoAnterior' AND TABLE_NAME = 'PedidosEstados')
BEGIN
	ALTER TABLE PedidosEstados ADD IdSucursalAnterior Int NULL
	ALTER TABLE PedidosEstados ADD IdDepositoAnterior Int NULL
	ALTER TABLE PedidosEstados ADD IdUbicacionAnterior Int NULL
END
GO

