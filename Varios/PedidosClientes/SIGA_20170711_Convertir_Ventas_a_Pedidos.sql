INSERT INTO PEDIDOS(IdSucursal,NumeroPedido,FechaPedido,Observacion,IdUsuario,DescuentoRecargo,DescuentoRecargoPorc,
				IdCliente,IdTipoComprobante,Letra,CentroEmisor,TipoDocVendedor,NroDocVendedor,IdFormasPago,
				IdTransportista, CotizacionDolar,IdTipoComprobanteFact,ImporteBruto,SubTotal,TotalImpuestos,
				TotalImpuestoInterno,ImporteTotal,IdEstadoVisita,NumeroOrdenCompra,Kilos)
				
SELECT IdSucursal,NumeroComprobante,Fecha,isnull(Observacion,''),Usuario,DescuentoRecargo,DescuentoRecargoPorc,IdCliente,
				'PEDIDO',Letra,CentroEmisor,TipoDocVendedor,NroDocVendedor,IdFormasPago,IdTransportista,
				CotizacionDolar,IdTipoComprobanteFact,ImporteBruto,SubTotal,TotalImpuestos,TotalImpuestoInterno,
				ImporteTotal,1,null,Kilos
FROM Ventas V

WHERE V.IdTipoComprobante = 'PRESUP'