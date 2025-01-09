
/* ------- REORGANIZO EL MENU Ventas ---------- */ 
   
UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'FacturacionElectro' THEN 10 
            WHEN 'FacturacionV2' THEN 20 
            WHEN 'FacturacionRapida' THEN 30 
            WHEN 'ImpresionMasiva' THEN 40 
            WHEN 'ConsolidarComprobPorProductos' THEN 50 
            WHEN 'DespacharMercaderia' THEN 60 
            WHEN 'ConsultarVentas' THEN 70 
            WHEN 'ConsultarFacturables' THEN 80 
            WHEN 'ConsultarFacturablesDetalle' THEN 90 
            WHEN 'LibrodeIvaVentas' THEN 100 
            WHEN 'InfResumenDeVentas' THEN 110 
            WHEN 'InfTarjetasPorVentas' THEN 120 
            WHEN 'InfTotalesDeVentasPorDia' THEN 130 
            WHEN 'InfTotalesDeVentasPorClientes' THEN 140 
            WHEN 'InfUltimaVentaPorClientes' THEN 150 
            WHEN 'InfVentasSumaPorProductos' THEN 160 
            WHEN 'InfVentasDetallePorProductos' THEN 170 
            WHEN 'InfVentasPorProductoCliente' THEN 180 
            WHEN 'InfVentasPorSubRubroProducto' THEN 190 
            WHEN 'InfUtilidadesPorCliente' THEN 200 
            WHEN 'InfUtilidadesPorMarca' THEN 210 
            WHEN 'InfUtilidadesPorProducto' THEN 220 
            WHEN 'InfUtilidadesPorComprobantes' THEN 230 
            WHEN 'InfUtilidadesPorComprobantDet' THEN 230 
            WHEN 'ConsultaNumeracionVentas' THEN 250
            WHEN 'CierreZ' THEN 260
            WHEN 'CierreZReimprimir' THEN 270
            WHEN 'EliminarComprobantes' THEN 280 
            WHEN 'EliminarVentas' THEN 290
            WHEN 'ModificarComprobantes' THEN 300 
            WHEN 'AnularComprobantes' THEN 310
            WHEN 'AnularComprobantesSinEmitir' THEN 320
            WHEN 'ComisionesVendedores' THEN 400
            WHEN 'Kilos' THEN 500
            ELSE 0 END)
  WHERE IdPadre = 'Ventas'
GO





