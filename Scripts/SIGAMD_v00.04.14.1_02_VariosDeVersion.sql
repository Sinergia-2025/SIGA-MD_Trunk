MERGE INTO Traducciones AS D
        USING   (SELECT 'PresupuestosProveedor' IdFuncion, '' Pantalla, 'Me' Control, 'es_AR' IdIdioma, 'Presupuestos Proveedor' Texto
       UNION ALL SELECT 'ConsultarPresupuestosProv',       '',                          'Me', 'es_AR', 'Consultar Presupuestos Proveedor'
       UNION ALL SELECT 'AnularPresupuestosProv',          '',                          'Me', 'es_AR', 'Anular Presupuesto Proveedores'
       UNION ALL SELECT 'PresupuestosAdminProv',           '',                          'Me', 'es_AR', 'Administración de Presupuestos Proveedor'
       UNION ALL SELECT 'PresupuestosAdminProv',           'PedidosClientesV2',         'Me', 'es_AR', 'Presupuesto Proveedores'
       UNION ALL SELECT 'EstadoPresupuestosProvABM',       'EstadosPedidosProvABM',     'Me', 'es_AR', 'Estados Presupuestos Proveedor'
       UNION ALL SELECT 'EstadoPresupuestosProvABM',       'EstadosPedidosProvDetalle', 'Me', 'es_AR', 'Estados Presupuestos Proveedor'
       UNION ALL SELECT 'InfPresupuestosDetalladosProv',   '',                          'Me', 'es_AR', 'Informe de Presupuestos Proveedor Detallados'
       UNION ALL SELECT 'InfPresupSumaPorProductosProv',   '',                          'Me', 'es_AR', 'Inf. de Presupuesto Proveedor Suma por Productos Prov'
       UNION ALL SELECT 'AnularPresupuestosProv',          '',                          '__AnulacionPedidoExitosa', 'es_AR', '¡¡¡ Presupuesto/s Proveedor Anulado/s Exitosamente !!!'
       UNION ALL SELECT 'AnularPresupuestosProv',          '',                          '__NoSeleccionoPedido',     'es_AR', 'ATENCION: NO Seleccionó Ningún Presupuesto Proveedor para Anular!!'
       UNION ALL SELECT 'InfPresupuestosDetalladosProv',   '', 'FechaPedido',                      'es_AR', 'Fecha Presupuesto'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__CambioEstadoMasivo',             'es_AR', '¿Desea cambiar masivamente el Estado actual de los Presupuestos Seleccionados al Estado: {0}?'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__ConfirmarCambioEstado',          'es_AR', '¿Desea cambiar el Estado actual del Presupuesto - {0} - al Estado: {1}?'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__ErrorCambioMasivoNoPermitido',   'es_AR', 'Presupuesto: {0}-->El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto o cambiar Criticidad/Fecha de Entrega.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__ErrorDebeCambiarEstado',         'es_AR', 'El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__ErrorEstadoNoPermiteCambio',     'es_AR', 'Presupuesto: {0} --> El Estado Actual NO permite cambio.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__NoSeleccionoPedido',             'es_AR', 'Debe seleccionar un Presupuesto para cambiar el Estado.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', '__NoSeleccionoPedidoModificar',    'es_AR', 'Por favor seleccione un Presupuesto.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', 'FechaPedido',                      'es_AR', 'Fecha Presup.'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', 'NumeroPedido',                     'es_AR', 'Presupuesto'
       UNION ALL SELECT 'PresupuestosAdminProv',           '', 'tsbModificarPedido',               'es_AR', 'Modificar Presupuesto'
       UNION ALL SELECT 'PresupuestosAdminProv', 'PedidosClientesV2', '__ConfirmarNuevoComprobante',       'es_AR', 'ATENCION: ¿Desea Realizar un Presupuesto Nuevo?'
       UNION ALL SELECT 'PresupuestosAdminProv', 'PedidosClientesV2', '__ErrorFechaEntregaInvalida',       'es_AR', 'La Fecha de Entrega del producto (Código {0} es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}.'
       UNION ALL SELECT 'PresupuestosAdminProv', 'PedidosClientesV2', '__ErrorFechaEntregaPedidoInvalida', 'es_AR', 'La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.'
       UNION ALL SELECT 'PresupuestosAdminProv', 'PedidosClientesV2', '__PedidoNoSuministrado',            'es_AR', 'Debe pasar un Presupuesto a modificar.'
       UNION ALL SELECT 'PresupuestosProveedor', 'PedidosProveedores', '__ConfirmarNuevoComprobante',       'es_AR', 'ATENCION: ¿Desea Realizar un Presupuesto Nuevo?'
       UNION ALL SELECT 'PresupuestosProveedor', 'PedidosProveedores', '__ErrorFechaEntregaInvalida',       'es_AR', 'La Fecha de Entrega del producto (Código {0} es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}.'
       UNION ALL SELECT 'PresupuestosProveedor', 'PedidosProveedores', '__ErrorFechaEntregaPedidoInvalida', 'es_AR', 'La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.'
       UNION ALL SELECT 'PresupuestosProveedor', 'PedidosProveedores', '__PedidoNoSuministrado',            'es_AR', 'Debe pasar un Presupuesto a modificar.')
     AS O ON O.IdFuncion = D.IdFuncion
         AND O.Pantalla  = D.Pantalla
         AND O.Control   = D.Control
         AND O.IdIdioma = D.IdIdioma
    WHEN NOT MATCHED THEN 
        INSERT (IdFuncion, Pantalla, Control, IdIdioma, Texto) VALUES (O.IdFuncion, O.Pantalla, O.Control, O.IdIdioma, O.Texto)
;
