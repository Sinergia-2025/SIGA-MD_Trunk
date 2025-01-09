PRINT ''
PRINT '0.- Datos para Turismo'
IF dbo.BaseConCuit('30714374938') = 'True'
BEGIN
    PRINT ''
    PRINT '1.- Tabla TurismoTurnos: Inicialización de Datos'
    INSERT INTO [dbo].[TurismoTurnos]([IdTurno],[NombreTurno])
         VALUES (1, 'Mañana'),
                (2, 'Tarde'),
                (3, 'Noche')

    PRINT ''
    PRINT '2.- Tabla TurismoCursos: Inicialización de Datos'
    INSERT INTO [dbo].[TurismoCursos] ([IdCurso],[NombreCurso]) 
         VALUES (  1,'1° Grado'),
                (  2,'2° Grado'),
                (  3,'3° Grado'),
                (  4,'4° Grado'),
                (  5,'5° Grado'),
                (  6,'6° Grado'),
                (  7,'7° Grado'),
                (  8,'1° Año'),
                (  9,'2° Año'),
                ( 10,'3° Año'),
                ( 11,'4° Año'),
                ( 12,'5° Año'),
                ( 13,'6° Año'),
                ( 14,'Sala 2 años'),
                ( 15,'Sala 3 años'),
                ( 16,'Sala 4 años'),
                ( 17,'Sala 5 años'),
                ( 99,'No aplica')

    PRINT ''
    PRINT '3.- Tabla EstadosTurismo: Inicialización de Datos'
    INSERT INTO [dbo].[EstadosTurismo]
            ([IdEstadoTurismo],[NombreEstadoTurismo],[Posicion],[Finalizado],[PorDefecto],[Color])
        VALUES
            (1, 'PENDIENTE', 1, 'False' ,'True', -32640)

    PRINT ''
    PRINT '4.- Tabla Categorias: Inicialización para Turismo'
    MERGE INTO Categorias AS DEST
            USING (SELECT 1 IdCategoria, 'Establecimiento' NombreCategoria, 0 DescuentoRecargo, NULL IdCaja, NULL IdTipoComprobante, NULL IdCuenta, NULL IdInteres, NULL IdCuentaSecundaria, NULL IdProducto, NULL IdInteresCuotas, 'False' RequiereRevisionAdministrativa, 'TURISMO' IdGrupoCategoria, 'False' ControlaBackup, 0 NivelAutorizacion, 'True' ActualizarAplicacion, 0 Comisiones UNION ALL
                   SELECT 2 IdCategoria, 'Pasajero'        NombreCategoria, 0 DescuentoRecargo, NULL IdCaja, NULL IdTipoComprobante, NULL IdCuenta, NULL IdInteres, NULL IdCuentaSecundaria, NULL IdProducto, NULL IdInteresCuotas, 'False' RequiereRevisionAdministrativa, 'TURISMO' IdGrupoCategoria, 'False' ControlaBackup, 0 NivelAutorizacion, 'True' ActualizarAplicacion, 0 Comisiones UNION ALL
                   SELECT 3 IdCategoria, 'Responsable'     NombreCategoria, 0 DescuentoRecargo, NULL IdCaja, NULL IdTipoComprobante, NULL IdCuenta, NULL IdInteres, NULL IdCuentaSecundaria, NULL IdProducto, NULL IdInteresCuotas, 'False' RequiereRevisionAdministrativa, 'TURISMO' IdGrupoCategoria, 'False' ControlaBackup, 0 NivelAutorizacion, 'True' ActualizarAplicacion, 0 Comisiones) 
                   AS ORIG ON DEST.IdCategoria = ORIG.IdCategoria
        WHEN MATCHED THEN
            UPDATE SET DEST.NombreCategoria                 = ORIG.NombreCategoria
                     , DEST.DescuentoRecargo                = ORIG.DescuentoRecargo
                     , DEST.IdCaja                          = ORIG.IdCaja
                     , DEST.IdTipoComprobante               = ORIG.IdTipoComprobante
                     , DEST.IdCuenta                        = ORIG.IdCuenta
                     , DEST.IdInteres                       = ORIG.IdInteres
                     , DEST.IdCuentaSecundaria              = ORIG.IdCuentaSecundaria
                     , DEST.IdProducto                      = ORIG.IdProducto
                     , DEST.IdInteresCuotas                 = ORIG.IdInteresCuotas
                     , DEST.RequiereRevisionAdministrativa  = ORIG.RequiereRevisionAdministrativa
                     , DEST.IdGrupoCategoria                = ORIG.IdGrupoCategoria
                     , DEST.ControlaBackup                  = ORIG.ControlaBackup
                     , DEST.NivelAutorizacion               = ORIG.NivelAutorizacion
                     , DEST.ActualizarAplicacion            = ORIG.ActualizarAplicacion
                     , DEST.Comisiones                      = ORIG.Comisiones

        WHEN NOT MATCHED THEN 
            INSERT(     IdCategoria,      NombreCategoria,      DescuentoRecargo,      IdCaja,      IdTipoComprobante,      IdCuenta,      IdInteres,      IdCuentaSecundaria,      IdProducto,      IdInteresCuotas,      RequiereRevisionAdministrativa,      IdGrupoCategoria,      ControlaBackup,      NivelAutorizacion,      ActualizarAplicacion,      Comisiones)
            VALUES(ORIG.IdCategoria, ORIG.NombreCategoria, ORIG.DescuentoRecargo, ORIG.IdCaja, ORIG.IdTipoComprobante, ORIG.IdCuenta, ORIG.IdInteres, ORIG.IdCuentaSecundaria, ORIG.IdProducto, ORIG.IdInteresCuotas, ORIG.RequiereRevisionAdministrativa, ORIG.IdGrupoCategoria, ORIG.ControlaBackup, ORIG.NivelAutorizacion, ORIG.ActualizarAplicacion, ORIG.Comisiones)
    ;

    PRINT ''
    PRINT '5.- Tabla Rubros: Inicialización para Turismo'
    MERGE INTO Rubros AS DEST
            USING (SELECT 1 IdRubro, 'Programas'   NombreRubro, NULL IdProvincia, NULL IdActividad, 0 ComisionPorVenta, 0 UnidHasta1, 0 UnidHasta2, 0 UnidHasta3, 0 UHPorc1, 0 UHPorc2, 0 UHPorc3, 0 UnidHasta4, 0 UnidHasta5, 0 UHPorc4, 0 UHPorc5, GETDATE() FechaActualizacionWeb, 1 Orden, 0 DescuentoRecargoPorc1, 0 DescuentoRecargoPorc2 UNION ALL
                   SELECT 2 IdRubro, 'Visitas'     NombreRubro, NULL IdProvincia, NULL IdActividad, 0 ComisionPorVenta, 0 UnidHasta1, 0 UnidHasta2, 0 UnidHasta3, 0 UHPorc1, 0 UHPorc2, 0 UHPorc3, 0 UnidHasta4, 0 UnidHasta5, 0 UHPorc4, 0 UHPorc5, GETDATE() FechaActualizacionWeb, 2 Orden, 0 DescuentoRecargoPorc1, 0 DescuentoRecargoPorc2 UNION ALL
                   SELECT 3 IdRubro, 'Actividades' NombreRubro, NULL IdProvincia, NULL IdActividad, 0 ComisionPorVenta, 0 UnidHasta1, 0 UnidHasta2, 0 UnidHasta3, 0 UHPorc1, 0 UHPorc2, 0 UHPorc3, 0 UnidHasta4, 0 UnidHasta5, 0 UHPorc4, 0 UHPorc5, GETDATE() FechaActualizacionWeb, 3 Orden, 0 DescuentoRecargoPorc1, 0 DescuentoRecargoPorc2 UNION ALL
                   SELECT 4 IdRubro, 'Gastronomia' NombreRubro, NULL IdProvincia, NULL IdActividad, 0 ComisionPorVenta, 0 UnidHasta1, 0 UnidHasta2, 0 UnidHasta3, 0 UHPorc1, 0 UHPorc2, 0 UHPorc3, 0 UnidHasta4, 0 UnidHasta5, 0 UHPorc4, 0 UHPorc5, GETDATE() FechaActualizacionWeb, 4 Orden, 0 DescuentoRecargoPorc1, 0 DescuentoRecargoPorc2
                   ) 
                   AS ORIG ON DEST.IdRubro = ORIG.IdRubro
        WHEN MATCHED THEN
            UPDATE SET   DEST.NombreRubro           = ORIG.NombreRubro
                     , DEST.IdProvincia           = ORIG.IdProvincia
                     , DEST.IdActividad           = ORIG.IdActividad
                     , DEST.ComisionPorVenta      = ORIG.ComisionPorVenta
                     , DEST.UnidHasta1            = ORIG.UnidHasta1
                     , DEST.UnidHasta2            = ORIG.UnidHasta2
                     , DEST.UnidHasta3            = ORIG.UnidHasta3
                     , DEST.UHPorc1               = ORIG.UHPorc1
                     , DEST.UHPorc2               = ORIG.UHPorc2
                     , DEST.UHPorc3               = ORIG.UHPorc3
                     , DEST.UnidHasta4            = ORIG.UnidHasta4
                     , DEST.UnidHasta5            = ORIG.UnidHasta5
                     , DEST.UHPorc4               = ORIG.UHPorc4
                     , DEST.UHPorc5               = ORIG.UHPorc5
                     , DEST.FechaActualizacionWeb = ORIG.FechaActualizacionWeb
                     , DEST.Orden                 = ORIG.Orden
                     , DEST.DescuentoRecargoPorc1 = ORIG.DescuentoRecargoPorc1
                     , DEST.DescuentoRecargoPorc2 = ORIG.DescuentoRecargoPorc2

        WHEN NOT MATCHED THEN 
            INSERT(     IdRubro,      NombreRubro,      IdProvincia,      IdActividad,      ComisionPorVenta,      UnidHasta1,      UnidHasta2,      UnidHasta3,      UHPorc1,      UHPorc2,      UHPorc3,      UnidHasta4,      UnidHasta5,      UHPorc4,      UHPorc5,      FechaActualizacionWeb,      Orden,      DescuentoRecargoPorc1,      DescuentoRecargoPorc2)
            VALUES(ORIG.IdRubro, ORIG.NombreRubro, ORIG.IdProvincia, ORIG.IdActividad, ORIG.ComisionPorVenta, ORIG.UnidHasta1, ORIG.UnidHasta2, ORIG.UnidHasta3, ORIG.UHPorc1, ORIG.UHPorc2, ORIG.UHPorc3, ORIG.UnidHasta4, ORIG.UnidHasta5, ORIG.UHPorc4, ORIG.UHPorc5, ORIG.FechaActualizacionWeb, ORIG.Orden, ORIG.DescuentoRecargoPorc1, ORIG.DescuentoRecargoPorc2)
    ;

    PRINT ''
    PRINT '6.- Tabla TiposComprobantes: Tipo de comprobante RESERVA'
    --Nuevo comprobante RESERVA
    INSERT [dbo].[TiposComprobantes] 
    /*01*/ ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
    /*02*/  [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], 
    /*03*/  [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], 
    /*04*/  [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], 
    /*05*/  [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], 
    /*06*/  [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica],
    /*07*/  [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], [EsAnticipo], [EsRecibo], [Grupo], 
    /*08*/  [EsPreElectronico], [GeneraContabilidad], [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg],
    /*09*/  [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], [IdProductoNCred], [IdProductoNDeb],
    /*10*/  [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], [EsDespachoImportacion], [CargaDescRecActual],
    /*11*/  [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito],
    /*12*/  [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], 
    /*13*/  [RequiereReferenciaCtaCte], [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado],
    /*14*/  [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC], [AFIPWSRequiereReferenciaComercial], 
    /*15*/  [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion], [Orden], [MarcaInvocado],
    /*16*/  [PermiteSeleccionarAlicuotaIVA], [ImportaObservGrales], [DescripcionImpresion], [InformaLibroIva]) 
    VALUES 
    /*01*/ ('RESERVA', 'False', 'RESERVA', 'TURISMO', 0, 
    /*02*/  'False', 'False', 'X', 100, 'True', 0, 
    /*03*/  NULL, 'False', 'False', 'False', 'False', 'Reserva', 
    /*04*/  'True', 1, 'False', NULL, 'False', 
    /*05*/  0, NULL, 0, '.', 
    /*06*/  'False', 0.01, 'False', 'False', 'False', 'False',
    /*07*/  'False', 'False', 1, 'False', 'False', 'TURISMO', 
    /*08*/  'False', 'False', 'False', 'False', 
    /*09*/  'False', NULL, NULL, NULL, NULL, 
    /*10*/  'False', 'False', '', 'False', 'False', 
    /*11*/  NULL, 'False', 'False', 
    /*12*/  'False', 'False', 8, 1, 
    /*13*/  'False', 'False', 'False', 'False', 
    /*14*/  NULL, 'False', 'False', 
    /*15*/  'False', 'False', 0, 10, 'False', 
    /*16*/  'False', 'False', 'Reserva', 'False')

    PRINT ''
    PRINT '6.1.- Tabla Impresoras: Agregar RESERVA a impresora NORMAL'
    --Asignacion a la Normal
    UPDATE Impresoras
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',RESERVA'
     WHERE IdImpresora = 'NORMAL'
    --   AND IdSucursal = 1
END
