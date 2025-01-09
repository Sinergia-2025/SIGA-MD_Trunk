UPDATE VentasProductos 
  SET Cantidad = Cantidad * (-1)
 WHERE IdTipoComprobante IN
(
SELECT IdTipoComprobante FROM dbo.TiposComprobantes
 WHERE CoeficienteValores<0
)
GO

UPDATE ComprasProductos 
  SET Cantidad = Cantidad * (-1)
 WHERE IdTipoComprobante IN
(
SELECT IdTipoComprobante FROM dbo.TiposComprobantes
 WHERE CoeficienteValores<0
)
GO
