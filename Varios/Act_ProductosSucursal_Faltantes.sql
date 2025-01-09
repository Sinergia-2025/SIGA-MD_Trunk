
--Completa los Productos combinando con la Sucursal

INSERT INTO ProductosSucursales
  (IdProducto, IdSucursal, PrecioFabrica, PrecioCosto, Usuario, FechaActualizacion
  ,Stock, StockInicial, PuntoDePedido, StockMinimo, StockMaximo, Ubicacion
  ,StockReservado, FechaActualizacionWeb, StockDefectuoso, StockFuturo,StockFuturoReservado)
SELECT P.IdProducto, S.IdSucursal, 0 AS PrecioFabrica, 0 AS PrecioCosto, 'admin' as Usuario, GetDATE() as Actualizacion
      ,0 AS Stock, 0 AS StockInicial, 0 AS PuntoDePedido, 0 AS StockMinimo, 0 AS StockMaximo, '' AS Ubicacion
      ,0 AS StockReservado, GETDATE() AS FechaActualizacionWeb, 0 as StockDefectuoso, 0 AS StockFuturo, 0 AS StockFuturoReservado
  FROM Productos P, Sucursales S
 WHERE NOT EXISTS 
   ( SELECT * FROM ProductosSucursales PS 
         WHERE PS.idproducto = P.IdProducto 
         AND PS.IdSucursal = S.IdSucursal 
     ) 
GO


--Completa los ProductosSucursal combinando con la Lista de Precios

INSERT INTO ProductosSucursalesPrecios 
(IdProducto, IdSucursal, IdListaPrecios, PrecioVenta, FechaActualizacion, Usuario, FechaActualizacionWeb)
SELECT F.IdProducto
      ,F.IdSucursal
      ,F.IdListaPrecios
      ,0 AS xxPrecioVenta		--PS.PrecioVenta
      ,GetDATE() as xxFechaActualizacion
      ,'admin' as xxUsuario
      ,GetDATE() as xxFechaActualizacionWeb
  FROM ProductosSucursales PS, ( 
SELECT P.IdProducto, S.IdSucursal, LP.IdListaPrecios FROM Productos P, Sucursales S, ListasDePrecios LP 
 WHERE NOT EXISTS 
   ( SELECT * FROM ProductosSucursalesPrecios PSP 
         WHERE PSP.idproducto = P.IdProducto 
         AND PSP.IdSucursal=S.IdSucursal 
         AND PSP.IdListaPrecios=LP.IdListaPrecios 
     ) 
                               ) F 
 WHERE PS.IdProducto = F.IdProducto 
   AND PS.IdSucursal = F.IdSucursal 
GO

