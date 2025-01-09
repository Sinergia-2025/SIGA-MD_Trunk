----------------------------------------------------
--INCORPORA CAMPOS CLIENTE ARBOREA.- --
PRINT ''
PRINT 'C0. Nuevo Campo: Tabla Clientes'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdClienteArborea' AND TABLE_NAME = 'Clientes')
    BEGIN
        ALTER TABLE dbo.Clientes ADD IdClienteArborea varchar(30) NULL
        ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_ClientesArborea ON dbo.Clientes
	        (
	        IdClienteArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaClientes ADD IdClienteArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.Prospectos ADD IdProspectoArborea varchar(30) NULL
        ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaProspectos ADD IdProspectoArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS RUBROS ARBOREA.- --
PRINT ''
PRINT 'D0. Nuevo Campo: Tabla Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdRubroArborea' AND TABLE_NAME = 'Rubros')
    BEGIN
        ALTER TABLE dbo.Rubros ADD IdRubroArborea varchar(30) NULL
        ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_RubroArborea ON dbo.Rubros
	        (
	        IdRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS SUB RUBROS ARBOREA.- --
PRINT ''
PRINT 'E0. Nuevo Campo: Tabla SUB Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdSubRubroArborea' AND TABLE_NAME = 'SubRubros')
    BEGIN
        ALTER TABLE dbo.SubRubros ADD IdSubRubroArborea varchar(30) NULL
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_SubRubroArborea ON dbo.SubRubros
	        (
	        IdSubRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS SUBSUB RUBROS ARBOREA.- --
PRINT ''
PRINT 'F0. Nuevo Campo: Tabla SUBSUB Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdSubSubRubroArborea' AND TABLE_NAME = 'SubSubRubros')
    BEGIN
        ALTER TABLE dbo.SubSubRubros ADD IdSubSubRubroArborea varchar(30) NULL
        ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_SubSubRubroArborea ON dbo.SubSubRubros
	        (
	        IdSubSubRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS PRODUCTOS ARBOREA.- --
PRINT ''
PRINT 'G0. Nuevo Campo: Tabla Productos'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'CodigoProductoArborea' AND TABLE_NAME = 'Productos')
    BEGIN
        ALTER TABLE dbo.Productos ADD CodigoProductoArborea varchar(30) NULL
        ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_CodigoProductoArborea ON dbo.Productos
	        (
	        CodigoProductoArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaProductos ADD CodigoProductoArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
-- ESTABLECE TODAS LAS OPCIONES DE MENU.- --
PRINT ''
PRINT 'A0. Nuevo Menu: Tiendas Web'
BEGIN
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A1. Nueva Tarea Programada: Bajada de Información de Arborea'
	IF dbo.ExisteFuncion('CmdSubidaArborea') = 0
	BEGIN    
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CmdSubidaArborea', 'CmdSubidaArborea', 'CmdSubidaArborea', 'False', 'False', 'True', 'True'
            ,NULL, 1000, 'Eniac.Win', 'CmdSubidaArborea', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CmdSubidaArborea' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A2. Nueva Tarea Programada: Subida de Información de Arborea'    
	IF dbo.ExisteFuncion('CmdBajadaArborea') = 0
	BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CmdBajadaArborea', 'CmdBajadaArborea', 'CmdBajadaArborea', 'False', 'False', 'True', 'True'
            ,NULL, 1000, 'Eniac.Win', 'CmdBajadaArborea', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CmdBajadaArborea' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A3. Nuevo Menu: Tiendas Web - Generacion de Padre'
	IF dbo.ExisteFuncion('TiendasWeb') = 0
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('TiendasWeb', 'Tiendas Web', 'Tiendas Web', 'True', 'False', 'True', 'True'
			, NULL, 165, NULL, NULL, NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TiendasWeb' AS Pantalla FROM dbo.Roles
		    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A4. Nuevo Menu: Tiendas Web - Sincronizacion Bajada - Arborea'
	IF dbo.ExisteFuncion('SincronizacionSubidaTiendaWeb') = 0
	BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('SincronizacionSubidaTiendaWeb', 'Sincronización Subida - Tienda Web', 'Sincronización Subida - Tienda Web', 'True', 'False', 'True', 'True'
            , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionSubidaTiendaWeb', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaTiendaWeb' AS Pantalla FROM dbo.Roles
	        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ----------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT 'A5. Nuevo Menu: Tiendas Web - Sincronizacion Subida - Arborea'
	IF dbo.ExisteFuncion('SincronizacionBajadaTiendaWeb') = 0
	BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('SincronizacionBajadaTiendaWeb', 'Sincronización Bajada - Tienda Web', 'Sincronización Bajada - Tienda Web', 'True', 'False', 'True', 'True'
            , 'TiendasWeb', 15, 'Eniac.Win', 'SincronizacionBajadaTiendaWeb', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaTiendaWeb' AS Pantalla FROM dbo.Roles
	        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    -----------------------------------------------------------------------------------------------------------------------	
    PRINT ''
    PRINT 'A6. Nuevo Menu: Tiendas Web - Administrador de Pedidos - Arborea'
	IF dbo.ExisteFuncion('AdministradorPedidosTiendasWeb') = 0
	BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('AdministradorPedidosTiendasWeb', 'Administrador de Pedidos - Tiendas Web', 'Administrador de Pedidos - Tiendas Web', 'True', 'False', 'True', 'True'
            ,'TiendasWeb', 20, 'Eniac.Win', 'AdministradorPedidosTiendasWeb', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'AdministradorPedidosTiendasWeb' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    -----------------------------------------------------------------------------------------------------------------------	
END
GO

----------------------------------------------------
-- INSERTA PARAMETROS DEFAULT ARBOREA.- --
PRINT ''
PRINT 'B0. Inserta parametro tabla de Parametros'
DECLARE @Valor as Varchar(10)
BEGIN
    PRINT ''
    PRINT 'B1. Carga URL Base Arborea'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAURLBASE' AS IdParametro, 
                    '' ValorParametro, 
                    'Tienda Arborea' CategoriaParametro, 
                    'ARBOREAURLBASE' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B2. Carga Usuario Token.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAUSUARIOTOKEN' AS IdParametro, 
                    '' ValorParametro, 
                    'Tienda Arborea' CategoriaParametro, 
                    'ARBOREAUSUARIOTOKEN' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B3. Carga Clave Token.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACLAVETOKEN' AS IdParametro, 
                    '' ValorParametro, 
                    'Tienda Arborea' CategoriaParametro, 
                    'ARBOREACLAVETOKEN' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B4. Carga Forma de Pago Default Arborea.-'
    BEGIN
        DECLARE @ValPar as Varchar(10)
        -- Recupero Primer Valor.- --
        SET @ValPar = (SELECT TOP(1) IdFormasPago FROM VentasFormasPago WHERE OrdenVentas = 1)
        -- Inserto Registro.- --
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAPEDIDOSFORMADEPAGO' AS IdParametro, 
                    @ValPar ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREAPEDIDOSFORMADEPAGO' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B5. Carga Tipo de Comprobante Default Arborea.-'
    -- Verifico si Existe el comprobante.- --
    IF not exists ( SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'PEDIDOARB')
        BEGIN
            -- Inserta Comprobante Mercado Libre
            INSERT [dbo].[TiposComprobantes] 
                ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], 
                [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], 
                [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], 
                [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], 
                [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], 
                [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], 
                [ImportaObservDeInvocados], [IdPlanCuenta], [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], 
                [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], 
                [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], [EsDespachoImportacion], 
                [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], 
                [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], 
                [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC], 
                [AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion], [Orden], 
                [MarcaInvocado], [PermiteSeleccionarAlicuotaIVA], [ImportaObservGrales], [DescripcionImpresion], [InformaLibroIva], 
                [SolicitaFechaDevolucion], [AFIPWSRequiereReferenciaTransferencia], [ActivaTildeMercDespacha]) 
            VALUES (N'PEDIDOARB', 0, N'Pedido Arborea', N'PEDIDOSCLIE', 0, 0, 1, N'X', 100, 0, 1, N'SI', 0, 0, 1, 0, N'Pedido ARB', 1, 1, 0, 
                    NULL, 0, 99, NULL, CAST(9999999.99 AS Decimal(14, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 1, 1, 0, 1, 1, 1, 0, 0, N'PEDIDOSCLIE', 
                    0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, N'', 0, 1, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 1, 0, NULL, 0, 0, 0, 0, 0, 10, 1, 0, 1, N'Pedido ARB', 0, 0, 0, 0)
            -- Incorpora Comprobante a Impresora.- --
            MERGE INTO Impresoras AS DEST
            USING (
                    SELECT * FROM Impresoras WHERE ComprobantesHabilitados like('%,PEDIDOARB%') OR ComprobantesHabilitados like('%,PEDIDOARB,%') OR ComprobantesHabilitados like('%PEDIDOARB,%')) AS ORIG 
                    ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdImpresora = ORIG.IdImpresora
            WHEN MATCHED THEN
                UPDATE SET DEST.ComprobantesHabilitados = ORIG.ComprobantesHabilitados + ', PEDIDOARB';
            -- Recupero Primer Valor.- --
            SET @Valor = (SELECT TOP(1) IdFormasPago FROM VentasFormasPago WHERE OrdenVentas = 1)
            -- Inserto Registro.- --
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'ARBOREAPEDIDOSTIPOCOMPROBANTE' AS IdParametro, 
                        'eFACT-Web' ValorParametro, 
                        'Tienda Arborea' CategoriaParametro, 
                        'ARBOREAPEDIDOSTIPOCOMPROBANTE' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END

    PRINT ''
    PRINT 'B6. Carga Vendedor Default Arborea.-'
    BEGIN
        -- Recupero Primer Valor.- --
        SET @Valor = (SELECT MAX(IdEmpleado) FROM Empleados) + 1 
        -- Inserta Vendedor Mercado Libre
        INSERT [dbo].[Empleados] 
            ([TipoDocEmpleado], [NroDocEmpleado], [NombreEmpleado], [TelefonoEmpleado], [CelularEmpleado], 
            [EsVendedor], [EsComprador], [IdUsuario], [ComisionPorVenta], [Direccion], [IdLocalidad], 
            [GeoLocalizacionLat], [GeoLocalizacionLng], [IdEmpleado], [Color], [NivelAutorizacion], [Clave], 
            [DebitoDirecto], [IdBanco], [IdDispositivo], [EsCobrador], [IdUsuarioMovil], [DebitoTarjeta]) 
        VALUES 
            ('COD', 1, 'Arborea', '', '', 1, 0, NULL, CAST(0.00 AS Decimal(5, 2)), '.', 2000, NULL, NULL,@Valor, NULL, 1, '', 0, NULL, NULL, 0, NULL, 0)

        -- Inserto Registro.- --
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAVENDEDOR' AS IdParametro, 
                    @Valor ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREAVENDEDOR' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B7. Carga Correo de Notificacion.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACORREONOTIFICACIONES' AS IdParametro, 
                    '.' ValorParametro, 
                    'Tienda Arborea' CategoriaParametro, 
                    'ARBOREACORREONOTIFICACIONES' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B8. Carga Categoria del Cliente Arborea.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACATEGORIACLIENTE' AS IdParametro, 
                    '1' ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREACATEGORIACLIENTE' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B9. Carga Id de Producto Envio.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAIDPRODUCTOENVIO' AS IdParametro, 
                    '.' ValorParametro, 
                    'Tienda Arborea' CategoriaParametro, 
                    'ARBOREAIDPRODUCTOENVIO' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B10. Carga Categoria del Cliente Arborea.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACATEGORIACLIENTE' AS IdParametro, 
                    '1' ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREACATEGORIACLIENTE' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B11. Carga Categoria Fiscal de Arborea.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACATEGORIAFISCALCLIENTE' AS IdParametro, 
                    '1' ValorParametro,  -- Consumidor Final.- --
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREACATEGORIAFISCALCLIENTE' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B12. Carga Criticidad Default Arborea.-'
    BEGIN
        -- Recupero Primer Valor.- --
        SET @Valor = (SELECT TOP(1) IdCriticidad FROM PedidosCriticidades WHERE Orden = 1)
        -- Inserto Registro.- --
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREAPEDIDOSCRITICIDAD' AS IdParametro, 
                    @Valor ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREAPEDIDOSCRITICIDAD' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B13. Carga Codigo Parent Principal Arborea.-'
    BEGIN
        -- Inserto Registro.- --
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREACATEGORIAPRINCIPAL' AS IdParametro, 
                    '.' ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREACATEGORIAPRINCIPAL' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'B14. Carga Lista de Precios Default Arborea.-'
    BEGIN
        -- Inserto Registro.- --
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'ARBOREALISTADEPRECIOS' AS IdParametro, 
                    (SELECT TOP(1) ValorParametro FROM PARAMETROS WHERE IdParametro = 'LISTAPRECIOSPREDETERMINADA') ValorParametro, 
                    'Tienda Web' CategoriaParametro, 
                    'ARBOREALISTADEPRECIOS' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

END
GO
----------------------------------------------------
PRINT ''
PRINT 'A0. Alta Lista de Precio Arborea 01.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS01' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS01' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'B0. Alta Lista de Precio Arborea 02.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS02' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS02' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'C0. Alta Lista de Precio Arborea 03.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS03' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS03' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'D0. Alta Lista de Precio Arborea 04.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS04' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS04' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'E0. Alta de URL de Lista de Precio Arborea.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREAURLLISTAPRECIOS' AS IdParametro, 
                '' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREAURLLISTAPRECIOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
PRINT ''
PRINT 'A0. Alta de URL de Lista de Precio Clientes Arborea.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREAURLLISTAPRECIOSCLIENTES' AS IdParametro, 
                '' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREAURLLISTAPRECIOSCLIENTES' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END