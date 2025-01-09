
PRINT ''
PRINT '1. Tabla TiposComprobantes: ImporteTope 14,2 NOT NULL.'
GO
ALTER TABLE TiposComprobantes ALTER COLUMN ImporteTope DECIMAL(14, 2) NOT NULL
GO

PRINT ''
PRINT '2. Tabla TiposComprobantes: ImporteTope ajusto Maximo segun Ventas.'
GO
IF EXISTS (SELECT TOP 1 IdSucursal FROM Ventas )
	UPDATE TC_U
	   SET ImporteTope = V.ImporteTope
	  FROM (SELECT CONVERT(DECIMAL, POWER(CONVERT(DECIMAL,10), CASE WHEN LEN(CONVERT(bigint, MAX(V.ImporteTotal))) + 1 > 12 THEN 14 ELSE  LEN(CONVERT(bigint, MAX(V.ImporteTotal))) END)) - 0.01 ImporteTope
			  FROM Ventas V
			 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
			 WHERE V.ImporteTotal < 1000000000) V
	  CROSS JOIN (SELECT * FROM TiposComprobantes TC_U WHERE ImporteTope = 0 AND EsRecibo = 'False') TC_U
	GO

PRINT ''
PRINT '3. Tabla TiposComprobantes: ImporteTope ajusto Maximo sin Ventas.'
GO
IF NOT EXISTS (SELECT TOP 1 IdSucursal FROM Ventas )
	UPDATE TiposComprobantes
	   SET ImporteTope = 99999999
	 WHERE ImporteTope = 0 AND EsRecibo = 'False'
	GO
