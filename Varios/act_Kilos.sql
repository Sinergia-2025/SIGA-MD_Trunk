
UPDATE VentasProductos
 SET Kilos = 0
-- WHERE Kilos is NULL
GO

UPDATE Ventas
 SET Kilos = 0
-- WHERE Kilos is NULL
GO


--SELECT VP.IdProducto, P.NombreProducto, P.Tamano, P.IdUnidadDeMedida, UM.ConversionAKilos, VP.Cantidad, VP.Cantidad*P.Tamano*UM.ConversionAKilos as Kilos2, Kilos 
-- FROM VentasProductos VP, Productos P, UnidadesDeMedidas UM
--  WHERE VP.IdProducto = P.IdProducto
--   AND P.IdUnidadDeMedida = UM.IdUnidadDeMedida;


UPDATE VentasProductos
 SET VentasProductos.Kilos =   
       ( SELECT ROUND(VentasProductos.Cantidad*P.Tamano*UM.ConversionAKilos, 2) FROM Productos P, UnidadesDeMedidas UM
           WHERE VentasProductos.IdProducto = P.IdProducto
             AND P.IdUnidadDeMedida = UM.IdUnidadDeMedida
         )
 WHERE IdProducto IN (SELECT IdProducto FROM Productos WHERE Tamano IS NOT NULL)
GO


--SELECT V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante, V.Kilos, VP.IdProducto, VP.Kilos
--  FROM Ventas V, VentasProductos VP
-- WHERE V.IdSucursal=VP.IdSucursal
--   AND V.IdTipoComprobante=VP.IdTipoComprobante
--   AND V.Letra=VP.Letra
--   AND V.CentroEmisor=VP.CentroEmisor
--   AND V.NumeroComprobante=VP.NumeroComprobante;


UPDATE Ventas
 SET Ventas.Kilos = 
       ( SELECT SUM(Kilos) FROM VentasProductos b
           WHERE Ventas.IdSucursal = b.IdSucursal
             AND Ventas.IdTipoComprobante = b.IdTipoComprobante
             AND Ventas.Letra = b.Letra
             AND Ventas.CentroEmisor = b.CentroEmisor
             AND Ventas.NumeroComprobante = b.NumeroComprobante
         )
  WHERE EXISTS 
     ( SELECT * FROM VentasProductos b
           WHERE Ventas.IdSucursal = b.IdSucursal
             AND Ventas.IdTipoComprobante = b.IdTipoComprobante
             AND Ventas.Letra = b.Letra
             AND Ventas.CentroEmisor = b.CentroEmisor
             AND Ventas.NumeroComprobante = b.NumeroComprobante
     )
GO

