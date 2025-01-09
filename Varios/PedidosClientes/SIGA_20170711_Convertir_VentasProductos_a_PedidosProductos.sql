INSERT INTO [PedidosProductos]
           ([IdSucursal],[NumeroPedido],[IdProducto],[Cantidad],[Precio],[Costo],[ImporteTotal],[NombreProducto],[CantEntregada]
           ,[CantEnProceso],[Orden],[DescuentoRecargoProducto],[DescuentoRecargoPorc2],[DescuentoRecargoPorc],[IdTipoImpuesto]
           ,[AlicuotaImpuesto],[ImporteImpuesto],[PrecioLista],[IdTipoComprobante],[Letra],[CentroEmisor],[FechaActualizacion]
           ,[IdListaPrecios],[NombreListaPrecios],[ImporteImpuestoInterno],[PrecioNeto],[ImporteTotalNeto],[DescRecGeneral]
           ,[DescRecGeneralProducto],[Kilos],[IdCriticidad],[FechaEntrega],[CantAnulada],[CantPendiente])
           
SELECT vp.[IdSucursal],vp.[NumeroComprobante],[IdProducto],[Cantidad],[Precio],[Costo],vp.[ImporteTotal],[NombreProducto],0,0
	   ,[Orden],[DescuentoRecargoProducto],[DescuentoRecargoPorc2],vp.[DescuentoRecargoPorc],[IdTipoImpuesto],[AlicuotaImpuesto]
	   ,[ImporteImpuesto],[PrecioLista],'PEDIDO',vp.[Letra],vp.[CentroEmisor],null,[IdListaPrecios],[NombreListaPrecios]
        ,[ImporteImpuestoInterno],[PrecioNeto],[ImporteTotalNeto],[DescRecGeneral],[DescRecGeneralProducto],vp.[Kilos],v.FechaEnvio,null,0,[Cantidad]
  FROM [VentasProductos] VP
 inner join Ventas V ON V.IdSucursal = VP.IdSucursal AND V.IdTipoComprobante = VP.IdTipoComprobante AND V.CentroEmisor = vp.CentroEmisor and v.Letra = vp.Letra and v.NumeroComprobante = vp.NumeroComprobante
WHERE VP.IdTipoComprobante = 'PRESUP'
GO

