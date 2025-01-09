PRINT ''
PRINT '1. Nueva Tabla ClientesActualizaciones'
/****** Object:  Table [dbo].[ClientesActualizaciones]    Script Date: 29/01/2020 21:59:08 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesActualizaciones](
	[IdCliente] [bigint] NOT NULL,
	[NombreServidor] [varchar](50) NOT NULL,
	[BaseDatos] [varchar](50) NOT NULL,
	[FechaEjecucion] [datetime] NOT NULL,
	[FechaInicioActualizacion] [datetime] NULL,
	[FechaFinActualizacion] [datetime] NULL,
	[IdUnico] [varchar](50) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[EstadoDescargaScripts] [varchar](10) NOT NULL,
	[EstadoDescargaInstalador] [varchar](10) NOT NULL,
	[EstadoBackup] [varchar](10) NOT NULL,
	[EstadoEjecucionScripts] [varchar](10) NOT NULL,
	[EstadoEjecucionInstalador] [varchar](10) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ClientesActualizaciones] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[NombreServidor] ASC,
	[BaseDatos] ASC,
	[FechaEjecucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ClientesActualizaciones]  WITH CHECK ADD  CONSTRAINT [FK_ClientesActualizaciones_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClientesActualizaciones] CHECK CONSTRAINT [FK_ClientesActualizaciones_Clientes]
GO


PRINT ''
PRINT '2. Nueva Tabla ClientesActualizacionesSucesos'
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesActualizacionesSucesos](
	[IdCliente] [bigint] NOT NULL,
	[NombreServidor] [varchar](50) NOT NULL,
	[BaseDatos] [varchar](50) NOT NULL,
	[FechaEjecucion] [datetime] NOT NULL,
	[TipoSuceso] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[TipoSucesoValue] [varchar](50) NOT NULL,
	[Datos] [text] NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ClientesActualizacionesSucesos] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[NombreServidor] ASC,
	[BaseDatos] ASC,
	[FechaEjecucion] ASC,
	[TipoSuceso] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ClientesActualizacionesSucesos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesActualizacionesSucesos_ClientesActualizaciones] FOREIGN KEY([IdCliente], [NombreServidor], [BaseDatos], [FechaEjecucion])
REFERENCES [dbo].[ClientesActualizaciones] ([IdCliente], [NombreServidor], [BaseDatos], [FechaEjecucion])
GO
ALTER TABLE [dbo].[ClientesActualizacionesSucesos] CHECK CONSTRAINT [FK_ClientesActualizacionesSucesos_ClientesActualizaciones]
GO


PRINT ''
PRINT '3. Nueva Tabla TiposVehiculos'
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposVehiculos](
	[IdTipoVehiculo] [int] NOT NULL,
	[NombreTipoVehiculo] [varchar](100) NULL,
 CONSTRAINT [PK_TiposVehiculos] PRIMARY KEY CLUSTERED 
(
	[IdTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


PRINT ''
PRINT '4. ADD FOREIGN KEY PRODUCTOS: Campo IdFormula referenciado a ProductosFormula'

IF OBJECT_ID('FK_Productos_ProductosFormulas') IS NULL 
BEGIN
    PRINT ''
    PRINT '4.1. Ajustar información pre-existente'
    UPDATE P
       SET IdFormula = NULL
      FROM Productos P
     WHERE P.IdFormula IS NOT NULL
       AND NOT EXISTS (SELECT * FROM ProductosFormulas PF WHERE PF.IdProducto = P.IdProducto AND PF.IdFormula = P.IdFormula)

    PRINT ''
    PRINT '4.2. ADD FOREIGN KEY PRODUCTOS: Agregando'
	ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_ProductosFormulas] FOREIGN KEY([IdProducto], [IdFormula])
	REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
	ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_ProductosFormulas]
END



PRINT ''
PRINT '5. Menu: Agrega pantalla TiposVehiculosABM'
IF dbo.ExisteFuncion('ArchivosTipos') = 'True'
    BEGIN
		INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
			VALUES
				('TiposVehiculosABM', 'Tipos de Vehículos', 'Tipos de Vehículos', 'True', 'False', 'True', 'True'
				,'ArchivosTipos', 199, 'Eniac.Win', 'TiposVehiculosABM', NULL, NULL
				,'True', 'S', 'N', 'N', 'N');

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'TiposVehiculosABM' AS Pantalla FROM dbo.Roles
		 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
	END

