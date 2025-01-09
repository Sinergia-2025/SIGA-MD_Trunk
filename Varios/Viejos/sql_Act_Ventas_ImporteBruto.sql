
UPDATE ventas SET
   ImporteBruto=SubTotal
 WHERE DescuentoRecargo=0;

UPDATE ventas SET
   ImporteBruto=SubTotal+(DescuentoRecargo*(-1) )
 WHERE DescuentoRecargo<>0;

/* NO HACE FALTA
UPDATE Ventas
 SET Ventas.ImporteBruto = 
       ( select sum(ImporteTotal) from VentasProductos b
           where Ventas.IdSucursal=b.IdSucursal
             AND Ventas.IdTipoComprobante=b.IdTipoComprobante
             AND Ventas.Letra=b.Letra
             AND Ventas.CentroEmisor=b.CentroEmisor
             AND Ventas.NumeroComprobante=b.NumeroComprobante
         )
 WHERE DescuentoRecargo<>0 ;
*/