
UPDATE Cheques
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

UPDATE Retenciones
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

------------- CUENTAS CORRIENTES ------------- 

INSERT INTO CuentasCorrientesProv
           (IdSucursal
           ,TipoDocProveedor
           ,NroDocProveedor
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,Fecha
           ,FechaVencimiento
           ,ImporteTotal
           ,IdFormasPago
           ,Observacion
           ,Saldo
           ,CantidadCuotas
           ,ImportePesos
           ,ImporteDolares
           ,ImporteEuros
           ,ImporteCheques
           ,ImporteTransfBancaria
           ,ImporteTickets
           ,IdCuentaBancaria
           ,IdCaja
           ,NumeroPlanilla
           ,NumeroMovimiento
           ,ImporteRetenciones)
SELECT IdSucursal
      ,'COD' AS XXTipoDocProveedor
      ,00 as XXNroDocProveedor
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,FechaVencimiento
      ,ImporteTotal
      ,IdFormasPago
      ,Observacion
      ,Saldo
      ,CantidadCuotas
      ,ImportePesos
      ,ImporteDolares
      ,ImporteEuros
      ,ImporteCheques
      ,ImporteTransfBancaria
      ,ImporteTickets
      ,IdCuentaBancaria
      ,IdCaja
      ,NumeroPlanilla
      ,NumeroMovimiento
      ,ImporteRetenciones
  FROM CuentasCorrientesProv
 WHERE TipoDocProveedor = 'COD'
   AND NroDocProveedor = -1
GO

UPDATE CuentasCorrientesProvCheques
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

UPDATE CuentasCorrientesProvPagos
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

UPDATE CuentasCorrientesProvRetenciones
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

DELETE CuentasCorrientesProv
 WHERE TipoDocProveedor = 'COD'
   AND NroDocProveedor = -1
GO

----------------------------------

UPDATE RecepcionNotasProveedoresF
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
  WHERE TipoDocProveedor = 'COD'
    AND NroDocProveedor = -1
GO

UPDATE RecepcionNotasProveedores
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

UPDATE MovimientosCompras
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

UPDATE FichasProductos
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

------------- CUENTAS CORRIENTES ------------- 

INSERT INTO Compras
           (IdSucursal
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroComprobante
           ,TipoDocProveedor
           ,NroDocProveedor
           ,Fecha
           ,TipoDocComprador
           ,NroDocComprador
           ,Neto210
           ,Neto10-1
           ,Neto270
           ,NetoNoGravado
           ,DescuentoRecargo
           ,IVA210
           ,IVA10-1
           ,IVA270
           ,ImporteTotal
           ,IdCategoriaFiscal
           ,IdFormasPago
           ,Observacion
           ,PorcentajeIVA
           ,IdRubro
           ,Bruto210
           ,Bruto10-1
           ,Bruto270
           ,BrutoNoGravado
           ,DescuentoRecargoPorc
           ,PercepcionIVA
           ,PercepcionIB
           ,PercepcionGanancias
           ,PercepcionVarias
           ,PeriodoFiscal)
SELECT IdSucursal
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,'COD' AS XXTipoDocProveedor
      ,00 as XXNroDocProveedor
      ,Fecha
      ,TipoDocComprador
      ,NroDocComprador
      ,Neto210
      ,Neto10-1
      ,Neto270
      ,NetoNoGravado
      ,DescuentoRecargo
      ,IVA210
      ,IVA10-1
      ,IVA270
      ,ImporteTotal
      ,IdCategoriaFiscal
      ,IdFormasPago
      ,Observacion
      ,PorcentajeIVA
      ,IdRubro
      ,Bruto210
      ,Bruto10-1
      ,Bruto270
      ,BrutoNoGravado
      ,DescuentoRecargoPorc
      ,PercepcionIVA
      ,PercepcionIB
      ,PercepcionGanancias
      ,PercepcionVarias
      ,PeriodoFiscal
  FROM Compras
 WHERE TipoDocProveedor = 'COD'
   AND NroDocProveedor = -1
GO

UPDATE ComprasProductos
   SET TipoDocProveedor = 'COD'
      ,NroDocProveedor = 00
   WHERE TipoDocProveedor = 'COD'
     AND NroDocProveedor = -1
GO

DELETE Compras
 WHERE TipoDocProveedor = 'COD'
   AND NroDocProveedor = -1
GO

----------------------------------

DELETE Proveedores
 WHERE TipoDocProveedor = 'COD'
   AND NroDocProveedor = -1
GO
