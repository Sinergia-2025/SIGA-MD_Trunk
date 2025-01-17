DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 3
;

PRINT ''
PRINT '1. Elimino VentasTarjetas.'
;

DELETE SIGA_PA_Separada.dbo.VentasTarjetas
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino VentasObservaciones.'
;
DELETE SIGA_PA_Separada.dbo.VentasObservaciones
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Elimino VentasImpuestos.'
;
DELETE SIGA_PA_Separada.dbo.VentasImpuestos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '4. Elimino VentasProductos.'
;
DELETE SIGA_PA_Separada.dbo.VentasProductos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '5. Elimino Ventas.'
;
DELETE SIGA_PA_Separada.dbo.Ventas
 WHERE IdSucursal = @IdSucDestino
;


PRINT ''
PRINT '6. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_PA_Separada.dbo.Ventas
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,TipoDocVendedor
           ,NroDocVendedor
           ,SubTotal
           ,DescuentoRecargo
           ,ImporteTotal
           ,IdCategoriaFiscal
           ,IdFormasPago
           ,Observacion
           ,ImporteBruto
           ,DescuentoRecargoPorc
           ,IdEstadoComprobante
           ,IdTipoComprobanteFact
           ,LetraFact
           ,CentroEmisorFact
           ,NumeroComprobanteFact
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,ImportePesos
           ,ImporteTickets
           ,ImporteTarjetas
           ,ImporteCheques
           ,Kilos
           ,Bultos
           ,ValorDeclarado
           ,IdTransportista
           ,NumeroLote
           ,TotalImpuestos
           ,CantidadInvocados
           ,CantidadLotes
           ,Usuario
           ,FechaAlta
           ,CAE
           ,CAEVencimiento
           ,Utilidad
           ,FechaTransmisionAFIP
           ,CotizacionDolar
           ,ComisionVendedor
           ,FechaImpresion
           ,IdAsiento
           ,MercDespachada
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,IdActividad
           ,IdProvincia
           ,FechaEnvio
           ,NumeroReparto
           ,FechaRendicion
           ,IdCliente
           ,IdProveedor
           ,FechaActualizacion
           ,Direccion
           ,IdLocalidad
           ,IdCategoria
           ,CodigoErrorAfip
           ,IdPlanCuenta
           ,TotalImpuestoInterno
           ,MetodoGrabacion
           ,IdFuncion
           ,SaldoActualCtaCte
           ,NumeroOrdenCompra
           ,IdCobrador
           ,IdMoneda)
SELECT @IdSucDestino AS IdSucursal
           ,V.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,TipoDocVendedor
           ,NroDocVendedor
           ,SubTotal
           ,DescuentoRecargo
           ,ImporteTotal
           ,IdCategoriaFiscal
           ,IdFormasPago
           ,Observacion
           ,ImporteBruto
           ,DescuentoRecargoPorc
           ,IdEstadoComprobante
           ,NULL AS xxIdTipoComprobanteFact -- No se traslada el vinculos de Invocados
           ,NULL AS xxLetraFact
           ,NULL AS xxCentroEmisorFact
           ,NULL AS xxNumeroComprobanteFact
           ,NULL AS xxIdCaja		-- El destino  no tiene los movimientos de Caja
           ,NULL AS xxNumeroPlanilla
           ,NULL AS xxNumeroMovimiento
           ,ImportePesos
           ,ImporteTickets
           ,ImporteTarjetas
           ,ImporteCheques
           ,Kilos
           ,Bultos
           ,ValorDeclarado
           ,IdTransportista
           ,NumeroLote
           ,TotalImpuestos
           ,CantidadInvocados
           ,CantidadLotes
           ,Usuario
           ,FechaAlta
           ,CAE
           ,CAEVencimiento
           ,Utilidad
           ,FechaTransmisionAFIP
           ,CotizacionDolar
           ,ComisionVendedor
           ,FechaImpresion
           ,IdAsiento
           ,MercDespachada
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,IdActividad
           ,IdProvincia
           ,FechaEnvio
           ,NumeroReparto
           ,FechaRendicion
           ,IdCliente
           ,IdProveedor
           ,FechaActualizacion
           ,Direccion
           ,IdLocalidad
           ,IdCategoria
           ,CodigoErrorAfip
           ,V.IdPlanCuenta
           ,TotalImpuestoInterno
           ,MetodoGrabacion
           ,IdFuncion
           ,SaldoActualCtaCte
           ,NumeroOrdenCompra
           ,IdCobrador
           ,IdMoneda
  FROM SIGA_PA.dbo.Ventas V -- Paso Ventas Blue.
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE V.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '7. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_PA_Separada.dbo.VentasProductos
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProducto
           ,Cantidad
           ,Precio
           ,Costo
           ,DescRecGeneral
           ,DescuentoRecargo
           ,PrecioLista
           ,Utilidad
           ,ImporteTotal
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc
           ,DescRecGeneralProducto
           ,PrecioNeto
           ,ImporteTotalNeto
           ,Kilos
           ,DescuentoRecargoPorc2
           ,NombreProducto
           ,IdTipoImpuesto
           ,AlicuotaImpuesto
           ,ImporteImpuesto
           ,Orden
           ,ComisionVendedorPorc
           ,ComisionVendedor
           ,IdListaPrecios
           ,NombreListaPrecios
           ,ImporteImpuestoInterno
           ,IdCentroCosto
           ,PrecioConImpuestos
           ,PrecioNetoConImpuestos
           ,ImporteTotalConImpuestos
           ,ImporteTotalNetoConImpuestos
           ,PrecioVentaPorTamano
           ,Tamano
           ,IdUnidadDeMedida
           ,IdMoneda
           ,Garantia
           ,FechaEntrega
           ,PorcImpuestoInterno
           ,TipoOperacion
           ,Nota
           ,NombreCortoListaPrecios
           ,OrigenPorcImpInt
           ,IdFormula)
SELECT @IdSucDestino AS IdSucursal
           ,VP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProducto
           ,Cantidad
           ,Precio
           ,Costo
           ,DescRecGeneral
           ,DescuentoRecargo
           ,PrecioLista
           ,Utilidad
           ,ImporteTotal
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc
           ,DescRecGeneralProducto
           ,PrecioNeto
           ,ImporteTotalNeto
           ,Kilos
           ,DescuentoRecargoPorc2
           ,NombreProducto
           ,IdTipoImpuesto
           ,AlicuotaImpuesto
           ,ImporteImpuesto
           ,Orden
           ,ComisionVendedorPorc
           ,ComisionVendedor
           ,IdListaPrecios
           ,NombreListaPrecios
           ,ImporteImpuestoInterno
           ,IdCentroCosto
           ,PrecioConImpuestos
           ,PrecioNetoConImpuestos
           ,ImporteTotalConImpuestos
           ,ImporteTotalNetoConImpuestos
           ,PrecioVentaPorTamano
           ,Tamano
           ,IdUnidadDeMedida
           ,IdMoneda
           ,Garantia
           ,FechaEntrega
           ,PorcImpuestoInterno
           ,TipoOperacion
           ,Nota
           ,NombreCortoListaPrecios
           ,OrigenPorcImpInt
           ,IdFormula
  FROM SIGA_PA.dbo.VentasProductos VP -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VP.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '8. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_PA_Separada.dbo.VentasImpuestos
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdTipoImpuesto
           ,Alicuota
           ,Bruto
           ,Neto
           ,Importe
           ,Total
           ,IdProvincia)
SELECT @IdSucDestino AS IdSucursal
      ,VI.IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,IdTipoImpuesto
      ,Alicuota
      ,Bruto
      ,Neto
      ,Importe
      ,Total
      ,IdProvincia
  FROM SIGA_PA.dbo.VentasImpuestos VI
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VI.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '9. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_PA_Separada.dbo.VentasObservaciones
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Linea
           ,Observacion)
SELECT @IdSucDestino AS IdSucursal
      ,VO.IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Linea
      ,Observacion
  FROM SIGA_PA.dbo.VentasObservaciones VO -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VO.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VO.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '10. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_PA_Separada.dbo.VentasTarjetas
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdTarjeta
           ,IdBanco
           ,Monto
           ,Cuotas
           ,NumeroCupon
           ,Orden)
SELECT @IdSucDestino AS IdSucursal
           ,VT.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdTarjeta
           ,IdBanco
           ,Monto
           ,Cuotas
           ,NumeroCupon
           ,Orden
  FROM SIGA_PA.dbo.VentasTarjetas VT -- Paso Ventas Blue
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VT.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VT.IdSucursal = @IdSucOrigen
;

/* FALTA  */

-- VentasPercepciones
-- dbo.VentasProductosFormulas
-- dbo.VentasProductosLotes
------------


 -- Cambio Sucursal de Ventas Blue.
 
PRINT ''
PRINT '11. Cambio Sucursal VentasNumeros.'
;
UPDATE SIGA_PA_Separada.dbo.VentasNumeros 
   SET VentasNumeros.IdSucursal = @IdSucDestino
 FROM SIGA_PA_Separada.dbo.VentasNumeros  VN
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VN.IdTipoComprobante
         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
  WHERE VN.IdSucursal = @IdSucOrigen
;



--DELETE VentasObservaciones
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = @IdSucDestino
--          AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
--          AND V.Letra = VentasObservaciones.Letra
--          AND V.CentroEmisor = VentasObservaciones.CentroEmisor
--          AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante)
--;

--DELETE VentasImpuestos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = @IdSucDestino
--          AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
--          AND V.Letra = VentasImpuestos.Letra
--          AND V.CentroEmisor = VentasImpuestos.CentroEmisor
--          AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante)
--;

--DELETE VentasProductos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = @IdSucDestino
--          AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
--          AND V.Letra = VentasProductos.Letra
--          AND V.CentroEmisor = VentasProductos.CentroEmisor
--          AND V.NumeroComprobante = VentasProductos.NumeroComprobante)
--;

--DELETE Ventas
-- WHERE IdSucursal = 1
--   AND IdTipoComprobante <> 'REMITOTRANSP'
--   AND EXISTS 
--     (SELECT * FROM Ventas V
--	    WHERE V.IdSucursal = @IdSucDestino
--          AND V.IdTipoComprobante = Ventas.IdTipoComprobante
--          AND V.Letra = Ventas.Letra
--          AND V.CentroEmisor = Ventas.CentroEmisor
--          AND V.NumeroComprobante = Ventas.NumeroComprobante)
--;
