PRINT ''
PRINT '1.PedidosProveedores:  Nuevo Campo: FechaReprogramacion'
	IF NOT EXISTS(
	  SELECT TOP 1 1
	  FROM INFORMATION_SCHEMA.COLUMNS
	  WHERE 
		[TABLE_NAME] = 'PedidosProveedores'
		AND [COLUMN_NAME] = 'FechaReprogramacion')
	BEGIN
		ALTER TABLE PedidosProveedores ADD FechaReprogramacion datetime Null
	END


