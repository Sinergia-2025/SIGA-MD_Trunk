SELECT A.CantSinImpuestos, B.CantImpuestosIntXImporte, C.CantImpuestosIntXPorcentaje
  FROM
	(
	SELECT COUNT(IdProducto) AS CantSinImpuestos FROM Productos
	 WHERE ImporteImpuestoInterno=0 AND PorcImpuestoInterno=0
	) A,
	(
	SELECT COUNT(IdProducto) AS CantImpuestosIntXImporte FROM Productos
	 WHERE ImporteImpuestoInterno>0
	) B, 
	( 
	SELECT COUNT(IdProducto) AS CantImpuestosIntXPorcentaje FROM Productos
	 WHERE PorcImpuestoInterno>0
	) C
GO
