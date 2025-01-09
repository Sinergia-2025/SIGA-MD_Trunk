
DELETE Parametros WHERE IdParametro = 'FACTURACIONDIAFIJOCTACTEDEFECTO'	
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('FacturacionCtaCteSolicitaDiaFijo', 'False', 'Ventas', 'Facturacion CtaCte Solicita Dia Fijo.')
GO
