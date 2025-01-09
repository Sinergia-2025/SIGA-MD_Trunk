IF dbo.ExisteCampo('ComprasProductos','FechaActualizacionCalidad') = 0
BEGIN 
	ALTER TABLE ComprasProductos ADD FechaActualizacionCalidad datetime NULL
END

IF dbo.ExisteTabla('CalidadOrdenDeControl') = 0
BEGIN
	CREATE TABLE CalidadOrdenDeControl(
		IdSucursal int	NOT NULL,
		IdTipoComprobante varchar(15) NOT NULL,
		Letra varchar(1) NOT NULL,
		CentroEmisor int NOT NULL,
		NumeroComprobante bigint NOT NULL,
		Fecha datetime NOT NULL,
		IdProveedor bigint NULL,
		IdProducto Varchar(15) NOT NULL,
		IdLote varchar(30) NULL,
		IdDeposito int NOT NULL,
		IdUbicacion int NOT NULL,
		idUsuario varchar(10) NOT NULL,
		IdSucursalCompra int NULL,
		IdTipoComprobanteCompra varchar(15) NULL,
		LetraCompra Varchar(1) NULL,
		CentroEmisorCompra int NULL,
		NumeroComprobanteCompra bigint NULL,
		OrdenComprobanteCompra int NULL,
		CantidadComprobante Decimal(16,2) NOT NULL,
		IdEstadoCalidad varchar(15) NOT NULL
	 CONSTRAINT [PK_CalidadOrdenDeControl] PRIMARY KEY CLUSTERED 
	(
		IdSucursal ASC,
		IdTipoComprobante ASC,
		Letra ASC,
		CentroEmisor ASC,
		NumeroComprobante ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	-- Proveedores.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControl_Proveedor FOREIGN KEY(IdProveedor)
	REFERENCES Proveedores (IdProveedor)
	-- Productos.- 
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControls_Productos FOREIGN KEY(IdProducto)
	REFERENCES Productos (IdProducto)
	-- Productos Lotes.- 
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControls_ProductosLotes 
			FOREIGN KEY(IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
	REFERENCES ProductosLotes (IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
	-- Depósitos.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControl_Depositos FOREIGN KEY(IdDeposito, IdSucursal)
	REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)
	-- Ubicaciones.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControl_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
	REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
	-- Usuarios.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControls_Usuarios FOREIGN KEY(IdUsuario)
	REFERENCES Usuarios (Id)
	-- Comprobante Compra Producto.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControls_ComprasProductos
		FOREIGN KEY(IdSucursalCompra, IdTipoComprobanteCompra, LetraCompra, CentroEmisorCompra, NumeroComprobanteCompra, IdProveedor, OrdenComprobanteCompra, IdProducto)
	REFERENCES ComprasProductos (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, Orden, IdProducto)
	-- Estados Calidad.-
	ALTER TABLE CalidadOrdenDeControl  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControls_EstadosCalidad FOREIGN KEY(IdEstadoCalidad)
	REFERENCES EstadosOrdenesCalidad (IdEstadoCalidad)
END

IF dbo.ExisteTabla('CalidadOrdenDeControlItems') = 0
BEGIN
	CREATE TABLE CalidadOrdenDeControlItems(
		IdSucursal int	NOT NULL,
		IdTipoComprobante varchar(15) NOT NULL,
		Letra varchar(1) NOT NULL,
		CentroEmisor int NOT NULL,
		NumeroComprobante bigint NOT NULL,
		idListaControl int NOT NULL,
		IdListaControlItem int NOT NULL,
		NivelInspeccion  varchar(10) NOT NULL,
		ValorAQL decimal(6,2) NOT NULL,
		IdMRPAQLA int NULL,
		CodigoNivel varchar(1) NULL,
		TamanoMuestreo int NULL,
		CantidadAceptacion int NULL,
		CantidadRechazo Int NULL
	 CONSTRAINT [PK_CalidadOrdenDeControlItems] PRIMARY KEY CLUSTERED 
	(
		IdSucursal ASC,
		IdTipoComprobante ASC,
		Letra ASC,
		CentroEmisor ASC,
		NumeroComprobante ASC,
		idListaControl ASC,
		IdListaControlItem ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	-- Lista Control Items.-
	ALTER TABLE CalidadOrdenDeControlItems  
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControlItem_ListaControlItem FOREIGN KEY(IdListaControlItem)
	REFERENCES CalidadListasControlItems (IdListaControlItem)
	-- Lista Control.-
	ALTER TABLE CalidadOrdenDeControlItems
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControlItem_ListaControl FOREIGN KEY(IdListaControl)
	REFERENCES CalidadListasControl (IdListaControl)
	-- MRP AQL A.-
	ALTER TABLE CalidadOrdenDeControlItems
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControlItem_MRPAQLA FOREIGN KEY(IdMRPAQLA)
	REFERENCES MRPAQLA (IdMRPAQLA)
	-- Calidad Orden control.-
	ALTER TABLE CalidadOrdenDeControlItems
		WITH CHECK ADD  CONSTRAINT FK_CalidadOrdenDeControlsItem_Control 
		FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
	REFERENCES CalidadOrdenDeControl (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
END

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadOrdenDeControlABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CalidadOrdenDeControlABM', 'Ordenes de Calidad', 'Ordenes de Calidad', 'True', 'False', 'True', 'True'
        ,'Calidad', 100, 'Eniac.Win', 'CalidadOrdenDeControlABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')		
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadOrdenDeControlABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '1. Carga Tipo de Comprobante Ordenes de Compras.-'
IF not exists ( SELECT *
                FROM TiposComprobantes 
                WHERE IdTipoComprobante = 'CALIDADCONTROL')
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
            [SolicitaFechaDevolucion], [AFIPWSRequiereReferenciaTransferencia], [ActivaTildeMercDespacha], [Color], [CodigoRoela], [SimulaPercepciones], 
			[ClaseComprobante], [SolicitaInformeCalidad]) 
        VALUES ('CALIDADCONTROL', 0, 'Orden de Calidad', 'CALIDAD', 0, 0, 1, 'X', 100, 0, 1, 'SI', 0, 0, 1, 0, 'Calidad', 1, 1, 0, 
                NULL, 0, 99, NULL, CAST(9999999.99 AS Decimal(14, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 1, 1, 0, 1, 1, 1, 0, 0, 
				'CALIDADCONTROL', 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, '', 0, 1, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 1, 0, NULL, 0, 0, 0, 
				0, 0, 10, 1, 0, 1, 'Calidad Control', 0, 0, 0, 0,NULL, 0, 0, '', 'False');

		UPDATE Impresoras SET
				ComprobantesHabilitados = ComprobantesHabilitados + ',CALIDADCONTROL'
			WHERE IdImpresora = 'NORMAL'	
	END
GO
-----------------------------------------------------------------------------------------------------------------------	
PRINT ''
PRINT '1. Carga Tipo de Comprobante Ordenes de Compras.-'
IF not exists ( SELECT *
                FROM VentasNumeros 
                WHERE IdTipoComprobante = 'CALIDADCONTROL')
BEGIN
	INSERT INTO [dbo].[VentasNumeros]
        ([IdTipoComprobante]
        ,[LetraFiscal]
        ,[CentroEmisor]
        ,[IdSucursal]
        ,[Numero]
        ,[IdTipoComprobanteRelacionado]
        ,[Fecha]
        ,[IdEmpresa])
	    VALUES
        ('CALIDADCONTROL','X',1,1,0,NULL,GETDATE(),1);
END
GO

IF dbo.ExisteCampo('Productos', 'IdUnidadDeMedidaCompra') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD IdUnidadDeMedidaCompra varchar(10) NULL
    ALTER TABLE dbo.Productos ADD IdUnidadDeMedidaProduccion varchar(10) NULL
END
GO
IF dbo.ExisteCampo('Productos', 'FactorConversionCompra') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD FactorConversionCompra decimal(14,10) NULL
    ALTER TABLE dbo.Productos ADD FactorConversionProduccion decimal(14,10) NULL
END
GO

IF dbo.ExisteFK('FK_Productos_UnidadesDeMedidas_IdUnidadDeMedidaCompras') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_UnidadesDeMedidas_IdUnidadDeMedidaCompras 
        FOREIGN KEY (IdUnidadDeMedidaCompra)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END	
GO
IF dbo.ExisteFK('FK_Productos_UnidadesDeMedidas_IdUnidadDeMedidaProduccion') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_UnidadesDeMedidas_IdUnidadDeMedidaProduccion
        FOREIGN KEY (IdUnidadDeMedidaProduccion)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END	

UPDATE Productos
   SET IdUnidadDeMedidaCompra = IdUnidadDeMedida
     , IdUnidadDeMedidaProduccion = IdUnidadDeMedida
 WHERE IdUnidadDeMedidaCompra IS NULL

UPDATE Productos
   SET FactorConversionCompra = 1
     , FactorConversionProduccion = 1
 WHERE FactorConversionCompra IS NULL

ALTER TABLE dbo.Productos ALTER COLUMN IdUnidadDeMedidaCompra     varchar(10) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN IdUnidadDeMedidaProduccion varchar(10) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN FactorConversionCompra     decimal(14,10) NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN FactorConversionProduccion decimal(14,10) NOT NULL

ALTER TABLE dbo.Productos ALTER COLUMN Conversion decimal(14,10) NOT NULL
ALTER TABLE dbo.AuditoriaProductos ALTER COLUMN Conversion decimal(14,10) NULL

IF dbo.ExisteCampo('AuditoriaProductos', 'IdUnidadDeMedidaCompra') = 0
BEGIN
    ALTER TABLE dbo.AuditoriaProductos ADD IdUnidadDeMedidaCompra varchar(10) NULL
    ALTER TABLE dbo.AuditoriaProductos ADD IdUnidadDeMedidaProduccion varchar(10) NULL
    ALTER TABLE dbo.AuditoriaProductos ADD FactorConversionCompra decimal(14,10) NULL
    ALTER TABLE dbo.AuditoriaProductos ADD FactorConversionProduccion decimal(14,10) NULL
END
GO

IF dbo.ExisteCampo('ProductosComponentes', 'IdUnidadDeMedidaProduccion') = 0
BEGIN
    ALTER TABLE dbo.ProductosComponentes ADD IdUnidadDeMedidaProduccion varchar(10) NULL
    ALTER TABLE dbo.ProductosComponentes ADD CantidadUMProduccion decimal(16, 10) NULL
    ALTER TABLE dbo.ProductosComponentes ADD FactorConversionProduccion decimal(16, 10) NULL
END
GO

UPDATE PC
   SET IdUnidadDeMedidaProduccion = P.IdUnidadDeMedidaProduccion
     , FactorConversionProduccion = P.FactorConversionProduccion
     , CantidadUMProduccion = PC.Cantidad * P.FactorConversionProduccion
  FROM ProductosComponentes PC
 INNER JOIN Productos P ON P.IdProducto = PC.IdProductoComponente
 WHERE PC.IdUnidadDeMedidaProduccion IS NULL
GO

ALTER TABLE dbo.ProductosComponentes ALTER COLUMN IdUnidadDeMedidaProduccion varchar(10) NOT NULL
ALTER TABLE dbo.ProductosComponentes ALTER COLUMN CantidadUMProduccion decimal(16, 10) NOT NULL
ALTER TABLE dbo.ProductosComponentes ALTER COLUMN FactorConversionProduccion decimal(16, 10) NOT NULL
ALTER TABLE dbo.ProductosComponentes ALTER COLUMN Cantidad decimal(16, 10) NOT NULL
GO

IF dbo.ExisteFK('FK_ProductosComponentes_UnidadesDeMedidas') = 0
BEGIN
ALTER TABLE dbo.ProductosComponentes ADD CONSTRAINT FK_ProductosComponentes_UnidadesDeMedidas
    FOREIGN KEY (IdUnidadDeMedidaProduccion)
    REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteCampo('Productos', 'ComisionPorVenta ') = 0
BEGIN
    ALTER TABLE Productos ADD ComisionPorVenta decimal(5,2) null
    ALTER TABLE AuditoriaProductos ADD ComisionPorVenta decimal(5,2) null
END
GO

UPDATE Productos
   SET ComisionPorVenta = 0
 WHERE ComisionPorVenta IS NULL;
GO

ALTER TABLE Productos ALTER COLUMN ComisionPorVenta decimal(5,2) NOT NULL

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListasControlConfigAsig') = 0
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CalidadListasControlConfigAsig', 'Asignación de Items a Lista de Calidad', 'Asignación de Items a Lista de Calidad', 'True', 'False', 'True', 'True'
            ,'Calidad', 2160, 'Eniac.Win', 'CalidadListasControlConfigAsig', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListasControlConfigAsig' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListaControlItemGrupo') = 0
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CalidadListaControlItemGrupo', 'ABM Grupos de Items de Listas de Control', 'Grupos de Items de Listas de Control', 'True', 'False', 'True', 'True'
            ,'Calidad', 2250, 'Eniac.Win', 'CalidadListaControlItemGrupoABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListaControlItemGrupo' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListasControlItemsSubGp') = 0
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CalidadListasControlItemsSubGp', 'ABM SubGrupos de Items de Listas de Control', 'SubGrupos de Items de Listas de Control', 'True', 'False', 'True', 'True'
            ,'Calidad', 2260, 'Eniac.Win', 'CalidadListasControlItemsSubGruposABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListasControlItemsSubGp' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListasControlTiposABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('CalidadListasControlTiposABM', 'ABM de Tipos Listas de Control', 'ABM de Tipos Listas de Control', 'True', 'False', 'True', 'True'
        ,'Calidad', 2300, 'Eniac.Win', 'CalidadListasControlTiposABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListasControlTiposABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO