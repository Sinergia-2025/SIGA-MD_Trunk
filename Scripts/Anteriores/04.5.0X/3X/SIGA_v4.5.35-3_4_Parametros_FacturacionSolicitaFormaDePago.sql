
DELETE Parametros WHERE IdParametro = 'FACTURACIONCARGARFORMAPGOOBLIGATORIA'	
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('FacturacionSolicitaFormaDePago', 'False', 'Ventas', 'Facturacion Solicita Forma de Pago.')
GO
