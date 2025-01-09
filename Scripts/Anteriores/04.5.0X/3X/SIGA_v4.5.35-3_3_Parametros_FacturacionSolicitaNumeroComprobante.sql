
DELETE Parametros WHERE IdParametro = 'FACTURACIONCARGARNROCOMPROBANTEOBLIGATORIO'	
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('FacturacionSolicitaNumeroDeComprobante', 'False', 'Ventas', 'Facturacion Solicita Numero de Comprobante.')
GO
