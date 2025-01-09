PRINT ''
PRINT '1.1. Actualizacion Parametro: URL Actualizador'
BEGIN
    UPDATE Parametros
       SET ValorParametro = 'http://sinergiamovil.com.ar/actualizador/WSActualizador.svc'
     WHERE IdParametro = 'URLACTUALIZADOR'
END
GO

PRINT ''
PRINT '1.2. Actualizacion Parametro: Path Destino MSI'
BEGIN
    UPDATE Parametros
       SET ValorParametro = 'D:\Eniac\Instaladores\'
     WHERE IdParametro = 'UBICACIONMSI'
END
GO

PRINT ''
PRINT '2. Tabla CRMNovedades: Nuevo indice IX_CRMNovedades_Padre'
IF dbo.SoyHAR() = 0     --Porque ya se corrió en HAR
BEGIN
    CREATE NONCLUSTERED INDEX [IX_CRMNovedades_Padre]
    ON [dbo].[CRMNovedades] ([IdTipoNovedadPadre],[IdNovedadPadre],[LetraPadre],[CentroEmisorPadre])
END
GO

PRINT ''
PRINT '3. Nueva Tabla DashBoardTableros.'
BEGIN
    -- CREAR TABLA TABLEROS--
    CREATE TABLE [dbo].[DashBoardsTableros](
	    [IdTableros] [int] NOT NULL,
	    [Descripcion] [varchar](30) NOT NULL,
	    [Estados] [bit] NOT NULL,
     CONSTRAINT [PK_DashBoardsTableros] PRIMARY KEY CLUSTERED 
    (
	    [IdTableros] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

END
GO
--*******************************************************************************
PRINT ''
PRINT '4. Nueva Tabla DashBoardsPaneles.'
BEGIN
    CREATE TABLE [dbo].[DashBoardsTablerosPaneles](
	    [IdDashBoardTablero] [int] NOT NULL,
	    [IdDashBoardPaneles] [int] NOT NULL,
	    [Orden] [int] NOT NULL,
	    [Estado] [bit] NOT NULL,
     CONSTRAINT [PK_DashTablerosPaneles] PRIMARY KEY CLUSTERED 
    (
	    IdDashBoardTablero, IdDashBoardPaneles
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    ALTER TABLE [dbo].[DashBoardsTablerosPaneles]  WITH CHECK ADD  CONSTRAINT [FK_DashBoards_Tableros] FOREIGN KEY([IdDashBoardTablero])
    REFERENCES [dbo].[DashBoardsTableros] ([IdTableros])
    ALTER TABLE [dbo].[DashBoardsTablerosPaneles] CHECK CONSTRAINT [FK_DashBoards_Tableros]

    ALTER TABLE [dbo].[DashBoardsTablerosPaneles]  WITH CHECK ADD  CONSTRAINT [FK_DashBoards_Paneles] FOREIGN KEY([IdDashBoardPaneles])
    REFERENCES [dbo].[DashBoardsPaneles] ([IdDashBoard])
    ALTER TABLE [dbo].[DashBoardsTablerosPaneles] CHECK CONSTRAINT [FK_DashBoards_Paneles]
END
GO


PRINT ''
PRINT '1. Nuevo tabla: Marcas de Vehiculos'
BEGIN
	CREATE TABLE [dbo].[MarcasVehiculos](
		[IdMarcaVehiculo] [int] NOT NULL,
		[NombreMarcaVehiculo] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_IdMarcasVehiculos] PRIMARY KEY CLUSTERED 
	(
		[IdMarcaVehiculo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO


PRINT ''
PRINT '2. Nueva tabla: Modelo de Vehiculos'
BEGIN
    CREATE TABLE [dbo].[ModelosVehiculos](
	    [IdModeloVehiculo] [int] NOT NULL,
	    [NombreModeloVehiculo] [varchar](50) NOT NULL,
	    [IdMarcaVehiculo] [int] NOT NULL,
     CONSTRAINT [PK_ModelosVehiculos] PRIMARY KEY CLUSTERED 
    (
	    [IdModeloVehiculo] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    ALTER TABLE [dbo].[ModelosVehiculos]  WITH CHECK ADD  CONSTRAINT [FK_ModelosVehiculos_MarcasVehiculos] FOREIGN KEY([IdMarcaVehiculo])
    REFERENCES [dbo].[MarcasVehiculos] ([IdMarcaVehiculo])

    ALTER TABLE [dbo].[ModelosVehiculos] CHECK CONSTRAINT [FK_ModelosVehiculos_MarcasVehiculos]
END
GO


PRINT ''
PRINT '3. Nuevo Tabla: Vehiculos'
BEGIN
    CREATE TABLE [dbo].[Vehiculos](
	    [PatenteVehiculo] [varchar](8) NOT NULL,
	    [IdMarcaVehiculo] [int] NOT NULL,
	    [IdModeloVehiculo] [int] NOT NULL,
	    [Color] [varchar](20) NOT NULL,
	    [VencimientoSeguro] [date] NULL,
	    [Ruta] [date] NULL,
	    [Vtv] [date] NULL,
	    [Activo] [bit] NOT NULL,
        [IdCliente] [bigint] NULL,
	    [EstaAdentro] [bit] NOT NULL,

     CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
    (
	    [PatenteVehiculo] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Clientes] FOREIGN KEY([IdCliente])
    REFERENCES [dbo].[Clientes] ([IdCliente])
    ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Clientes]

    ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_MarcasVehiculos] FOREIGN KEY([IdMarcaVehiculo])
    REFERENCES [dbo].[MarcasVehiculos] ([IdMarcaVehiculo])
    ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_MarcasVehiculos]

    ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_ModelosVehiculos] FOREIGN KEY([IdModeloVehiculo])
    REFERENCES [dbo].[ModelosVehiculos] ([IdModeloVehiculo])
    ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_ModelosVehiculos]

END
GO

IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('30715016717') = 'True'

    PRINT ''
    PRINT '4. Nuevo Menu: Marcas de Vehiculos'
    BEGIN
        PRINT ''
        PRINT '4.1. Nueva Función: Marcas de Vehiculos'
        INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
        ('MarcasVehiculos', 'Marcas de Vehiculos', 'Marcas de Vehiculos', 'True', 'False', 'True', 'True'
        ,'Archivos', 35, 'Eniac.Win', 'MarcasVehiculosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

        PRINT ''
        PRINT '4.2. Roles para función: MarcasVehiculos'
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'MarcasVehiculos' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    GO

    PRINT ''
    PRINT '5. Nuevo Menu: Modelos Vehiculos'
    BEGIN
        PRINT ''
        PRINT '5.1. Nueva Función: Modelos Vehiculos'
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('ModelosVehiculos', 'Modelos Vehiculos', 'Modelos Vehiculos', 'True', 'False', 'True', 'True'
            ,'Archivos', 36, 'Eniac.Win', 'ModelosVehiculosABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

        PRINT ''
        PRINT '5.2. Roles para función: ModelosVehiculos'
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
            SELECT DISTINCT Id AS Rol, 'ModelosVehiculos' AS Pantalla FROM dbo.Roles
	            WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    GO

    PRINT ''
    PRINT '6. Nuevo Menu: Vehiculos'
    BEGIN
        PRINT ''
        PRINT '6.1. Nueva Función: Vehiculos'
            INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
            VALUES
                ('ABMVehiculos', 'Vehiculos', 'Vehiculos', 'True', 'False', 'True', 'True'
                ,'Archivos', 37, 'Eniac.Win', 'VehiculosABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N', 'True')

        PRINT ''
        PRINT '6.2. Roles para función: Vehiculos'
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
            SELECT DISTINCT Id AS Rol, 'ABMVehiculos' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

    END
    GO
