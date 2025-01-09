------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPProcesosProductivosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPProcesosProductivosABM', 'Procesos Productivos', 'Procesos Productivos', 'True', 'False', 'True', 'True'
        , 'MRP', 100, 'Eniac.Win', 'MRPProcesosProductivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPProcesosProductivosABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T1. Nueva Tabla: ProcesosProductivos.'
IF dbo.ExisteTabla('MRPProcesosProductivos') = 0
BEGIN
    CREATE TABLE MRPProcesosProductivos(
	    IdProcesoProductivo				bigint			NOT NULL,
		IdProductoProceso				varchar(15)		NOT NULL,	
	    CodigoProcesoProductivo			varchar(30)		NOT NULL,
	    DescripcionProceso				varchar(50)		NOT NULL,
	    CostoManoObraInterna			decimal(16, 4)	NOT NULL,
	    CostoManoObraExterna			decimal(16, 4)	NOT NULL,
	    CostoMateriaPrima				decimal(16, 4)	NOT NULL,
	    CostoTotalProceso	 			decimal(16, 4)	NOT NULL,
		FechaAltaProceso				Datetime		NOT NULL,
		FechaModificaProceso			Datetime		NOT NULL,
		FechaActualizaCostos			Datetime		NOT NULL,
		TiempoTotalProceso				Decimal(16,8)	NOT NULL,
		IdArchivoAdjunto				int				NOT NULL,
		RespetaOrden					bit				NOT NULL,
		Activo							bit				NOT NULL,
     CONSTRAINT PK_MRPProcesosProductivos 
     PRIMARY KEY CLUSTERED (IdProcesoProductivo ASC, IdProductoProceso ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 ALTER TABLE MRPProcesosProductivos  WITH CHECK ADD FOREIGN KEY(IdProductoProceso) REFERENCES Productos (IdProducto)
	 ALTER TABLE MRPProcesosProductivos  WITH CHECK ADD FOREIGN KEY(IdProductoProceso, IdArchivoAdjunto)   REFERENCES ProductosLinks (IdProducto, ItemLink)

	 CREATE UNIQUE INDEX IDX_CodigoProcesoProductivo ON MRPProcesosProductivos (CodigoProcesoProductivo);
	 CREATE INDEX IDX_ActivoProcesoProductivo ON MRPProcesosProductivos (Activo);

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T2. Nueva Tabla: ProcesosProductivosOperaciones.'
IF dbo.ExisteTabla('MRPProcesosProductivosOperaciones') = 0
BEGIN
    CREATE TABLE MRPProcesosProductivosOperaciones(
		IdOperacion						int				NOT NULL,
	    IdProcesoProductivo				bigint			NOT NULL,
	    CodigoProcProdOperacion			varchar(30)		NOT NULL, 
	    DescripcionOperacion			varchar(50)		NOT NULL,
		SucursalOperacion				int				NOT NULL,
		DepositoOperacion				int				NOT NULL,
		UbicacionOperacion				int				NOT NULL,
		CentroProductorOperacion		int				NOT NULL,
		PAPTiemposMaquina				decimal(16,8)	NOT NULL,
		PAPTiemposHHombre				decimal(16,8)	NOT NULL,
		ProdTiemposMaquina				decimal(16,8)	NOT NULL,
		ProdTiemposHHombre				decimal(16,8)	NOT NULL,
		Proveedor						bigint			NULL,
		NormasDispositivos				varchar(MAX)	NULL,
	    NormasMetodos					varchar(MAX)	NULL,
	    NormasSeguridad					varchar(MAX)	NULL,
	    NormasControlCalidad			varchar(MAX)	NULL,
     CONSTRAINT PK_MRPProcesosProductivosOperaciones 
     PRIMARY KEY CLUSTERED (IdOperacion ASC, IdProcesoProductivo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 ALTER TABLE MRPProcesosProductivosOperaciones  WITH CHECK ADD FOREIGN KEY(SucursalOperacion) REFERENCES Sucursales	(IdSucursal)
	 ALTER TABLE MRPProcesosProductivosOperaciones  WITH CHECK ADD FOREIGN KEY(DepositoOperacion, SucursalOperacion)  REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)
	 ALTER TABLE MRPProcesosProductivosOperaciones  WITH CHECK ADD FOREIGN KEY(DepositoOperacion, SucursalOperacion, UbicacionOperacion) REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)

	 ALTER TABLE MRPProcesosProductivosOperaciones  WITH CHECK ADD FOREIGN KEY(CentroProductorOperacion)  REFERENCES MRPCentrosProductores (IdCentroProductor)
	 ALTER TABLE MRPProcesosProductivosOperaciones  WITH CHECK ADD FOREIGN KEY(Proveedor)				  REFERENCES Proveedores (IdProveedor)

	 CREATE UNIQUE INDEX IDX_CodigoProcProdOperacion	ON MRPProcesosProductivosOperaciones (CodigoProcProdOperacion);

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T3. Nueva Tabla: ProcesosProductivosProductos.'
IF dbo.ExisteTabla('MRPProcesosProductivosProductos') = 0
BEGIN
    CREATE TABLE MRPProcesosProductivosProductos(
		IdOperacion						int				NOT NULL,
	    IdProcesoProductivo				bigint			NOT NULL,
		IdProductoProceso				varchar(15)		NOT NULL,	
	    CantidadSolicitada				decimal(16,2)	NOT NULL, 
		TipoUtilizacionProducto			varchar(3)		NULL,
		IdProductoSustituye				varchar(15)		NULL,
		EsProductoNecesario				bit				NOT NULL,
     CONSTRAINT PK_MRPProcesosProductivosProductos 
     PRIMARY KEY CLUSTERED (IdOperacion ASC, IdProcesoProductivo ASC, IdProductoProceso ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]


	 CREATE UNIQUE INDEX IDX_TipoUtilizacion	ON MRPProcesosProductivosProductos (TipoUtilizacionProducto);
	 CREATE INDEX IDX_TipoProcProdProducto		ON MRPProcesosProductivosProductos (EsProductoNecesario);

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T4. Nueva Tabla: ProcesosProductivosCategoriasEmpleados.'
IF dbo.ExisteTabla('MRPProcesosProductivosCategoriasEmpleados') = 0
BEGIN
    CREATE TABLE MRPProcesosProductivosCategoriasEmpleados(
		IdOperacion						int				NOT NULL,
	    IdProcesoProductivo				bigint			NOT NULL,
		IdCategoriaEmpleado				int				NOT NULL,	
	    CantidadCategoria				decimal(16,2)	NOT NULL, 
     CONSTRAINT PK_MRPProcesosProductivosCategoriasEmpleados
     PRIMARY KEY CLUSTERED (IdOperacion ASC, IdProcesoProductivo ASC, IdCategoriaEmpleado ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T5. Tabla ProductosLinks: Nuevos campos'
IF dbo.ExisteCampo('ProductosLinks', 'IdTipoAdjunto') = 0
BEGIN
    ALTER TABLE ProductosLinks ADD IdTipoAdjunto Integer NULL

	ALTER TABLE ProductosLinks ADD CONSTRAINT FK_IdTipoAdjunto FOREIGN KEY
		(IdTipoAdjunto) 
	 REFERENCES TiposAdjuntos
		(IdTipoAdjunto) 
	 ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T6. Tabla ProductosLinks: Nuevos campos'
BEGIN

	DECLARE @CodTipAdj as Integer = (SELECT MAX(IdTipoAdjunto) FROM TiposAdjuntos) + 1 
	INSERT INTO [dbo].[TiposAdjuntos]
           ([IdTipoAdjunto]
           ,[NombreTipoAdjunto])
     VALUES
           (@CodTipAdj, 'GENERAL')
	UPDATE ProductosLinks SET IdTipoAdjunto = @CodTipAdj
    ALTER TABLE ProductosLinks ALTER COLUMN IdTipoAdjunto Integer NOT NULL

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T7. Tabla Empleados: Nuevos campos'
IF dbo.ExisteCampo('MRPCentrosProductores', 'PAPUnidad') = 1
BEGIN
    ALTER TABLE MRPCentrosProductores DROP COLUMN PAPUnidad				
    ALTER TABLE MRPCentrosProductores DROP COLUMN PAPTiemposMin			
    ALTER TABLE MRPCentrosProductores DROP COLUMN PAPTiemposMax			
    ALTER TABLE MRPCentrosProductores DROP COLUMN PAPHHombreMin			
    ALTER TABLE MRPCentrosProductores DROP COLUMN PAPHHombreMax			
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdUnidad				
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdCantUTiempoMin		
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdCantUTiempoMax		
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdTiemposMin			
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdTiemposMax			
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdHHombreMin			
    ALTER TABLE MRPCentrosProductores DROP COLUMN ProdHHombreMax			
END
GO
---------------------------------------------------
PRINT ''
PRINT 'T8. Tabla Empleados: Nuevos campos'
IF dbo.ExisteCampo('MRPCentrosProductores', 'TiempoPAP') = 0
BEGIN
    ALTER TABLE MRPCentrosProductores ADD TiempoPAP					Decimal (16,8) NULL
    ALTER TABLE MRPCentrosProductores ADD TiempoProductivo			Decimal (16,8) NULL
    ALTER TABLE MRPCentrosProductores ADD TiempoNoProductivo		Decimal (16,8) NULL
    ALTER TABLE MRPCentrosProductores ADD HorasHombrePAP			Decimal (16,8) NULL
    ALTER TABLE MRPCentrosProductores ADD HorasHombreProductivo		Decimal (16,8) NULL
    ALTER TABLE MRPCentrosProductores ADD HorasHombreNoProductivo	Decimal (16,8) NULL
END
GO

PRINT ''
PRINT 'T9. Tabla Empleados: Nuevos campos'
IF dbo.ExisteCampo('MRPCentrosProductores', 'IdProveedorDefecto') = 0
BEGIN
    ALTER TABLE MRPCentrosProductores ADD IdProveedorDefecto bigint NULL
END
GO

PRINT ''
PRINT 'T10. Tabla Empleados: Nuevos campos'
IF dbo.ExisteFK('FK_MRPIdProveedor') = 0
BEGIN
	ALTER TABLE MRPCentrosProductores ADD CONSTRAINT FK_MRPIdProveedor FOREIGN KEY
		(IdProveedorDefecto) 
	 REFERENCES Proveedores
		(IdProveedor) 
	 ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T11. Tabla Empleados: Update-Redefine campos'
BEGIN
	UPDATE MRPCentrosProductores 
		SET 
			TiempoPAP					= 0,
			TiempoProductivo			= 0,
			TiempoNoProductivo			= 0,
			HorasHombrePAP				= 0,
			HorasHombreProductivo		= 0,
			HorasHombreNoProductivo		= 0

    ALTER TABLE MRPCentrosProductores ALTER COLUMN TiempoPAP				Decimal (16,8) NOT NULL
    ALTER TABLE MRPCentrosProductores ALTER COLUMN TiempoProductivo			Decimal (16,8) NOT NULL
    ALTER TABLE MRPCentrosProductores ALTER COLUMN TiempoNoProductivo		Decimal (16,8) NOT NULL
    ALTER TABLE MRPCentrosProductores ALTER COLUMN HorasHombrePAP			Decimal (16,8) NOT NULL
    ALTER TABLE MRPCentrosProductores ALTER COLUMN HorasHombreProductivo	Decimal (16,8) NOT NULL
    ALTER TABLE MRPCentrosProductores ALTER COLUMN HorasHombreNoProductivo	Decimal (16,8) NOT NULL
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T12. Tabla Productos: Nuevos campos'
IF dbo.ExisteCampo('Productos', 'IdProcesoProductivoDefecto') = 0
BEGIN
    ALTER TABLE Productos ADD IdProcesoProductivoDefecto		Integer		  NULL
    ALTER TABLE Productos ADD ControlaRealizar					Varchar(MAX)  NULL
    ALTER TABLE Productos ADD InformeControlCalidad				bit			  NULL
    ALTER TABLE Productos ADD ValorAQL							Decimal (6,2) NULL

    ALTER TABLE AuditoriaProductos ADD IdProcesoProductivoDefecto		Integer		  NULL
    ALTER TABLE AuditoriaProductos ADD ControlaRealizar					Varchar(MAX)  NULL
    ALTER TABLE AuditoriaProductos ADD InformeControlCalidad			bit			  NULL
    ALTER TABLE AuditoriaProductos ADD ValorAQL							Decimal (6,2) NULL

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T13. Tabla Productos: Nuevos campos'
BEGIN
	UPDATE Productos
		SET 
			InformeControlCalidad			= 0,
			ValorAQL						= 0

    ALTER TABLE Productos ALTER COLUMN InformeControlCalidad	bit			NOT NULL
    ALTER TABLE Productos ALTER COLUMN ValorAQL					Decimal (6,2)	NOT NULL

	UPDATE AuditoriaProductos
		SET 
			InformeControlCalidad			= 0,
			ValorAQL						= 0

	ALTER TABLE AuditoriaProductos ALTER COLUMN InformeControlCalidad	bit				NOT NULL
    ALTER TABLE AuditoriaProductos ALTER COLUMN ValorAQL				Decimal (6,2)	NOT NULL

END
GO
------------------------------------------------------------------------------------------------------------------------
DECLARE @idBuscador int
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B1. Nuevo Buscador: Categoria Empleados'
SET @idBuscador = 500

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Categorias Empleados' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoCategoriaEmpleado'     IdBuscadorNombreCampo,  1 Orden, 'Codigo'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'					IdBuscadorNombreCampo,  2 Orden, 'Descripcion'			Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B2. Nuevo Buscador: Tareas'
SET @idBuscador = 510

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'MRP Tareas' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoTarea'				IdBuscadorNombreCampo,  1 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'				IdBuscadorNombreCampo,  2 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B3. Nuevo Buscador: Normas'
SET @idBuscador = 520

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'MRP Normas Fabricacion' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoNormaFab'				IdBuscadorNombreCampo,  1 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'					IdBuscadorNombreCampo,  2 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B4. Nuevo Buscador: Secciones'
SET @idBuscador = 530

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'MRP Secciones' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoSeccion'				IdBuscadorNombreCampo,  1 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'					IdBuscadorNombreCampo,  2 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B5. Nuevo Buscador: Centros Productores'
SET @idBuscador = 540

DELETE FROM BuscadoresCampos WHERE  IdBuscador = @idBuscador
DELETE FROM Buscadores       WHERE  IdBuscador = @idBuscador

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'MRP Centros Productores' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'CodigoCentroProductor'			IdBuscadorNombreCampo,  1 Orden, 'Codigo'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'						IdBuscadorNombreCampo,  2 Orden, 'Descripcion'			Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'ClaseCentroProductor'			IdBuscadorNombreCampo,  3 Orden, 'Clase'				Titulo, @alineacion_izq Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Nuevo Tipo de Comprobante: Orden Compra a Proveedor'
DECLARE @tipo VARCHAR(MAX) = 'ORDENCOMPRAPROV'
IF NOT EXISTS (SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'ORDENCOMPRAPROV')
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

    /*16*/  SolicitaFechaDevolucion, AFIPWSRequiereReferenciaTransferencia, ActivaTildeMercDespacha, Color, CodigoRoela, ClaseComprobante) 
           VALUES 
    /*01*/ ('ORDENCOMPRAPROV', 'False', 'Orden Compra a Proveedor', @tipo, 0, 
    /*02*/  'False', 'True', 'X', 100, 'True', 
    /*03*/  1, NULL, 'True', 'False', 'True', 
    /*04*/  'False', 'O,C.Prov.', 'True', 1, 'False', 
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
    /*15*/  'True', 'False', 'False', 'Orden Compra a Proveedor', 'False', 

    /*16*/  'False', 'False', 'False', NULL, '', '')
END

PRINT ''
PRINT '2. Menu: Orden Compra'
IF dbo.ExisteFuncion('OrdenCompraProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraProv', 'Orden Compra Prov.', 'Orden Compra Proveedor', 'True', 'False', 'True', 'True'
        ,NULL, 25, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('OrdenCompraProv') = 1 AND dbo.ExisteFuncion('OrdenCompraProveedor') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraProveedor', 'Orden de Compra a Proveedor', 'Orden de Compra a Proveedor', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 10, 'Eniac.Win', 'PedidosProveedores', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('ConsultarOrdenCompraProv', 'Consultar Orden de Compra Proveedores', 'Consultar Orden de Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 20, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('AnularOrdenCompraProv', 'Anular Orden de Compra Proveedores', 'Anular Orden de Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 30, 'Eniac.Win', 'AnularPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('OrdenCompraAdminProv', 'Administracion de Orden de Compra Prov', 'Administracion de Orden de Compra Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 40, 'Eniac.Win', 'PedidosAdminProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('EstadoOrdenCompraProvABM', 'ABM Estados de Orden Compra Proveedores', 'ABM Estados de Orden Compra Proveedores', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 50, 'Eniac.Win', 'EstadosPedidosProvABM', NULL, 'PRESUPPROV\,' + @tipo
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfOrdenCompraDetalladosProv', 'Inf. de Orden de Compra Detallado Prov', 'Inf. de Orden de Compra Detallado Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 60, 'Eniac.Win', 'InfPedidosDetalladosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfOCSumaPorProductosProv', 'Inf. de Orden de Compra Suma por Productos Prov', 'Inf. de Orden de Compra Suma por Productos Prov', 'True', 'False', 'True', 'True'
        ,'OrdenCompraProv', 70, 'Eniac.Win', 'InfPedidosSumaPorProductosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('ConsultarOrdenCompraProv') = 1 AND dbo.ExisteFuncion('ConsultarOCProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConsultarOCProv-VerPre', 'Ver Precios en Consultar Orden Compra', 'Ver Precios en Consultar Orden Compra', 'False', 'False', 'True', 'True'
        ,'ConsultarOrdenCompraProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('InfOrdenCompraDetalladosProv') = 1 AND dbo.ExisteFuncion('InfOCDetalladosProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfOCDetalladosProv-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True'
        ,'InfOrdenCompraDetalladosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('OrdenCompraAdminProv') = 1 AND dbo.ExisteFuncion('OrdenCompraAdminProv-Modif') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenCompraAdminProv-Modif', 'Modif. OrdenCompra', 'Modif. OrdenCompra', 'False', 'False', 'True', 'True'
        ,'OrdenCompraAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('OrdenCompraAdminProv-VerPre', 'Ver Precios en Admin OrdenCompra', 'Ver Precios en Admin OrdenCompra', 'False', 'False', 'True', 'True'
        ,'OrdenCompraAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END

UPDATE Funciones
   SET Parametros = @tipo
 WHERE IdPadre = 'OrdenCompraProv'
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
IF NOT EXISTS(SELECT * FROM EstadosPedidosProveedores WHERE TipoEstadoPedido = @tipo)
BEGIN
	INSERT INTO EstadosPedidosProveedores
			   (IdEstado, IdTipoComprobante, IdTipoEstado, Orden, TipoEstadoPedido
			   ,Color, TipoEstadoPedidoCliente, IdEstadoPedidoCliente, IdTipoMovimiento, StockAfectado
			   ,IdEstadoDestino)

		SELECT IdEstado, IdTipoComprobante, IdTipoEstado, Orden, @tipo TipoEstadoPedido
			  ,Color, TipoEstadoPedidoCliente, IdEstadoPedidoCliente, IdTipoMovimiento, StockAfectado
			  ,IdEstadoDestino
		  FROM EstadosPedidosProveedores
		 WHERE TipoEstadoPedido = 'PEDIDOSPROV'
END
GO

PRINT ''
PRINT '4. Traducciones: Presupuestos Proveedores'
MERGE INTO Traducciones AS D
        USING   (SELECT 'OrdenCompraProveedor' IdFuncion, '' Pantalla, 'Me' Control, 'es_AR' IdIdioma, 'Orden de Compra Proveedor' Texto
       UNION ALL SELECT 'ConsultarOrdenCompraProv',       '',                          'Me', 'es_AR', 'Consultar Orden de Compra Proveedor'
       UNION ALL SELECT 'AnularOrdenCompraProv',          '',                          'Me', 'es_AR', 'Anular Orden de Compra Proveedores'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '',                          'Me', 'es_AR', 'Administración de Orden de Compra Proveedor'
       UNION ALL SELECT 'OrdenCompraAdminProv',           'PedidosClientesV2',         'Me', 'es_AR', 'Orden Compra Proveedores'
       UNION ALL SELECT 'EstadoOrdenCompraProvABM',       'EstadosPedidosProvABM',     'Me', 'es_AR', 'Estados Orden de Compra Proveedor'
       UNION ALL SELECT 'EstadoOrdenCompraProvABM',       'EstadosPedidosProvDetalle', 'Me', 'es_AR', 'Estados Orden de Compra Proveedor'
       UNION ALL SELECT 'InfOrdenCompraDetalladosProv',   '',                          'Me', 'es_AR', 'Informe de Orden de Compras Proveedor Detallados'
       UNION ALL SELECT 'InfOCSumaPorProductosProv',   '',                          'Me', 'es_AR', 'Inf. de Orden de Compra Proveedor Suma por Productos Prov'
       UNION ALL SELECT 'AnularOrdenCompraProv',          '',                          '__AnulacionPedidoExitosa', 'es_AR', '¡¡¡ Orden/s de Compra/s Proveedor Anulado/s Exitosamente !!!'
       UNION ALL SELECT 'AnularOrdenCompraProv',          '',                          '__NoSeleccionoPedido',     'es_AR', 'ATENCION: NO Seleccionó Ningún Orden de Compra Proveedor para Anular!!'
       UNION ALL SELECT 'InfOrdenCompraDetalladosProv',   '', 'FechaPedido',                      'es_AR', 'Fecha O. Compra'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__CambioEstadoMasivo',             'es_AR', '¿Desea cambiar masivamente el Estado actual de las Ordenes de Compra Seleccionados al Estado: {0}?'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__ConfirmarCambioEstado',          'es_AR', '¿Desea cambiar el Estado actual de la Orden de Compra - {0} - al Estado: {1}?'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__ErrorCambioMasivoNoPermitido',   'es_AR', 'Orden de Compra: {0}-->El Estado a cambiar debe ser distinto al Estado Actual de la Orden de Compra o cambiar Criticidad/Fecha de Entrega.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__ErrorDebeCambiarEstado',         'es_AR', 'El Estado a cambiar debe ser distinto al Estado Actual de la Orden de Compra.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__ErrorEstadoNoPermiteCambio',     'es_AR', 'Orden de Compra: {0} --> El Estado Actual NO permite cambio.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__NoSeleccionoPedido',             'es_AR', 'Debe seleccionar una Orden de Compra para cambiar el Estado.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', '__NoSeleccionoPedidoModificar',    'es_AR', 'Por favor seleccione una Orden de Compra.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', 'FechaPedido',                      'es_AR', 'Fecha O.C.'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', 'NumeroPedido',                     'es_AR', 'O. Compra'
       UNION ALL SELECT 'OrdenCompraAdminProv',           '', 'tsbModificarPedido',               'es_AR', 'Modificar Orden de Compra'
       UNION ALL SELECT 'OrdenCompraAdminProv', 'PedidosClientesV2', '__ConfirmarNuevoComprobante',       'es_AR', 'ATENCION: ¿Desea Realizar una Orden de Compra Nuevo?'
       UNION ALL SELECT 'OrdenCompraAdminProv', 'PedidosClientesV2', '__ErrorFechaEntregaInvalida',       'es_AR', 'La Fecha de Entrega del producto (Código {0} es menor a la Fecha de la Orden de Compra ({1:dd/MM/yyyy}.'
       UNION ALL SELECT 'OrdenCompraAdminProv', 'PedidosClientesV2', '__ErrorFechaEntregaPedidoInvalida', 'es_AR', 'La Fecha de Entrega es menor a la Fecha de la Orden de Compra ({0:dd/MM/yyyy}.'
       UNION ALL SELECT 'OrdenCompraAdminProv', 'PedidosClientesV2', '__PedidoNoSuministrado',            'es_AR', 'Debe pasar una Orden de Compra a modificar.'
       UNION ALL SELECT 'OrdenCompraProveedor', 'PedidosProveedores', '__ConfirmarNuevoComprobante',       'es_AR', 'ATENCION: ¿Desea Realizar una Orden de Compra Nuevo?'
       UNION ALL SELECT 'OrdenCompraProveedor', 'PedidosProveedores', '__ErrorFechaEntregaInvalida',       'es_AR', 'La Fecha de Entrega del producto (Código {0} es menor a la Fecha de la Orden de Compra ({1:dd/MM/yyyy}.'
       UNION ALL SELECT 'OrdenCompraProveedor', 'PedidosProveedores', '__ErrorFechaEntregaPedidoInvalida', 'es_AR', 'La Fecha de Entrega es menor a la Fecha de la Orden de Compra ({0:dd/MM/yyyy}.'
       UNION ALL SELECT 'OrdenCompraProveedor', 'PedidosProveedores', '__PedidoNoSuministrado',            'es_AR', 'Debe pasar una Orden de Compra a modificar.')
     AS O ON O.IdFuncion = D.IdFuncion
         AND O.Pantalla  = D.Pantalla
         AND O.Control   = D.Control
         AND O.IdIdioma = D.IdIdioma
    WHEN NOT MATCHED THEN 
        INSERT (IdFuncion, Pantalla, Control, IdIdioma, Texto) VALUES (O.IdFuncion, O.Pantalla, O.Control, O.IdIdioma, O.Texto)
;
--------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @idParametro VARCHAR(MAX) = 'REQCOMPRAPERMITEFECHAENTREGADISTINTAS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Permite Fecha de Entrega Distintas en Productos'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

GO
--         1         2         3         4         5         6         7         8         9        10        11        12
--123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('AnularRequerimientosCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AnularRequerimientosCompras', 'Anular Requerimiento de Compra', 'Anular Requerimiento de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 210, 'Eniac.Win', 'AnularRequerimientosCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AnularRequerimientosCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

--         1         2         3         4         5         6         7         8         9        10        11        12
--123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('InfRequerimientosCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfRequerimientosCompras', 'Inf. Requerimiento de Compra', 'Inf. Requerimiento de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 510, 'Eniac.Win', 'InfRequerimientosCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfRequerimientosCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
--         1         2         3         4         5         6         7         8         9        10        11        12
--123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
PRINT ''
PRINT '1. Nuevo Tipo de Comprobante: Orden Compra a Proveedor'
DECLARE @tipo VARCHAR(MAX) = 'REQCOMPRAS'
IF NOT EXISTS (SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'REQUERIMIENTO')
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

    /*16*/  SolicitaFechaDevolucion, AFIPWSRequiereReferenciaTransferencia, ActivaTildeMercDespacha, Color, CodigoRoela, ClaseComprobante) 
           VALUES 
    /*01*/ ('REQUERIMIENTO', 'False', 'Requerimiento de Compra', @tipo, 0, 
    /*02*/  'False', 'True', 'X', 100, 'True', 
    /*03*/  1, NULL, 'True', 'False', 'True', 
    /*04*/  'False', 'Req.Comp.', 'True', 1, 'False', 
    /*05*/  '', 'False', 99, NULL, 9999999.99, 

    /*06*/  '.', 'False', 0.01, 'False', 'True', 
    /*07*/  'True', 'False', 'False', 'False', 2, 
    /*08*/  'False', 'False', 'REQCOMPRAS', 'False', 'False', 
    /*09*/  'False', 'False', 'False', NULL, NULL, 
    /*10*/  NULL, NULL, 'False', 'False', '', 

    /*11*/  'False', 'True', NULL, 'True', 'True', 
    /*12*/  'True', 'False', 8, 1, 'False', 
    /*13*/  'True', 'True', 'False', NULL, 'False', 
    /*14*/  'False', 'False', 'False', 'False', 10, 
    /*15*/  'True', 'False', 'False', 'Requerimiento de Compra', 'False', 

    /*16*/  'False', 'False', 'False', NULL, '', '')
END
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Menu: Orden Compra'
IF dbo.ExisteFuncion('RequerimientosCompras') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
	VALUES
		('RequerimientosCompras', 'Requerimientos', 'Requerimientos', 'True', 'False', 'True', 'True'
		,NULL, 23, 'Eniac.Win', NULL, NULL, NULL
		,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('RequerimientosComprasABM') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
	VALUES
		('RequerimientosComprasABM', 'Requerimiento de Compra', 'Requerimiento de Compra', 'True', 'False', 'True', 'True'
		,'RequerimientosCompras', 10, 'Eniac.Win', 'RequerimientosComprasABM', NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
END
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT R.Id IdRol, F.Id IdFuncion
	FROM Funciones F
	CROSS JOIN (SELECT * FROM Roles WHERE Id IN ('Adm', 'Supervisor', 'Oficina')) R
	WHERE (F.Id = 'RequerimientosCompras' OR F.IdPadre = 'RequerimientosCompras')
	AND NOT EXISTS (SELECT * FROM RolesFunciones RF WHERE RF.IdRol = R.Id AND RF.IdFuncion = F.Id)
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('RequerimientosCompras') = 0
BEGIN
    CREATE TABLE RequerimientosCompras(
	    IdRequerimientoCompra bigint NOT NULL,
	    IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroRequerimiento bigint NOT NULL,
	    Fecha datetime NOT NULL,
	    FechaAlta datetime NOT NULL,
	    IdUsuarioAlta varchar(10) NOT NULL,
	    Observacion varchar(100) NOT NULL,
     CONSTRAINT PK_RequerimientosCompras PRIMARY KEY CLUSTERED (IdRequerimientoCompra ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_RequerimientosCompras_Sucursales') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosCompras  WITH CHECK ADD  CONSTRAINT FK_RequerimientosCompras_Sucursales FOREIGN KEY(IdSucursal)
    REFERENCES dbo.Sucursales (IdSucursal)
    ALTER TABLE dbo.RequerimientosCompras CHECK CONSTRAINT FK_RequerimientosCompras_Sucursales
END
GO

IF dbo.ExisteFK('FK_RequerimientosCompras_TiposComprobantes') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosCompras  WITH CHECK ADD  CONSTRAINT FK_RequerimientosCompras_TiposComprobantes FOREIGN KEY(IdTipoComprobante)
    REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ALTER TABLE dbo.RequerimientosCompras CHECK CONSTRAINT FK_RequerimientosCompras_TiposComprobantes
END
GO

IF dbo.ExisteFK('FK_RequerimientosCompras_Usuarios') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosCompras  WITH CHECK ADD  CONSTRAINT FK_RequerimientosCompras_Usuarios FOREIGN KEY(IdUsuarioAlta)
    REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.RequerimientosCompras CHECK CONSTRAINT FK_RequerimientosCompras_Usuarios
END
GO

IF dbo.ExisteIX('AK_RequerimientosCompras') = 0
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX AK_RequerimientosCompras ON RequerimientosCompras
        (IdSucursal ASC, IdTipoComprobante ASC, Letra ASC, CentroEmisor ASC, NumeroRequerimiento ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('RequerimientosComprasProductos') = 0
BEGIN
    CREATE TABLE RequerimientosComprasProductos(
	    IdRequerimientoCompra bigint NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Orden int NOT NULL,
        NombreProducto varchar(60) NOT NULL,
	    Cantidad decimal(16, 4) NOT NULL,
	    FechaEntrega datetime NOT NULL,
	    Observacion varchar(100) NOT NULL,
	    FechaAnulacion datetime NULL,
	    IdUsuarioAnulacion varchar(10) NULL,
     CONSTRAINT PK_RequerimientosComprasProductos PRIMARY KEY CLUSTERED (IdRequerimientoCompra ASC, IdProducto ASC, Orden ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductos_Productos') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductos_Productos FOREIGN KEY(IdProducto)
    REFERENCES dbo.Productos (IdProducto)
    ALTER TABLE dbo.RequerimientosComprasProductos CHECK CONSTRAINT FK_RequerimientosComprasProductos_Productos
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductos_RequerimientosCompras') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductos_RequerimientosCompras FOREIGN KEY(IdRequerimientoCompra)
    REFERENCES dbo.RequerimientosCompras (IdRequerimientoCompra)
    ALTER TABLE dbo.RequerimientosComprasProductos CHECK CONSTRAINT FK_RequerimientosComprasProductos_RequerimientosCompras
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductos_Usuarios') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductos_Usuarios FOREIGN KEY(IdUsuarioAnulacion)
    REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.RequerimientosComprasProductos CHECK CONSTRAINT FK_RequerimientosComprasProductos_Usuarios
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('RequerimientosComprasProductosAsignaciones') = 0
BEGIN
    CREATE TABLE RequerimientosComprasProductosAsignaciones(
	    IdRequerimientoCompra bigint NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Orden int NOT NULL,
	    IdSucursalPedido int NOT NULL,
	    IdTipoComprobantePedido varchar(15) NOT NULL,
	    LetraPedido varchar(1) NOT NULL,
	    CentroEmisorPedido int NOT NULL,
	    NumeroPedido bigint NOT NULL,
	    Cantidad decimal(16, 4) NOT NULL,
	    FechaAsignacion datetime NOT NULL,
	    IdUsuarioAsignacion varchar(10) NOT NULL,
     CONSTRAINT PK_RequerimientosComprasProductosAsignaciones PRIMARY KEY CLUSTERED (IdRequerimientoCompra ASC, IdProducto ASC, Orden ASC,
                            IdSucursalPedido ASC, IdTipoComprobantePedido ASC, LetraPedido ASC, CentroEmisorPedido ASC, NumeroPedido ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductosAsignaciones_PedidosProveedores') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_PedidosProveedores FOREIGN KEY(IdSucursalPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido, NumeroPedido)
    REFERENCES dbo.PedidosProveedores (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido)
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones CHECK CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_PedidosProveedores
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductosAsignaciones_RequerimientosComprasProductos') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_RequerimientosComprasProductos FOREIGN KEY(IdRequerimientoCompra, IdProducto, Orden)
    REFERENCES dbo.RequerimientosComprasProductos (IdRequerimientoCompra, IdProducto, Orden)
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones CHECK CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_RequerimientosComprasProductos
END
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductosAsignaciones_Usuarios') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones  WITH CHECK ADD  CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_Usuarios FOREIGN KEY(IdUsuarioAsignacion)
    REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.RequerimientosComprasProductosAsignaciones CHECK CONSTRAINT FK_RequerimientosComprasProductosAsignaciones_Usuarios
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE PedidosProductos DROP CONSTRAINT [FK_PedidosProductos_UnidadesDeMedidas]
GO

ALTER TABLE VentasProductos DROP CONSTRAINT [FK_VentasProductos_UnidadesDeMedidas]
GO

ALTER TABLE Productos DROP CONSTRAINT [FK_Productos_UnidadesDeMedidas2]
GO

ALTER TABLE UnidadesDeMedidas DROP CONSTRAINT PK_UnidadesDeMedidas
GO

ALTER TABLE UnidadesDeMedidas ALTER COLUMN IdUnidadDeMedida varchar(10) not null
GO

ALTER TABLE PedidosProductos ALTER COLUMN IdUnidadDeMedida varchar(10) not null
GO

ALTER TABLE VentasProductos ALTER COLUMN IdUnidadDeMedida varchar(10) not null
GO

ALTER TABLE Productos ALTER COLUMN IdUnidadDeMedida varchar(10) not null
GO

ALTER TABLE Productos ALTER COLUMN IdUnidadDeMedida2 varchar(10) null
GO

ALTER TABLE AuditoriaProductos ALTER COLUMN IdUnidadDeMedida varchar(10) null
GO

ALTER TABLE AuditoriaProductos ALTER COLUMN IdUnidadDeMedida2 varchar(10) null
GO


ALTER TABLE UnidadesDeMedidas ADD  CONSTRAINT [PK_UnidadesDeMedidas] PRIMARY KEY CLUSTERED 
(
	[IdUnidadDeMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]


ALTER TABLE [dbo].[PedidosProductos]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProductos_UnidadesDeMedidas] FOREIGN KEY([IdUnidadDeMedida])
REFERENCES [dbo].[UnidadesDeMedidas] ([IdUnidadDeMedida])
GO

ALTER TABLE [dbo].[PedidosProductos] CHECK CONSTRAINT [FK_PedidosProductos_UnidadesDeMedidas]
GO

ALTER TABLE [dbo].[VentasProductos]  WITH CHECK ADD  CONSTRAINT [FK_VentasProductos_UnidadesDeMedidas] FOREIGN KEY([IdUnidadDeMedida])
REFERENCES [dbo].[UnidadesDeMedidas] ([IdUnidadDeMedida])
GO

ALTER TABLE [dbo].[VentasProductos] CHECK CONSTRAINT [FK_VentasProductos_UnidadesDeMedidas]
GO


ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_UnidadesDeMedidas2] FOREIGN KEY([IdUnidadDeMedida2])
REFERENCES [dbo].[UnidadesDeMedidas] ([IdUnidadDeMedida])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_UnidadesDeMedidas2]
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'I1. Nuevo Indice: IDX_CodigoProcProdOperacion.'
IF EXISTS (SELECT * FROM sys.indexes WHERE name='IDX_CodigoProcProdOperacion' AND object_id = OBJECT_ID('MRPProcesosProductivosOperaciones'))
BEGIN
	DROP INDEX IDX_CodigoProcProdOperacion  ON MRPProcesosProductivosOperaciones 
	CREATE INDEX IDX_CodigoProcProdOperacion	ON MRPProcesosProductivosOperaciones (CodigoProcProdOperacion);
END
GO

PRINT ''
PRINT 'C1. Cambia Campo: IdProveedorDefecto.'
IF dbo.ExisteCampo('MRPCentrosProductores', 'IdProveedorDefecto') = 1 AND dbo.ExisteCampo('MRPCentrosProductores', 'IdProveedor') = 0
BEGIN
	EXEC sp_rename 'MRPCentrosProductores.IdProveedorDefecto', 'IdProveedor', 'COLUMN';
END
GO

PRINT ''
PRINT 'C2. Cambia Campo: IdProcesoProductivoDefecto.'
BEGIN
    ALTER TABLE Productos ALTER COLUMN IdProcesoProductivoDefecto				bigint		  NULL
    ALTER TABLE AuditoriaProductos ALTER COLUMN IdProcesoProductivoDefecto		bigint		  NULL
END
GO

PRINT ''
PRINT 'C2. Cambia Campo: IdArchivoAdjunto.'
BEGIN
    ALTER TABLE MRPProcesosProductivos ALTER COLUMN IdArchivoAdjunto			int			  NULL
END
GO


PRINT ''
PRINT '3. Tabla Tareas: Nuevo campo'
IF dbo.ExisteCampo('MRPTareas', 'IdCentroProductor') = 0
BEGIN
    ALTER TABLE MRPTareas ADD IdCentroProductor		Integer		  NULL
	ALTER TABLE MRPTareas ADD CONSTRAINT FK_MRPTareasCentroProductor FOREIGN KEY
		(IdCentroProductor) 
	 REFERENCES MRPCentrosProductores
		(IdCentroProductor)
END
GO