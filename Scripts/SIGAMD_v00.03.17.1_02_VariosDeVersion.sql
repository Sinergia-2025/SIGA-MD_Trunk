PRINT ''
PRINT '1. Nuevo Tipo de Comprobante: Presupuesto a Proveedor'
DECLARE @tipo VARCHAR(MAX) = 'PRESUPPROV'
IF NOT EXISTS (SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'PRESUPPROVEEDOR')
BEGIN
    PRINT '1.1. Agrendo tipo de comprobante'
    INSERT TiposComprobantes 
    /*01*/ (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, 
    /*02*/  GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime, 
    /*03*/  CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual, 
    /*04*/  ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, 
    /*05*/  ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, 

    /*06*/  IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, 
    /*07*/  UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, 
    /*08*/  EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad, 
    /*09*/  UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb, 
    /*10*/  IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, 

    /*11*/  EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito, 
    /*12*/  InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte, 
    /*13*/  ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, 
    /*14*/  AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden, 
    /*15*/  MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva, 

    /*16*/  SolicitaFechaDevolucion, AFIPWSRequiereReferenciaTransferencia, ActivaTildeMercDespacha, Color, CodigoRoela,
    /*17*/  ClaseComprobante)
           VALUES 
    /*01*/ ('PRESUPPROVEEDOR', 'False', 'Presupuesto a Proveedor', @tipo, 0, 
    /*02*/  'False', 'True', 'X', 100, 'True', 
    /*03*/  1, NULL, 'True', 'False', 'True', 
    /*04*/  'False', 'Pres.Prov.', 'True', 1, 'False', 
    /*05*/  '', 'False', 99, NULL, 9999999.99, 

    /*06*/  '.', 'False', 0.01, 'False', 'True', 
    /*07*/  'True', 'False', 'False', 'False', 2, 
    /*08*/  'False', 'False', 'COMPRAS', 'False', 'False', 
    /*09*/  'False', 'False', 'False', NULL, NULL, 
    /*10*/  NULL, NULL, 'False', 'False', '', 

    /*11*/  'False', 'True', NULL, 'True', 'True', 
    /*12*/  'True', 'False', 8, 1, 'False', 
    /*13*/  'True', 'True', 'False', NULL, 'False', 
    /*14*/  'False', 'False', 'False', 'False', 10, 
    /*15*/  'True', 'False', 'False', 'Presupuesto a Proveedor', 'False', 

    /*16*/  'False', 'False', 'False', NULL, '',
    /*17*/  '')
END
ELSE
BEGIN
    PRINT '1.2. Actualzando tipo de comprobante'
    UPDATE TiposComprobantes 
       SET Tipo = @tipo
     WHERE IdTipoComprobante = 'PRESUPPROVEEDOR'
END
GO

PRINT ''
PRINT '2. Menu: Presupuesto a Proveedor'
IF dbo.ExisteFuncion('PresupuestosProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosProv', 'Presupuestos Prov.', 'Presupuestos Proveedor', 'True', 'False', 'True', 'True'
        ,NULL, 24, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('PresupuestosProv') = 1 AND dbo.ExisteFuncion('PresupuestosProveedor') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosProveedor', 'Presupuesto a Proveedor', 'Presupuesto a Proveedor', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 10, 'Eniac.Win', 'PedidosProveedores', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('ConsultarPresupuestosProv', 'Consultar Presupuesto Proveedores', 'Consultar Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 20, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('AnularPresupuestosProv', 'Anular Presupuesto Proveedores', 'Anular Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 30, 'Eniac.Win', 'AnularPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('PresupuestosAdminProv', 'Administracion de Presupuesto Prov', 'Administracion de Presupuesto Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 40, 'Eniac.Win', 'PedidosAdminProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('EstadoPresupuestosProvABM', 'ABM Estados de Presupuesto Proveedores', 'ABM Estados de Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 50, 'Eniac.Win', 'EstadosPedidosProvABM', NULL, 'PRESUPPROV\,PEDIDOSPROV'
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfPresupuestosDetalladosProv', 'Inf. de Presupuesto Detallado Prov', 'Inf. de Presupuesto Detallado Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 60, 'Eniac.Win', 'InfPedidosDetalladosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfPresupSumaPorProductosProv', 'Inf. de Presupuesto Suma por Productos Prov', 'Inf. de Presupuesto Suma por Productos Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 70, 'Eniac.Win', 'InfPedidosSumaPorProductosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('ConsultarPresupuestosProv') = 1 AND dbo.ExisteFuncion('ConsultarPresupProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConsultarPresupProv-VerPre', 'Ver Precios en Consultar Pedidos', 'Ver Precios en Consultar Pedidos', 'False', 'False', 'True', 'True'
        ,'ConsultarPresupuestosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('InfPresupuestosDetalladosProv') = 1 AND dbo.ExisteFuncion('InfPresupDetalladosProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfPresupDetalladosProv-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True'
        ,'InfPresupuestosDetalladosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('PresupuestosAdminProv') = 1 AND dbo.ExisteFuncion('PresupuestosAdminProv-Modif') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosAdminProv-Modif', 'Modif. Pedidos', 'Modif. Pedidos', 'False', 'False', 'True', 'True'
        ,'PresupuestosAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('PresupuestosAdminProv-VerPre', 'Ver Precios en Admin Pedidos', 'Ver Precios en Admin Pedidos', 'False', 'False', 'True', 'True'
        ,'PresupuestosAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END

UPDATE Funciones
   SET Parametros = 'PRESUPPROV'
 WHERE IdPadre = 'PresupuestosProv'
   AND ISNULL(Parametros, '') = ''

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT R.Id IdRol, F.Id IdFuncion
  FROM Funciones F
 CROSS JOIN (SELECT * FROM Roles WHERE Id IN ('Adm', 'Supervisor', 'Oficina')) R
 WHERE F.Plus = 'X'
   AND NOT EXISTS (SELECT * FROM RolesFunciones RF WHERE RF.IdRol = R.Id AND RF.IdFuncion = F.Id)

UPDATE Funciones
   SET Plus = 'S'
 WHERE Plus = 'X'

PRINT ''
PRINT '3. Tabla EstadosPedidosProveedores: Estados Presupuestos Proveedores'
INSERT INTO EstadosPedidosProveedores
           (IdEstado, IdTipoComprobante, IdTipoEstado, Orden, TipoEstadoPedido
           ,Color, TipoEstadoPedidoCliente, IdEstadoPedidoCliente, IdTipoMovimiento, StockAfectado
           ,IdEstadoDestino)

    SELECT IdEstado, IdTipoComprobante, IdTipoEstado, Orden, 'PRESUPPROV' TipoEstadoPedido
          ,Color, TipoEstadoPedidoCliente, IdEstadoPedidoCliente, IdTipoMovimiento, StockAfectado
          ,IdEstadoDestino
      FROM EstadosPedidosProveedores

GO

PRINT ''
PRINT '4. Traducciones: Presupuestos Proveedores'
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

