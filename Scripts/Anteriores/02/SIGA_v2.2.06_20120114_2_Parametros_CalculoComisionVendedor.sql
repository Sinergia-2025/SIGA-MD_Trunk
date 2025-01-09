
--DELETE Parametros WHERE IdParametro = 'CALCULOCOMISIONVENDEDOR'
--GO


INSERT INTO Parametros 

  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)

 VALUES

  ('CALCULOCOMISIONVENDEDOR', 'FACTURACION', NULL, 'Calculo de Comision del Vendedor, Opciones: FACTURACION ó LISTADO')

GO
