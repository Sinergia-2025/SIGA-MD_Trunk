DECLARE @idSucursalOriginal INT = 1
DECLARE @idSucursalNuevo INT = @idSucursalOriginal
DECLARE @idTipoComprobanteOriginal VARCHAR(MAX) = 'CONVENIO'
DECLARE @idTipoComprobanteNuevo VARCHAR(MAX) = @idTipoComprobanteOriginal
DECLARE @letraOriginal VARCHAR(MAX) = 'X'
DECLARE @letraNuevo VARCHAR(MAX) = @letraOriginal
DECLARE @emisorOriginal SMALLINT = 1
DECLARE @emisorNuevo SMALLINT = @emisorOriginal

DECLARE @numeroOriginal BIGINT = 55
DECLARE @numeroNuevo BIGINT = 2018070101

PRINT '1. Creo nuevo registro de CuentasCorrientes'
INSERT INTO [dbo].[CuentasCorrientes]
           ([IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante]
           ,[Fecha],[FechaVencimiento],[ImporteTotal],[IdFormasPago],[Observacion]
           ,[Saldo],[CantidadCuotas],[ImportePesos],[ImporteDolares],[ImporteEuros]
           ,[ImporteCheques],[ImporteTarjetas],[ImporteTickets],[ImporteTransfBancaria],[IdCuentaBancaria]
           ,[TipoDocVendedor],[NroDocVendedor],[ImporteRetenciones],[IdCaja],[NumeroPlanilla]
           ,[NumeroMovimiento],[IdUsuario],[IdEstadoComprobante],[IdCliente],[FechaActualizacion]
           ,[IdClienteCtaCte],[IdCategoria],[SaldoCtaCte],[IdAsiento],[IdPlanCuenta]
           ,[MetodoGrabacion],[IdFuncion],[ImprimeSaldos],[IdCobrador],[IdEstadoCliente]
           ,[NumeroOrdenCompra],[Referencia])
     SELECT @idSucursalNuevo [IdSucursal],@idTipoComprobanteNuevo [IdTipoComprobante],@letraNuevo [Letra],@emisorNuevo [CentroEmisor],@numeroNuevo AS [NumeroComprobante]
           ,[Fecha],[FechaVencimiento],[ImporteTotal],[IdFormasPago],[Observacion]
           ,[Saldo],[CantidadCuotas],[ImportePesos],[ImporteDolares],[ImporteEuros]
           ,[ImporteCheques],[ImporteTarjetas],[ImporteTickets],[ImporteTransfBancaria],[IdCuentaBancaria]
           ,[TipoDocVendedor],[NroDocVendedor],[ImporteRetenciones],[IdCaja],[NumeroPlanilla]
           ,[NumeroMovimiento],[IdUsuario],[IdEstadoComprobante],[IdCliente],[FechaActualizacion]
           ,[IdClienteCtaCte],[IdCategoria],[SaldoCtaCte],[IdAsiento],[IdPlanCuenta]
           ,[MetodoGrabacion],[IdFuncion],[ImprimeSaldos],[IdCobrador],[IdEstadoCliente]
           ,[NumeroOrdenCompra],[Referencia]
       FROM [dbo].[CuentasCorrientes]
      WHERE [IdSucursal] = @idSucursalOriginal
        AND [IdTipoComprobante] = @idTipoComprobanteOriginal
        AND [Letra] = @letraOriginal
        AND [CentroEmisor] = @emisorOriginal
        AND [NumeroComprobante] = @numeroOriginal

PRINT '2. Actualizo CuentasCorrientesPagos al nuevo numero'
UPDATE [dbo].[CuentasCorrientesPagos]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '3. Borro el viejo registro de CuetasCorrientes'
DELETE [dbo].[CuentasCorrientes]
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal


PRINT '4. Creo nuevo registro de Ventas'
INSERT INTO [dbo].[Ventas]
           ([IdSucursal],[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante]
           ,[Fecha],[TipoDocVendedor],[NroDocVendedor],[SubTotal],[DescuentoRecargo]
           ,[ImporteTotal],[IdCategoriaFiscal],[IdFormasPago],[Observacion],[ImporteBruto]
           ,[DescuentoRecargoPorc],[IdEstadoComprobante],[IdTipoComprobanteFact],[LetraFact],[CentroEmisorFact]
           ,[NumeroComprobanteFact],[IdCaja],[NumeroPlanilla],[NumeroMovimiento],[ImportePesos]
           ,[ImporteTickets],[ImporteTarjetas],[ImporteCheques],[Kilos],[Bultos]
           ,[ValorDeclarado],[IdTransportista],[NumeroLote],[TotalImpuestos],[CantidadInvocados]
           ,[CantidadLotes],[Usuario],[FechaAlta],[CAE],[CAEVencimiento]
           ,[Utilidad],[FechaTransmisionAFIP],[CotizacionDolar],[ComisionVendedor],[FechaImpresion]
           ,[IdAsiento],[MercDespachada],[ImporteTransfBancaria],[IdCuentaBancaria],[IdActividad]
           ,[IdProvincia],[FechaEnvio],[NumeroReparto],[FechaRendicion],[IdCliente]
           ,[IdProveedor],[FechaActualizacion],[Direccion],[IdLocalidad],[IdCategoria]
           ,[CodigoErrorAfip],[IdPlanCuenta],[TotalImpuestoInterno],[MetodoGrabacion],[IdFuncion]
           ,[SaldoActualCtaCte],[NumeroOrdenCompra],[IdCobrador],[IdMoneda])
     SELECT @idSucursalNuevo [IdSucursal],@idTipoComprobanteNuevo [IdTipoComprobante],@letraNuevo [Letra],@emisorNuevo [CentroEmisor],@numeroNuevo AS [NumeroComprobante]
           ,[Fecha],[TipoDocVendedor],[NroDocVendedor],[SubTotal],[DescuentoRecargo]
           ,[ImporteTotal],[IdCategoriaFiscal],[IdFormasPago],[Observacion],[ImporteBruto]
           ,[DescuentoRecargoPorc],[IdEstadoComprobante],[IdTipoComprobanteFact],[LetraFact],[CentroEmisorFact]
           ,[NumeroComprobanteFact],[IdCaja],[NumeroPlanilla],[NumeroMovimiento],[ImportePesos]
           ,[ImporteTickets],[ImporteTarjetas],[ImporteCheques],[Kilos],[Bultos]
           ,[ValorDeclarado],[IdTransportista],[NumeroLote],[TotalImpuestos],[CantidadInvocados]
           ,[CantidadLotes],[Usuario],[FechaAlta],[CAE],[CAEVencimiento]
           ,[Utilidad],[FechaTransmisionAFIP],[CotizacionDolar],[ComisionVendedor],[FechaImpresion]
           ,[IdAsiento],[MercDespachada],[ImporteTransfBancaria],[IdCuentaBancaria],[IdActividad]
           ,[IdProvincia],[FechaEnvio],[NumeroReparto],[FechaRendicion],[IdCliente]
           ,[IdProveedor],[FechaActualizacion],[Direccion],[IdLocalidad],[IdCategoria]
           ,[CodigoErrorAfip],[IdPlanCuenta],[TotalImpuestoInterno],[MetodoGrabacion],[IdFuncion]
           ,[SaldoActualCtaCte],[NumeroOrdenCompra],[IdCobrador],[IdMoneda]
       FROM [dbo].[Ventas]
      WHERE [IdSucursal] = @idSucursalOriginal
        AND [IdTipoComprobante] = @idTipoComprobanteOriginal
        AND [Letra] = @letraOriginal
        AND [CentroEmisor] = @emisorOriginal
        AND [NumeroComprobante] = @numeroOriginal

PRINT '5. Actualizo VentasProductos al nuevo numero'
UPDATE [dbo].[VentasProductos]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '6. Actualizo VentasProductosLotes al nuevo numero'
UPDATE [dbo].[VentasProductosLotes]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '7. Actualizo VentasTarjetas al nuevo numero'
UPDATE [dbo].[VentasTarjetas]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '8. Actualizo VentasCheques al nuevo numero'
UPDATE [dbo].[VentasCheques]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '9. Actualizo VentasChequesRechazados al nuevo numero'
UPDATE [dbo].[VentasChequesRechazados]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '10. Actualizo VentasObservaciones al nuevo numero'
UPDATE [dbo].[VentasObservaciones]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '11. Actualizo VentasImpuestos al nuevo numero'
UPDATE [dbo].[VentasImpuestos]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '12. Actualizo VentasPercepciones al nuevo numero'
UPDATE [dbo].[VentasPercepciones]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '13. Actualizo VentasAdjuntos al nuevo numero'
UPDATE [dbo].[VentasAdjuntos]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '14. Actualizo VentasClientesContactos al nuevo numero'
UPDATE [dbo].[VentasClientesContactos]
   SET [IdSucursal] = @idSucursalNuevo
      ,[IdTipoComprobante] = @idTipoComprobanteNuevo
      ,[Letra] = @letraNuevo
      ,[CentroEmisor] = @emisorNuevo
      ,[NumeroComprobante] = @numeroNuevo
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal

PRINT '15. Borro el viejo registro de Ventas'
DELETE [dbo].[Ventas]
 WHERE [IdSucursal] = @idSucursalOriginal
   AND [IdTipoComprobante] = @idTipoComprobanteOriginal
   AND [Letra] = @letraOriginal
   AND [CentroEmisor] = @emisorOriginal
   AND [NumeroComprobante] = @numeroOriginal
