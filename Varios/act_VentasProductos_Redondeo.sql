
SELECT IdSucursal
     , IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
     , DescuentoRecargo, ROUND(DescuentoRecargo,2)
     , Utilidad, ROUND(Utilidad,2)
	 , ImporteTotal, ROUND(ImporteTotal,2)
	 , DescuentoRecargoProducto, ROUND(DescuentoRecargoProducto,2)
	 , PrecioNeto, ROUND(PrecioNeto,2)
	 , ImporteTotalNeto, ROUND(ImporteTotalNeto,2)
	 , PrecioConImpuestos, ROUND(PrecioConImpuestos,2)
	 , PrecioNetoConImpuestos, ROUND(PrecioNetoConImpuestos,2)
	 , ImporteTotalConImpuestos, ROUND(ImporteTotalConImpuestos,2)
  FROM VentasProductos

 --WHERE IdTipoComprobante = 'ePRE-FACT'
 --  AND Letra = 'A' 
 --  AND NumeroComprobante >= 1419
 
  WHERE IdTipoComprobante = 'COTIZACION'
    AND NumeroComprobante >= 424

  AND ROUND(PrecioNeto, 2) <> PrecioNeto
GO


UPDATE VentasProductos
   SET DescuentoRecargo = ROUND(DescuentoRecargo,2)
     , Utilidad = ROUND(Utilidad,2)
	 , ImporteTotal = ROUND(ImporteTotal,2)
	 , DescuentoRecargoProducto = ROUND(DescuentoRecargoProducto,2)
	 , PrecioNeto = ROUND(PrecioNeto,2)
	 , ImporteTotalNeto = ROUND(ImporteTotalNeto,2)
	 , PrecioConImpuestos = ROUND(PrecioConImpuestos,2)
	 , PrecioNetoConImpuestos = ROUND(PrecioNetoConImpuestos,2)
	 , ImporteTotalConImpuestos = ROUND(ImporteTotalConImpuestos,2)
 FROM VentasProductos

 --WHERE IdTipoComprobante = 'ePRE-FACT'
 --  AND Letra = 'A' 
 --  AND NumeroComprobante >= 1419
 
  WHERE IdTipoComprobante = 'COTIZACION'
    AND NumeroComprobante >= 424

  AND ROUND(PrecioNeto, 2) <> PrecioNeto
GO
