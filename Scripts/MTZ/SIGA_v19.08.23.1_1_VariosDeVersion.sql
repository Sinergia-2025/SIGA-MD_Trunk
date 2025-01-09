PRINT ''
PRINT '1. Tabla Nueva CalidadPlantillas'
CREATE TABLE [dbo].[CalidadPlantillas](
	[IdPlantillaCalidad] [int] NOT NULL,
	[NombrePlantillaCalidad] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CalidadPlantillas] PRIMARY KEY CLUSTERED 
(
	[IdPlantillaCalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Tabla Nueva CalidadPlantillasListasControl'
CREATE TABLE [dbo].[CalidadPlantillasListasControl](
	[IdPlantillaCalidad] [int] NOT NULL,
	[IdListaControl] [int] NOT NULL,
 CONSTRAINT [PK_CalidadPlantillasListasControl] PRIMARY KEY CLUSTERED 
(
	[IdPlantillaCalidad] ASC,
	[IdListaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadPlantillasListasControl]  WITH CHECK ADD  CONSTRAINT [FK_CalidadPlantillasListasControl_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO
ALTER TABLE [dbo].[CalidadPlantillasListasControl] CHECK CONSTRAINT [FK_CalidadPlantillasListasControl_CalidadListasControl]
GO
ALTER TABLE [dbo].[CalidadPlantillasListasControl]  WITH CHECK ADD  CONSTRAINT [FK_CalidadPlantillasListasControl_CalidadPlantillas] FOREIGN KEY([IdPlantillaCalidad])
REFERENCES [dbo].[CalidadPlantillas] ([IdPlantillaCalidad])
GO
ALTER TABLE [dbo].[CalidadPlantillasListasControl] CHECK CONSTRAINT [FK_CalidadPlantillasListasControl_CalidadPlantillas]
GO

PRINT ''
PRINT '3. Tabla Nueva EmpleadosObjetivos'
CREATE TABLE [dbo].[EmpleadosObjetivos](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[PeriodoFiscal] [int] NOT NULL,
	[ImporteObjetivo] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_EmpleadosObjetivos_1] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[PeriodoFiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmpleadosObjetivos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosObjetivos_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO
ALTER TABLE [dbo].[EmpleadosObjetivos] CHECK CONSTRAINT [FK_EmpleadosObjetivos_Empleados]
GO

PRINT ''
PRINT '4. Menu Plantillas de Listas de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '4.1. Menu Plantillas de Listas de Control: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('PlantillasCalidadABM', 'Plantillas de Listas de Control', 'Plantillas de Listas de Control', 'True', 'False', 'True', 'True'
             ,'Calidad', 45, 'Eniac.Win', 'PlantillasCalidadABM', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '4.2. Menu Plantillas de Listas de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'PlantillasCalidadABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

END;

PRINT ''
PRINT '5. Tabla CalidadListasControlProductos: Nueva columna Aplica'
ALTER TABLE CalidadListasControlProductos ADD Aplica bit null
GO
PRINT ''
PRINT '5.1. Tabla CalidadListasControlProductos: Valor por defecto para Aplica'
UPDATE CalidadListasControlProductos SET Aplica = 'True'
GO
PRINT ''
PRINT '5.2. Tabla CalidadListasControlProductos: NOT NULL para Aplica'
ALTER TABLE CalidadListasControlProductos ALTER COLUMN Aplica bit not null
GO

PRINT ''
PRINT '6. Tabla Nueva AuditoriaCalidadListasControlProductos'
CREATE TABLE [dbo].[AuditoriaCalidadListasControlProductos](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdListaControl] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[IdUsuario] [varchar](10) NULL,
	[FecIngreso] [datetime] NULL,
	[FecEgreso] [datetime] NULL,
	[CincoS] [varchar](25) NULL,
	[CincoSComment] [varchar](8000) NULL,
	[CincoSC] [varchar](25) NULL,
	[CincoSCommentC] [varchar](8000) NULL,
	[CincoSUsr] [varchar](50) NULL,
	[CincoSFecha] [datetime] NULL,
	[CincoSUsrC] [varchar](50) NULL,
	[CincoSFechaC] [datetime] NULL,
	[Aplica] [bit] NOT NULL,
 CONSTRAINT [PK_AuditoriaCalidadListasControlProductos] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[IdProducto] ASC,
	[IdListaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '7. Menu Plantillas de Listas de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '7.1. Menu_ProductosListasControl-Gerencia.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ProductosListasControl-Gerenc', 'Listas de Control por Productos-Vista Gerencia', 'Listas de Control por Productos-Vista Gerencia', 
        'False', 'False', 'True', 'True', 'Calidad', 10, 'Eniac.Win', 'ProductosListasControl-Gerencia', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ProductosListasControl-Gerenc' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'Calidad'

    PRINT ''
    PRINT '7.2. Menu_ProductosListasControl-Calidad.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ProductosListasControl-Calidad', 'Listas de Control por Productos-Calidad', 'Listas de Control por Productos-Calidad', 
        'False', 'False', 'True', 'True', 'Calidad', 10, 'Eniac.Win', 'ProductosListasControl-Calidad', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ProductosListasControl-Calidad' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'Calidad'

END;
