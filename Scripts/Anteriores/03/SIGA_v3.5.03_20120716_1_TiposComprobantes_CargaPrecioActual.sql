UPDATE TiposComprobantes 
   SET CargaPrecioActual = 'False'
 WHERE AfectaCaja = 'True'
  AND Tipo IN ('VENTAS','COMPRAS')
GO
