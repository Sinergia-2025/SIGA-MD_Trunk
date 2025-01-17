DECLARE @IdSucOrigen INT = 5
DECLARE @IdSucDestino INT = 1

DECLARE @COTIZACION INT
SELECT @COTIZACION = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.Ventas 
                                           WHERE IdSucursal=1 AND IdtipoComprobante='COTIZACION';

DECLARE @DEVCOTIZACION  INT
SELECT @DEVCOTIZACION  = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.Ventas 
                                           WHERE IdSucursal=1 AND IdtipoComprobante='DEV-COTIZACION';

DECLARE @PRESUP  INT
SELECT @PRESUP  = MAX(NumeroComprobante) FROM SIGA_Distrib_Trinidad.dbo.Ventas 
                                          WHERE IdSucursal=1 AND IdtipoComprobante='PRESUP';


PRINT ''
PRINT '1. Inserto Ventas.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.Ventas
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
           ,IdMoneda
      ,[IdClienteVinculado]
      ,[FechaEnvioCorreo]
      ,[NombreCliente]
      ,[Cuit]
      ,[TipoDocCliente]
      ,[NroDocCliente]
      ,[FechaTransferencia]
      ,[Palets]
      ,[Cbu]
      ,[CbuAlias]
      ,[NumeroComprobanteFiscal]
      ,[CantidadReintentosImpresion]
      ,[NroVersionAplicacion]
      ,[ReferenciaComercial]
      ,[AnulacionFCE])
SELECT @IdSucDestino AS IdSucursal
           ,V.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
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
           ,IdClienteVinculado
      ,[FechaEnvioCorreo]
      ,[NombreCliente]
      ,[Cuit]
      ,[TipoDocCliente]
      ,[NroDocCliente]
      ,[FechaTransferencia]
      ,[Palets]
      ,[Cbu]
      ,[CbuAlias]
      ,[NumeroComprobanteFiscal]
      ,[CantidadReintentosImpresion]
      ,[NroVersionAplicacion]
      ,[ReferenciaComercial]
      ,[AnulacionFCE]
  FROM SIGA_Distrib_Trinidad.dbo.Ventas V
  WHERE V.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;

PRINT ''
PRINT '7. Inserto VentasProductos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasProductos
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
           ,IdFormula
           ,Automatico
           ,IdEstadoVenta
			 ,IdOferta)
SELECT @IdSucDestino AS IdSucursal
           ,VP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
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
           ,Automatico
           ,IdEstadoVenta
		   ,IdOferta
  FROM SIGA_Distrib_Trinidad.dbo.VentasProductos VP
  WHERE VP.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;

PRINT ''
PRINT '8. Inserto VentasImpuestos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasImpuestos
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
      --,NumeroComprobante
	  ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
      ,IdTipoImpuesto
      ,Alicuota
      ,Bruto
      ,Neto
      ,Importe
      ,Total
      ,IdProvincia
  FROM SIGA_Distrib_Trinidad.dbo.VentasImpuestos VI
  WHERE VI.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;

PRINT ''
PRINT '9. Inserto VentasObservaciones.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasObservaciones
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
      --,NumeroComprobante
	  ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
      ,Linea
      ,Observacion
  FROM SIGA_Distrib_Trinidad.dbo.VentasObservaciones VO -- Paso Ventas Blue
  WHERE VO.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;


PRINT ''
PRINT '10. Inserto VentasTarjetas.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasTarjetas
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
           ,Orden
		   ,NumeroLote
		   ,IdTarjetaCupon)
SELECT @IdSucDestino AS IdSucursal
           ,VT.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
           ,IdTarjeta
           ,IdBanco
           ,Monto
           ,Cuotas
           ,NumeroCupon
           ,Orden
		   ,NumeroLote
		   ,IdTarjetaCupon
  FROM SIGA_Distrib_Trinidad.dbo.VentasTarjetas VT
  WHERE VT.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;

PRINT ''
PRINT '11. Inserto VentasPercepciones.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasPercepciones
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
		   ,IdTipoImpuesto
		   ,EmisorPercepcion
		   ,NumeroPercepcion)
SELECT @IdSucDestino AS IdSucursal
           ,VP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           --,NumeroComprobante
		   ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
           ,IdTipoImpuesto
		   ,EmisorPercepcion
		   ,NumeroPercepcion
  FROM SIGA_Distrib_Trinidad.dbo.VentasPercepciones VP
  WHERE VP.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')
;

PRINT ''
PRINT '12. Inserto VentasProductosFormulas.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasProductosFormulas
			([IdSucursal]
			,[IdTipoComprobante]
			,[Letra]
			,[CentroEmisor]
			  ,[NumeroComprobante]
			  ,[IdProducto]
			  ,[Orden]
			  ,[IdProductoComponente]
			  ,[IdFormula]
			  ,[NombreProductoComponente]
			  ,[NombreFormula]
			  ,[PrecioCosto]
			  ,[PrecioVenta]
			  ,[Cantidad]
			  ,[SegunCalculoForma])
SELECT @IdSucDestino AS IdSucursal
			,[IdTipoComprobante]
			,[Letra]
			,[CentroEmisor]
			  --,[NumeroComprobante]
			  ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
			  ,[IdProducto]
			  ,[Orden]
			  ,[IdProductoComponente]
			  ,[IdFormula]
			  ,[NombreProductoComponente]
			  ,[NombreFormula]
			  ,[PrecioCosto]
			  ,[PrecioVenta]
			  ,[Cantidad]
			  ,[SegunCalculoForma]
	FROM SIGA_Distrib_Trinidad.dbo.VentasProductosFormulas VPF
  WHERE VPF.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')

PRINT ''
PRINT '13. Inserto VentasProductosLotes.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.VentasProductosLotes
		(IdSucursal
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[Orden]
      ,[IdProducto]
      ,[IdLote]
      ,[FechaVencimiento]
      ,[Cantidad])
SELECT @IdSucDestino AS IdSucursal
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      --,[NumeroComprobante]
	  ,CASE WHEN IdTipoComprobante = 'COTIZACION' THEN NumeroComprobante + @COTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'DEV-COTIZACION'  THEN NumeroComprobante + @DEVCOTIZACION ELSE
                          CASE WHEN IdTipoComprobante = 'PRESUP'  THEN NumeroComprobante + @PRESUP ELSE
                          NumeroComprobante END END END AS xxNumeroComprobante
      ,[Orden]
      ,[IdProducto]
      ,[IdLote]
      ,[FechaVencimiento]
      ,[Cantidad]
	FROM SIGA_Distrib_Trinidad.dbo.VentasProductosLotes VPL
  WHERE VPL.IdSucursal = @IdSucOrigen
  AND IdTipoComprobante IN ('COTIZACION','DEV-COTIZACION','eFACT','eNCRED', 'PRESUP')

--------------


-- -- Cambio Sucursal de Ventas Blue.
 
--PRINT ''
--PRINT '11. Cambio Sucursal VentasNumeros.'
--;
--UPDATE SIGA_Distrib_Trinidad.dbo.VentasNumeros 
--   SET VentasNumeros.IdSucursal = @IdSucDestino
-- FROM SIGA_Distrib_Trinidad.dbo.VentasNumeros  VN
--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VN.IdTipoComprobante
--         AND (TC.AfectaCaja=1 AND TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
--  WHERE VN.IdSucursal = @IdSucOrigen
--;



----DELETE VentasObservaciones
---- WHERE IdSucursal = 1
----   AND EXISTS 
----     (SELECT * FROM Ventas V
----	    WHERE V.IdSucursal = @IdSucDestino
----          AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
----          AND V.Letra = VentasObservaciones.Letra
----          AND V.CentroEmisor = VentasObservaciones.CentroEmisor
----          AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante)
----;

----DELETE VentasImpuestos
---- WHERE IdSucursal = 1
----   AND EXISTS 
----     (SELECT * FROM Ventas V
----	    WHERE V.IdSucursal = @IdSucDestino
----          AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
----          AND V.Letra = VentasImpuestos.Letra
----          AND V.CentroEmisor = VentasImpuestos.CentroEmisor
----          AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante)
----;

----DELETE VentasProductos
---- WHERE IdSucursal = 1
----   AND EXISTS 
----     (SELECT * FROM Ventas V
----	    WHERE V.IdSucursal = @IdSucDestino
----          AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
----          AND V.Letra = VentasProductos.Letra
----          AND V.CentroEmisor = VentasProductos.CentroEmisor
----          AND V.NumeroComprobante = VentasProductos.NumeroComprobante)
----;

----DELETE Ventas
---- WHERE IdSucursal = 1
----   AND IdTipoComprobante <> 'REMITOTRANSP'
----   AND EXISTS 
----     (SELECT * FROM Ventas V
----	    WHERE V.IdSucursal = @IdSucDestino
----          AND V.IdTipoComprobante = Ventas.IdTipoComprobante
----          AND V.Letra = Ventas.Letra
----          AND V.CentroEmisor = Ventas.CentroEmisor
----          AND V.NumeroComprobante = Ventas.NumeroComprobante)
----;
