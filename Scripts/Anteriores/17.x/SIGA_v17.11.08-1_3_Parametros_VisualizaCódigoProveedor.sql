
DECLARE @valorParametro varchar(MAX)
SET @valorParametro = (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'UTILIZAPRECIODECOMPRA')	
;
INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('VISUALIZACODIGOPROVEEDOR', @valorParametro, 'COMPRAS', 'Visualiza código del Proveedor')
;

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('PEDIDOSPROVIMPRESIONMUESTRACODIGOPROV', 'True', 'PEDIDOSPROV', 'Impresión muestra codigo del Proveedor')
;
