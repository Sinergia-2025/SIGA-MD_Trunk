
INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CARGOSEXPENSASFECHAFACTURA', 'PrimerDiaPeriodoActual', null, 'Fecha Factura')
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CARGOSEXPENSASFORMAPAGO', 3, null, 'Forma de Pago')
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CARGOSEXPENSASPERIODOFACTURA', 'PeriodoSiguiente', null, 'Facturar con periodo')
GO
	
INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CARGOSEXPENSASTIPOCOMPROBANTE', 'ePRE-FACT', null, 'Tipo de comprobante')
GO		
