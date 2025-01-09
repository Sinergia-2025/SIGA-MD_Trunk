
DELETE Parametros 
 WHERE IdParametro = 'FACTURAPEDIDOS'
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('PEDIDOSFACTURARAUTOMATICO', 'True', NULL, 'Pedidos Pendientes: Facturados Autómaticamente.')
GO
