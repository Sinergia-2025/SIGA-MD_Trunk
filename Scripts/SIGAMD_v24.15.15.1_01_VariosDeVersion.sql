IF dbo.ExisteTabla('VentasProductosFormulasLotes') = 0
BEGIN
    CREATE TABLE [dbo].[VentasProductosFormulasLotes](
	    [IdSucursal] [int] NOT NULL,
	    [IdTipoComprobante] [varchar](15) NOT NULL,
	    [Letra] [varchar](1) NOT NULL,
	    [CentroEmisor] [int] NOT NULL,
	    [NumeroComprobante] [bigint] NOT NULL,
	    [IdProducto] [varchar](15) NOT NULL,
	    [Orden] [int] NOT NULL,
	    [IdProductoComponente] [varchar](15) NOT NULL,
	    [IdFormula] [int] NOT NULL,
	    [IdLote] [varchar](30) NOT NULL,
	    [FechaVencimiento] [datetime] NULL,
	    [Cantidad] [decimal](16, 4) NOT NULL,
	    [IdDeposito] [int] NULL,
	    [IdUbicacion] [int] NULL,
     CONSTRAINT [PK_VentasProductosFormulasLotes] PRIMARY KEY CLUSTERED (
	    [IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC,
	    [IdProducto] ASC, [Orden] ASC, [IdProductoComponente] ASC, [IdFormula] ASC,	[IdLote] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_VentasProductosFormulasLotes_Productos') = 0
BEGIN
    ALTER TABLE [dbo].[VentasProductosFormulasLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormulasLotes_Productos] 
                          FOREIGN KEY([IdProducto])
        REFERENCES [dbo].[Productos] ([IdProducto])
    ALTER TABLE [dbo].[VentasProductosFormulasLotes] CHECK CONSTRAINT [FK_VentasProductosFormulasLotes_Productos]
END
GO

IF dbo.ExisteFK('FK_VentasProductosFormulasLotes_ProductosLotes') = 0
BEGIN
    ALTER TABLE [dbo].[VentasProductosFormulasLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormulasLotes_ProductosLotes] 
                              FOREIGN KEY ([IdSucursal], [IdProductoComponente], [IdLote], [IdDeposito], [IdUbicacion])
        REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto],           [IdLote], [IdDeposito], [IdUbicacion])
    ALTER TABLE [dbo].[VentasProductosFormulasLotes] CHECK CONSTRAINT [FK_VentasProductosFormulasLotes_ProductosLotes]
END
GO

IF dbo.ExisteFK('FK_VentasProductosFormulasLotes_VentasProductosFormulas') = 0
BEGIN
    ALTER TABLE [dbo].[VentasProductosFormulasLotes]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormulasLotes_VentasProductosFormulas] 
                                       FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProducto], [Orden], [IdProductoComponente], [IdFormula])
        REFERENCES [dbo].[VentasProductosFormulas] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProducto], [Orden], [IdProductoComponente], [IdFormula])
    ALTER TABLE [dbo].[VentasProductosFormulasLotes] CHECK CONSTRAINT [FK_VentasProductosFormulasLotes_VentasProductosFormulas]
END
GO

IF dbo.ExisteTabla('VentasProductosFormulasNrosSerie') = 0
BEGIN
    CREATE TABLE [dbo].[VentasProductosFormulasNrosSerie](
	    [IdSucursal] [int] NOT NULL,
	    [IdTipoComprobante] [varchar](15) NOT NULL,
	    [Letra] [varchar](1) NOT NULL,
	    [CentroEmisor] [int] NOT NULL,
	    [NumeroComprobante] [bigint] NOT NULL,
	    [IdProducto] [varchar](15) NOT NULL,
	    [Orden] [int] NOT NULL,
	    [IdProductoComponente] [varchar](15) NOT NULL,
	    [IdFormula] [int] NOT NULL,
	    [NroSerie] [varchar](50) NOT NULL,
    CONSTRAINT [PK_VentasProductosFormulasNrosSerie] PRIMARY KEY CLUSTERED (
	    [IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, 
        [IdProducto] ASC, [Orden] ASC, [IdProductoComponente] ASC, [IdFormula] ASC,	[NroSerie] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_VentasProductosFormulasNrosSerie_VentasProductosFormulas') = 0
BEGIN
    ALTER TABLE [dbo].[VentasProductosFormulasNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductosFormulasNrosSerie_VentasProductosFormulas]
                                        FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProducto], [Orden], [IdProductoComponente], [IdFormula])
        REFERENCES [dbo].[VentasProductosFormulas] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProducto], [Orden], [IdProductoComponente], [IdFormula])

    ALTER TABLE [dbo].[VentasProductosFormulasNrosSerie] CHECK CONSTRAINT [FK_VentasProductosFormulasNrosSerie_VentasProductosFormulas]
END
GO

PRINT ''
PRINT '1. Agrega campos MRPProcesoProductivosOperaciones para talleres externos.'
IF dbo.ExisteCampo('MRPProcesosProductivosOperaciones', 'TipoOperacionExterna') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosOperaciones ADD TipoOperacionExterna varchar(50) NULL
    ALTER TABLE MRPProcesosProductivosOperaciones ADD IdOperacionExternaVinculada int NULL
END
GO

PRINT ''
PRINT '2. Marca Operaciones para talleres externos Envio.'
BEGIN
	UPDATE 
		PO
	SET
		PO.TipoOperacionExterna = 'ENVIO'
	FROM 
		MRPProcesosProductivosOperaciones AS PO
		INNER JOIN MRPCentrosProductores as CP
		  ON PO.CentroProductorOperacion = CP.IdCentroProductor
	WHERE 
		CP.ClaseCentroProductor = 'EXT' AND PO.TipoOperacionExterna IS NULL
END
GO

PRINT ''
PRINT '3. Crea Clave Foranea Recursiva.'
IF dbo.ExisteFK('FK_OperacionesVinculadas') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosOperaciones 
		ADD CONSTRAINT FK_OperacionesVinculadas
        FOREIGN KEY (IdOperacionExternaVinculada, IdProcesoProductivo)
        REFERENCES MRPProcesosProductivosOperaciones(IdOperacion, IdProcesoProductivo)
END
GO

PRINT ''
PRINT '4. Inserta los Registro de Recepcion.'
BEGIN
	INSERT INTO [dbo].[MRPProcesosProductivosOperaciones]
			   ([IdOperacion]
			   ,[IdProcesoProductivo]
			   ,[CodigoProcProdOperacion]
			   ,[DescripcionOperacion]
			   ,[SucursalOperacion]
			   ,[DepositoOperacion]
			   ,[UbicacionOperacion]
			   ,[CentroProductorOperacion]
			   ,[PAPTiemposMaquina]
			   ,[PAPTiemposHHombre]
			   ,[ProdTiemposMaquina]
			   ,[ProdTiemposHHombre]
			   ,[Proveedor]
			   ,[NormasDispositivos]
			   ,[NormasMetodos]
			   ,[NormasSeguridad]
			   ,[NormasControlCalidad]
			   ,[CostoExterno]
			   ,[UnidadesHora]
			   ,[IdCodigoTarea]
			   ,[TipoOperacionExterna]
			   ,[IdOperacionExternaVinculada])
	SELECT (CodigoProcProdOperacion + 1)
		  ,[IdProcesoProductivo]
		  ,FORMAT(CodigoProcProdOperacion + 1,'000')
		  ,[DescripcionOperacion]
		  ,[SucursalOperacion]
		  ,[DepositoOperacion]
		  ,[UbicacionOperacion]
		  ,[CentroProductorOperacion]
		  ,[PAPTiemposMaquina]
		  ,[PAPTiemposHHombre]
		  ,[ProdTiemposMaquina]
		  ,[ProdTiemposHHombre]
		  ,[Proveedor]
		  ,[NormasDispositivos]
		  ,[NormasMetodos]
		  ,[NormasSeguridad]
		  ,[NormasControlCalidad]
		  ,[CostoExterno]
		  ,[UnidadesHora]
		  ,[IdCodigoTarea]
		  ,'RECEPCION'
		  ,IdOperacion 
	  FROM [dbo].[MRPProcesosProductivosOperaciones] AS OP2
	WHERE TipoOperacionExterna = 'ENVIO' AND IdOperacionExternaVinculada IS NULL;
END
GO

PRINT ''
PRINT '5. Vincula los Registro de Recepcion con la Emision.'
BEGIN
	UPDATE 
		PO 
	SET 
		PO.IdOperacionExternaVinculada = PO2.IdOperacion
	FROM MRPProcesosProductivosOperaciones PO
		INNER JOIN (SELECT IdOperacion, IdOperacionExternaVinculada, idProcesoProductivo FROM MRPProcesosProductivosOperaciones WHERE TipoOperacionExterna = 'RECEPCION') 
		AS PO2 ON PO.IdOperacion = PO2.IdOperacionExternaVinculada AND PO2.IdProcesoProductivo = PO.IdProcesoProductivo
	WHERE TipoOperacionExterna = 'ENVIO'
END
GO

PRINT ''
PRINT '6. Genera los Registro de Productos para la Recepcion.'
BEGIN
	INSERT INTO [dbo].[MRPProcesosProductivosProductos]
			   ([IdOperacion]
			   ,[IdProcesoProductivo]
			   ,[IdProductoProceso]
			   ,[CantidadSolicitada]
			   ,[EsProductoNecesario]
			   ,[PrecioCostoProducto]
			   ,[IdSucursalOrigen]
			   ,[IdDepositoOrigen]
			   ,[IDUbicacionOrigen])
		SELECT PO.IdOperacion, 
			   PO.IdProcesoProductivo, 
			   PPP.IdProductoProceso, 
			   PPP.CantidadSolicitada, 
			   PPP.EsProductoNecesario,
			   PPP.PrecioCostoProducto,
			   PPP.IdSucursalOrigen,
			   PPP.IdDepositoOrigen,
			   PPP.IDUbicacionOrigen
		FROM MRPProcesosProductivosOperaciones PO 
			INNER JOIN MRPProcesosProductivosProductos PPP ON PPP.IdOperacion = PO.IdOperacionExternaVinculada AND PPP.IdProcesoProductivo = PO.IdProcesoProductivo
		WHERE PO.TipoOperacionExterna = 'RECEPCION' 
			AND NOT EXISTS (SELECT * FROM MRPProcesosProductivosProductos WHERE IdOperacion = PO.IdOperacion 
				AND IdProcesoProductivo = PO.IdProcesoProductivo and IdProductoProceso = PPP.IdProductoProceso)
END
GO

PRINT ''
PRINT '6. Genera los Registro de Categorias de empleados para la Recepcion.'
BEGIN
	INSERT INTO [dbo].[MRPProcesosProductivosCategoriasEmpleados]
			   ([IdOperacion]
			   ,[IdProcesoProductivo]
			   ,[IdCategoriaEmpleado]
			   ,[CantidadCategoria]
			   ,[ValorHoraCategoria])
	SELECT PO.IdOperacion, 
		   PO.IdProcesoProductivo, 
		   PPC.IdCategoriaEmpleado, 
		   PPC.CantidadCategoria, 
		   PPC.ValorHoraCategoria
	FROM MRPProcesosProductivosOperaciones PO 
		INNER JOIN MRPProcesosProductivosCategoriasEmpleados PPC 
			ON PPC.IdOperacion = PO.IdOperacionExternaVinculada 
		   AND PPC.IdProcesoProductivo = PO.IdProcesoProductivo
	WHERE PO.TipoOperacionExterna = 'RECEPCION' 
		AND NOT EXISTS (SELECT * FROM MRPProcesosProductivosCategoriasEmpleados WHERE IdOperacion = PO.IdOperacion 
					AND IdProcesoProductivo = PO.IdProcesoProductivo and IdCategoriaEmpleado = PPC.IdCategoriaEmpleado)
END
GO

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPOperacion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfOrdenProduccionMRPOperacion', 'Inf. Operaciones de Ordenes de Producción', 'Inf. Operaciones de Ordenes de Producción', 'True', 'False', 'True', 'True'
        ,'MRP', 1300, 'Eniac.Win', 'InfOrdenesProduccionMRPOperaciones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfOrdenProduccionMRPOperacion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
