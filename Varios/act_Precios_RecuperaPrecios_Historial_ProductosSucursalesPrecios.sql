--UPDATE ProductosSucursalesPrecios
--   SET PrecioVenta = HP.PrecioVentaNuevo
SELECT *
  FROM (SELECT PS.IdProducto, PS.IdSucursal, PS.IdListaPrecios, PS.PrecioVenta
             ,(SELECT TOP 1 PrecioVenta
	            FROM HistorialPrecios HP
                WHERE HP.IdProducto = PS.IdProducto
                  AND HP.IdSucursal = PS.IdSucursal
                  AND HP.IdListaPrecios = PS.IdListaPrecios
                  AND HP.FechaHora < '20190321'
	           ORDER BY FechaHora DESC) PrecioVentaNuevo
         FROM ProductosSucursalesPrecios PS
        /*WHERE PS.IdProducto = '0011'*/ ) HP
 INNER JOIN ProductosSucursalesPrecios PS ON PS.IdProducto = HP.IdProducto 
                                         --AND PS.IdSucursal = HP.IdSucursal
										 AND HP.IdListaPrecios = PS.IdListaPrecios
 INNER JOIN Productos P ON P.IdProducto = PS.IdProducto
 INNER JOIN ComprasProductos CP ON CP.IdProducto = P.IdProducto
--                       AND CP.Idsucursal = 1
                       AND CP.IdProveedor = 1
                       AND CP.IdTipoComprobante = 'FACTCOM'
                       and CP.Centroemisor = 5
                       AND CP.NumeroComprobante = 42461
 WHERE P.Activo = 1
   AND PS.PrecioVenta <> 0
   AND HP.PrecioVentaNuevo IS NOT NULL
