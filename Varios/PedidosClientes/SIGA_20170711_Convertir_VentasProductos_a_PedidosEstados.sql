INSERT INTO [PedidosEstados]
           ([IdSucursal],[NumeroPedido],[IdProducto],[FechaEstado],[IdEstado],[IdUsuario],[Observacion],[IdTipoComprobanteFact]
           ,[LetraFact],[CentroEmisorFact],[NumeroComprobanteFact],[Orden],[IdCriticidad],[FechaEntrega],[IdTipoComprobante]
           ,[Letra],[CentroEmisor],[NumeroReparto],[CantEstado])

SELECT VP.[IdSucursal]
      ,VP.[NumeroComprobante]
      ,[IdProducto]
      ,V.Fecha
      ,'PENDIENTE'
      ,V.Usuario
      ,''
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,[Orden]
      ,'Normal'
      ,isnull(V.FechaEnvio,v.Fecha)
      ,'PEDIDO'
      ,VP.[Letra]
      ,VP.[CentroEmisor]
	 ,NULL
	 ,VP.Cantidad
  FROM [VentasProductos] vp
 inner join Ventas V ON V.IdSucursal = VP.IdSucursal AND V.IdTipoComprobante = VP.IdTipoComprobante AND V.CentroEmisor = vp.CentroEmisor and v.Letra = vp.Letra and v.NumeroComprobante = vp.NumeroComprobante
WHERE VP.IdTipoComprobante = 'PRESUP'
GO
