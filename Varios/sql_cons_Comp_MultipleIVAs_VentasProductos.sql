
SELECT 'STD' as QUE, [IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante],[Orden],[IdProducto],[Cantidad],[Precio],[Costo],[DescRecGeneral],[DescuentoRecargo],[PrecioLista],[Utilidad],[ImporteTotal],[DescuentoRecargoProducto],[DescuentoRecargoPorc],[DescRecGeneralProducto],[PrecioNeto],[ImporteTotalNeto],[Kilos],[DescuentoRecargoPorc2],[NombreProducto], NULL AS [IdTipoImpuesto], PorcentajeIVA AS [AlicuotaImpuesto], NULL AS [ImporteImpuesto]
  FROM [SIGA].[dbo].[VentasProductos]

UNION ALL

SELECT 'MIVA' as QUE, [IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante],[Orden],[IdProducto],[Cantidad],[Precio],[Costo],[DescRecGeneral],[DescuentoRecargo],[PrecioLista],[Utilidad],[ImporteTotal],[DescuentoRecargoProducto],[DescuentoRecargoPorc],[DescRecGeneralProducto],[PrecioNeto],[ImporteTotalNeto],[Kilos],[DescuentoRecargoPorc2],
[NombreProducto], [IdTipoImpuesto],[AlicuotaImpuesto],[ImporteImpuesto]
  FROM [SIGA_Distrib_LasPalmeras].[dbo].[VentasProductos]  
  Order by IdTipoComprobante, IdProducto, QUE desc

