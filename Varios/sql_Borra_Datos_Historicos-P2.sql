
DELETE MovimientosComprasProductos
 WHERE EXISTS 
     (SELECT * FROM MovimientosCompras MC
       WHERE MC.IdSucursal=MovimientosComprasProductos.IdSucursal
         AND MC.IdTipoMovimiento=MovimientosComprasProductos.IdTipoMovimiento
         AND MC.NumeroMovimiento=MovimientosComprasProductos.NumeroMovimiento
         AND CONVERT(varchar(11), MC.FechaMovimiento, 120) >= '2014-01-01')
GO

DELETE MovimientosCompras
  WHERE CONVERT(varchar(11), FechaMovimiento, 120) >= '2014-01-01'
GO

DELETE ComprasProductos
 WHERE EXISTS 
     (SELECT * FROM Compras C
       WHERE C.IdSucursal=ComprasProductos.IdSucursal
         AND C.IdTipoComprobante=ComprasProductos.IdTipoComprobante
         AND C.Letra=ComprasProductos.Letra
         AND C.CentroEmisor=ComprasProductos.CentroEmisor
         AND C.NumeroComprobante=ComprasProductos.NumeroComprobante
         AND C.TipoDocProveedor=ComprasProductos.TipoDocProveedor
         AND C.NroDocProveedor=ComprasProductos.NroDocProveedor
         AND CONVERT(varchar(11), C.Fecha, 120) >= '2014-01-01')
GO

DELETE Compras
  WHERE CONVERT(varchar(11), Fecha, 120) >= '2014-01-01'
GO

DELETE MovimientosVentasProductos
 WHERE EXISTS 
     (SELECT * FROM MovimientosVentas MV
       WHERE MV.IdSucursal=MovimientosVentasProductos.IdSucursal
         AND MV.IdTipoMovimiento=MovimientosVentasProductos.IdTipoMovimiento
         AND MV.NumeroMovimiento=MovimientosVentasProductos.NumeroMovimiento
         AND CONVERT(varchar(11), MV.FechaMovimiento, 120) >= '2014-01-01')
GO

DELETE MovimientosVentas
  WHERE CONVERT(varchar(11), FechaMovimiento, 120) >= '2014-01-01'
GO

DELETE VentasTarjetas
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasTarjetas.IdSucursal
         AND V.IdTipoComprobante = VentasTarjetas.IdTipoComprobante
         AND V.Letra = VentasTarjetas.Letra
         AND V.CentroEmisor = VentasTarjetas.CentroEmisor
         AND V.NumeroComprobante = VentasTarjetas.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasImpuestos
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasObservaciones
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasProductosLotes
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasProductos
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasCheques
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE VentasChequesRechazados
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) >= '2014-01-01')
GO

DELETE Ventas
 WHERE CONVERT(varchar(11), Fecha, 120) >= '2014-01-01'
GO

-- LO CORRECTO SERIA RECALCULAR EL MAX, PERO LA BASE ES HISTORICA, DEJA DE USARSE.
--UPDATE VentasNumeros
--   SET Numero = 0
--GO   

--DELETE VentasNumeros
--  WHERE IdTipoComprobanteRelacionado IS NULL
--GO   

DELETE PeriodosFiscales
 WHERE PeriodoFiscal >= 201401
GO

DELETE LibrosBancos 
 WHERE CONVERT(varchar(11), FechaMovimiento, 120) >= '2014-01-01'
GO

--DELETE DepositosCheques
--GO

--DELETE Depositos
--GO

--DELETE ChequesHistorial
--GO

--DELETE Cheques
--GO

--DELETE Retenciones
--GO

--DELETE CajasDetalle
-- WHERE EXISTS 
--     ( SELECT * FROM Cajas C
--       WHERE C.IdSucursal = CajasDetalle.IdSucursal
--         AND C.IdCaja = CajasDetalle.IdCaja
--         AND C.NumeroPlanilla = CajasDetalle.NumeroPlanilla
--         AND CONVERT(varchar(11), C.FechaPlanilla, 120) >= '2014-01-01')
--GO

--DELETE Cajas 
-- WHERE CONVERT(varchar(11), C.FechaPlanilla, 120) >= '2014-01-01'
--GO

DELETE HistorialPrecios
 WHERE CONVERT(varchar(11), FechaHora, 120) >= '2014-01-01'
GO

DELETE HistorialConsultaProductos
 WHERE CONVERT(varchar(11), FechaHora, 120) >= '2014-01-01'
GO

UPDATE ProductosSucursales SET
  --StockInicial = 0,
  Stock = 0
GO

UPDATE ProductosSucursales 
 SET ProductosSucursales.Stock = 
        ( SELECT SUM(cantidad) FROM MovimientosComprasProductos b
            WHERE ProductosSucursales.idproducto = b.idproducto
          )
 WHERE ProductosSucursales.idsucursal = 1
   AND EXISTS 
     ( SELECT * FROM MovimientosComprasProductos MCP
       WHERE MCP.idproducto = ProductosSucursales.idproducto
     )
GO


UPDATE ProductosSucursales
 SET ProductosSucursales.Stock = ProductosSucursales.Stock
      + ( SELECT sum(cantidad) from MovimientosVentasProductos b
           WHERE ProductosSucursales.idproducto=b.idproducto
         )
 where ProductosSucursales.idsucursal=1
   AND EXISTS 
     ( SELECT * FROM MovimientosVentasProductos MVP
       WHERE MVP.idproducto=ProductosSucursales.idproducto
     )
GO

UPDATE ProductosSucursales SET 
   StockInicial = 0
   , Stock = 0
 WHERE EXISTS 
     ( SELECT * FROM Productos P
        WHERE P.idproducto=ProductosSucursales.idproducto
          AND P.AfectaStock = 'False'
     )
GO
