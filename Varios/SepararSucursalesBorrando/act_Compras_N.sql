DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 3
;

PRINT ''
PRINT '1. Elimino ComprasObservaciones.'
;

DELETE SIGA_Separada.dbo.ComprasObservaciones
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino ComprasImpuestos.'
;
DELETE SIGA_Separada.dbo.ComprasImpuestos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Elimino ComprasProductos.'
;
DELETE SIGA_Separada.dbo.ComprasProductos
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '4. Elimino Compras.'
;
DELETE SIGA_Separada.dbo.Compras
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '5. Inserto Compras.'
;

INSERT INTO SIGA_Separada.dbo.Compras
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
           ,[NumeroComprobanteVenta])
SELECT @IdSucDestino AS IdSucursal
           ,C.IdTipoComprobante
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
  FROM SIGA.dbo.Compras C
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
                                 AND TC.AfectaCaja=1 AND TC.GrabaLibro=0
  WHERE C.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '6. Inserto ComprasProductos.'
;
INSERT INTO SIGA_Separada.dbo.ComprasProductos
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
  FROM SIGA.dbo.ComprasProductos CP
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CP.IdTipoComprobante
                                  AND TC.AfectaCaja=1 AND TC.GrabaLibro=0 
  WHERE CP.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '7. Inserto ComprasImpuestos.'
;
INSERT INTO SIGA_Separada.dbo.ComprasImpuestos
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
  FROM SIGA.dbo.ComprasImpuestos CI
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante
                                   AND TC.AfectaCaja=1 AND TC.GrabaLibro=0
  WHERE CI.IdSucursal = @IdSucOrigen
;


PRINT ''
PRINT '8. Inserto ComprasObservaciones.'
;
INSERT INTO SIGA_Separada.dbo.ComprasObservaciones
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
  FROM SIGA.dbo.ComprasObservaciones CO
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CO.IdTipoComprobante
                                 AND TC.AfectaCaja=1 AND TC.GrabaLibro=0
  WHERE CO.IdSucursal = @IdSucOrigen
;


/* FALTA  */

-- ComprasCheques

--------------


 -- Cambio Sucursal de Compras Blue.
 
PRINT ''
PRINT '9. Cambio Sucursal ComprasNumeros.'
;
UPDATE SIGA_Separada.dbo.ComprasNumeros 
   SET ComprasNumeros.IdSucursal = @IdSucDestino
 FROM SIGA_Separada.dbo.ComprasNumeros CN
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CN.IdTipoComprobante
         AND TC.AfectaCaja=1 AND TC.GrabaLibro=0
  WHERE CN.IdSucursal = @IdSucOrigen
;


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
