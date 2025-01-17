delete Bitacora
where IdFuncion in
 (
SELECT id FROM [Funciones]
 WHERE id='VentasUtilidades' or IdPadre='VentasUtilidades'
    or id='ComisionesVendedores' or IdPadre='ComisionesVendedores'
    or id='Kilos' or IdPadre='Kilos'
    or id='VentasRepartos' or IdPadre='VentasRepartos'
    or id='VentasFiscal' or IdPadre='VentasFiscal'
    or id='VentasAnulModifElim' or IdPadre='VentasAnulModifElim'
    or id='Ventas' or IdPadre IN ('Ventas','FacturacionV2', 'FacturacionRapida', 'ConsultarFacturables', 'InformeDeVentas')
    or id='Turnos' or IdPadre='Turnos'
    or id='Pedidos' or IdPadre IN ('Pedidos', 'PedidosAdmin', 'ConsultarPedidos', 'InfPedidosSumaPorProductos','InfPedidosDetallados')
    or id='PedidosProv' or IdPadre IN ('PedidosProv', 'PedidosAdminProv', 'ConsultarPedidosProv', 'InfPedidosSumaPorProductosProv')
    or id='Compras' or IdPadre='Compras'
    or id='Stock' or IdPadre='Stock'
    or id='Precios' or IdPadre IN ('Precios', 'ConsultarPrecios')
    or id='Estadisticas' or IdPadre='Estadisticas'
    or id='Logistica' or IdPadre='Logistica'
    or id='AFIPTablasAfip' or IdPadre='AFIPTablasAfip'
    or id='AFIP' or IdPadre='AFIP'
)
GO


delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM [Funciones]
 WHERE id='VentasUtilidades' or IdPadre='VentasUtilidades'
    or id='ComisionesVendedores' or IdPadre='ComisionesVendedores'
    or id='Kilos' or IdPadre='Kilos'
    or id='VentasRepartos' or IdPadre='VentasRepartos'
    or id='VentasFiscal' or IdPadre='VentasFiscal'
    or id='VentasAnulModifElim' or IdPadre='VentasAnulModifElim'
    or id='Ventas' or IdPadre IN ('Ventas','FacturacionV2', 'FacturacionRapida', 'ConsultarFacturables', 'InformeDeVentas')
    or id='Turnos' or IdPadre='Turnos'
    or id='Pedidos' or IdPadre IN ('Pedidos', 'PedidosAdmin', 'ConsultarPedidos', 'InfPedidosSumaPorProductos','InfPedidosDetallados')
    or id='PedidosProv' or IdPadre IN ('PedidosProv', 'PedidosAdminProv', 'ConsultarPedidosProv', 'InfPedidosSumaPorProductosProv')
    or id='Compras' or IdPadre='Compras'
    or id='Stock' or IdPadre='Stock'
    or id='Precios' or IdPadre IN ('Precios', 'ConsultarPrecios')
    or id='Estadisticas' or IdPadre='Estadisticas'
    or id='Logistica' or IdPadre='Logistica'
    or id='AFIPTablasAfip' or IdPadre='AFIPTablasAfip'
    or id='AFIP' or IdPadre='AFIP'
)
GO

delete [Funciones]
 WHERE id='VentasUtilidades' or IdPadre='VentasUtilidades'
    or id='ComisionesVendedores' or IdPadre='ComisionesVendedores'
    or id='Kilos' or IdPadre='Kilos'
    or id='VentasRepartos' or IdPadre='VentasRepartos'
    or id='VentasFiscal' or IdPadre='VentasFiscal'
    or id='VentasAnulModifElim' or IdPadre='VentasAnulModifElim'
    or id='Ventas' or IdPadre IN ('Ventas','FacturacionV2', 'FacturacionRapida', 'ConsultarFacturables', 'InformeDeVentas')
    or id='Turnos' or IdPadre='Turnos'
    or id='Pedidos' or IdPadre IN ('Pedidos', 'PedidosAdmin', 'ConsultarPedidos', 'InfPedidosSumaPorProductos','InfPedidosDetallados')
    or id='PedidosProv' or IdPadre IN ('PedidosProv', 'PedidosAdminProv', 'ConsultarPedidosProv', 'InfPedidosSumaPorProductosProv')
    or id='Compras' or IdPadre='Compras'
    or id='Stock' or IdPadre='Stock'
    or id='Precios' or IdPadre IN ('Precios', 'ConsultarPrecios')
    or id='Estadisticas' or IdPadre='Estadisticas'
    or id='Logistica' or IdPadre='Logistica'
    or id='AFIPTablasAfip' or IdPadre='AFIPTablasAfip'
    or id='AFIP' or IdPadre='AFIP'
GO


UPDATE Parametros SET ValorParametro = 'False'
 WHERE IdParametro IN ('MODULOVENTAS', 'MODULOPEDIDOS', 'MODULOPEDIDOSPROV', 'MODULOCOMPRAS')
GO
