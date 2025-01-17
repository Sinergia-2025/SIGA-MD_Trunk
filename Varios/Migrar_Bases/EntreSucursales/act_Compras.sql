DECLARE @IdSucOrigen INT = 5
DECLARE @IdSucDestino INT = 1
;

PRINT ''
PRINT '5. Inserto Compras.'
;

INSERT INTO SIGA_Distrib_Trinidad.dbo.Compras
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[TipoDocComprador]
           ,[NroDocComprador]
           ,[Neto210_Viejo]
           ,[Neto105_Viejo]
           ,[Neto270_Viejo]
           ,[NetoNoGravado_Viejo]
           ,[DescuentoRecargo]
           ,[IVA210_Viejo]
           ,[IVA105_Viejo]
           ,[IVA270_Viejo]
           ,[ImporteTotal]
           ,[IdCategoriaFiscal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[PorcentajeIVA]
           ,[IdRubro]
           ,[Bruto210_Viejo]
           ,[Bruto105_Viejo]
           ,[Bruto270_Viejo]
           ,[BrutoNoGravado_Viejo]
           ,[DescuentoRecargoPorc]
           ,[PercepcionIVA]
           ,[PercepcionIB]
           ,[PercepcionGanancias]
           ,[PercepcionVarias]
           ,[PeriodoFiscal]
           ,[IdAsiento]
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
           ,[IdPlanCuenta]
           ,[CotizacionDolar]
           ,[FechaOficializacionDespacho]
           ,[IdAduana]
           ,[IdDestinacion]
           ,[NumeroDespacho]
           ,[DigitoVerificadorDespacho]
           ,[IdDespachante]
           ,[IdAgenteTransporte]
           ,[DerechoAduanero]
           ,[BienCapitalDespacho]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[NumeroManifiestoDespacho]
           ,[Bultos]
           ,[ValorDeclarado]
           ,[IdTransportista]
           ,[NumeroLote]
           ,[IVA105Calculado]
           ,[IVA210Calculado]
           ,[IVA270Calculado]
           ,[IVAModificadoManual]
           ,[TotalBruto]
           ,[TotalNeto]
           ,[TotalIVA]
           ,[TotalPercepciones]
           ,[IdSucursalVenta]
           ,[IdTipoComprobanteVenta]
           ,[LetraVenta]
           ,[CentroEmisorVenta]
           ,[NumeroComprobanteVenta]
		   ,[IdEmpresa]
		  ,[NombreProveedor]
		  ,[CuitProveedor]
		  ,[IdCaja]
		  ,[NumeroPlanilla]
		  ,[NumeroMovimiento])
SELECT @IdSucDestino AS IdSucursal
           ,C.IdTipoComprobante
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[TipoDocComprador]
           ,[NroDocComprador]
           ,[Neto210_Viejo]
           ,[Neto105_Viejo]
           ,[Neto270_Viejo]
           ,[NetoNoGravado_Viejo]
           ,[DescuentoRecargo]
           ,[IVA210_Viejo]
           ,[IVA105_Viejo]
           ,[IVA270_Viejo]
           ,[ImporteTotal]
           ,[IdCategoriaFiscal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[PorcentajeIVA]
           ,[IdRubro]
           ,[Bruto210_Viejo]
           ,[Bruto105_Viejo]
           ,[Bruto270_Viejo]
           ,[BrutoNoGravado_Viejo]
           ,[DescuentoRecargoPorc]
           ,[PercepcionIVA]
           ,[PercepcionIB]
           ,[PercepcionGanancias]
           ,[PercepcionVarias]
           ,[PeriodoFiscal]
           ,[IdAsiento]
           ,[ImportePesos]
           ,[ImporteTarjetas]
           ,[ImporteCheques]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[IdEstadoComprobante]
           ,NULL AS xxIdTipoComprobanteFact
           ,NULL AS xxLetraFact
           ,NULL AS xxCentroEmisorFact
           ,NULL AS xxNumeroComprobanteFact
           ,[CantidadInvocados]
           ,[IdProveedor]
           ,[IdProveedorFact]
           ,[Usuario]
           ,[FechaActualizacion]
           ,C.IdPlanCuenta
           ,[CotizacionDolar]
           ,[FechaOficializacionDespacho]
           ,[IdAduana]
           ,[IdDestinacion]
           ,[NumeroDespacho]
           ,[DigitoVerificadorDespacho]
           ,[IdDespachante]
           ,[IdAgenteTransporte]
           ,[DerechoAduanero]
           ,[BienCapitalDespacho]
           ,[MetodoGrabacion]
           ,[IdFuncion]
           ,[NumeroManifiestoDespacho]
           ,[Bultos]
           ,[ValorDeclarado]
           ,[IdTransportista]
           ,[NumeroLote]
           ,[IVA105Calculado]
           ,[IVA210Calculado]
           ,[IVA270Calculado]
           ,[IVAModificadoManual]
           ,[TotalBruto]
           ,[TotalNeto]
           ,[TotalIVA]
           ,[TotalPercepciones]
           ,[IdSucursalVenta]
           ,[IdTipoComprobanteVenta]
           ,[LetraVenta]
           ,[CentroEmisorVenta]
           ,[NumeroComprobanteVenta]
		   ,[IdEmpresa]
		  ,[NombreProveedor]
		  ,[CuitProveedor]
		  ,[IdCaja]
		  ,[NumeroPlanilla]
		  ,[NumeroMovimiento]
  FROM SIGA_Distrib_Trinidad.dbo.Compras C
  WHERE C.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '6. Inserto ComprasProductos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.ComprasProductos
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProducto
           ,Cantidad
           ,Precio
           ,DescRecGeneral
           ,DescuentoRecargo
           ,ImporteTotal
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc
           ,DescRecGeneralProducto
           ,PrecioNeto
           ,ImporteTotalNeto
           ,PorcentajeIVA
           ,IVA
           ,Orden
           ,NombreProducto
           ,IdProveedor
           ,IdConcepto
           ,PasajeMovimiento
           ,MontoAplicado
           ,MontoSaldo
           ,ProporcionalImp
           ,IdCentroCosto)
SELECT @IdSucDestino AS IdSucursal
           ,CP.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProducto
           ,Cantidad
           ,Precio
           ,DescRecGeneral
           ,DescuentoRecargo
           ,ImporteTotal
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc
           ,DescRecGeneralProducto
           ,PrecioNeto
           ,ImporteTotalNeto
           ,PorcentajeIVA
           ,IVA
           ,Orden
           ,NombreProducto
           ,IdProveedor
           ,IdConcepto
           ,PasajeMovimiento
           ,MontoAplicado
           ,MontoSaldo
           ,ProporcionalImp
           ,IdCentroCosto
  FROM SIGA_Distrib_Trinidad.dbo.ComprasProductos CP
  WHERE CP.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '7. Inserto ComprasImpuestos.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.ComprasImpuestos
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProveedor
           ,Orden
           ,IdTipoImpuesto
           ,IdProvincia
           ,Emisor
           ,Numero
           ,BaseImponible
           ,Alicuota
           ,Importe
           ,EsDespacho
           ,Bruto)
SELECT @IdSucDestino AS IdSucursal
           ,CI.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,IdProveedor
           ,Orden
           ,IdTipoImpuesto
           ,IdProvincia
           ,Emisor
           ,Numero
           ,BaseImponible
           ,Alicuota
           ,Importe
           ,EsDespacho
           ,Bruto
  FROM SIGA_Distrib_Trinidad.dbo.ComprasImpuestos CI
  WHERE CI.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '8. Inserto ComprasObservaciones.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.ComprasObservaciones
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Linea
           ,Observacion
           ,IdProveedor)
SELECT @IdSucDestino AS IdSucursal
           ,CO.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Linea
           ,Observacion
           ,IdProveedor
  FROM SIGA_Distrib_Trinidad.dbo.ComprasObservaciones CO
  WHERE CO.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '9. Inserto ComprasCheques.'
;
INSERT INTO SIGA_Distrib_Trinidad.dbo.ComprasCheques
           (IdSucursal
           ,[IdTipoComprobante]
			  ,[Letra]
			  ,[CentroEmisor]
			  ,[NumeroComprobante]
			  ,[NumeroCheque]
			  ,[IdBanco]
			  ,[IdBancoSucursal]
			  ,[IdLocalidad]
			  ,[IdProveedor])
SELECT @IdSucDestino AS IdSucursal
           ,[IdTipoComprobante]
			  ,[Letra]
			  ,[CentroEmisor]
			  ,[NumeroComprobante]
			  ,[NumeroCheque]
			  ,[IdBanco]
			  ,[IdBancoSucursal]
			  ,[IdLocalidad]
			  ,[IdProveedor]
  FROM SIGA_Distrib_Trinidad.dbo.ComprasCheques CC
  WHERE CC.IdSucursal = @IdSucOrigen
;

--------------


--DELETE ComprasObservaciones
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Compras C
--	    WHERE C.IdSucursal = 3
--          AND C.IdProveedor = ComprasObservaciones.IdProveedor
--          AND C.IdTipoComprobante = ComprasObservaciones.IdTipoComprobante
--          AND C.Letra = ComprasObservaciones.Letra
--          AND C.CentroEmisor = ComprasObservaciones.CentroEmisor
--          AND C.NumeroComprobante = ComprasObservaciones.NumeroComprobante)
--;

--DELETE ComprasImpuestos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Compras C
--	    WHERE C.IdSucursal = 3
--          AND C.IdProveedor = ComprasImpuestos.IdProveedor
--          AND C.IdTipoComprobante = ComprasImpuestos.IdTipoComprobante
--          AND C.Letra = ComprasImpuestos.Letra
--          AND C.CentroEmisor = ComprasImpuestos.CentroEmisor
--          AND C.NumeroComprobante = ComprasImpuestos.NumeroComprobante)
--;

--DELETE ComprasProductos
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Compras C
--	    WHERE C.IdSucursal = 3
--          AND C.IdProveedor = ComprasProductos.IdProveedor
--          AND C.IdTipoComprobante = ComprasProductos.IdTipoComprobante
--          AND C.Letra = ComprasProductos.Letra
--          AND C.CentroEmisor = ComprasProductos.CentroEmisor
--          AND C.NumeroComprobante = ComprasProductos.NumeroComprobante)
--;

--DELETE Compras
-- WHERE IdSucursal = 1
--   AND EXISTS 
--     (SELECT * FROM Compras C
--	    WHERE C.IdSucursal = 3
--          AND C.IdProveedor = Compras.IdProveedor
--          AND C.IdTipoComprobante = Compras.IdTipoComprobante
--          AND C.Letra = Compras.Letra
--          AND C.CentroEmisor = Compras.CentroEmisor
--          AND C.NumeroComprobante = Compras.NumeroComprobante)
--;
