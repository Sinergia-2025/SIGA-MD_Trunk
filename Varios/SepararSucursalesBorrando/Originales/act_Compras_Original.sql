
INSERT INTO Compras
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,TipoDocComprador
           ,NroDocComprador
           ,Neto210
           ,Neto105
           ,Neto270
           ,NetoNoGravado
           ,DescuentoRecargo
           ,IVA210
           ,IVA105
           ,IVA270
           ,ImporteTotal
           ,IdCategoriaFiscal
           ,IdFormasPago
           ,Observacion
           ,PorcentajeIVA
           ,IdRubro
           ,Bruto210
           ,Bruto105
           ,Bruto270
           ,BrutoNoGravado
           ,DescuentoRecargoPorc
           ,PercepcionIVA
           ,PercepcionIB
           ,PercepcionGanancias
           ,PercepcionVarias
           ,PeriodoFiscal
           ,IdAsiento
           ,ImportePesos
           ,ImporteTarjetas
           ,ImporteCheques
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,IdEstadoComprobante
           ,IdTipoComprobanteFact
           ,LetraFact
           ,CentroEmisorFact
           ,NumeroComprobanteFact
           ,CantidadInvocados
           ,IdProveedor
           ,IdProveedorFact
           ,Usuario
           ,FechaActualizacion
           ,IdPlanCuenta
           ,CotizacionDolar
           ,FechaOficializacionDespacho
           ,IdAduana
           ,IdDestinacion
           ,NumeroDespacho
           ,DigitoVerificadorDespacho
           ,IdDespachante
           ,IdAgenteTransporte
           ,DerechoAduanero
           ,BienCapitalDespacho
           ,MetodoGrabacion
           ,IdFuncion)
SELECT 3 AS IdSucursal
           ,C.IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,TipoDocComprador
           ,NroDocComprador
           ,Neto210
           ,Neto105
           ,Neto270
           ,NetoNoGravado
           ,DescuentoRecargo
           ,IVA210
           ,IVA105
           ,IVA270
           ,ImporteTotal
           ,IdCategoriaFiscal
           ,IdFormasPago
           ,Observacion
           ,PorcentajeIVA
           ,IdRubro
           ,Bruto210
           ,Bruto105
           ,Bruto270
           ,BrutoNoGravado
           ,DescuentoRecargoPorc
           ,PercepcionIVA
           ,PercepcionIB
           ,PercepcionGanancias
           ,PercepcionVarias
           ,PeriodoFiscal
           ,IdAsiento
           ,ImportePesos
           ,ImporteTarjetas
           ,ImporteCheques
           ,ImporteTransfBancaria
           ,IdCuentaBancaria
           ,IdEstadoComprobante
           ,IdTipoComprobanteFact
           ,LetraFact
           ,CentroEmisorFact
           ,NumeroComprobanteFact
           ,CantidadInvocados
           ,IdProveedor
           ,IdProveedorFact
           ,Usuario
           ,FechaActualizacion
           ,C.IdPlanCuenta
           ,CotizacionDolar
           ,FechaOficializacionDespacho
           ,IdAduana
           ,IdDestinacion
           ,NumeroDespacho
           ,DigitoVerificadorDespacho
           ,IdDespachante
           ,IdAgenteTransporte
           ,DerechoAduanero
           ,BienCapitalDespacho
           ,MetodoGrabacion
           ,IdFuncion
  FROM Compras C
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
                                 AND TC.GrabaLibro=0
  WHERE C.IdSucursal = 1
GO

-------------------

INSERT INTO ComprasProductos
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
           ,[PasajeMovimiento]
           ,[MontoAplicado]
           ,[MontoSaldo]
           ,[ProporcionalImp]
           ,[IdConcepto]
           ,[IdCentroCosto])
SELECT 3 AS IdSucursal
           ,CP.IdTipoComprobante
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
           ,[PasajeMovimiento]
           ,[MontoAplicado]
           ,[MontoSaldo]
           ,[ProporcionalImp]
           ,[IdConcepto]
           ,[IdCentroCosto]
  FROM ComprasProductos CP
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CP.IdTipoComprobante
                                  AND TC.GrabaLibro=0 
  WHERE CP.IdSucursal = 1
GO

INSERT INTO ComprasImpuestos
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdProveedor]
           ,[Orden]
           ,[IdTipoImpuesto]
           ,[IdProvincia]
           ,[Emisor]
           ,[Numero]
           ,[BaseImponible]
           ,[Alicuota]
           ,[Importe]
           ,[EsDespacho])
SELECT 3 AS IdSucursal
           ,CI.IdTipoComprobante
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[IdProveedor]
           ,[Orden]
           ,[IdTipoImpuesto]
           ,[IdProvincia]
           ,[Emisor]
           ,[Numero]
           ,[BaseImponible]
           ,[Alicuota]
           ,[Importe]
           ,[EsDespacho]
  FROM ComprasImpuestos CI
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante
                                   AND TC.GrabaLibro=0
  WHERE CI.IdSucursal = 1
GO

INSERT INTO ComprasObservaciones
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Linea]
           ,[Observacion]
           ,[IdProveedor])
SELECT 3 AS IdSucursal
           ,CO.IdTipoComprobante
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Linea]
           ,[Observacion]
           ,[IdProveedor]
  FROM ComprasObservaciones CO
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CO.IdTipoComprobante
                                 AND TC.GrabaLibro=0 
  WHERE CO.IdSucursal = 1
GO


DELETE ComprasObservaciones
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM Compras C
	    WHERE C.IdSucursal = 3
          AND C.IdProveedor = ComprasObservaciones.IdProveedor
          AND C.IdTipoComprobante = ComprasObservaciones.IdTipoComprobante
          AND C.Letra = ComprasObservaciones.Letra
          AND C.CentroEmisor = ComprasObservaciones.CentroEmisor
          AND C.NumeroComprobante = ComprasObservaciones.NumeroComprobante)
GO

DELETE ComprasImpuestos
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM Compras C
	    WHERE C.IdSucursal = 3
          AND C.IdProveedor = ComprasImpuestos.IdProveedor
          AND C.IdTipoComprobante = ComprasImpuestos.IdTipoComprobante
          AND C.Letra = ComprasImpuestos.Letra
          AND C.CentroEmisor = ComprasImpuestos.CentroEmisor
          AND C.NumeroComprobante = ComprasImpuestos.NumeroComprobante)
GO

DELETE ComprasProductos
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM Compras C
	    WHERE C.IdSucursal = 3
          AND C.IdProveedor = ComprasProductos.IdProveedor
          AND C.IdTipoComprobante = ComprasProductos.IdTipoComprobante
          AND C.Letra = ComprasProductos.Letra
          AND C.CentroEmisor = ComprasProductos.CentroEmisor
          AND C.NumeroComprobante = ComprasProductos.NumeroComprobante)
GO

DELETE Compras
 WHERE IdSucursal = 1
   AND EXISTS 
     (SELECT * FROM Compras C
	    WHERE C.IdSucursal = 3
          AND C.IdProveedor = Compras.IdProveedor
          AND C.IdTipoComprobante = Compras.IdTipoComprobante
          AND C.Letra = Compras.Letra
          AND C.CentroEmisor = Compras.CentroEmisor
          AND C.NumeroComprobante = Compras.NumeroComprobante)
GO
