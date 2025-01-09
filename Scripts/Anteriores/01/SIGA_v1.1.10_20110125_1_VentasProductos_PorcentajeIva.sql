
ALTER TABLE VentasProductos ADD
	PorcentajeIVA decimal(6, 2) NULL
GO


SELECT * FROM Productos
  WHERE EsNogravado = 'True'
GO 


UPDATE VentasProductos
 SET PorcentajeIva = 0
 WHERE IdProducto IN
 ( SELECT IdProducto FROM Productos
    WHERE EsNogravado = 'True'
 )
GO


UPDATE VentasProductos
 SET PorcentajeIva = 
       ( select PorcentajeIVA from Ventas b
           where VentasProductos.IdSucursal = b.IdSucursal
             AND VentasProductos.IdTipoComprobante = b.IdTipoComprobante
             AND VentasProductos.Letra = b.Letra
             AND VentasProductos.CentroEmisor = b.CentroEmisor
             AND VentasProductos.NumeroComprobante = b.NumeroComprobante
         )
 WHERE PorcentajeIva IS NULL
GO


ALTER TABLE VentasProductos ALTER COLUMN
	PorcentajeIVA decimal(6, 2) NOT NULL
GO