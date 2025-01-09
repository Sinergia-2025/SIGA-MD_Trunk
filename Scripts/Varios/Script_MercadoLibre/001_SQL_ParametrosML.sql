-- INSERTA PARAMETROS DEFAULT MERCADO LIBRE.- --
PRINT ''
PRINT 'B1. Carga APP-ID del Usuario Mercado Libre.-'
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'MERCADOLIBREAPPID' AS IdParametro, 
				'8477661978426261' ValorParametro, 
				'Tienda Web' CategoriaParametro, 
				'MERCADOLIBREAPPID' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B2. Carga Client-Secret del Usuario Mercado Libre.- '
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRESECRETKEY' AS IdParametro, 
                '1oOiZCj3hFeWkXciXzOrjNlXgRruGJNv' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRESECRETKEY' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B3. Carga Codigo-Reseller del Usuario Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECODIGORESELLER' AS IdParametro, 
                '' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECODIGORESELLER' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B4. Carga Codigo TG de Refresh Token Mercado Libre.-'    
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREREFRESHTOKEN' AS IdParametro, 
                '' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREREFRESHTOKEN' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B5. Carga Fecha expiracion de Token Mercado Libre.- '
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREFECHATOKEN' AS IdParametro, 
                '2021-01-01 00:00:00.000' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREFECHATOKEN' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B6. Carga Codigo de Token Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRETOKEN' AS IdParametro, 
                '' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRETOKEN' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B7. Carga URL Base Mercado Libre'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREURLBASE' AS IdParametro, 
                'https://api.mercadolibre.com/' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREURLBASE' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B8. Carga Codigo de Imagen Default Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREIMAGENDEFAULT' AS IdParametro, 
                '751525-MLA46263535201_062021' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREIMAGENDEFAULT' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B9. Carga Categoria Default Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECATEGORIADEFAULT' AS IdParametro, 
                'MLA3530' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECATEGORIADEFAULT' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B10. Carga Categoria del Cliente Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECATEGORIACLIENTE' AS IdParametro, 
                '1' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECATEGORIACLIENTE' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B11. Carga Categoria Fiscal de Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECATEGORIAFISCALCLIENTE' AS IdParametro, 
                '1' ValorParametro,  -- Consumidor Final.- --
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECATEGORIAFISCALCLIENTE' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B12. Carga Correo Notificacion Default Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECORREONOTIFICACIONES' AS IdParametro, 
                '.' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECORREONOTIFICACIONES' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B13. Carga Producto Envio Default Mercado Libre.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREIDPRODUCTOENVIO' AS IdParametro, 
                '.' ValorParametro,
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREIDPRODUCTOENVIO' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B14. Carga Lista de Precios Default Mercado Libre.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRELISTAPRECIOS' AS IdParametro, 
                (SELECT TOP(1) ValorParametro FROM PARAMETROS WHERE IdParametro = 'LISTAPRECIOSPREDETERMINADA') ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRELISTAPRECIOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B15. Carga Criticidad Default Mercado Libre.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREPEDIDOSCRITICIDAD' AS IdParametro, 
                (SELECT TOP(1) IdCriticidad FROM PedidosCriticidades WHERE Orden = 1) ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREPEDIDOSCRITICIDAD' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B16. Carga Forma de Pago Default Mercado Libre.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREPEDIDOSFORMADEPAGO' AS IdParametro, 
                (SELECT TOP(1) IdFormasPago FROM VentasFormasPago WHERE OrdenVentas = 1) ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREPEDIDOSFORMADEPAGO' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B17. Carga Tipo de Comprobante Default Mercado Libre.-'
-- Verifico si Existe el comprobante.- --
IF not exists ( SELECT *
                FROM TiposComprobantes 
                WHERE IdTipoComprobante = 'PEDIDOML')
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
            [SolicitaFechaDevolucion], [AFIPWSRequiereReferenciaTransferencia], [ActivaTildeMercDespacha], [Color], [CodigoRoela]) 
        VALUES (N'PEDIDOML', 0, N'Pedido Mercado Libre', N'PEDIDOSCLIE', 0, 0, 1, N'X', 100, 0, 1, N'SI', 0, 0, 1, 0, N'Pedido ML', 1, 1, 0, 
                NULL, 0, 99, NULL, CAST(9999999.99 AS Decimal(14, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 1, 1, 0, 1, 1, 1, 0, 0, N'PEDIDOSCLIE', 
                0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, N'', 0, 1, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 1, 0, NULL, 0, 0, 0, 0, 0, 10, 1, 0, 1, N'Pedido ML', 0, 0, 0, 0,NULL, 0)
	END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B18. Carga Comprobante Default Mercado Libre en Impresoras.-'
BEGIN
    -- Incorpora Comprobante a Impresora.- --
    MERGE INTO Impresoras AS DEST
    USING (
            SELECT * FROM Impresoras WHERE ComprobantesHabilitados like('%,PEDIDOML%') OR ComprobantesHabilitados like('%,PEDIDOML,%') OR ComprobantesHabilitados like('%PEDIDOML,%')) AS ORIG 
            ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdImpresora = ORIG.IdImpresora
    WHEN MATCHED THEN
        UPDATE SET DEST.ComprobantesHabilitados = ORIG.ComprobantesHabilitados + ', PEDIDOML';
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B19. Asigna Tipo de Comprobante Default Mercado Libre.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREPEDIDOSTIPOCOMPROBANTE' AS IdParametro, 
                'eFACT-Web' ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREPEDIDOSTIPOCOMPROBANTE' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B20. Carga Vendedor Default Mercado Libre.-'
BEGIN
	DECLARE @Valor as Varchar(10)
	SET @Valor = (SELECT MAX(IdEmpleado) FROM Empleados) + 1 
    -- Inserta Vendedor Mercado Libre
    INSERT [dbo].[Empleados] 
        ([TipoDocEmpleado], [NroDocEmpleado], [NombreEmpleado], [TelefonoEmpleado], [CelularEmpleado], 
        [EsVendedor], [EsComprador], [IdUsuario], [ComisionPorVenta], [Direccion], [IdLocalidad], 
        [GeoLocalizacionLat], [GeoLocalizacionLng], [IdEmpleado], [Color], [NivelAutorizacion], [Clave], 
        [DebitoDirecto], [IdBanco], [IdDispositivo], [EsCobrador], [IdUsuarioMovil], [DebitoTarjeta], [IdTarjeta], [Eschofer], [IdTransportista]) 
    VALUES 
        ('COD', 1, 'Mercado Libre', '', '', 1, 0, NULL, CAST(0.00 AS Decimal(5, 2)), '.', 2000, NULL, NULL,@Valor,
		 NULL, 1, '', 0, NULL, NULL, 0, NULL, 0, NULL,0,NULL)

    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBREVENDEDOR' AS IdParametro, 
                @Valor ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBREVENDEDOR' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT 'B21. Carga Caja Default Mercado Libre.-'
BEGIN
	DECLARE @Caja as Integer
	-- Obtengo Mayor numero de Caja.- --
	SET @Caja = (SELECT MAX(IdCaja) as maximo  from CajasNombres)
	-- Inserta parametros.- --        
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MERCADOLIBRECAJADEFAULT' AS IdParametro, 
                @Caja ValorParametro, 
                'Tienda Web' CategoriaParametro, 
                'MERCADOLIBRECAJADEFAULT' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO