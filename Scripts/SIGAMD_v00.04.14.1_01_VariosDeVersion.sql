PRINT ''
PRINT 'F0. Nuevo Menu Padre: MRP'
IF dbo.ExisteFuncion('MRP') = 0
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	VALUES
		('MRP', 'MRP', 'MRP', 'True', 'False', 'True', 'True'
		, NULL, 140, NULL, NULL, NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRP' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F1. Nuevo Menu Categoría de Empleados: MRP - ABM de Categoría Empleados'
IF dbo.ExisteFuncion('MRPCategoriasEmpleadosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPCategoriasEmpleadosABM', 'Categoría Empleados', 'Categoría Empleados', 'True', 'False', 'True', 'True'
        , 'Archivos', 13, 'Eniac.Win', 'MRPCategoriasEmpleadosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCategoriasEmpleadosABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F2. Nuevo Menu Centros Productores: MRP - ABM de Centros Productores'
IF dbo.ExisteFuncion('MRPCentrosProductoresABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPCentrosProductoresABM', 'ABM de Centros Productores', 'ABM de Centros Productores', 'True', 'False', 'True', 'True'
        , 'MRP', 2100, 'Eniac.Win', 'MRPCentrosProductoresABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCentrosProductoresABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F3. Nuevo Menu Mornas de Fabricación: MRP - ABM de Normas de Fabricación'
IF dbo.ExisteFuncion('MRPNormasFabricacionABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPNormasFabricacionABM', 'ABM de Normas de Fabricación', 'ABM de Normas de Fabricación', 'True', 'False', 'True', 'True'
        , 'MRP', 2200, 'Eniac.Win', 'MRPNormasFabricacionABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPNormasFabricacionABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F4. Nuevo Menu Secciones: MRP - ABM de Secciones'
IF dbo.ExisteFuncion('MRPSeccionesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPSeccionesABM', 'ABM de Secciones', 'ABM de Secciones', 'True', 'False', 'True', 'True'
        , 'MRP', 2300, 'Eniac.Win', 'MRPSeccionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPSeccionesABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F5. Nuevo Menu Tareas: MRP - ABM de Tareas'
IF dbo.ExisteFuncion('MRPTareasABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPTareasABM', 'ABM de Tareas', 'ABM de Tareas', 'True', 'False', 'True', 'True'
        , 'MRP', 2400, 'Eniac.Win', 'MRPTareasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPTareasABM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F6. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRPProcesosProductivosABM') = 0
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

PRINT ''
PRINT 'T1. Nueva Tabla: Categorias de Empleados.'
IF dbo.ExisteTabla('MRPCategoriasEmpleados') = 0
BEGIN
    CREATE TABLE MRPCategoriasEmpleados(
	    IdCategoriaEmpleado int NOT NULL,
	    CodigoCategoriaEmpleado varchar(30) NOT NULL,
	    Descripcion varchar(50) NOT NULL,
	    ValorHoraProduccion decimal(16, 2) NOT NULL,
		Activo bit NOT NULL,
     CONSTRAINT PK_MRPCategoriasEmpleados 
     PRIMARY KEY CLUSTERED (IdCategoriaEmpleado ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 CREATE UNIQUE INDEX IDX_CodigoCategoriaE ON MRPCategoriasEmpleados (CodigoCategoriaEmpleado);
	 CREATE INDEX IDX_ActivoCategoriaE ON MRPCategoriasEmpleados (Activo);


	INSERT INTO [dbo].[MRPCategoriasEmpleados]
				([IdCategoriaEmpleado]
				,[CodigoCategoriaEmpleado]
				,[Descripcion]
				,[ValorHoraProduccion]
				,[Activo])
			VALUES
				(1
				,'UN'
				,'CATEGORIA UNICA'
				,0.00
				,1)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T2. Nueva Tabla: Secciones.'
IF dbo.ExisteTabla('MRPSecciones') = 0
BEGIN
    CREATE TABLE MRPSecciones(
	    IdSeccion int NOT NULL,
	    CodigoSeccion varchar(30) NOT NULL,
	    Descripcion varchar(50) NOT NULL,
	    ClaseSeccion varchar(3) NOT NULL,
		Activo bit NOT NULL,
     CONSTRAINT PK_MRPSecciones 
     PRIMARY KEY CLUSTERED (IdSeccion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 CREATE UNIQUE INDEX IDX_CodigoSecciones ON MRPSecciones (CodigoSeccion);
	 CREATE INDEX IDX_ClasesSecciones ON MRPSecciones (ClaseSeccion);
	 CREATE INDEX IDX_ActivoSecciones ON MRPSecciones (Activo);
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T3. Nueva Tabla: Normas de Fabricacion.'
IF dbo.ExisteTabla('MRPNormasFabricacion') = 0
BEGIN
    CREATE TABLE MRPNormasFabricacion(
	    IdNormaFab int NOT NULL,
	    CodigoNormaFab varchar(30) NOT NULL,
	    Descripcion varchar(50) NOT NULL,
	    DetalleDispositivos varchar(MAX) NULL,
	    DetalleMetodos varchar(MAX) NULL,
	    DetalleSeguridad varchar(MAX) NULL,
	    DetalleControlCalidad varchar(MAX) NULL,
		Activo bit NOT NULL,
     CONSTRAINT PK_MRPNormasFabricacion 
     PRIMARY KEY CLUSTERED (IdNormaFab ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 CREATE UNIQUE INDEX IDX_CodigoNormaFab ON MRPNormasFabricacion (CodigoNormaFab);
	 CREATE INDEX IDX_ActivoNormaFab ON MRPNormasFabricacion (Activo);
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T4. Nueva Tabla: Tareas.'
IF dbo.ExisteTabla('MRPTareas') = 0
BEGIN
    CREATE TABLE MRPTareas(
	    IdTarea int NOT NULL,
	    CodigoTarea varchar(30) NOT NULL,
	    Descripcion varchar(50) NOT NULL,
		Activo bit NOT NULL,
     CONSTRAINT PK_MRPTareas
     PRIMARY KEY CLUSTERED (IdTarea ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 CREATE UNIQUE INDEX IDX_CodigoTarea ON MRPTareas (CodigoTarea);
	 CREATE INDEX IDX_ActivoTarea ON MRPTareas (Activo);
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T5. Nueva Tabla: Centros Productores.'
IF dbo.ExisteTabla('MRPCentrosProductores') = 0
BEGIN
    CREATE TABLE MRPCentrosProductores(
		IdCentroProductor		Integer NOT NULL,
		CodigoCentroProductor	VarChar (30) NOT NULL, 
		Descripcion				VarChar (50) NOT NULL,
		IdSeccion				Integer NULL,    
		ClaseCentroProductor	Varchar(3),
		Dotacion				Integer NOT NULL,
		HorasLunes				Decimal(6,2) NOT NULL,
		HorasMartes				Decimal (6,2) NOT NULL,
		HorasMiercoles			Decimal (6,2) NOT NULL,
		HorasJueves				Decimal (6,2) NOT NULL,
		HorasViernes			Decimal (6,2) NOT NULL,
		HorasSabado				Decimal (6,2) NOT NULL,
		HorasDomingo			Decimal (6,2) NOT NULL,
		PAPUnidad				Varchar(3),
		PAPTiemposMin			Decimal (6,2) NOT NULL,
		PAPTiemposMax			Decimal (6,2) NOT NULL,
		PAPHHombreMin			Decimal (6,2) NOT NULL,
		PAPHHombreMax			Decimal (6,2) NOT NULL, 
		ProdUnidad				Varchar(3),
		ProdCantUTiempoMin		Decimal (6,4) NOT NULL,
		ProdCantUTiempoMax		Decimal (6,4) NOT NULL,
		ProdTiemposMin			Decimal (6,4) NOT NULL,
		ProdTiemposMax			Decimal (6,4) NOT NULL,
		ProdHHombreMin			Decimal (6,4) NOT NULL,
		ProdHHombreMax			Decimal (6,4) NOT NULL,
		Activo					bit NOT NULL,

     CONSTRAINT PK_MRPCentrosProductores
     PRIMARY KEY CLUSTERED (IdCentroProductor ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 CREATE UNIQUE INDEX IDX_CodigoCentroProductor ON MRPCentrosProductores (CodigoCentroProductor);
	 CREATE INDEX IDX_ActivoCentroProductor ON MRPCentrosProductores (Activo);

	 ALTER TABLE MRPCentrosProductores ADD CONSTRAINT FK_CentrosProductores_Seccion FOREIGN KEY
		(IdSeccion) 
	 REFERENCES MRPSecciones
		(IdSeccion) 
	 ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'C1. Tabla Empleados: Nuevo campo Categoria de Empleado'
IF dbo.ExisteCampo('Empleados', 'IdCategoriaEmpleado') = 0
BEGIN
    ALTER TABLE Empleados ADD IdCategoriaEmpleado Integer NULL
    ALTER TABLE Empleados ADD CONSTRAINT FK_Empleados_Categoria FOREIGN KEY
			(IdCategoriaEmpleado) 
		REFERENCES MRPCategoriasEmpleados
			(IdCategoriaEmpleado) 
		ON UPDATE  NO ACTION 
	    ON DELETE  NO ACTION 
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'C1.1 Tabla Empleados: Update campo Categoria de Empleado'
BEGIN
    UPDATE Empleados SET IdCategoriaEmpleado = 1
	ALTER TABLE Empleados ALTER COLUMN IdCategoriaEmpleado Integer NOT NULL
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'C2. Tabla Empleados: Nuevo campo ValorHoraProduccion'
IF dbo.ExisteCampo('Empleados', 'ValorHoraProd') = 0
BEGIN
    ALTER TABLE Empleados ADD ValorHoraProd Decimal(16, 2) NULL
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'B1. Nuevo Buscador: Categoria Empleados'
DECLARE @idBuscador int = 500
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

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
        USING (SELECT @idBuscador IdBuscador, 'IdCategoriaEmpleado'     IdBuscadorNombreCampo,  1 Orden, 'Id'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'CodigoCategoriaEmpleado'	IdBuscadorNombreCampo,  2 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'				IdBuscadorNombreCampo,  3 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Activo'					IdBuscadorNombreCampo,  4 Orden, 'Activo'			Titulo, @alineacion_izq Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
SET @alineacion_der = 64
SET @alineacion_izq = 16

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
        USING (SELECT @idBuscador IdBuscador, 'IdTarea'					IdBuscadorNombreCampo,  1 Orden, 'Id'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'CodigoTarea'				IdBuscadorNombreCampo,  2 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'				IdBuscadorNombreCampo,  3 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Activo'					IdBuscadorNombreCampo,  4 Orden, 'Activo'			Titulo, @alineacion_izq Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
SET @alineacion_der = 64
SET @alineacion_izq = 16

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
        USING (SELECT @idBuscador IdBuscador, 'IdNormaFab'					IdBuscadorNombreCampo,  1 Orden, 'Id'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'CodigoNormaFab'				IdBuscadorNombreCampo,  2 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'				IdBuscadorNombreCampo,  3 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Activo'					IdBuscadorNombreCampo,  4 Orden, 'Activo'			Titulo, @alineacion_izq Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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
SET @alineacion_der = 64
SET @alineacion_izq = 16

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
        USING (SELECT @idBuscador IdBuscador, 'IdSeccion'					IdBuscadorNombreCampo,  1 Orden, 'Id'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'CodigoSeccion'				IdBuscadorNombreCampo,  2 Orden, 'Codigo'			Titulo, @alineacion_izq Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Descripcion'					IdBuscadorNombreCampo,  3 Orden, 'Descripcion'		Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Activo'						IdBuscadorNombreCampo,  4 Orden, 'Activo'			Titulo, @alineacion_izq Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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

