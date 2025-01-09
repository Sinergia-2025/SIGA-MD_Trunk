PRINT ''
PRINT '0. Habilitar Ticket a Metalsur.'
IF dbo.BaseConCuit('33631312379') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Tabla CRMTiposNovedades: Agregando TICKETS'
    --INSERT CRMTiposNovedades
    --       (IdTipoNovedad, NombreTipoNovedad, UnidadDeMedida, UsuarioRequerido, UsuarioPorDefecto,
    --        ProximoContactoRequerido, PrimerOrdenGrilla, PrimerOrdenDesc, SegundoOrdenGrilla, SegundoOrdenDesc,
    --        VisualizaOtrasNovedades, VisualizaRevisionAdministrativa, PermiteBorrarComentarios, DiasProximoContacto, PermiteIngresarNumero,
    --        ReportaCantidad, ReportaAvance, LetrasHabilitadas, VerCambios)
    --VALUES ('TICKETS', 'Tickets', '%', 'True', 'True',
    --        'False', 'N__FechaNovedad', 'True', '', 'False',
    --        'True', 'True', 'True', 1, 'False',
    --        'False', 'True', 'X', 'False')

    PRINT ''
    PRINT '1.2. Tabla CRMTiposComentariosNovedades: Agregando TICKETS'
    --INSERT CRMTiposComentariosNovedades 
    --       (IdTipoComentarioNovedad, NombreTipoComentarioNovedad, Posicion, PorDefecto, Color, IdTipoNovedad, VisibleParaCliente, VisibleParaRepresentante)
    --VALUES (101, 'COMENTARIO',         1, 'True',  NULL,      'TICKETS', 'False', 'True'),
    --       (102, 'ADJUNTO',            2, 'False', -16711681, 'TICKETS', 'False', 'True'),
    --       (103, 'COMENTARIO PUBLICO', 3, 'False', -8323328,  'TICKETS', 'True', 'True')

    PRINT ''
    PRINT '1.3. Tabla CRMPrioridadesNovedades: Agregando TICKETS'
    INSERT CRMPrioridadesNovedades 
           (IdPrioridadNovedad, NombrePrioridadNovedad, Posicion, IdTipoNovedad, PorDefecto) 
    VALUES (801, 'MUY ALTA', 1, 'TICKETS', 'False'),
           (802, 'ALTA', 2, 'TICKETS', 'True'),
           (803, 'MEDIA', 3, 'TICKETS', 'False'),
           (804, 'BAJA', 4, 'TICKETS', 'False')

    PRINT ''
    PRINT '1.4. Tabla CRMEstadosNovedades: Agregando TICKETS'
    INSERT CRMEstadosNovedades 
           (IdEstadoNovedad, NombreEstadoNovedad, Posicion, SolicitaUsuario, Finalizado, IdTipoNovedad, PorDefecto, Color, DiasProximoContacto, ActualizaUsuarioResponsable, SolicitaProveedorService, Imprime, Reporte, Embebido, AcumulaContador1, AcumulaContador2) 
    VALUES (801, 'NUEVO',      10, 'True', 'False', 'TICKETS', 'True', -65536,    NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False'),
           (802, 'ASIGNADO',   20, 'True', 'False', 'TICKETS', 'False', NULL,     NULL, 'True',  'False', 'False', NULL, 'False', 'False', 'False'),
           (803, 'EN PROCESO', 30, 'True', 'False', 'TICKETS', 'False', -8323328, NULL, 'True',  'False', 'False', NULL, 'False', 'False', 'False'),
           (804, 'FINALIZADO', 40, 'True', 'True',  'TICKETS', 'False', NULL,     NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False'),
           (805, 'CANCELADO',  50, 'True', 'True',  'TICKETS', 'False', NULL,     NULL, 'False', 'False', 'False', NULL, 'False', 'False', 'False')

    PRINT ''
    PRINT '1.5. Tabla CRMCategoriasNovedades: Agregando TICKETS'
    INSERT CRMCategoriasNovedades
           (IdCategoriaNovedad, NombreCategoriaNovedad, Posicion, IdTipoNovedad, PorDefecto, Reporta, Color, PublicarEnWeb)
    VALUES (801, 'CONSULTA', 1, 'TICKETS', 'True',  'NO', NULL,   'True'),
           (802, 'RECLAMO',  2, 'TICKETS', 'False', 'NO', -32768, 'True')

    PRINT ''
    PRINT '1.6. Tabla CRMMediosComunicacionesNovedades: Agregando TICKETS'
    INSERT CRMMediosComunicacionesNovedades
           (IdMedioComunicacionNovedad, NombreMedioComunicacionNovedad, Posicion, IdTipoNovedad, PorDefecto, Color)
    VALUES (801, 'CORREO',                1, 'TICKETS', 'False', NULL),
           (802, 'TELEFONICO',            2, 'TICKETS', 'False', NULL),
           (803, 'CELULAR',               3, 'TICKETS', 'False', NULL),
           (804, 'WHATSAPP',              4, 'TICKETS', 'False', NULL),
           (805, 'WEB',                   5, 'TICKETS', 'False', NULL),
           (806, 'PERSONALMENTE',         6, 'TICKETS', 'False', NULL),
           (807, 'FACEBOOK',              7, 'TICKETS', 'False', NULL),
           (808, 'TWITTER',               8, 'TICKETS', 'False', NULL),
           (809, 'TEAMVIEWER',            9, 'TICKETS', 'False', NULL),
           (810, 'CELULAR PERSONAL',     10, 'TICKETS', 'False', NULL),
           (811, 'SKYPE / ZOOM / OTRO',  11, 'TICKETS', 'False', NULL),
           (812, 'APP POST-VENTA',       12, 'TICKETS', 'True',  NULL)

    PRINT ''
    PRINT '1.7. Tabla CRMMetodosResolucionesNovedades: Agregando TICKETS'
    INSERT CRMMetodosResolucionesNovedades
           (IdMetodoResolucionNovedad, NombreMetodoResolucionNovedad, Posicion, IdTipoNovedad, PorDefecto)
    VALUES (801, 'CLIENTE',       1, 'TICKETS', 'False'),
           (802, 'REMOTO',        2, 'TICKETS', 'False'),
           (803, 'OFICINA',       3, 'TICKETS', 'True'),
           (804, 'FUERA OFICINA', 4, 'TICKETS', 'False')

    PRINT ''
    PRINT '1.8. Tabla CRMTiposNovedadesDinamicos: Agregando TICKETS'
    --INSERT CRMTiposNovedadesDinamicos 
    --       (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden) 
    --VALUES ('TICKETS', 'CLIENTES', 'True', 10)


    --PRINT ''
    --PRINT '3. Parametros: Inicializar parámetros'
    --DECLARE @idParametro VARCHAR(MAX)
    --DECLARE @descripcionParametro VARCHAR(MAX)
    --DECLARE @valorParametro VARCHAR(MAX)

    --SET @idParametro = 'SIMOVILCOBRANZAINCLUIRCLIENTES'
    --SET @descripcionParametro = 'Incluir Clientes'
    --SET @valorParametro = 'TodosLosClientes'

    --PRINT ''
    --PRINT '3.1. Parametros: Incluir Clientes = TodosLosClientes'
    --MERGE INTO Parametros AS DEST
    --        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    --    WHEN MATCHED THEN
    --        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    --    WHEN NOT MATCHED THEN 
    --        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    --;

    --SET @idParametro = 'SIMOVILSUBIDAINCLUIRCUENTASCORRIENTES'
    --SET @descripcionParametro = 'Cuentas Corrientes'
    --SET @valorParametro = 'False'

    --PRINT ''
    --PRINT '3.2. Parametros: Incluir Cuentas Corrientes = False'
    --MERGE INTO Parametros AS DEST
    --        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    --    WHEN MATCHED THEN
    --        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    --    WHEN NOT MATCHED THEN 
    --        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    --;

END
