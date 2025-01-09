
Delete MovimientosStockProductosLotes
GO

Delete MovimientosStockProductosNrosSerie
GO

DELETE MovimientosStockProductos
GO

DELETE MovimientosStock
GO

DELETE RepartosGastos
GO

DELETE RepartosProductosSinDescargar
GO

DELETE RepartosComprobantesProductos
GO

DELETE RepartosComprobantes
GO

DELETE Repartos
GO

--- Se borra antes los pedidos de clientte spor la Referencia desde Proveedores.
DELETE PedidosEstados
GO

Delete OrdenesProduccionMRPProductos
Go

Delete OrdenesProduccionMRPCategoriasEmpleados
Go

Delete OrdenesProduccionMRPOperaciones
Go

Delete OrdenesProduccionMRP
Go

Delete OrdenesProduccionEstados
Go

Delete OrdenesProduccionProductos
Go

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

Delete RequerimientosComprasProductosAsignaciones
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

DELETE TarjetasCuponesHistorial
GO

DELETE TarjetasCupones
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

DELETE VentasAdjuntos
GO

DELETE Ventas
GO

UPDATE VentasNumeros
   SET Numero = 0
GO   

--DELETE VentasNumeros
--  WHERE IdTipoComprobanteRelacionado IS NULL
--GO   

DELETE PeriodosFiscales
GO

DELETE LibrosBancos 
GO

DELETE ChequesHistorial
GO

DELETE Cheques
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

--DELETE HistorialPrecios
--GO

--DELETE HistorialConsultaProductos
--GO

DELETE ProductosNrosSerie
GO

DELETE ProductosLotes
GO

--UPDATE ProductosSucursales SET 
--    Stock = 0
--    ,StockInicial = 0
--GO

--Update ProductosDepositos Set
--    Stock = 0
--    ,Stock2 = 0
--GO

--Update ProductosUbicaciones Set
--    Stock = 0
--    ,Stock2 = 0
--GO

--UPDATE ProductosSucursales SET 
--    Stock = 0
--    ,StockInicial = 0
--    ,PrecioFabrica=0
--    ,PrecioCosto=0
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

DELETE CRMNovedadesSeguimientoAdjuntos
GO

DELETE CRMNovedadesSeguimiento
GO

DELETE AuditoriaCRMNovedades
GO

DELETE CRMNovedades
GO

--DELETE Dispositivos WHERE NombreDispositivo like '%SINERGIA%' or NombreDispositivo like '%DEMO-PC%' or NombreDispositivo = 'TERRA-PC'
--Borro todo porque la base trae las PC de la Empresa que se tomo.
DELETE Dispositivos 
GO

DELETE Dispositivos
 WHERE FechaUltimoLogin < (SELECT MIN(FECHA) FROM Ventas)
GO

--Habria que tomarlo de los parametros!
DELETE CuentasDeCajas
 WHERE IdCuentaCaja NOT IN (1, 2, 3, 4, 5, 6, 7, 8, 11, 12, 13, 14, 15, 16, 17, 18 , 26)
GO

--Habria que tomarlo de los parametros!
DELETE CuentasBancos
 WHERE IdCuentaBanco NOT IN (4, 5, 6, 7, 11, 13)
GO

--DELETE UsuariosAccesos
--GO

--DELETE UsuariosClaves
--GO

--DELETE Bitacora
--GO

Delete RequerimientosComprasProductos
GO

Delete RequerimientosCompras
GO

Delete OrdenesProduccionObservaciones
GO

Delete OrdenesProduccion
GO

Delete NovedadesProduccionMRPTiempos
GO

delete NovedadesProduccionMRPProductos
GO

Delete NovedadesProduccionMRP
GO

Delete NovedadesProduccionMRPProductos
GO

Delete NovedadesProduccionMRPProductosLotes
GO