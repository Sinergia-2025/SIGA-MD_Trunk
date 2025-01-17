
PRINT 'Envio de Movimientos a Sucursal = 3'
GO

PRINT '1. Inserto Tabla: Cajas'
GO

INSERT INTO [SIGA].[dbo].[Cajas]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[FechaPlanilla]
           ,[PesosSaldoInicial]
           ,[PesosSaldoFinal]
           ,[DolaresSaldoInicial]
           ,[DolaresSaldoFinal]
           ,[EurosSaldoInicial]
           ,[EurosSaldoFinal]
           ,[ChequesSaldoInicial]
           ,[ChequesSaldoFinal]
           ,[TarjetasSaldoInicial]
           ,[TarjetasSaldoFinal]
           ,[TicketsSaldoInicial]
           ,[TicketsSaldoFinal]
           ,[PesosSaldoFinalDigit]
           ,[DolaresSaldoFinalDigit]
           ,[ChequesSaldoFinalDigit]
           ,[TarjetasSaldoFinalDigit]
           ,[TicketsSaldoFinalDigit]
           ,[BancosSaldoInicial]
           ,[BancosSaldoFinal]
           ,[BancosSaldoFinalDigit])
SELECT 3 as [XXIdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[FechaPlanilla]
      ,0 AS [XXPesosSaldoInicial]
      ,0 AS [XXPesosSaldoFinal]
      ,0 AS [XXDolaresSaldoInicial]
      ,0 AS [XXDolaresSaldoFinal]
      ,0 AS [XXEurosSaldoInicial]
      ,0 AS [XXEurosSaldoFinal]
      ,0 AS [XXChequesSaldoInicial]
      ,0 AS [XXChequesSaldoFinal]
      ,0 AS [XXTarjetasSaldoInicial]
      ,0 AS [XXTarjetasSaldoFinal]
      ,0 AS [XXTicketsSaldoInicial]
      ,0 AS [XXTicketsSaldoFinal]
      ,0 AS [XXPesosSaldoFinalDigit]
      ,0 AS [XXDolaresSaldoFinalDigit]
      ,0 AS [XXChequesSaldoFinalDigit]
      ,0 AS [XXTarjetasSaldoFinalDigit]
      ,0 AS [XXTicketsSaldoFinalDigit]
      ,0 AS [XXBancosSaldoInicial]
      ,0 AS [XXBancosSaldoFinal]
      ,0 AS [XXBancosSaldoFinalDigit]
  FROM [SIGA_A_2015].[dbo].[Cajas]
   WHERE IdSucursal = 1
GO

PRINT '2. Inserto Tabla: CajasDetalle // Solo de Ventas Contado'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT 3 AS [XXIdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.Ventas V, SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.IdTipoComprobante = V.IdTipoComprobante
         AND TC.GrabaLibro = 'False'
         AND V.IdSucursal = CajasDetalle.IdSucursal
         AND V.IdCaja = CajasDetalle.IdCaja
         AND V.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND V.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '3. Inserto Tabla: Ventas'
GO

INSERT INTO [SIGA].[dbo].[Ventas]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[SubTotal]
           ,[DescuentoRecargo]
           ,[ImporteTotal]
           ,[IdCategoriaFiscal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[ImporteBruto]
           ,[DescuentoRecargoPorc]
           ,[IdEstadoComprobante]
           ,[IdTipoComprobanteFact]
           ,[LetraFact]
           ,[CentroEmisorFact]
           ,[NumeroComprobanteFact]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[ImportePesos]
           ,[ImporteTickets]
           ,[ImporteTarjetas]
           ,[ImporteCheques]
           ,[Kilos]
           ,[Bultos]
           ,[ValorDeclarado]
           ,[IdTransportista]
           ,[NumeroLote]
           ,[TotalImpuestos]
           ,[CantidadInvocados]
           ,[CantidadLotes]
           ,[Usuario]
           ,[FechaAlta]
           ,[CAE]
           ,[CAEVencimiento]
           ,[Utilidad]
           ,[FechaTransmisionAFIP]
           ,[CotizacionDolar]
           ,[ComisionVendedor]
           ,[FechaImpresion]
           ,[PeriodoContable]
           ,[MercDespachada]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[IdActividad]
           ,[IdProvincia]
           ,[FechaEnvio]
           ,[NumeroReparto]
           ,[FechaRendicion]
           ,[IdCliente]
           ,[IdProveedor]
           ,[FechaActualizacion]
           ,[Direccion]
           ,[IdLocalidad]
           ,[IdCategoria])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[SubTotal]
      ,[DescuentoRecargo]
      ,[ImporteTotal]
      ,[IdCategoriaFiscal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[ImporteBruto]
      ,[DescuentoRecargoPorc]
      ,[IdEstadoComprobante]
      ,[IdTipoComprobanteFact]
      ,[LetraFact]
      ,[CentroEmisorFact]
      ,[NumeroComprobanteFact]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[ImportePesos]
      ,[ImporteTickets]
      ,[ImporteTarjetas]
      ,[ImporteCheques]
      ,[Kilos]
      ,[Bultos]
      ,[ValorDeclarado]
      ,[IdTransportista]
      ,[NumeroLote]
      ,[TotalImpuestos]
      ,[CantidadInvocados]
      ,[CantidadLotes]
      ,[Usuario]
      ,[FechaAlta]
      ,[CAE]
      ,[CAEVencimiento]
      ,[Utilidad]
      ,[FechaTransmisionAFIP]
      ,[CotizacionDolar]
      ,[ComisionVendedor]
      ,[FechaImpresion]
      ,[PeriodoContable]
      ,[MercDespachada]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[IdActividad]
      ,[IdProvincia]
      ,[FechaEnvio]
      ,[NumeroReparto]
      ,[FechaRendicion]
      ,[IdCliente]
      ,[IdProveedor]
      ,[FechaActualizacion]
      ,[Direccion]
      ,[IdLocalidad]
      ,[IdCategoria]
  FROM SIGA_A_2015.dbo.Ventas V
 WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND TC.IdTipoComprobante = V.IdTipoComprobante
     )
GO

PRINT '4. Inserto Tabla: VentasImpuestos'
GO

INSERT INTO [SIGA].[dbo].[VentasImpuestos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdTipoImpuesto]
           ,[Alicuota]
           ,[Bruto]
           ,[Neto]
           ,[Importe]
           ,[Total])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdTipoImpuesto]
      ,[Alicuota]
      ,[Bruto]
      ,[Neto]
      ,[Importe]
      ,[Total]
  FROM [SIGA_A_2015].[dbo].[VentasImpuestos] VI
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = VI.IdSucursal
         AND V.IdTipoComprobante = VI.IdTipoComprobante
         AND V.Letra = VI.Letra
         AND V.CentroEmisor = VI.CentroEmisor
         AND V.NumeroComprobante = VI.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '5. Inserto Tabla: VentasProductos'
GO

INSERT INTO [SIGA].[dbo].[VentasProductos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdProducto]
           ,[Cantidad]
           ,[Precio]
           ,[Costo]
           ,[DescRecGeneral]
           ,[DescuentoRecargo]
           ,[PrecioLista]
           ,[Utilidad]
           ,[ImporteTotal]
           ,[DescuentoRecargoProducto]
           ,[DescuentoRecargoPorc]
           ,[DescRecGeneralProducto]
           ,[PrecioNeto]
           ,[ImporteTotalNeto]
           ,[Kilos]
           ,[DescuentoRecargoPorc2]
           ,[NombreProducto]
           ,[IdTipoImpuesto]
           ,[AlicuotaImpuesto]
           ,[ImporteImpuesto]
           ,[Orden]
           ,[ComisionVendedorPorc]
           ,[ComisionVendedor])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdProducto]
      ,[Cantidad]
      ,[Precio]
      ,[Costo]
      ,[DescRecGeneral]
      ,[DescuentoRecargo]
      ,[PrecioLista]
      ,[Utilidad]
      ,[ImporteTotal]
      ,[DescuentoRecargoProducto]
      ,[DescuentoRecargoPorc]
      ,[DescRecGeneralProducto]
      ,[PrecioNeto]
      ,[ImporteTotalNeto]
      ,[Kilos]
      ,[DescuentoRecargoPorc2]
      ,[NombreProducto]
      ,[IdTipoImpuesto]
      ,[AlicuotaImpuesto]
      ,[ImporteImpuesto]
      ,[Orden]
      ,[ComisionVendedorPorc]
      ,[ComisionVendedor]
  FROM [SIGA_A_2015].[dbo].[VentasProductos] VP
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = VP.IdSucursal
         AND V.IdTipoComprobante = VP.IdTipoComprobante
         AND V.Letra = VP.Letra
         AND V.CentroEmisor = VP.CentroEmisor
         AND V.NumeroComprobante = VP.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '6. Inserto Tabla: VentasObservaciones'
GO

INSERT INTO [SIGA].[dbo].[VentasObservaciones]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Linea]
           ,[Observacion])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Linea]
      ,[Observacion]
  FROM [SIGA_A_2015].[dbo].[VentasObservaciones] VO
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = VO.IdSucursal
         AND V.IdTipoComprobante = VO.IdTipoComprobante
         AND V.Letra = VO.Letra
         AND V.CentroEmisor = VO.CentroEmisor
         AND V.NumeroComprobante = VO.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '7. Inserto Tabla: MovimientosVentas'
GO

INSERT INTO [SIGA].[dbo].[MovimientosVentas]
           ([IdSucursal]
           ,[IdTipoMovimiento]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[Neto]
           ,[Total]
           ,[IdCategoriaFiscal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Usuario]
           ,[Observacion]
           ,[TotalImpuestos]
           ,[IdCliente])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoMovimiento]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[Neto]
      ,[Total]
      ,[IdCategoriaFiscal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Usuario]
      ,[Observacion]
      ,[TotalImpuestos]
      ,[IdCliente]
  FROM [SIGA_A_2015].[dbo].[MovimientosVentas] MV
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Ventas V
       WHERE 1 = MV.IdSucursal
         AND V.IdTipoComprobante = MV.IdTipoComprobante
         AND V.Letra = MV.Letra
         AND V.CentroEmisor = MV.CentroEmisor
         AND V.NumeroComprobante = MV.NumeroComprobante
         AND V.IdSucursal = 3
     )
GO

PRINT '8. Inserto Tabla: MovimientosVentasProductos'
GO

INSERT INTO [SIGA].[dbo].[MovimientosVentasProductos]
           ([IdSucursal]
           ,[IdTipoMovimiento]
           ,[NumeroMovimiento]
           ,[IdProducto]
           ,[Cantidad]
           ,[Precio]
           ,[IdLote]
           ,[Orden])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoMovimiento]
      ,[NumeroMovimiento]
      ,[IdProducto]
      ,[Cantidad]
      ,[Precio]
      ,[IdLote]
      ,[Orden]
  FROM [SIGA_A_2015].[dbo].[MovimientosVentasProductos] MVP
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.MovimientosVentas MV
       WHERE 1 = MVP.IdSucursal
         AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento
         AND MV.NumeroMovimiento = MVP.NumeroMovimiento
         AND MV.IdSucursal = 3
     )
GO

PRINT '9. Inserto Tabla: Compras'
GO

INSERT INTO [SIGA].[dbo].[Compras]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[TipoDocComprador]
           ,[NroDocComprador]
           ,[Neto210]
           ,[Neto105]
           ,[Neto270]
           ,[NetoNoGravado]
           ,[DescuentoRecargo]
           ,[IVA210]
           ,[IVA105]
           ,[IVA270]
           ,[ImporteTotal]
           ,[IdCategoriaFiscal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[PorcentajeIVA]
           ,[IdRubro]
           ,[Bruto210]
           ,[Bruto105]
           ,[Bruto270]
           ,[BrutoNoGravado]
           ,[DescuentoRecargoPorc]
           ,[PercepcionIVA]
           ,[PercepcionIB]
           ,[PercepcionGanancias]
           ,[PercepcionVarias]
           ,[PeriodoFiscal]
           ,[PeriodoContable]
           ,[ImportePesos]
           ,[ImporteTarjetas]
           ,[ImporteCheques]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[IdEstadoComprobante]
           ,[IdTipoComprobanteFact]
           ,[LetraFact]
           ,[CentroEmisorFact]
           ,[NumeroComprobanteFact]
           ,[CantidadInvocados]
           ,[IdProveedor]
           ,[IdProveedorFact]
           ,[Usuario]
           ,[FechaActualizacion])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[TipoDocComprador]
      ,[NroDocComprador]
      ,[Neto210]
      ,[Neto105]
      ,[Neto270]
      ,[NetoNoGravado]
      ,[DescuentoRecargo]
      ,[IVA210]
      ,[IVA105]
      ,[IVA270]
      ,[ImporteTotal]
      ,[IdCategoriaFiscal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[PorcentajeIVA]
      ,[IdRubro]
      ,[Bruto210]
      ,[Bruto105]
      ,[Bruto270]
      ,[BrutoNoGravado]
      ,[DescuentoRecargoPorc]
      ,[PercepcionIVA]
      ,[PercepcionIB]
      ,[PercepcionGanancias]
      ,[PercepcionVarias]
      ,[PeriodoFiscal]
      ,[PeriodoContable]
      ,[ImportePesos]
      ,[ImporteTarjetas]
      ,[ImporteCheques]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[IdEstadoComprobante]
      ,[IdTipoComprobanteFact]
      ,[LetraFact]
      ,[CentroEmisorFact]
      ,[NumeroComprobanteFact]
      ,[CantidadInvocados]
      ,[IdProveedor]
      ,[IdProveedorFact]
      ,[Usuario]
      ,[FechaActualizacion]
  FROM [SIGA_A_2015].[dbo].[Compras] C
 WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND TC.IdTipoComprobante = C.IdTipoComprobante
     )
GO

PRINT '10. Inserto Tabla: ComprasProductos'
GO

INSERT INTO [SIGA].[dbo].[ComprasProductos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdProducto]
           ,[Cantidad]
           ,[Precio]
           ,[DescRecGeneral]
           ,[DescuentoRecargo]
           ,[ImporteTotal]
           ,[DescuentoRecargoProducto]
           ,[DescuentoRecargoPorc]
           ,[DescRecGeneralProducto]
           ,[PrecioNeto]
           ,[ImporteTotalNeto]
           ,[PorcentajeIVA]
           ,[IVA]
           ,[Orden]
           ,[NombreProducto]
           ,[IdProveedor]
           ,[IdConcepto]
           ,[PasajeMovimiento]
           ,[MontoAplicado]
           ,[MontoSaldo]
           ,[ProporcionalImp])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdProducto]
      ,[Cantidad]
      ,[Precio]
      ,[DescRecGeneral]
      ,[DescuentoRecargo]
      ,[ImporteTotal]
      ,[DescuentoRecargoProducto]
      ,[DescuentoRecargoPorc]
      ,[DescRecGeneralProducto]
      ,[PrecioNeto]
      ,[ImporteTotalNeto]
      ,[PorcentajeIVA]
      ,[IVA]
      ,[Orden]
      ,[NombreProducto]
      ,[IdProveedor]
      ,[IdConcepto]
      ,[PasajeMovimiento]
      ,[MontoAplicado]
      ,[MontoSaldo]
      ,[ProporcionalImp]
  FROM [SIGA_A_2015].[dbo].[ComprasProductos] CP
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Compras C
       WHERE 1 = CP.IdSucursal
         AND C.IdTipoComprobante = CP.IdTipoComprobante
         AND C.Letra = CP.Letra
         AND C.CentroEmisor = CP.CentroEmisor
         AND C.NumeroComprobante = CP.NumeroComprobante
         AND C.IdProveedor = CP.IdProveedor
         AND C.IdSucursal = 3
     )
GO

PRINT '11. Inserto Tabla: ComprasObservaciones'
GO

INSERT INTO [SIGA].[dbo].ComprasObservaciones
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdProveedor]
           ,[Linea]
           ,[Observacion])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdProveedor]
      ,[Linea]
      ,[Observacion]
  FROM [SIGA_A_2015].[dbo].[ComprasObservaciones] CO
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Compras C
       WHERE 1 = CO.IdSucursal
         AND C.IdTipoComprobante = CO.IdTipoComprobante
         AND C.Letra = CO.Letra
         AND C.CentroEmisor = CO.CentroEmisor
         AND C.NumeroComprobante = CO.NumeroComprobante
         AND C.IdProveedor = CO.IdProveedor
         AND C.IdSucursal = 3
     )
GO

PRINT '12. Inserto Tabla: MovimientosCompras'
GO

INSERT INTO [SIGA].[dbo].[MovimientosCompras]
           ([IdSucursal]
           ,[IdTipoMovimiento]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[Neto210]
           ,[Neto105]
           ,[Neto270]
           ,[NetoNoGravado]
           ,[IVA210]
           ,[IVA105]
           ,[IVA270]
           ,[Total]
           ,[PorcentajeIVA]
           ,[IdCategoriaFiscal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdSucursal2]
           ,[Usuario]
           ,[Observacion]
           ,[PercepcionIVA]
           ,[PercepcionIB]
           ,[PercepcionGanancias]
           ,[PercepcionVarias]
           ,[IdProduccion]
           ,[IdProveedor])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoMovimiento]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[Neto210]
      ,[Neto105]
      ,[Neto270]
      ,[NetoNoGravado]
      ,[IVA210]
      ,[IVA105]
      ,[IVA270]
      ,[Total]
      ,[PorcentajeIVA]
      ,[IdCategoriaFiscal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdSucursal2]
      ,[Usuario]
      ,[Observacion]
      ,[PercepcionIVA]
      ,[PercepcionIB]
      ,[PercepcionGanancias]
      ,[PercepcionVarias]
      ,[IdProduccion]
      ,[IdProveedor]
  FROM [SIGA_A_2015].[dbo].[MovimientosCompras] MC
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.Compras C
       WHERE 1 = MC.IdSucursal
         AND C.IdTipoComprobante = MC.IdTipoComprobante
         AND C.Letra = MC.Letra
         AND C.CentroEmisor = MC.CentroEmisor
         AND C.NumeroComprobante = MC.NumeroComprobante
         AND C.IdProveedor = MC.IdProveedor
         AND C.IdSucursal = 3
     )
GO

PRINT '13. Inserto Tabla: MovimientosComprasProductos'
GO

INSERT INTO [SIGA].[dbo].[MovimientosComprasProductos]
           ([IdSucursal]
           ,[IdTipoMovimiento]
           ,[NumeroMovimiento]
           ,[IdProducto]
           ,[Cantidad]
           ,[Precio]
           ,[IdLote]
           ,[Orden])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoMovimiento]
      ,[NumeroMovimiento]
      ,[IdProducto]
      ,[Cantidad]
      ,[Precio]
      ,[IdLote]
      ,[Orden]
  FROM [SIGA_A_2015].[dbo].[MovimientosComprasProductos] MCP
 WHERE EXISTS 
     ( SELECT * FROM SIGA.dbo.MovimientosCompras MC
       WHERE 1 = MCP.IdSucursal
         AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
         AND MC.NumeroMovimiento = MCP.NumeroMovimiento
         AND MC.IdSucursal = 3
     )
GO

PRINT '14. Inserto Tabla: CajasDetalle // Solo de Recibos'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT 3 AS [XXIdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.CuentasCorrientes CC, SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.IdTipoComprobante = CC.IdTipoComprobante
         AND TC.GrabaLibro = 'False'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'RECIBO')
         AND 1 = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '15. Inserto Tabla: CuentasCorrientes // Comprobantes y Recibos NO Estandares'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientes]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[ImporteTickets]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[ImporteRetenciones]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdCliente]
           ,[FechaActualizacion]
           ,[IdClienteCtaCte]
           ,[IdCategoria])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[ImporteRetenciones]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdCliente]
      ,[FechaActualizacion]
      ,[IdClienteCtaCte]
      ,[IdCategoria]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientes] CC
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND TC.EsRecibo = 'False'
         AND TC.EsAnticipo = 'False'
         AND TC.IdTipoComprobante = CC.IdTipoComprobante
     )
   OR EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'RECIBO')
         AND TC.IdTipoComprobante = CC.IdTipoComprobante
     )
GO

PRINT '16. Inserto Tabla: CuentasCorrientesPagos // Comprobantes y Recibos NO Estandares'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesPagos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[CuotaNumero]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteCuota]
      ,[SaldoCuota]
      ,[IdFormasPago]
      ,[Observacion]
      ,[IdTipoComprobante2]
      ,[NumeroComprobante2]
      ,[CentroEmisor2]
      ,[CuotaNumero2]
      ,[Letra2]
      ,[DescuentoRecargo]
      ,[DescuentoRecargoPorc]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesPagos] CCP
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND TC.EsRecibo = 'False'
         AND TC.EsAnticipo = 'False'
         AND TC.IdTipoComprobante = CCP.IdTipoComprobante
     )
   OR EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC
       WHERE TC.GrabaLibro = 'False'
         AND (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')
         AND TC.IdTipoComprobante NOT IN ('ANTICIPO', 'RECIBO')
         AND TC.IdTipoComprobante = CCP.IdTipoComprobante
     )
GO

PRINT '17. Inserto Tabla: CajasDetalle // Solo de Recibos Estandares'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT 3 AS [XXIdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC, SIGA_A_2015.dbo.CuentasCorrientes CC, SIGA_A_2015.dbo.CuentasCorrientesPagos CCP
       WHERE TC.IdTipoComprobante = CCP.IdTipoComprobante2
         AND TC.GrabaLibro = 'False'
         AND CCP.IdTipoComprobante IN ('ANTICIPO', 'RECIBO')
         AND CCP.IdSucursal = CC.IdSucursal
         AND CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante         
         AND CC.IdSucursal = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '18. Inserto Tabla: CuentasCorrientes // Recibos Estandares Depurados'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientes]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[ImporteTickets]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[ImporteRetenciones]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdCliente]
           ,[FechaActualizacion]
           ,[IdClienteCtaCte]
           ,[IdCategoria])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[ImporteRetenciones]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdCliente]
      ,[FechaActualizacion]
      ,[IdClienteCtaCte]
      ,[IdCategoria]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientes] CC
   WHERE EXISTS 
     ( SELECT * FROM SIGA_A_2015.dbo.TiposComprobantes TC, SIGA_A_2015.dbo.CuentasCorrientesPagos CCP
       WHERE TC.IdTipoComprobante = CCP.IdTipoComprobante2
         AND TC.GrabaLibro = 'False'
         AND CCP.IdTipoComprobante IN ('ANTICIPO', 'RECIBO')
         AND CCP.IdSucursal = CC.IdSucursal
         AND CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante
     )
GO

PRINT '19. Inserto Tabla: CajasDetalle // Recibos Estandares Depurados V2'
GO

INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[PeriodoContable]
           ,[ImporteBancos])
SELECT 3 AS [XXIdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[PeriodoContable]
      ,[ImporteBancos]
  FROM [SIGA_A_2015].[dbo].[CajasDetalle]
WHERE EXISTS 
     ( SELECT * FROM [SIGA_A_2015].[dbo].[CuentasCorrientes] CC
	   WHERE NOT EXISTS 
		 ( SELECT * FROM SIGA.dbo.CuentasCorrientes CC2
		   WHERE CC2.IdTipoComprobante = CC.IdTipoComprobante
			 AND CC2.Letra = CC.Letra
			 AND CC2.CentroEmisor = CC.CentroEmisor
			 AND CC2.NumeroComprobante = CC.NumeroComprobante
		 )
	     AND CC.NumeroComprobante > 999       
         AND CC.IdSucursal = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  

PRINT '20. Inserto Tabla: CuentasCorrientes // Recibos Estandares Depurados V2'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientes]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[ImporteTickets]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[ImporteRetenciones]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[IdEstadoComprobante]
           ,[IdUsuario]
           ,[IdCliente]
           ,[FechaActualizacion]
           ,[IdClienteCtaCte]
           ,[IdCategoria])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteTotal]
      ,[IdFormasPago]
      ,[Observacion]
      ,[Saldo]
      ,[CantidadCuotas]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[ImporteTickets]
      ,[ImporteTransfBancaria]
      ,[IdCuentaBancaria]
      ,[TipoDocVendedor]
      ,[NroDocVendedor]
      ,[ImporteRetenciones]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[IdEstadoComprobante]
      ,[IdUsuario]
      ,[IdCliente]
      ,[FechaActualizacion]
      ,[IdClienteCtaCte]
      ,[IdCategoria]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientes] CC
   WHERE NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientes CC2
       WHERE CC2.IdTipoComprobante = CC.IdTipoComprobante
         AND CC2.Letra = CC.Letra
         AND CC2.CentroEmisor = CC.CentroEmisor
         AND CC2.NumeroComprobante = CC.NumeroComprobante
     )
   AND NumeroComprobante > 999
GO

PRINT '21. Inserto Tabla: CuentasCorrientesPagos // Comprobantes Depurados'
GO

INSERT INTO [SIGA].[dbo].[CuentasCorrientesPagos]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc])
SELECT 3 AS [XXIdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[CuotaNumero]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteCuota]
      ,[SaldoCuota]
      ,[IdFormasPago]
      ,[Observacion]
      ,[IdTipoComprobante2]
      ,[NumeroComprobante2]
      ,[CentroEmisor2]
      ,[CuotaNumero2]
      ,[Letra2]
      ,[DescuentoRecargo]
      ,[DescuentoRecargoPorc]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesPagos] CCP
   WHERE NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientesPagos CCP2
       WHERE CCP2.IdTipoComprobante = CCP.IdTipoComprobante
         AND CCP2.Letra = CCP.Letra
         AND CCP2.CentroEmisor = CCP.CentroEmisor
         AND CCP2.NumeroComprobante = CCP.NumeroComprobante
     )
  AND IdTipoComprobante2 IN ('COTIZACION', 'DEV-COTIZACION', 'COTIZCHEQRECH', 'FACTMONOT')
GO
