UPDATE ProductosSucursales
   SET PrecioVenta = HP.PrecioVentaNuevo
--SELECT *
  FROM (SELECT PS.IdProducto, PS.IdSucursal, PS.PrecioVenta
             ,(SELECT TOP 1 PrecioVenta
	            FROM HistorialPrecios HP
                WHERE HP.IdProducto = PS.IdProducto
                  AND HP.IdSucursal = PS.IdSucursal
                  AND HP.IdListaPrecios = 0
                  AND HP.FechaHora < '20170705'
	           ORDER BY FechaHora DESC) PrecioVentaNuevo
         FROM ProductosSucursales PS
        /*WHERE PS.IdProducto = '0011'*/ ) HP
 INNER JOIN ProductosSucursales PS ON PS.IdProducto = HP.IdProducto AND PS.IdSucursal = HP.IdSucursal
 INNER JOIN Productos P ON P.IdProducto = PS.IdProducto
 WHERE P.Activo = 1
   AND PS.PrecioVenta <> 0
--   AND HP.PrecioVentaNuevo IS NULL
