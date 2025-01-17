INSERT INTO SIGA_PA_Separada.dbo.[Ventas]
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
           ,[IdAsiento]
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
           ,[CodigoErrorAfip]
           ,[IdPlanCuenta]
           ,[TotalImpuestoInterno]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[SaldoActualCtaCte]
           ,[NumeroOrdenCompra]
           ,[IdCobrador]
           ,[IdMoneda])
SELECT 3 AS [IdSucursal]
           ,V.IdTipoComprobante
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
           ,[IdAsiento]
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
           ,[CodigoErrorAfip]
           ,V.IdPlanCuenta
           ,[TotalImpuestoInterno]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[SaldoActualCtaCte]
           ,[NumeroOrdenCompra]
           ,[IdCobrador]
           ,[IdMoneda]
  FROM SIGA_PA.dbo.Ventas V -- Paso Ventas Blue.
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE V.IdSucursal = 2
GO

-------------------

INSERT INTO SIGA_PA_Separada.dbo.[VentasProductos]
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
           ,[ComisionVendedor]
           ,[IdListaPrecios]
           ,[NombreListaPrecios]
           ,[ImporteImpuestoInterno]
           ,[IdCentroCosto]
           ,[PrecioConImpuestos]
           ,[PrecioNetoConImpuestos]
           ,[ImporteTotalConImpuestos]
           ,[ImporteTotalNetoConImpuestos]
           ,[PrecioVentaPorTamano]
           ,[Tamano]
           ,[IdUnidadDeMedida]
           ,[IdMoneda]
           ,[Garantia]
           ,[FechaEntrega]
           ,[PorcImpuestoInterno]
           ,[TipoOperacion]
           ,[Nota]
           ,[NombreCortoListaPrecios]
           ,[OrigenPorcImpInt]
           ,[IdFormula])
SELECT 3 AS [IdSucursal]
           ,VP.IdTipoComprobante
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
           ,[IdListaPrecios]
           ,[NombreListaPrecios]
           ,[ImporteImpuestoInterno]
           ,[IdCentroCosto]
           ,[PrecioConImpuestos]
           ,[PrecioNetoConImpuestos]
           ,[ImporteTotalConImpuestos]
           ,[ImporteTotalNetoConImpuestos]
           ,[PrecioVentaPorTamano]
           ,[Tamano]
           ,[IdUnidadDeMedida]
           ,[IdMoneda]
           ,[Garantia]
           ,[FechaEntrega]
           ,[PorcImpuestoInterno]
           ,[TipoOperacion]
           ,[Nota]
           ,[NombreCortoListaPrecios]
           ,[OrigenPorcImpInt]
           ,[IdFormula]
  FROM SIGA_PA.dbo.VentasProductos VP -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VP.IdSucursal = 2
GO

INSERT INTO SIGA_PA_Separada.dbo.VentasImpuestos
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
           ,[Total]
           ,[IdProvincia])
SELECT 3 AS [IdSucursal]
      ,VI.IdTipoComprobante
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[IdTipoImpuesto]
      ,[Alicuota]
      ,[Bruto]
      ,[Neto]
      ,[Importe]
      ,[Total]
      ,[IdProvincia]
  FROM SIGA_PA.dbo.VentasImpuestos VI
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VI.IdSucursal = 2
GO

INSERT INTO SIGA_PA_Separada.dbo.VentasObservaciones
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Linea]
           ,[Observacion])
SELECT 3 AS [IdSucursal]
      ,VO.IdTipoComprobante
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Linea]
      ,[Observacion]
  FROM SIGA_PA.dbo.VentasObservaciones VO -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VO.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VO.IdSucursal = 2
GO


INSERT INTO SIGA_PA_Separada.dbo.VentasTarjetas
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdTarjeta]
           ,[IdBanco]
           ,[Monto]
           ,[Cuotas]
           ,[NumeroCupon]
           ,[Orden])
SELECT 3 AS [IdSucursal]
           ,VT.IdTipoComprobante
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdTarjeta]
           ,[IdBanco]
           ,[Monto]
           ,[Cuotas]
           ,[NumeroCupon]
           ,[Orden]
  FROM SIGA_PA.dbo.VentasTarjetas VT -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VT.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VT.IdSucursal = 2
GO

/* FALTA  */

-- VentasPercepciones
-- dbo.VentasProductosFormulas
-- dbo.VentasProductosLotes
------------

--DELETE VentasObservaciones
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = 3
--          AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
--          AND V.Letra = VentasObservaciones.Letra
--          AND V.CentroEmisor = VentasObservaciones.CentroEmisor
--          AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante)
--GO

--DELETE VentasImpuestos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = 3
--          AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
--          AND V.Letra = VentasImpuestos.Letra
--          AND V.CentroEmisor = VentasImpuestos.CentroEmisor
--          AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante)
--GO

--DELETE VentasProductos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = 3
--          AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
--          AND V.Letra = VentasProductos.Letra
--          AND V.CentroEmisor = VentasProductos.CentroEmisor
--          AND V.NumeroComprobante = VentasProductos.NumeroComprobante)
--GO

--DELETE Ventas
-- WHERE IdSucursal = 1
--   AND IdTipoComprobante <> 'REMITOTRANSP'
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = 3
--          AND V.IdTipoComprobante = Ventas.IdTipoComprobante
--          AND V.Letra = Ventas.Letra
--          AND V.CentroEmisor = Ventas.CentroEmisor
--          AND V.NumeroComprobante = Ventas.NumeroComprobante)
--GO
