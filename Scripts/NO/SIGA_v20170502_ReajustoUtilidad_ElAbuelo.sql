
IF EXISTS (SELECT 1 FROM Parametros WHERE IdParametro = 'PRECIOCONIVA' AND ValorParametro = 'SI')
    BEGIN

		SELECT * FROM VentasProductos VP
		 INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal 
							AND V.IdTipoComprobante = VP.IdTipoComprobante
							AND V.Letra = VP.Letra
							AND V.CentroEmisor = VP.CentroEmisor
							AND V.NumeroComprobante = VP.NumeroComprobante
		 WHERE CONVERT(varchar(11), V.Fecha, 120) >= '2017-03-08'
		  AND VP.Costo<>0
		  AND EXISTS 
			  (SELECT IdProducto FROM ProductosSucursales PS
			   WHERE VP.IdSucursal = PS.IdSucursal
				 AND VP.IdProducto = PS.IdProducto
				 AND ROUND(VP.Costo/121/100,2) = ROUND(PS.PrecioCosto,2)
			  )

    END;
 

