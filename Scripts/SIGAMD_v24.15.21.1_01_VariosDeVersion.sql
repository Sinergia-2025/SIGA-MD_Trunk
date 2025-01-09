PRINT ''
PRINT '1. Agrega campos OrdenesProduccionMRPOperaciones para talleres externos.'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'TipoOperacionExterna') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD TipoOperacionExterna varchar(50) NULL
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD IdOperacionExternaVinculada int NULL
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
		OrdenesProduccionMRPOperaciones AS PO
		INNER JOIN MRPCentrosProductores as CP
		  ON PO.CentroProductorOperacion = CP.IdCentroProductor
	WHERE 
		CP.ClaseCentroProductor = 'EXT' AND PO.TipoOperacionExterna IS NULL
END
GO

PRINT ''
PRINT '3. Crea Clave Foranea Recursiva.'
IF dbo.ExisteFK('FK_OrdenesOperacionesVinculadas') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPOperaciones 
		ADD CONSTRAINT FK_OrdenesOperacionesVinculadas
        FOREIGN KEY (IdSucursal, NumeroOrdenProduccion, IdTipocomprobante, LetraComprobante, CentroEmisor, Orden, IdProducto, 
					 IdProcesoProductivo, IdOperacionExternaVinculada)
        REFERENCES OrdenesProduccionMRPOperaciones(IdSucursal, NumeroOrdenProduccion, IdTipocomprobante, LetraComprobante, CentroEmisor, Orden, IdProducto, 
												   IdProcesoProductivo, IdOperacion)
END
GO

PRINT ''
PRINT '4. Inserta los Registro de Recepcion.'
BEGIN
	INSERT INTO [dbo].[OrdenesProduccionMRPOperaciones]
			   ([IdSucursal]
			   ,[NumeroOrdenProduccion]
			   ,[IdTipoComprobante]
			   ,[LetraComprobante]
			   ,[CentroEmisor]
			   ,[Orden]
			   ,[IdProducto]
			   ,[IdProcesoProductivo]
			   ,[IdOperacion]
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
			   ,[IdEstadoTarea]
			   ,[FechaComienzo]
			   ,[IdEmpleado]
			   ,[IdCodigoTarea]
			   ,[TipoOperacionExterna]
			   ,[IdOperacionExternaVinculada])
	SELECT 
				[IdSucursal]
			   ,[NumeroOrdenProduccion]
			   ,[IdTipoComprobante]
			   ,[LetraComprobante]
			   ,[CentroEmisor]
			   ,[Orden]
			   ,[IdProducto]
			   ,[IdProcesoProductivo]
			   ,(CodigoProcProdOperacion + 1)
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
			   ,[IdEstadoTarea]
			   ,[FechaComienzo]
			   ,[IdEmpleado]
			   ,[IdCodigoTarea]
				,'RECEPCION'
			   ,IdOperacion 
	  FROM [dbo].[OrdenesProduccionMRPOperaciones] AS OP2
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
	FROM OrdenesProduccionMRPOperaciones PO
		INNER JOIN (SELECT IdOperacion, IdOperacionExternaVinculada, idProcesoProductivo FROM OrdenesProduccionMRPOperaciones WHERE TipoOperacionExterna = 'RECEPCION') 
		AS PO2 ON PO.IdOperacion = PO2.IdOperacionExternaVinculada AND PO2.IdProcesoProductivo = PO.IdProcesoProductivo
	WHERE TipoOperacionExterna = 'ENVIO'
END
GO

PRINT ''
PRINT '6. Genera los Registro de Productos para la Recepcion.'
BEGIN
	INSERT INTO OrdenesProduccionMRPProductos
			   ([IdSucursal]
			   ,[NumeroOrdenProduccion]
			   ,[IdTipoComprobante]
			   ,[LetraComprobante]
			   ,[CentroEmisor]
			   ,[Orden]
			   ,[IdProducto]
			   ,[IdProcesoProductivo]
			   ,[IdOperacion]
			   ,[IdProductoProceso]
			   ,[EsProductoNecesario]
			   ,[CantidadSolicitada]
			   ,[PrecioCostoProducto]
			   ,[IdSucursalOrigen]
			   ,[IdDepositoOrigen]
			   ,[IDUbicacionOrigen]
			   ,[IdSucursalOp]
			   ,[IdTipocomprobanteOP]
			   ,[LetraComprobanteOP]
			   ,[CentroEmisorOP]
			   ,[NumeroOrdenProduccionOP]
			   ,[OrdenOP]
			   ,[EstadoCompra]
			   ,[IdRequerimiento]
			   ,[IdProductoRQ]
			   ,[OrdenRQ]
			   ,[IdProductoOP]
			   ,[CantidadProcesada]
			   ,[CantidadUnitaria])
		SELECT  PO.IdSucursal
			   ,PO.NumeroOrdenProduccion
			   ,PO.IdTipoComprobante
			   ,PO.LetraComprobante
			   ,PO.CentroEmisor
			   ,PO.Orden
			   ,PO.IdProducto
			   ,PO.IdProcesoProductivo
			   ,PO.IdOperacion
			   ,PPP.IdProductoProceso
			   ,PPP.EsProductoNecesario
			   ,PPP.CantidadSolicitada
			   ,PPP.PrecioCostoProducto
			   ,PPP.IdSucursalOrigen
			   ,PPP.IdDepositoOrigen
			   ,PPP.IDUbicacionOrigen
			   ,PPP.IdSucursalOp
			   ,PPP.IdTipocomprobanteOP
			   ,PPP.LetraComprobanteOP
			   ,PPP.CentroEmisorOP
			   ,PPP.NumeroOrdenProduccionOP
			   ,PPP.OrdenOP
			   ,PPP.EstadoCompra
			   ,PPP.IdRequerimiento
			   ,PPP.IdProductoRQ
			   ,PPP.OrdenRQ
			   ,PPP.IdProductoOP
			   ,PPP.CantidadProcesada
			   ,PPP.CantidadUnitaria
		FROM OrdenesProduccionMRPOperaciones PO 
			INNER JOIN OrdenesProduccionMRPProductos PPP 
			ON PPP.IdSucursal = PO.IdSucursal
			AND PPP.NumeroOrdenProduccion = PO.NumeroOrdenProduccion
			AND PPP.IdTipoComprobante = PO.IdTipoComprobante
			AND PPP.LetraComprobante = PO.LetraComprobante
			AND PPP.CentroEmisor = PO.CentroEmisor
			AND PPP.Orden = PO.Orden
			AND PPP.IdProducto = PO.IdProducto
			AND PPP.IdProcesoProductivo = PO.IdProcesoProductivo
			AND PPP.IdOperacion = PO.IdOperacionExternaVinculada 
		WHERE PO.TipoOperacionExterna = 'RECEPCION' 
			AND NOT EXISTS (SELECT * FROM OrdenesProduccionMRPProductos WHERE 
					IdOperacion = PO.IdOperacion 
				AND IdSucursal = PO.IdSucursal
				AND NumeroOrdenProduccion = PO.NumeroOrdenProduccion
				AND IdTipoComprobante = PO.IdTipoComprobante
				AND LetraComprobante = PO.LetraComprobante
				AND CentroEmisor = PO.CentroEmisor
				AND Orden = PO.Orden
				AND IdProducto = PO.IdProducto
				AND IdProcesoProductivo = PO.IdProcesoProductivo 
				AND EsProductoNecesario = PPP.EsProductoNecesario
				AND IdProductoProceso = PPP.IdProductoProceso)
END
GO

PRINT ''
PRINT '7. Genera los Registro de Categorias de Empleados para la Recepcion.'
BEGIN
	INSERT INTO [dbo].[OrdenesProduccionMRPCategoriasEmpleados]
			   ([IdSucursal]
			   ,[NumeroOrdenProduccion]
			   ,[IdTipoComprobante]
			   ,[LetraComprobante]
			   ,[CentroEmisor]
			   ,[Orden]
			   ,[IdProducto]
			   ,[IdProcesoProductivo]
			   ,[IdOperacion]
			   ,[IdCategoriaEmpleado]
			   ,[CantidadCategoria]
			   ,[ValorHoraCategoria])
	SELECT 
			   PO.IdSucursal
			  ,PO.NumeroOrdenProduccion
			  ,PO.IdTipoComprobante
			  ,PO.LetraComprobante
			  ,PO.CentroEmisor
			  ,PO.Orden
			  ,PO.IdProducto
			  ,PO.IdProcesoProductivo
			  ,PO.IdOperacion
			  ,PPC.IdCategoriaEmpleado
			  ,PPC.CantidadCategoria
			  ,PPC.ValorHoraCategoria
	FROM OrdenesProduccionMRPOperaciones PO 
		INNER JOIN OrdenesProduccionMRPCategoriasEmpleados PPC 
			ON	PPC.IdSucursal = PO.IdSucursal
			AND PPC.NumeroOrdenProduccion = PO.NumeroOrdenProduccion
			AND PPC.IdTipoComprobante = PO.IdTipoComprobante
			AND PPC.LetraComprobante = PO.LetraComprobante
			AND PPC.CentroEmisor = PO.CentroEmisor
			AND PPC.Orden = PO.Orden
			AND PPC.IdProducto = PO.IdProducto
			AND PPC.IdProcesoProductivo = PO.IdProcesoProductivo
			AND PPC.IdOperacion = PO.IdOperacionExternaVinculada 
	WHERE PO.TipoOperacionExterna = 'RECEPCION' 
			AND NOT EXISTS (SELECT * FROM OrdenesProduccionMRPCategoriasEmpleados WHERE 
					IdOperacion = PO.IdOperacion 
				AND IdSucursal = PO.IdSucursal
				AND NumeroOrdenProduccion = PO.NumeroOrdenProduccion
				AND IdTipoComprobante = PO.IdTipoComprobante
				AND LetraComprobante = PO.LetraComprobante
				AND CentroEmisor = PO.CentroEmisor
				AND Orden = PO.Orden
				AND IdProducto = PO.IdProducto
				AND IdProcesoProductivo = PO.IdProcesoProductivo 
				AND IdCategoriaEmpleado = PPC.IdCategoriaEmpleado)
END
GO

DELETE Bitacora WHERE IdFuncion = 'InfOrdenProduccionMRPProductos'
DELETE RolesFunciones WHERE IdFuncion = 'InfOrdenProduccionMRPProductos'
DELETE Funciones WHERE Id = 'InfOrdenProduccionMRPProductos'

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfOrdenProduccionMRPProductos', 'Inf. Detalle Operaciones de Orden Produccion', 'Inf. Detalle Operaciones de Orden Produccion', 'True', 'False', 'True', 'True'
        ,'MRP', 1400, 'Eniac.Win', 'InfOrdenesProduccionMRPProductos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfOrdenProduccionMRPProductos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nuevo Menu Procesos Productivos: MRP - Anulacion de Plan Maestro'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAnulacionPlanMaestro') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAnulacionPlanMaestro', 'Anulación de Plan Maestro.', 'Anulación de Plan Maestro.', 'True', 'False', 'True', 'True'
        ,'MRP', 480, 'Eniac.Win', 'MRPAnulacionPlanMaestro', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAnulacionPlanMaestro' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

DECLARE @idBuscador int
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

PRINT ''
PRINT 'B5. Nuevo Buscador: Procesos Productivos'
SET @idBuscador = 550

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'MRP Procesos Productivos' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoProcesoProductivo'         IdBuscadorNombreCampo,  1 Orden, 'Codigo'                Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'DescripcionProceso'              IdBuscadorNombreCampo,  2 Orden, 'Descripcion'           Titulo, @alineacion_izq Alineacion, 180 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdProductoProceso'               IdBuscadorNombreCampo,  3 Orden, 'Código Producto'       Titulo, @alineacion_izq Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreProducto'                  IdBuscadorNombreCampo,  4 Orden, 'Producto'              Titulo, @alineacion_izq Alineacion, 170 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila);

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfNovedadesProduccionMRP') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfNovedadesProduccionMRP', 'Inf. Declaraciones de Produccion', 'Inf. Declaraciones de Produccion', 'True', 'False', 'True', 'True'
        ,'MRP', 1500, 'Eniac.Win', 'InfNovedadesProduccionMRP', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfNovedadesProduccionMRP' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfNovProduccionMRPTiempos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfNovProduccionMRPTiempos', 'Inf. Tiempos de Declaraciones de Produccion', 'Inf. Tiempos de Declaraciones de Produccion', 'True', 'False', 'True', 'True'
        ,'MRP', 1520, 'Eniac.Win', 'InfNovedadesProduccionMRPTiempos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfNovProduccionMRPTiempos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfNovProduccionMRPProductos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfNovProduccionMRPProductos', 'Inf. Productos de Declaraciones de Produccion', 'Inf. Productos de Declaraciones de Produccion', 'True', 'False', 'True', 'True'
        ,'MRP', 1510, 'Eniac.Win', 'InfNovedadesProduccionMRPProductos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfNovProduccionMRPProductos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '1. Agrega Nueva Función con permisos para eliminar item.'
IF dbo.ExisteFuncion('FacturacionRapidaSupri') = 0
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FacturacionRapidaSupri', 'Facturacion Rapida – Eliminar', 'Facturacion Rapida – Eliminar', 'False', 'False', 'True', 'True'
        ,'FacturacionRapida', 15, 'Eniac.Win', 'FacturacionRapidaSupri', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FacturacionRapidaSupri' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END

PRINT ''
PRINT '2. Agrega Nueva Función con permisos para crear nuevo o salir.'
IF dbo.ExisteFuncion('FacturacionRapidaNuevoSalida') = 0
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FacturacionRapidaNuevoSalida', 'Facturacion Rapida – Nuevo y Salida', 'Facturacion Rapida – Nuevo y Salida', 'False', 'False', 'True', 'True'
        ,'FacturacionRapida', 20, 'Eniac.Win', 'FacturacionRapidaNuevoSalida', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FacturacionRapidaNuevoSalida' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END