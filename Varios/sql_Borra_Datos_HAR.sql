-- Primero limpiar referencias a contabilidad.
--  d:\Sistemas\VB.NET_2013\App\SiGA\trunk\Varios\act_Contabilidad_LimpiaTodaContabilidadDesdeUnIdAsiento.sql

DELETE ContabilidadAsientosCuentasTmp
GO

DELETE ContabilidadAsientosTmp
GO

DELETE ContabilidadAsientosCuentas
GO

DELETE ContabilidadAsientos
GO

DELETE MovimientosComprasProductos
GO

DELETE MovimientosCompras
GO

--- Se borra antes los pedidos de clientte spor la Referencia desde Proveedores.

DELETE PedidosEstados
GO

DELETE PedidosProductos
GO

DELETE PedidosObservaciones
GO

DELETE Pedidos
GO

DELETE PedidosEstadosProveedores
GO

DELETE PedidosProductosProveedores
GO

DELETE PedidosObservacionesProveedores
GO

DELETE PedidosProveedores
GO

DELETE ComprasObservaciones
GO

DELETE ComprasImpuestos
GO

DELETE ComprasProductos
GO

DELETE ComprasCheques
GO

DELETE Compras
GO

DELETE ComprasNumeros
GO

DELETE CuentasCorrientesProvRetenciones
GO

DELETE CuentasCorrientesProvPagos 
GO

DELETE CuentasCorrientesProvCheques 
GO

DELETE CuentasCorrientesProv
GO

DELETE CuentasCorrientesTarjetas 
GO

DELETE CuentasCorrientesRetenciones 
GO

DELETE CuentasCorrientesPagos 
GO

DELETE CuentasCorrientesCheques 
GO

DELETE CuentasCorrientesTransferencias
GO

DELETE CuentasCorrientes
GO

DELETE MovimientosVentasProductos
GO

DELETE MovimientosVentas
GO

DELETE MovimientosNumeros
GO

DELETE CartasAClientes
GO

DELETE FichasPagosAjustes
GO

DELETE FichasPagosDetalle
GO

DELETE FichasPagos
GO

DELETE FichasProductos
GO

DELETE Fichas
GO

DELETE RecepcionNotasProveedores
GO

DELETE RecepcionNotasEstados
GO

DELETE RecepcionNotas
GO

DELETE RecepcionNotasProveedoresF
GO

DELETE RecepcionNotasEstadosF
GO

DELETE RecepcionNotasF
GO

DELETE VentasPercepciones
GO

DELETE VentasTarjetas
GO

DELETE VentasProductosLotes
GO

DELETE VentasImpuestos
GO

DELETE VentasObservaciones
GO

DELETE VentasProductosLotes
GO

DELETE VentasProductos
GO

DELETE VentasCheques
GO

DELETE VentasChequesRechazados
GO

DELETE VentasCajeros
GO

DELETE VentasInvocados
GO

DELETE VentasAdjuntos
GO

DELETE Ventas
GO

--UPDATE VentasNumeros
--   SET Numero = 0
--GO   

--DELETE VentasNumeros
--  WHERE IdTipoComprobanteRelacionado IS NULL
--GO   

--DELETE PeriodosFiscales
--GO

DELETE LibrosBancos 
GO

DELETE ChequesHistorial
GO

DELETE Cheques
GO


DELETE CajasDetalle
GO

DELETE DepositosCheques
GO

DELETE Depositos
GO


DELETE PercepcionVentas
GO

DELETE Retenciones
GO

DELETE RetencionesCompras
GO

DELETE CajasDetalle
GO

DELETE Cajas WHERE NumeroPlanilla>1
GO

UPDATE Cajas
 SET PesosSaldoFinal=0,
     ChequesSaldoFinal = 0,
     TarjetasSaldoFinal = 0,
     TicketsSaldoFinal = 0,
     DolaresSaldoFinal = 0,
     EurosSaldoFinal = 0
GO

DELETE HistorialPrecios
GO

DELETE HistorialConsultaProductos
GO

--DELETE ProductosNrosSerie
--GO

--DELETE ProductosLotes
--GO

--UPDATE ProductosSucursales SET 
--    Stock = 0
--    ,StockInicial = 0
--GO

--UPDATE ProductosSucursales SET 
--    Stock = 0
--    ,StockInicial = 0
--    ,PrecioFabrica=0
--    ,PrecioCosto=0
--    ,PrecioVenta=0
--    ,PuntoDePedido=0
--    ,StockMinimo=0
--    ,FechaActualizacion=GETDATE()
--    ,Usuario='Admin'
--GO

--UPDATE ProductosSucursalesPrecios SET 
--     PrecioVenta=0
--    ,FechaActualizacion=GETDATE()
--    ,Usuario='Admin'
--GO


--DELETE AuditoriaClientes
--   WHERE CONVERT(varchar(11), FechaAuditoria, 120) >= '2011-01-25'
--GO

DELETE ProduccionProductosComponentes
GO

DELETE ProduccionProductos
GO

DELETE Produccion
GO

DELETE Alquileres
GO

--DELETE UsuariosAccesos
--GO

DELETE ContabilidadAsientosCuentasTmp
GO

DELETE ContabilidadAsientosTmp
GO

DELETE ContabilidadAsientosCuentas
GO

DELETE ContabilidadAsientos
GO

DELETE LiquidacionesObservaciones
GO

DELETE LiquidacionesDetallesClientes
GO

DELETE LiquidacionesCargos
GO

DELETE Liquidaciones
GO

DELETE CargosClientesObservaciones
GO

DELETE CargosClientes
GO

--DELETE UsuariosAccesos
--GO

--DELETE Bitacora
--GO

