---*********************************** MODULOS COMPLETOS ******************************************


PRINT ''
PRINT '1. Eliminio Modulo PRESUPUESTOS'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Presupuestos' OR IdPadre = 'Presupuestos'
  )
GO

DELETE Bitacora WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Presupuestos' OR IdPadre = 'Presupuestos'
  )
GO

DELETE Traducciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Presupuestos' OR IdPadre = 'Presupuestos'
  )
GO

DELETE Funciones
 WHERE Id = 'Presupuestos' OR IdPadre = 'Presupuestos'
GO


PRINT ''
PRINT '2. ELIMINO MODULO CONTABILIDAD'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='Contabilidad'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='ContabilidadAsientosABM'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE id = 'Contabilidad'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='Contabilidad'
)
GO

DELETE Funciones
 WHERE IdPadre='ContabilidadAsientosABM'
GO

DELETE Funciones
 WHERE IdPadre='Contabilidad'
GO

DELETE Funciones
 WHERE id='Contabilidad'
GO


PRINT ''
PRINT '3. ELIMINO MODULO CRM'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre LIKE 'CRM%' AND IdPadre <> 'CRM'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='CRM'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE id = 'CRM'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='CRM'
)
GO

DELETE Funciones
 WHERE IdPadre LIKE 'CRM%' AND IdPadre <> 'CRM'
GO

DELETE Funciones
 WHERE IdPadre='CRM'
GO

DELETE Funciones
 WHERE id='CRM'
GO

PRINT ''
PRINT '4.1. ELIMINO MODULO PEDIDOS - Parte 1: Los hijos de las Funciones'
GO

DELETE RolesFunciones 
 WHERE IdFuncion IN
 (SELECT id FROM Funciones
 WHERE IdPadre in (SELECT id FROM Funciones
 WHERE IdPadre='Pedidos'))
GO

DELETE Bitacora
 WHERE IdFuncion IN
 (SELECT id FROM Funciones
 WHERE IdPadre in (SELECT id FROM Funciones
 WHERE IdPadre='Pedidos'))
GO

DELETE Funciones
 WHERE Id IN
 (SELECT id FROM Funciones
 WHERE IdPadre in (SELECT id FROM Funciones
 WHERE IdPadre='Pedidos'))
GO

PRINT ''
PRINT '4.2. ELIMINO MODULO PEDIDOS - Parte 2: Las Funciones y el Padre'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='Pedidos'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE id = 'Pedidos'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='Pedidos'
)
GO

DELETE Funciones
 WHERE IdPadre='Pedidos'
GO

DELETE Funciones
 WHERE id='Pedidos'
GO


PRINT ''
PRINT '5. ELIMINO MODULO PEDIDOS PROVEEDORES'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre IN 
   (SELECT id FROM Funciones
    WHERE IdPadre='PedidosProv')
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='PedidosProv'
)
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE id = 'PedidosProv'
)
GO


DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 WHERE IdPadre='PedidosProv'
)
GO

DELETE Funciones
 WHERE IdPadre IN 
   (SELECT id FROM Funciones
    WHERE IdPadre='PedidosProv')
GO

DELETE Funciones
 WHERE IdPadre='PedidosProv'
GO

DELETE Funciones
 WHERE id='PedidosProv'
GO


PRINT ''
PRINT '6. Eliminio Modulo TURNOS'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Turnos' OR IdPadre = 'Turnos'
  )
GO

DELETE Bitacora WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Turnos' OR IdPadre = 'Turnos'
  )
GO

DELETE Traducciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'Turnos' OR IdPadre = 'Turnos'
  )
GO

DELETE Funciones
 WHERE Id = 'Turnos' OR IdPadre = 'Turnos'
GO


PRINT ''
PRINT '7. Eliminio Modulo REPARTOS'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'VentasRepartos' OR IdPadre = 'VentasRepartos'
  )
GO

DELETE Bitacora WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'VentasRepartos' OR IdPadre = 'VentasRepartos'
  )
GO

DELETE Traducciones WHERE IdFuncion IN
 (
	SELECT Id FROM Funciones
	 WHERE Id = 'VentasRepartos' OR IdPadre = 'VentasRepartos'
  )
GO

DELETE Funciones
 WHERE Id = 'VentasRepartos' OR IdPadre = 'VentasRepartos'
GO


--****************************************** PANTALLAS ********************************************

PRINT ''
PRINT '8. Elimino Pantallas de VENTAS.'
GO

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where IdPadre in ('FacturacionRapida'
     ,'Cajero'
     ,'ImpresionMasiva'
     ,'EnvioMasivoDeComprobantes'
     ,'ConsultarFacturablesDetalle'
     ,'InfTotalesDeVentasPorDia'
     ,'InfTotalesDeVentasPorClientes'
     ,'InfUltimaVentaPorClientes'
     ,'InfVentasPorProductoCliente'
     ,'InfNoCompradores'
     ,'InfComparativoDiario'
     ,'ModificarComprobantesDeVentas'
     ,'CopiarComprobantesNCred')
)
GO


delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'FacturacionRapida'
    or id='Cajero'
    or id='ImpresionMasiva'
    or id='EnvioMasivoDeComprobantes'
    or id='ConsultarFacturablesDetalle'
    or id='InfTotalesDeVentasPorDia'
    or id='InfTotalesDeVentasPorClientes'
    or id='InfUltimaVentaPorClientes'
    or id='InfVentasPorProductoCliente'
    or id='InfNoCompradores'
    or id='InfComparativoDiario'
    or id='ModificarComprobantesDeVentas'
    or id='CopiarComprobantesNCred'
)
GO


DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'FacturacionRapida'
    or id='Cajero'
    or id='ImpresionMasiva'
    or id='EnvioMasivoDeComprobantes'
    or id='ConsultarFacturablesDetalle'
    or id='InfTotalesDeVentasPorDia'
    or id='InfTotalesDeVentasPorClientes'
    or id='InfUltimaVentaPorClientes'
    or id='InfVentasPorProductoCliente'
    or id='InfNoCompradores'
    or id='InfComparativoDiario'
    or id='ModificarComprobantesDeVentas'
    or id='CopiarComprobantesNCred'
)
GO

Delete Funciones
Where IdPadre in ('FacturacionRapida'
    ,'Cajero'
    ,'ImpresionMasiva'
    ,'EnvioMasivoDeComprobantes'
    ,'ConsultarFacturablesDetalle'
    ,'InfTotalesDeVentasPorDia'
    ,'InfTotalesDeVentasPorClientes'
    ,'InfUltimaVentaPorClientes'
    ,'InfVentasPorProductoCliente'
    ,'InfNoCompradores'
    ,'ModificarComprobantesDeVentas'
    ,'CopiarComprobantesNCred'
)
GO

Delete Funciones
Where Id in ('FacturacionRapida'
    ,'Cajero'
    ,'ImpresionMasiva'
    ,'EnvioMasivoDeComprobantes'
    ,'ConsultarFacturablesDetalle'
    ,'InfTotalesDeVentasPorDia'
    ,'InfTotalesDeVentasPorClientes'
    ,'InfUltimaVentaPorClientes'
    ,'InfVentasPorProductoCliente'
    ,'InfNoCompradores'
    ,'ModificarComprobantesDeVentas'
    ,'CopiarComprobantesNCred'
)
GO

PRINT ''
PRINT '9. Elimino Pantallas de FACTURA ELECTRONICA.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'ConsultarCAI'
    or id= 'ConsultarTablasAFIP'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'ConsultarCAI'
    or id= 'ConsultarTablasAFIP'
)
GO

Delete Funciones
Where Id in (
    'ConsultarCAI'
   ,'ConsultarTablasAFIP'
)
GO

PRINT ''
PRINT '10. Elimino Pantallas de UTILIDADES.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfUtilidadesPorComprobantes'
    or id= 'InfUtilidadesPorComprobantDet'
    or id= 'InfUtilidadesPorListaDePrecios'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfUtilidadesPorComprobantes'
    or id= 'InfUtilidadesPorComprobantDet'
    or id= 'InfUtilidadesPorListaDePrecios'
)
GO

Delete Funciones
Where Id in (
    'InfUtilidadesPorComprobantes'
   ,'InfUtilidadesPorComprobantDet'
   ,'InfUtilidadesPorListaDePrecios'
)
GO


PRINT ''
PRINT '11. Elimino Pantallas de COMISIONES DE VENDEDORES.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfComisionesSobreVentas'
    or id= 'ComisionesVendedorLista'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfComisionesSobreVentas'
    or id= 'ComisionesVendedorLista'
)
GO

Delete Funciones
Where Id in (
    'InfComisionesSobreVentas'
   ,'ComisionesVendedorLista'
)
GO


PRINT ''
PRINT '12. Elimino Pantallas de KILOS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfKilosCompMensualPorCliente'
    or id= 'InfKilosCompMarcasPorCliente'
    or id= 'InfKilosCompMensualXCliente2R'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfKilosCompMensualPorCliente'
    or id= 'InfKilosCompMarcasPorCliente'
    or id= 'InfKilosCompMensualXCliente2R'
)
GO

Delete Funciones
Where Id in (
    'InfKilosCompMensualPorCliente'
   ,'InfKilosCompMarcasPorCliente'
   ,'InfKilosCompMensualXCliente2R'
)
GO


PRINT ''
PRINT '13. Elimino Pantallas de COMPRAS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'ModificarCompras'
    or id= 'ProductosProveedores'
    or id= 'InfProductosProveedores'
    or id= 'AduanasABM'
    or id= 'AduanasAgentesTransporteABM'
    or id= 'AduanasDespachantesABM'
    or id= 'AduanasDestinacionesABM'
    or id= 'ConceptosABM'
    or id= 'RubrosConceptosABM'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'ModificarCompras'
    or id= 'ProductosProveedores'
    or id= 'InfProductosProveedores'
    or id= 'AduanasABM'
    or id= 'AduanasAgentesTransporteABM'
    or id= 'AduanasDespachantesABM'
    or id= 'AduanasDestinacionesABM'
    or id= 'ConceptosABM'
    or id= 'RubrosConceptosABM'
)
GO

Delete Funciones
Where Id in (
    'ModificarCompras'
   ,'ProductosProveedores'
   ,'InfProductosProveedores'
   ,'AduanasABM'
   ,'AduanasAgentesTransporteABM'
   ,'AduanasDespachantesABM'
   ,'AduanasDestinacionesABM'
   ,'ConceptosABM'
   ,'RubrosConceptosABM'
)
GO


PRINT ''
PRINT '14. Elimino Pantallas de STOCK.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfResumenMovimDeProductos'
    or id= 'InfDiasDeStockPorProductos'
    or id= 'InfProductosMasMovimientos'
    or id= 'ConsultarLotesDeProductos'
    or id= 'InfPuntoDePedidoDeProductos'
    or id= 'InfStockMinimoDeProductos'
    or id= 'InfStockPorModelo'
    or id= 'BlanquearStock'
    or id= 'ConsultarNroSerieProductos'
    or id= 'GenerarPedidoProveedorDesdeStocks'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfResumenMovimDeProductos'
    or id= 'InfDiasDeStockPorProductos'
    or id= 'InfProductosMasMovimientos'
    or id= 'ConsultarLotesDeProductos'
    or id= 'InfPuntoDePedidoDeProductos'
    or id= 'InfStockMinimoDeProductos'
    or id= 'InfStockPorModelo'
    or id= 'BlanquearStock'
    or id= 'ConsultarNroSerieProductos'
    or id= 'GenerarPedidoProveedorDesdeStocks'
)
GO

Delete Funciones
Where Id in (
    'InfResumenMovimDeProductos'
   ,'InfDiasDeStockPorProductos'
   ,'InfProductosMasMovimientos'
   ,'ConsultarLotesDeProductos'
   ,'InfPuntoDePedidoDeProductos'
   ,'InfStockMinimoDeProductos'
   ,'InfStockPorModelo'
   ,'BlanquearStock'
   ,'ConsultarNroSerieProductos'
   ,'GenerarPedidoProveedorDesdeStocks'
)
GO


PRINT ''
PRINT '14. Elimino Pantallas de PRECIOS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfHistoricoDePrecios'
    or id= 'ConsultarPreciosClientes'
    or id= 'ConsultarPreciosPorProducto'
    or id= 'InfHistoricoConsProd'
    or id= 'EmisionDeEtiquetasDePrecios'
    or id= 'EmisionDeEtiquetasCodBarra'
    or id= 'ConsultarPreciosPorCuotas'
    or id= 'ClientesDescuentosSubRubros'
    or id= 'ClientesDescuentosProductos'
    or id= 'FormatosEtiquetasABM'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfHistoricoDePrecios'
    or id= 'ConsultarPreciosClientes'
    or id= 'ConsultarPreciosPorProducto'
    or id= 'InfHistoricoConsProd'
    or id= 'EmisionDeEtiquetasDePrecios'
    or id= 'EmisionDeEtiquetasCodBarra'
    or id= 'ConsultarPreciosPorCuotas'
    or id= 'ClientesDescuentosSubRubros'
    or id= 'ClientesDescuentosProductos'
    or id= 'FormatosEtiquetasABM'
)
GO

Delete Funciones
Where Id in (
    'InfHistoricoDePrecios'
   ,'ConsultarPreciosClientes'
   ,'ConsultarPreciosPorProducto'
   ,'InfHistoricoConsProd'
   ,'EmisionDeEtiquetasDePrecios'
   ,'EmisionDeEtiquetasCodBarra'
   ,'ConsultarPreciosPorCuotas'
   ,'ClientesDescuentosSubRubros'
   ,'ClientesDescuentosProductos'
   ,'FormatosEtiquetasABM'
)
GO


PRINT ''
PRINT '15. Elimino Pantallas de AFIP.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfPercepciones'
    or id= 'InfRetenciones'
    or id= 'InfRetencionesEmitidas'
    or id= 'RegimenesABM'
    or id= 'EscalasRetGananciasABM'
    or id= 'ActividadesABM'
    or id= 'EmpresaActividades'
    or id= 'ProvinciasABM'
    or id= 'ImportarContribuyentesARBA'
    or id= 'ConsultarContribuyentesARBA'
    or id= 'PosicionDeIVA'
)
GO


DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfPercepciones'
    or id= 'InfRetenciones'
    or id= 'InfRetencionesEmitidas'
    or id= 'RegimenesABM'
    or id= 'EscalasRetGananciasABM'
    or id= 'ActividadesABM'
    or id= 'EmpresaActividades'
    or id= 'ProvinciasABM'
    or id= 'ImportarContribuyentesARBA'
    or id= 'ConsultarContribuyentesARBA'
    or id= 'PosicionDeIVA'
)
GO

Delete Funciones
Where Id in (
    'InfPercepciones'
   ,'InfRetenciones'
   ,'InfRetencionesEmitidas'
   ,'RegimenesABM'
   ,'EscalasRetGananciasABM'
   ,'ActividadesABM'
   ,'EmpresaActividades'
   ,'ProvinciasABM'
   ,'ImportarContribuyentesARBA'
   ,'ConsultarContribuyentesARBA'
   ,'PosicionDeIVA'
)
GO

PRINT ''
PRINT '16. Elimino Pantallas de CUENTAS CORRIENTES DE CLIENTES.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'GenerarMinutas'
    or id= 'ImpresionMasivaRecibos'
    or id= 'AnulacionRecibosAClientes'
    or id= 'InfComprobantesCtaCteClientesFecha'
    or id= 'InfSaldosPorAntiguedadDeDeuda'
    or id= 'Kardex'
    or id= 'InfComisionesProductos'
    or id= 'ConsultarCtaCteDetalleClientes'
    or id= 'InfCtaCteDetalleClientes'
    or id= 'ConsultarCtaCteDetClientesDH'
    or id= 'RecibosVinculados'
    or id= 'EnvioMasivoDeCompVenc'
    or id= 'InfCtaCteDetalleProximoPago'
    or id= 'InfCCDetClientesCobranzaYDeuda'
    or id= 'InfCoeficienteCobranzas'
    or id= 'InfTotaldeCobranzaPorDia'
    or id= 'InfVentasCobranzas'
    or id= 'ModificarComprobantesDeVentas'
    or id= 'InfComisionesProductos'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'GenerarMinutas'
    or id= 'ImpresionMasivaRecibos'
    or id= 'AnulacionRecibosAClientes'
    or id= 'InfComprobantesCtaCteClientesFecha'
    or id= 'InfSaldosPorAntiguedadDeDeuda'
    or id= 'Kardex'
    or id= 'InfComisionesProductos'
    or id= 'ConsultarCtaCteDetalleClientes'
    or id= 'InfCtaCteDetalleClientes'
    or id= 'ConsultarCtaCteDetClientesDH'
    or id= 'RecibosVinculados'
    or id= 'EnvioMasivoDeCompVenc'
    or id= 'InfCtaCteDetalleProximoPago'
    or id= 'InfCCDetClientesCobranzaYDeuda'
    or id= 'InfCoeficienteCobranzas'
    or id= 'InfTotaldeCobranzaPorDia'
    or id= 'InfVentasCobranzas'
    or id= 'ModificarComprobantesDeVentas'
    or id= 'InfComisionesProductos'
)
GO

Delete Funciones
Where Id in (
    'GenerarMinutas'
   ,'ImpresionMasivaRecibos'
   ,'AnulacionRecibosAClientes'
   ,'InfComprobantesCtaCteClientesFecha'
   ,'InfSaldosPorAntiguedadDeDeuda'
   ,'Kardex'
   ,'InfComisionesProductos'
   ,'ConsultarCtaCteDetalleClientes'
   ,'InfCtaCteDetalleClientes'
   ,'ConsultarCtaCteDetClientesDH'
   ,'RecibosVinculados'
   ,'EnvioMasivoDeCompVenc'
   ,'InfCtaCteDetalleProximoPago'
   ,'InfCCDetClientesCobranzaYDeuda'
   ,'InfCoeficienteCobranzas'
   ,'InfTotaldeCobranzaPorDia'
   ,'InfVentasCobranzas'
   ,'ModificarComprobantesDeVentas'
   ,'InfComisionesProductos'
)
GO

PRINT ''
PRINT '17. Elimino Pantallas de CUENTAS CORRIENTES DE PROVEEDORES.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfComprobCtaCteProvFecha'
    or id= 'KardexProveedores'
    or id= 'ConsultarCtaCteDetalleProveedores'
    or id= 'InfCtaCteDetalleProveedores'
    or id= 'ConsultarCtaCteDetProveedorDH'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfComprobCtaCteProvFecha'
    or id= 'KardexProveedores'
    or id= 'ConsultarCtaCteDetalleProveedores'
    or id= 'InfCtaCteDetalleProveedores'
    or id= 'ConsultarCtaCteDetProveedorDH'
    
)
GO

Delete Funciones
Where Id in (
    'InfComprobCtaCteProvFecha'
   ,'KardexProveedores'
   ,'ConsultarCtaCteDetalleProveedores'
   ,'InfCtaCteDetalleProveedores'
   ,'ConsultarCtaCteDetProveedorDH'
)
GO

PRINT ''
PRINT '18. Elimino Pantallas de CAJA.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'CerrarPlanillaDeCaja'
    or id= 'InfCheques'
    or id= 'ChequesPropios'
    or id= 'ConsultarVentasPorPlanilla'
    or id= 'InfCobranzasRealizadas'
    or id= 'InfPagosRealizados'
    or id= 'InformeHistoricoCheques'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'CerrarPlanillaDeCaja'
    or id= 'InfCheques'
    or id= 'ChequesPropios'
    or id= 'ConsultarVentasPorPlanilla'
    or id= 'InfCobranzasRealizadas'
    or id= 'InfPagosRealizados'
    or id= 'InformeHistoricoCheques'
)
GO

Delete Funciones
Where Id in (
    'CerrarPlanillaDeCaja'
   ,'InfCheques'
   ,'ChequesPropios'
   ,'ConsultarVentasPorPlanilla'
   ,'InfCobranzasRealizadas'
   ,'InfPagosRealizados'
   ,'InformeHistoricoCheques'
)
GO


PRINT ''
PRINT '19. Elimino Pantallas de BANCO.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'ResumenAnual'
    or id= 'IntercambioDeMovimientos'
    or id= 'ExtraccionesBancarias'
    or id= 'AnularExtracciones'
    or id= 'TransferenciasEntreCuentas'
    or id= 'ConsultarDepositos'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'ResumenAnual'
    or id= 'IntercambioDeMovimientos'
    or id= 'ExtraccionesBancarias'
    or id= 'AnularExtracciones'
    or id= 'TransferenciasEntreCuentas'
    or id= 'ConsultarDepositos'
)
GO

Delete Funciones
Where Id in (
    'ResumenAnual'
   ,'IntercambioDeMovimientos'
   ,'ExtraccionesBancarias'
   ,'AnularExtracciones'
   ,'TransferenciasEntreCuentas'
   ,'ConsultarDepositos'
)
GO

PRINT ''
PRINT '20. Elimino Pantallas de ESTADISTICAS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'EstadisticaDeVentasClientes'
    or id= 'EstadisticaDeVentasProductos'
    or id= 'EstadisticaComprasProveedores'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'EstadisticaDeVentasClientes'
    or id= 'EstadisticaDeVentasProductos'
    or id= 'EstadisticaComprasProveedores'
)
GO

Delete Funciones
Where Id in (
    'EstadisticaDeVentasClientes'
   ,'EstadisticaDeVentasProductos'
   ,'EstadisticaComprasProveedores'
)
GO

PRINT ''
PRINT '21. Elimino Pantallas de ARCHIVOS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'ContactosABM'
    or id= 'MediosdePagoABM'
    or id= 'ProspectosABM'
    or id= 'TiposContactosABM'
    or id= 'FeriadosABM'
    or id= 'EmpresasABM'
    or id= 'ProductosPorCliente'
)
GO


DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'ContactosABM'
    or id= 'MediosdePagoABM'
    or id= 'ProspectosABM'
    or id= 'TiposContactosABM'
    or id= 'FeriadosABM'
    or id= 'EmpresasABM'
    or id= 'ProductosPorCliente'
)
GO

Delete Funciones
Where Id in (
    'ContactosABM'
   ,'MediosdePagoABM'
   ,'ProspectosABM'
   ,'TiposContactosABM'
   ,'FeriadosABM'
   ,'EmpresasABM'
   ,'ProductosPorCliente'
)
GO

PRINT ''
PRINT '22. Elimino Pantallas de PROCESOS.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'ImportarProductosExcelListMult'
    or id= 'ExportarClientesWeb'
    or id= 'ExportarSaldosCtaCteClientesWeb'
    or id= 'ExportarCtaCteClientes'
    or id= 'EnvioMasivoDeCorreos'
    or id= 'ImportarProductosExcelListasMultiples'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'ImportarProductosExcelListMult'
    or id= 'ExportarClientesWeb'
    or id= 'ExportarSaldosCtaCteClientesWeb'
    or id= 'ExportarCtaCteClientes'
    or id= 'EnvioMasivoDeCorreos'
    or id= 'ImportarProductosExcelListasMultiples'
)
GO

Delete Funciones
Where Id in (
    'ImportarProductosExcelListMult'
   ,'ExportarClientesWeb'
   ,'ExportarSaldosCtaCteClientesWeb'
   ,'ExportarCtaCteClientes'
   ,'EnvioMasivoDeCorreos'
   ,'ImportarProductosExcelListasMultiples'
)
GO


PRINT ''
PRINT '23. Elimino Pantallas de CONFIGURACION.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'UsuariosConfiguraciones'
    or id= 'TareasProgramadasABM'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'UsuariosConfiguraciones'
    or id= 'TareasProgramadasABM'
)
GO

Delete Funciones
Where Id in ('UsuariosConfiguraciones'
    ,'TareasProgramadasABM'
)
GO

PRINT ''
PRINT '24. Elimino Pantallas de SEGURIDAD.'
GO

delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 where id= 'InfAccesosDeUsuarios'
    or id= 'InfBitacora'
)
GO

DELETE Bitacora WHERE IdFuncion IN
 (
SELECT id FROM Funciones
 where id= 'InfAccesosDeUsuarios'
    or id= 'InfBitacora'
)
GO

Delete Funciones
Where Id in (
    'InfAccesosDeUsuarios'
   ,'InfBitacora'
)
GO
