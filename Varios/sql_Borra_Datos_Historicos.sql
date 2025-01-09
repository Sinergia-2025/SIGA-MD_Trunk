
-- Fecha segun solicitud del cliente.

DECLARE @fecha as varchar(11) = '2019-10-01'
;

PRINT ''
PRINT 'Borro Tabla: MovimientosComprasProductos.'
;
DELETE FROM MovimientosComprasProductos
 WHERE EXISTS 
     (SELECT * FROM MovimientosCompras MC
       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = MC.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE MC.IdSucursal=MovimientosComprasProductos.IdSucursal
         AND MC.IdTipoMovimiento=MovimientosComprasProductos.IdTipoMovimiento
         AND MC.NumeroMovimiento=MovimientosComprasProductos.NumeroMovimiento
         AND CONVERT(varchar(11), MC.FechaMovimiento, 120) < @fecha
      )
;

PRINT ''
PRINT 'Borro Tabla: MovimientosCompras.'
;
DELETE A
 FROM MovimientosCompras A
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
  WHERE CONVERT(varchar(11), FechaMovimiento, 120) < @fecha
;

PRINT ''
PRINT 'Borro Tabla: ComprasProductos.'
;
DELETE ComprasProductos
 WHERE EXISTS 
     (SELECT * FROM Compras C
       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE C.IdSucursal=ComprasProductos.IdSucursal
         AND C.IdTipoComprobante=ComprasProductos.IdTipoComprobante
         AND C.Letra=ComprasProductos.Letra
         AND C.CentroEmisor=ComprasProductos.CentroEmisor
         AND C.NumeroComprobante=ComprasProductos.NumeroComprobante
         AND C.IdProveedor=ComprasProductos.IdProveedor
         AND CONVERT(varchar(11), C.Fecha, 120) < @fecha
      )
;

PRINT ''
PRINT 'Borro Tabla: ComprasImpuestos.'
;
DELETE ComprasImpuestos
 WHERE EXISTS 
     (SELECT * FROM Compras C
       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE C.IdSucursal=ComprasImpuestos.IdSucursal
         AND C.IdTipoComprobante=ComprasImpuestos.IdTipoComprobante
         AND C.Letra=ComprasImpuestos.Letra
         AND C.CentroEmisor=ComprasImpuestos.CentroEmisor
         AND C.NumeroComprobante=ComprasImpuestos.NumeroComprobante
         AND C.IdProveedor=ComprasImpuestos.IdProveedor
         AND CONVERT(varchar(11), C.Fecha, 120) < @fecha
      )
;

PRINT ''
PRINT 'Borro Tabla: Compras.'
;
DELETE A
 FROM Compras A
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
  WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
;

--DELETE ComprasNumeros CN
--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CN.IdTipoComprobante AND TC.GrabaLibro = 'False' 
--;

/* ---------------------------------------------------------------------------- */

-- Se ANULA EL BORRADO de la cuenta corriente. Deberia ser por saldo. Pensando un poco mas.

			--DELETE A
			--  FROM CuentasCorrientesProvPagos A
			--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--  WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
			--;

			--DELETE CuentasCorrientesProvCheques
			-- WHERE EXISTS 
			--     (SELECT * FROM CuentasCorrientesProv A
			--       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--       WHERE A.IdSucursal=CuentasCorrientesProvCheques.IdSucursal
			--         AND A.IdTipoComprobante=CuentasCorrientesProvCheques.IdTipoComprobante
			--         AND A.Letra=CuentasCorrientesProvCheques.Letra
			--         AND A.CentroEmisor=CuentasCorrientesProvCheques.CentroEmisor
			--         AND A.NumeroComprobante=CuentasCorrientesProvCheques.NumeroComprobante
			--         AND A.IdProveedor=CuentasCorrientesProvCheques.IdProveedor
			--         AND CONVERT(varchar(11), A.Fecha, 120) < @fecha
			--      )
			--;

			--DELETE A 
			--  FROM CuentasCorrientesProv A
			--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--  WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
			--;


			--DELETE CuentasCorrientesRetenciones 
			-- WHERE EXISTS 
			--     (SELECT * FROM CuentasCorrientes A
			--       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--       WHERE A.IdSucursal=CuentasCorrientesRetenciones.IdSucursal
			--         AND A.IdTipoComprobante=CuentasCorrientesRetenciones.IdTipoComprobante
			--         AND A.Letra=CuentasCorrientesRetenciones.Letra
			--         AND A.CentroEmisor=CuentasCorrientesRetenciones.CentroEmisor
			--         AND A.NumeroComprobante=CuentasCorrientesRetenciones.NumeroComprobante
			--         AND CONVERT(varchar(11), A.Fecha, 120) < @fecha
			--      )
			--;

			--DELETE A
			--  FROM CuentasCorrientesPagos A
			--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--  WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
			--;

			--DELETE CuentasCorrientesCheques 
			-- WHERE EXISTS 
			--     (SELECT * FROM CuentasCorrientes A
			--       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--       WHERE A.IdSucursal=CuentasCorrientesCheques.IdSucursal
			--         AND A.IdTipoComprobante=CuentasCorrientesCheques.IdTipoComprobante
			--         AND A.Letra=CuentasCorrientesCheques.Letra
			--         AND A.CentroEmisor=CuentasCorrientesCheques.CentroEmisor
			--         AND A.NumeroComprobante=CuentasCorrientesCheques.NumeroComprobante
			--         AND CONVERT(varchar(11), A.Fecha, 120) < @fecha
			--      )
			--;

			--DELETE A 
			--   FROM CuentasCorrientes A
			--  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
			--  WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
			--;

/* ---------------------------------------------------------------------------- */

PRINT ''
PRINT 'Borro Tabla: MovimientosVentasProductos.'
;
DELETE MovimientosVentasProductos
 WHERE EXISTS 
     (SELECT * FROM MovimientosVentas MV
       INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = MV.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE MV.IdSucursal=MovimientosVentasProductos.IdSucursal
         AND MV.IdTipoMovimiento=MovimientosVentasProductos.IdTipoMovimiento
         AND MV.NumeroMovimiento=MovimientosVentasProductos.NumeroMovimiento
         AND CONVERT(varchar(11), MV.FechaMovimiento, 120) < @fecha
      )
;

PRINT ''
PRINT 'Borro Tabla: RepartosComprobantesProductos.'
;
DELETE RepartosComprobantesProductos
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = RepartosComprobantesProductos.IdSucursal
         AND V.NumeroReparto = RepartosComprobantesProductos.IdReparto
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: RepartosComprobantes.'
;
--DELETE RepartosComprobantes
-- WHERE EXISTS 
--     ( SELECT * FROM Ventas V
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
--       WHERE V.IdSucursal = RepartosComprobantes.IdSucursal
--         AND V.NumeroReparto = RepartosComprobantes.IdReparto
--         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
--;

DELETE RepartosComprobantes
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
        INNER JOIN Repartos R ON R.IdSucursal = RepartosComprobantes.IdSucursal AND R.IdReparto = RepartosComprobantes.IdReparto
       WHERE V.IdSucursal = RepartosComprobantes.IdSucursal
         AND V.IdTipoComprobante = RepartosComprobantes.IdTipoComprobanteFact
         AND V.Letra = RepartosComprobantes.LetraFact
         AND V.CentroEmisor = RepartosComprobantes.CentroEmisorFact
         AND V.NumeroComprobante = RepartosComprobantes.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: PedidosObservaciones.'
;
DELETE PedidosObservaciones
 WHERE EXISTS 
     ( SELECT * FROM Pedidos P
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE P.IdSucursal = PedidosObservaciones.IdSucursal
         AND P.IdTipoComprobante = PedidosObservaciones.IdTipoComprobante
         AND P.Letra = PedidosObservaciones.Letra
         AND P.CentroEmisor = PedidosObservaciones.CentroEmisor
         AND P.NumeroPedido = PedidosObservaciones.NumeroPedido
         AND CONVERT(varchar(11), P.FechaPedido, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: PedidosProductosFormulas.'
;
DELETE PedidosProductosFormulas
 WHERE EXISTS 
     ( SELECT * FROM Pedidos P
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE P.IdSucursal = PedidosProductosFormulas.IdSucursal
         AND P.IdTipoComprobante = PedidosProductosFormulas.IdTipoComprobante
         AND P.Letra = PedidosProductosFormulas.Letra
         AND P.CentroEmisor = PedidosProductosFormulas.CentroEmisor
         AND P.NumeroPedido = PedidosProductosFormulas.NumeroPedido
         AND CONVERT(varchar(11), P.FechaPedido, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: PedidosEstados.'
;
DELETE PedidosEstados
 WHERE EXISTS 
     ( SELECT * FROM Pedidos P
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE P.IdSucursal = PedidosEstados.IdSucursal
         AND P.IdTipoComprobante = PedidosEstados.IdTipoComprobante
         AND P.Letra = PedidosEstados.Letra
         AND P.CentroEmisor = PedidosEstados.CentroEmisor
         AND P.NumeroPedido = PedidosEstados.NumeroPedido
         AND CONVERT(varchar(11), P.FechaPedido, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: PedidosProductos.'
;
DELETE PedidosProductos
 WHERE EXISTS 
     ( SELECT * FROM Pedidos P
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE P.IdSucursal = PedidosProductos.IdSucursal
         AND P.IdTipoComprobante = PedidosProductos.IdTipoComprobante
         AND P.Letra = PedidosProductos.Letra
         AND P.CentroEmisor = PedidosProductos.CentroEmisor
         AND P.NumeroPedido = PedidosProductos.NumeroPedido
         AND CONVERT(varchar(11), P.FechaPedido, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: Pedidos.'
;
DELETE A
  FROM Pedidos A
-- INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
 WHERE CONVERT(varchar(11), FechaPedido, 120) < @fecha
;

PRINT ''
PRINT 'Borro Tabla: MovimientosVentas.'
;
DELETE A
  FROM MovimientosVentas A
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
  WHERE CONVERT(varchar(11), FechaMovimiento, 120) < @fecha
;

--DELETE MovimientosNumeros
--;

--DELETE dbo.CartasAClientes
--;

--DELETE dbo.FichasPagosAjustes
--;

--DELETE dbo.FichasPagosDetalle
--;

--DELETE dbo.FichasPagos
--;

--DELETE dbo.FichasProductos
--;

--DELETE dbo.Fichas
--;

--DELETE RecepcionNotasProveedores
--;

--DELETE RecepcionNotasEstados
--;

--DELETE RecepcionNotas
--;

--DELETE RecepcionNotasProveedoresF
--;

--DELETE RecepcionNotasEstadosF
--;

--DELETE RecepcionNotasF
--;

PRINT ''
PRINT 'Borro Tabla: VentasTarjetas.'
;
DELETE VentasTarjetas
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasTarjetas.IdSucursal
         AND V.IdTipoComprobante = VentasTarjetas.IdTipoComprobante
         AND V.Letra = VentasTarjetas.Letra
         AND V.CentroEmisor = VentasTarjetas.CentroEmisor
         AND V.NumeroComprobante = VentasTarjetas.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasImpuestos.'
;
DELETE VentasImpuestos
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasImpuestos.IdSucursal
         AND V.IdTipoComprobante = VentasImpuestos.IdTipoComprobante
         AND V.Letra = VentasImpuestos.Letra
         AND V.CentroEmisor = VentasImpuestos.CentroEmisor
         AND V.NumeroComprobante = VentasImpuestos.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasObservaciones.'
;
DELETE VentasObservaciones
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasObservaciones.IdSucursal
         AND V.IdTipoComprobante = VentasObservaciones.IdTipoComprobante
         AND V.Letra = VentasObservaciones.Letra
         AND V.CentroEmisor = VentasObservaciones.CentroEmisor
         AND V.NumeroComprobante = VentasObservaciones.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasProductosLotes.'
;
DELETE VentasProductosLotes
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasProductosLotes.IdSucursal
         AND V.IdTipoComprobante = VentasProductosLotes.IdTipoComprobante
         AND V.Letra = VentasProductosLotes.Letra
         AND V.CentroEmisor = VentasProductosLotes.CentroEmisor
         AND V.NumeroComprobante = VentasProductosLotes.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasProductos.'
;
DELETE VentasProductos
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasProductos.IdSucursal
         AND V.IdTipoComprobante = VentasProductos.IdTipoComprobante
         AND V.Letra = VentasProductos.Letra
         AND V.CentroEmisor = VentasProductos.CentroEmisor
         AND V.NumeroComprobante = VentasProductos.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasCheques.'
;
DELETE VentasCheques
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasCheques.IdSucursal
         AND V.IdTipoComprobante = VentasCheques.IdTipoComprobante
         AND V.Letra = VentasCheques.Letra
         AND V.CentroEmisor = VentasCheques.CentroEmisor
         AND V.NumeroComprobante = VentasCheques.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasChequesRechazados.'
;
DELETE VentasChequesRechazados
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasChequesRechazados.IdSucursal
         AND V.IdTipoComprobante = VentasChequesRechazados.IdTipoComprobante
         AND V.Letra = VentasChequesRechazados.Letra
         AND V.CentroEmisor = VentasChequesRechazados.CentroEmisor
         AND V.NumeroComprobante = VentasChequesRechazados.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;

PRINT ''
PRINT 'Borro Tabla: VentasPercepciones.'
;
DELETE VentasPercepciones
 WHERE EXISTS 
     ( SELECT * FROM Ventas V
        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
       WHERE V.IdSucursal = VentasPercepciones.IdSucursal
         AND V.IdTipoComprobante = VentasPercepciones.IdTipoComprobante
         AND V.Letra = VentasPercepciones.Letra
         AND V.CentroEmisor = VentasPercepciones.CentroEmisor
         AND V.NumeroComprobante = VentasPercepciones.NumeroComprobante
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
;


--DELETE RepartosComprobantes
-- WHERE EXISTS 
--     ( SELECT * FROM Ventas V
--        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.GrabaLibro = 'False' 
--       WHERE V.IdSucursal = RepartosComprobantes.IdSucursal
--         AND V.IdTipoComprobante = RepartosComprobantes.IdTipoComprobanteFact
--         AND V.Letra = RepartosComprobantes.LetraFact
--         AND V.CentroEmisor = RepartosComprobantes.CentroEmisorFact
--         AND V.NumeroComprobante = RepartosComprobantes.NumeroComprobante
--         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
--;

PRINT ''
PRINT 'Borro Tabla: Ventas.'
;
DELETE A
  FROM Ventas A
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = A.IdTipoComprobante AND TC.GrabaLibro = 'False' 
 WHERE CONVERT(varchar(11), Fecha, 120) < @fecha
;

--UPDATE VentasNumeros
--   SET Numero = 0
--;   

--DELETE VentasNumeros
--  WHERE IdTipoComprobanteRelacionado IS NULL
--;   

--DELETE PeriodosFiscales
--;

--DELETE LibrosBancos 
--;

--DELETE DepositosCheques
--;

--DELETE Depositos
--;

--DELETE ChequesHistorial
--;

--DELETE Cheques
--;

--DELETE Retenciones
--;

PRINT ''
PRINT 'Borro Tabla: CajasDetalle.'
;
DELETE CajasDetalle
 WHERE CONVERT(varchar(11), FechaMovimiento, 120) < @fecha
   AND NOT EXISTS
     ( SELECT * FROM Ventas V
       WHERE V.IdSucursal = CajasDetalle.IdSucursal
         AND V.IdCaja = CajasDetalle.IdCaja
         AND V.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND V.NumeroMovimiento = CajasDetalle.NumeroMovimiento
         AND CONVERT(varchar(11), V.Fecha, 120) < @fecha)
   AND NOT EXISTS
     ( SELECT * FROM CuentasCorrientes CC
       WHERE CC.IdSucursal = CajasDetalle.IdSucursal
         AND CC.IdCaja = CajasDetalle.IdCaja
         AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
         AND CONVERT(varchar(11), CC.Fecha, 120) < @fecha)
   AND NOT EXISTS
     ( SELECT * FROM CuentasCorrientesProv CCP
       WHERE CCP.IdSucursal = CajasDetalle.IdSucursal
         AND CCP.IdCaja = CajasDetalle.IdCaja
         AND CCP.NumeroPlanilla = CajasDetalle.NumeroPlanilla
         AND CCP.NumeroMovimiento = CajasDetalle.NumeroMovimiento
         AND CONVERT(varchar(11), CCP.Fecha, 120) < @fecha)
;

--DELETE Cajas WHERE NumeroPlanilla>1
--;

-- REEMPLAZAR POR UNO QUE LOS RECALCULE.
--UPDATE Cajas
--   SET PesosSaldoInicial=0
--      ,PesosSaldoFinal=0
--      ,ChequesSaldoInicial = 0
--      ,ChequesSaldoFinal = 0
--      ,TarjetasSaldoInicial = 0
--      ,TarjetasSaldoFinal = 0
--      ,TicketsSaldoInicial = 0
--      ,TicketsSaldoFinal = 0
--      ,RetencionesSaldoInicial = 0
--      ,RetencionesSaldoFinal = 0
--      ,BancosSaldoInicial = 0
--      ,BancosSaldoFinal = 0
--;

PRINT ''
PRINT 'Borro Tabla: HistorialPrecios.'
;
DELETE HistorialPrecios
 WHERE CONVERT(varchar(11), FechaHora, 120) < @fecha
;

PRINT ''
PRINT 'Borro Tabla: HistorialConsultaProductos.'
;
DELETE HistorialConsultaProductos
 WHERE CONVERT(varchar(11), FechaHora, 120) < @fecha
;

--DELETE ProductosNrosSerie
--;

--DELETE ProductosLotes
--;

--DELETE ProductosSucursalesPrecios
-- WHERE IdProducto NOT IN 
--  (SELECT IdProducto FROM dbo.MovimientosVentasProductos UNION SELECT IdProducto FROM dbo.MovimientosComprasProductos)
--;

--DELETE ProductosSucursales
-- WHERE IdProducto NOT IN 
--  (SELECT IdProducto FROM dbo.MovimientosVentasProductos UNION SELECT IdProducto FROM dbo.MovimientosComprasProductos)
--;

--DELETE Productos
-- WHERE IdProducto NOT IN 
--  (SELECT IdProducto FROM dbo.MovimientosVentasProductos UNION SELECT IdProducto FROM dbo.MovimientosComprasProductos)
--;


--DELETE AuditoriaClientes
--   WHERE CONVERT(varchar(11), FechaAuditoria, 120) >= '2011-01-25'
--;

--DELETE ProduccionProductosComponentes
--;

--DELETE ProduccionProductos
--;

--DELETE Produccion
--;

--DELETE Alquileres
--;

--DELETE ContabilidadAsientosCuentas
--;

--DELETE ContabilidadAsientos
--;

--UPDATE ProductosSucursales SET
--  StockInicial = 0,
--  Stock = 0
--;

--UPDATE ProductosSucursales 
-- SET ProductosSucursales.Stock = 
--        ( SELECT SUM(cantidad) FROM MovimientosComprasProductos b
--            WHERE ProductosSucursales.idproducto = b.idproducto
--          )
-- WHERE ProductosSucursales.idsucursal = 1
--   AND EXISTS 
--     ( SELECT * FROM MovimientosComprasProductos MCP
--       WHERE MCP.idproducto = ProductosSucursales.idproducto
--     )
--;

--UPDATE ProductosSucursales
-- SET ProductosSucursales.Stock = ProductosSucursales.Stock
--      + ( SELECT sum(cantidad) from MovimientosVentasProductos b
--           WHERE ProductosSucursales.idproducto=b.idproducto
--         )
-- where ProductosSucursales.idsucursal=1
--   AND EXISTS 
--     ( SELECT * FROM MovimientosVentasProductos MVP
--       WHERE MVP.idproducto=ProductosSucursales.idproducto
--     )
--;

--UPDATE ProductosSucursales SET 
--   StockInicial = 0
--   , Stock = 0
-- WHERE EXISTS 
--     ( SELECT * FROM Productos P
--        WHERE P.idproducto=ProductosSucursales.idproducto
--          AND P.AfectaStock = 'False'
--     )
--;
