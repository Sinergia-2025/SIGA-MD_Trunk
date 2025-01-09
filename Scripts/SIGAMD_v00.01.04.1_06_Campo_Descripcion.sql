PRINT ''
PRINT '1. Nuevo Campo Descripcion: FormasdePago.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'Descripcion' AND TABLE_NAME = 'VentasFormasPago')
BEGIN
	ALTER TABLE VentasFormasPago ADD Descripcion VarChar(Max) NULL
END
GO

