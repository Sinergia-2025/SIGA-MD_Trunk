
SELECT 'STD' as QUE, [IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante],[Fecha],[TipoDocVendedor],[NroDocVendedor],[TipoDocCliente],[NroDocCliente],[IdCategoriaFiscal],[IdFormasPago],[Observacion],[ImporteBruto],[DescuentoRecargoPorc],[DescuentoRecargo],[NoGravado],[SubTotal],[PorcentajeIVA],[IvaInscripto],[IvaNoInscripto], NULL AS [TotalImpuestos],[ImporteTotal],[IdEstadoComprobante],[IdTipoComprobanteFact],[LetraFact],[CentroEmisorFact],[NumeroComprobanteFact],[NumeroPlanilla],[NumeroMovimiento],[ImportePesos],[ImporteTickets],
[ImporteTarjetas],[ImporteCheques],[Kilos],[Bultos],[ValorDeclarado],[IdTransportista],[NumeroLote]
  FROM [SIGA].[dbo].[Ventas]
    
UNION ALL

SELECT 'MIVA' as QUE, [IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante],[Fecha],[TipoDocVendedor],[NroDocVendedor],[TipoDocCliente],[NroDocCliente],[IdCategoriaFiscal],[IdFormasPago],[Observacion],[ImporteBruto],[DescuentoRecargoPorc],[DescuentoRecargo], NULL AS [NoGravado],[SubTotal], NULL AS [PorcentajeIVA], NULL AS [IvaInscripto], NULL AS [IvaNoInscripto], [TotalImpuestos],[ImporteTotal],[IdEstadoComprobante],[IdTipoComprobanteFact],[LetraFact],[CentroEmisorFact],[NumeroComprobanteFact], [NumeroPlanilla],[NumeroMovimiento],[ImportePesos],[ImporteTickets],[ImporteTarjetas],[ImporteCheques],[Kilos],[Bultos],[ValorDeclarado],[IdTransportista],[NumeroLote]
  FROM [SIGA_Distrib_LasPalmeras].[dbo].[Ventas]
  Order by IdTipoComprobante, QUE desc
