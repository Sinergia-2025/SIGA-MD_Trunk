SELECT V.IdSucursal, V.IdTipoComprobante, V.Letra, V.NumeroComprobante, V.Fecha
      ,C.CodigoCliente
      ,V.ImporteBruto "VENTAS - ImporteBruto", VP.ImporteTotal "VENTAS PRODUCTOS - ImporteTotal"
  FROM Ventas AS V
 INNER JOIN (SELECT IdSucursal, IdTipoComprobante, Letra, NumeroComprobante, CONVERT(decimal(12,2), ROUND(SUM(ImporteTotal), 2)) AS ImporteTotal FROM VentasProductos VP GROUP BY IdSucursal, IdTipoComprobante, Letra, NumeroComprobante) AS VP
            ON VP.IdSucursal = V.IdSucursal
           AND VP.IdTipoComprobante = V.IdTipoComprobante
           AND VP.Letra = V.Letra
           AND VP.NumeroComprobante = V.NumeroComprobante
 INNER JOIN Clientes C ON C.IdCliente = V.IdCliente
 WHERE V.ImporteBruto - VP.ImporteTotal>0.01 OR V.ImporteBruto - VP.ImporteTotal<-0.01
;

SELECT Precio
--      ,Utilidad
      ,ImporteTotal
      ,PrecioNeto
      ,ImporteTotalNeto
     
  FROM VentasProductos 
 WHERE IdTipoComprobante = 'COTIZACION' AND NumeroComprobante IN ( 733, 764, 738 , 735, 740)
go


UPDATE VentasProductos
   SET Precio = ROUND(Precio*1.21,4)
      ,ImporteTotal = ROUND(ImporteTotal*1.21,4)
      ,PrecioNeto = ROUND(PrecioNeto*1.21,4)
      ,ImporteTotalNeto = ROUND(ImporteTotalNeto*1.21,4)
 WHERE IdTipoComprobante = 'COTIZACION' AND NumeroComprobante IN ( 733, 764, 738 , 735, 740)
go

UPDATE VentasProductos
   SET Utilidad = ROUND((PrecioNeto-Costo)*Cantidad,4)
 WHERE IdTipoComprobante = 'COTIZACION' AND NumeroComprobante IN ( 733, 764, 738 , 735, 740)
go


UPDATE Ventas
 SET Ventas.Utilidad = 
       ( SELECT SUM(Utilidad) FROM VentasProductos b
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
 AND IdTipoComprobante = 'COTIZACION' AND NumeroComprobante IN ( 733, 764, 738 , 735, 740)
GO
