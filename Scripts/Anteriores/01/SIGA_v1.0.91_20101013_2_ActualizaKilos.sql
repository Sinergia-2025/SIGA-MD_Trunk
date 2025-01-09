
UPDATE VentasProductos
 SET VentasProductos.Kilos = VentasProductos.Cantidad * 
(          
SELECT P.Tamano*UdM.ConversionAKilos AS Peso
  FROM Productos P, UnidadesDeMedidas UdM
 WHERE VentasProductos.IdProducto = P.IdProducto
--    AND P.IdUnidadDeMedida IS NOT NULL
    AND P.IdUnidadDeMedida = UdM.IdUnidadDeMedida
)
 WHERE EXISTS 
     ( SELECT * FROM Productos Prod
       WHERE Prod.idproducto=VentasProductos.idproducto
         AND Prod.IdUnidadDeMedida IS NOT NULL  )
GO

UPDATE Ventas
 SET Ventas.Kilos = 
       ( select sum(Kilos) from VentasProductos b
           where Ventas.IdSucursal = b.IdSucursal
             AND Ventas.IdTipoComprobante = b.IdTipoComprobante
             AND Ventas.Letra = b.Letra
             AND Ventas.CentroEmisor = b.CentroEmisor
             AND Ventas.NumeroComprobante = b.NumeroComprobante
         )
 WHERE IdEstadoComprobante IS NULL
   OR IdEstadoComprobante <> 'ANULADO'
GO
