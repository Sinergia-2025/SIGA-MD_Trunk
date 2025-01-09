DECLARE @Suc1 int = 1
DECLARE @Suc2 int = ISNULL((SELECT IdSucursalAsociada FROM Sucursales WHERE Id = @suc1), @Suc1)

PRINT @Suc1 
PRINT @Suc2

UPDATE ProductosSucursales 
   SET --StockInicial = 0   ---- NO toco STock inicial porque podria tener valor de una depuracion de movimientos.
    Stock = 0
 WHERE IdSucursal IN (@Suc1, @Suc2)
;

UPDATE PU
   SET Stock = 
           (SELECT ISNULL( SUM(cantidad), 0)
              FROM MovimientosStockProductos MSP
             WHERE MSP.IdProducto   = PU.IdProducto
               AND ((MSP.IdSucursal  = SU.IdSucursal       AND MSP.IdDeposito  = SU.IdDeposito       AND MSP.IdUbicacion = SU.IdUbicacion) OR
                    (MSP.IdSucursal  = SU.SucursalAsociada AND MSP.IdDeposito  = SU.DepositoAsociado AND MSP.IdUbicacion = SU.UbicacionAsociada))
            ) 
  FROM ProductosUbicaciones PU
 INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal   = PU.IdSucursal
                                    AND SU.IdDeposito   = PU.IdDeposito
                                    AND SU.IdUbicacion  = PU.IdUbicacion
 WHERE 1 = 1
   AND PU.IdSucursal IN (@Suc1, @Suc2)

UPDATE PD
   SET Stock = PU.Stock
  FROM ProductosDepositos PD
 INNER JOIN (SELECT IdSucursal, IdDeposito, IdProducto, SUM(Stock) Stock
               FROM ProductosUbicaciones
              GROUP BY IdProducto, IdSucursal, IdDeposito) PU
         ON PU.IdProducto = PD.IdProducto
        AND PU.IdSucursal = PD.IdSucursal
        AND PU.IdDeposito = PD.IdDeposito
 WHERE 1 = 1
   AND PD.IdSucursal IN (@Suc1, @Suc2)

UPDATE PS
   SET Stock = StockInicial + PD.Stock
  FROM ProductosSucursales PS
 INNER JOIN (SELECT PD.IdSucursal, PD.IdProducto, SUM(PD.Stock) Stock
               FROM ProductosDepositos PD
              INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito
              WHERE SD.TipoDeposito = 'OPERATIVO'
              GROUP BY PD.IdProducto, PD.IdSucursal) PD
         ON PS.IdProducto = PD.IdProducto
        AND PS.IdSucursal = PD.IdSucursal
 WHERE 1 = 1
   AND PS.IdSucursal IN (@Suc1, @Suc2)
