IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposNaves')

BEGIN
	CREATE TABLE [dbo].[TiposNaves](
		[IdTipoNave] [smallint] NOT NULL,
		[NombreTipoNave] [varchar](50) NOT NULL,
		[Seco] [bit] NOT NULL,
	 CONSTRAINT [PK_TiposNaves] PRIMARY KEY CLUSTERED 
	(
		[IdTipoNave] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[TiposNaves] ADD  CONSTRAINT [DF_TiposNaves_Seco]  DEFAULT ((1)) FOR [Seco]
END
GO

PRINT ' 1 Tabla: TiposNaves  ---------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Naves')

BEGIN
	CREATE TABLE [dbo].[Naves](
		[IdNave] [smallint] NOT NULL,
		[NombreNave] [varchar](30) NOT NULL,
		[NombrePC] [varchar](20) NOT NULL,
		[EnMantenimiento] [bit] NOT NULL,
		[LimiteDeKilos] [int] NOT NULL,
		[IdTipoNave] [smallint] NOT NULL,
	 CONSTRAINT [PK_Naves] PRIMARY KEY CLUSTERED 
	(
		[IdNave] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Naves]  WITH CHECK ADD  CONSTRAINT [FK_Naves_TipoNave] FOREIGN KEY([IdTipoNave])
	REFERENCES [dbo].[TiposNaves] ([IdTipoNave])

	ALTER TABLE [dbo].[Naves] CHECK CONSTRAINT [FK_Naves_TipoNave]
END 
GO

PRINT ' 2 Tabla: Naves  -----------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AreasComunes')

BEGIN
	CREATE TABLE [dbo].[AreasComunes](
		[IdAreaComun] [varchar](10) NOT NULL,
		[NombreAreaComun] [varchar](50) NOT NULL,
		[ParticipaExpensas] [bit] NOT NULL,
		[IdNave] [smallint] NULL,
		[IdCliente] [bigint] NULL,
		[Superficie] [int] NOT NULL,
		[Coeficiente] [numeric](15, 10) NOT NULL,
	 CONSTRAINT [PK_AreasComunes] PRIMARY KEY CLUSTERED 
	(
		[IdAreaComun] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[AreasComunes] ADD  CONSTRAINT [DF_AreasComunes_Superficie]  DEFAULT ((0)) FOR [Superficie]

	ALTER TABLE [dbo].[AreasComunes] ADD  CONSTRAINT [DF_AreasComunes_Coeficiente]  DEFAULT ((0)) FOR [Coeficiente]

	ALTER TABLE [dbo].[AreasComunes]  WITH CHECK ADD  CONSTRAINT [FK_AreasComunes_Clientes] FOREIGN KEY([IdCliente])
	REFERENCES [dbo].[Clientes] ([IdCliente])

	ALTER TABLE [dbo].[AreasComunes] CHECK CONSTRAINT [FK_AreasComunes_Clientes]

	ALTER TABLE [dbo].[AreasComunes]  WITH CHECK ADD  CONSTRAINT [FK_AreasComunes_Naves] FOREIGN KEY([IdNave])
	REFERENCES [dbo].[Naves] ([IdNave])

	ALTER TABLE [dbo].[AreasComunes] CHECK CONSTRAINT [FK_AreasComunes_Naves]
END 
GO

PRINT ' 3 Tabla: AreasComunes  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sectores')

BEGIN
	CREATE TABLE [dbo].[Sectores](
		[IdSector] [smallint] NOT NULL,
		[NombreSector] [varchar](50) NOT NULL,
		[Observaciones] [nvarchar](200) NOT NULL,
		[IdAreaComun] [varchar](10) NULL,
	 CONSTRAINT [PK_Sectores] PRIMARY KEY CLUSTERED 
	(
		[IdSector] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Sectores]  WITH CHECK ADD  CONSTRAINT [FK_Sectores_AreasComunes] FOREIGN KEY([IdAreaComun])
	REFERENCES [dbo].[AreasComunes] ([IdAreaComun])

	ALTER TABLE [dbo].[Sectores] CHECK CONSTRAINT [FK_Sectores_AreasComunes]

END 
GO

PRINT ' 4 Tabla: Sectores  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Casilleros')

BEGIN
	CREATE TABLE [dbo].[Casilleros](
		[IdCasillero] [int] NOT NULL,
		[CodigoCasillero] [int] NOT NULL,
		[IdSector] [smallint] NOT NULL,
		[FilaCasillero] [smallint] NOT NULL,
		[ColumnaCasillero] [smallint] NOT NULL,
		[IdCliente] [bigint] NULL,
		[Activo] [bit] NOT NULL,
	 CONSTRAINT [PK_Casilleros] PRIMARY KEY CLUSTERED 
	(
		[IdCasillero] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Casilleros] ADD  CONSTRAINT [DF_Casilleros_Activo]  DEFAULT ((1)) FOR [Activo]

	ALTER TABLE [dbo].[Casilleros]  WITH CHECK ADD  CONSTRAINT [FK_Casilleros_Clientes] FOREIGN KEY([IdCliente])
	REFERENCES [dbo].[Clientes] ([IdCliente])

	ALTER TABLE [dbo].[Casilleros] CHECK CONSTRAINT [FK_Casilleros_Clientes]

	ALTER TABLE [dbo].[Casilleros]  WITH CHECK ADD  CONSTRAINT [FK_Casilleros_Sectores] FOREIGN KEY([IdSector])
	REFERENCES [dbo].[Sectores] ([IdSector])

	ALTER TABLE [dbo].[Casilleros] CHECK CONSTRAINT [FK_Casilleros_Sectores]

END 
GO

PRINT ' 5 Tabla: Casilleros  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposEmbarcaciones')

BEGIN	
	CREATE TABLE [dbo].[TiposEmbarcaciones](
		[IdTipoEmbarcacion] [int] NOT NULL,
		[NombreTipoEmbarcacion] [varchar](30) NOT NULL,
	 CONSTRAINT [PK_TiposEmbarcaciones] PRIMARY KEY CLUSTERED 
	(
		[IdTipoEmbarcacion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END 
GO

PRINT ' 6 Tabla: TiposEmbarcaciones  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CategoriasCamas')

BEGIN
	CREATE TABLE [dbo].[CategoriasCamas](
		[IdCategoriaCama] [int] NOT NULL,
		[NombreCategoriaCama] [varchar](30) NOT NULL,
		[CantidadAccionesRequeridas] [int] NOT NULL,
		[Alto] [decimal](6, 2) NOT NULL,
		[Ancho] [decimal](6, 2) NOT NULL,
		[Largo] [decimal](6, 2) NOT NULL,
		[TasaMunicipal] [decimal](10, 2) NOT NULL,
		[ImporteExpensas] [decimal](10, 2) NOT NULL,
		[ImporteAlquiler] [decimal](10, 2) NOT NULL,
		[PorcDescAlquiler] [decimal](7, 4) NOT NULL,
		[ImporteGastosAdmin] [decimal](10, 2) NOT NULL,
		[ImporteGastosIntermAlq] [decimal](10, 2) NOT NULL,
	 CONSTRAINT [PK_CategoriasCamas] PRIMARY KEY CLUSTERED 
	(
		[IdCategoriaCama] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[CategoriasCamas] ADD  CONSTRAINT [DF_CategoriasCamas_TasaMunicipal]  DEFAULT ((0)) FOR [TasaMunicipal]
END 
GO

PRINT ' 7 Tabla: CategoriasCamas  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CategoriasAcciones')

BEGIN
	CREATE TABLE [dbo].[CategoriasAcciones](
		[IdCategoriaAccion] [int] NOT NULL,
		[NombreCategoriaAccion] [varchar](30) NOT NULL,
		[Pies] [int] NOT NULL,
		[CoeficienteDistribucionExpensas] [decimal](18, 10) NOT NULL,
	 CONSTRAINT [PK_CategoriasAcciones] PRIMARY KEY CLUSTERED 
	(
		[IdCategoriaAccion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

PRINT ' 8 Tabla: CategoriasAcciones  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CategoriasImagenes')

BEGIN
	CREATE TABLE [dbo].[CategoriasImagenes](
		[IdCategoriaImagen] [int] NOT NULL,
		[IdCategoria] [int] NOT NULL,
		[IdTipoNave] [smallint] NULL,
		[Foto] [image] NULL,
		[ColorFuente] [varchar](50) NOT NULL,
		[FotoReverso] [image] NULL,
		[ColorFuenteVto] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_CategoriasImagenes] PRIMARY KEY CLUSTERED 
	(
		[IdCategoriaImagen] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[CategoriasImagenes]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasImagenes_Categorias] FOREIGN KEY([IdCategoria])
	REFERENCES [dbo].[Categorias] ([IdCategoria])

	ALTER TABLE [dbo].[CategoriasImagenes] CHECK CONSTRAINT [FK_CategoriasImagenes_Categorias]

	ALTER TABLE [dbo].[CategoriasImagenes]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasImagenes_TiposNaves] FOREIGN KEY([IdTipoNave])
	REFERENCES [dbo].[TiposNaves] ([IdTipoNave])

	ALTER TABLE [dbo].[CategoriasImagenes] CHECK CONSTRAINT [FK_CategoriasImagenes_TiposNaves]
END 
GO

PRINT ' 9 Tabla: CategoriasImagenes  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Destinos')

BEGIN
	CREATE TABLE [dbo].[Destinos](
		[IdDestino] [smallint] NOT NULL,
		[NombreDestino] [varchar](30) NOT NULL,
		[EsLibre] [bit] NOT NULL,
	 CONSTRAINT [PK_Destinos] PRIMARY KEY CLUSTERED 
	(
		[IdDestino] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

END
GO

PRINT ' 10 Tabla: Destinos  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Documentos')

BEGIN
	CREATE TABLE [dbo].[Documentos](
		[IdDocumento] [bigint] NOT NULL,
		[Nombre] [varchar](50) NOT NULL,
		[Grupo] [varchar](15) NOT NULL,
		[Version] [decimal](3, 2) NOT NULL,
		[Documento] [image] NULL,
	 CONSTRAINT [PK_IdDocumento] PRIMARY KEY CLUSTERED 
	(
		[IdDocumento] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END
GO

PRINT ' 11 Tabla: Documentos  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MarcasEmbarcaciones')

BEGIN
	CREATE TABLE [dbo].[MarcasEmbarcaciones](
		[IdMarcaEmbarcacion] [int] NOT NULL,
		[NombreMarcaEmbarcacion] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_MarcasEmbarcaciones] PRIMARY KEY CLUSTERED 
	(
		[IdMarcaEmbarcacion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

PRINT ' 12 Tabla: MarcasEmbarcaciones  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ModelosEmbarcaciones')

BEGIN
	CREATE TABLE [dbo].[ModelosEmbarcaciones](
		[IdModeloEmbarcacion] [int] NOT NULL,
		[NombreModeloEmbarcacion] [varchar](50) NOT NULL,
		[IdMarcaEmbarcacion] [int] NOT NULL,
	 CONSTRAINT [PK_ModelosEmbarcaciones] PRIMARY KEY CLUSTERED 
	(
		[IdModeloEmbarcacion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ModelosEmbarcaciones]  WITH CHECK ADD  CONSTRAINT [FK_ModelosEmbarcaciones_MarcasEmbarcaciones] FOREIGN KEY([IdMarcaEmbarcacion])
	REFERENCES [dbo].[MarcasEmbarcaciones] ([IdMarcaEmbarcacion])

	ALTER TABLE [dbo].[ModelosEmbarcaciones] CHECK CONSTRAINT [FK_ModelosEmbarcaciones_MarcasEmbarcaciones]
END 
GO

PRINT ' 13 Tabla: ModelosEmbarcaciones  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MarcasMotores')

BEGIN
CREATE TABLE [dbo].[MarcasMotores](
	[IdMarcaMotor] [int] NOT NULL,
	[NombreMarcaMotor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MarcasMotores] PRIMARY KEY CLUSTERED 
(
	[IdMarcaMotor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

END
GO

PRINT ' 14 Tabla: MarcasMotores  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ModelosMotores')

BEGIN
	CREATE TABLE [dbo].[ModelosMotores](
		[IdModeloMotor] [int] NOT NULL,
		[NombreModeloMotor] [varchar](50) NOT NULL,
		[IdMarcaMotor] [int] NOT NULL,
	 CONSTRAINT [PK_ModelosMotores] PRIMARY KEY CLUSTERED 
	(
		[IdModeloMotor] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ModelosMotores]  WITH CHECK ADD  CONSTRAINT [FK_ModelosMotores_MarcasMotores] FOREIGN KEY([IdMarcaMotor])
	REFERENCES [dbo].[MarcasMotores] ([IdMarcaMotor])

	ALTER TABLE [dbo].[ModelosMotores] CHECK CONSTRAINT [FK_ModelosMotores_MarcasMotores]

END 
GO

PRINT ' 15 Tabla: ModelosMotores  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposSociedades')

BEGIN
	CREATE TABLE [dbo].[TiposSociedades](
		[IdTipoSociedad] [int] NOT NULL,
		[NombreTipoSociedad] [varchar](10) NOT NULL,
	 CONSTRAINT [PK_TiposSociedades] PRIMARY KEY CLUSTERED 
	(
		[IdTipoSociedad] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END 
GO

PRINT ' 16 Tabla: TiposSociedades  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposMatriculas')

BEGIN
	CREATE TABLE [dbo].[TiposMatriculas](
		[IdTipoMatricula] [int] NOT NULL,
		[NombreTipoMatricula] [varchar](5) NOT NULL,
		[TieneNumeros] [bit] NOT NULL,
	 CONSTRAINT [PK_TiposMatriculas] PRIMARY KEY CLUSTERED 
	(
		[IdTipoMatricula] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

PRINT ' 17 Tabla: TiposMatriculas  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposTimoneles')

BEGIN
	CREATE TABLE [dbo].[TiposTimoneles](
		[IdTipoTimonel] [int] NOT NULL,
		[NombreTipoTimonel] [varchar](30) NOT NULL,
		[Prefijo] [varchar](5) NOT NULL,
	 CONSTRAINT [PK_TiposTimoneles] PRIMARY KEY CLUSTERED 
	(
		[IdTipoTimonel] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

PRINT ' 18 Tabla: TiposTimoneles  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposMotores')

BEGIN
	CREATE TABLE [dbo].[TiposMotores](
		[IdTipoMotor] [smallint] NOT NULL,
		[NombreTipoMotor] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_TipoMotor] PRIMARY KEY CLUSTERED 
	(
		[IdTipoMotor] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
PRINT ' 19 Tabla: TiposMotores  ------------------------------------------------------------------------------------------------------------------------------'

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CategoriasEmbarcaciones')

BEGIN
	CREATE TABLE [dbo].[CategoriasEmbarcaciones](
		[IdCategoriaEmbarcacion] [int] NOT NULL,
		[NombreCategoriaEmbarcacion] [varchar](30) NOT NULL,
		[IdTipoEmbarcacion] [int] NOT NULL,
		[ImporteExpensas] [decimal](10, 2) NOT NULL,
		[ImporteAlquiler] [decimal](10, 2) NOT NULL,
		[PorcDescAlquiler] [decimal](7, 4) NOT NULL,
		[ImporteGastosAdmin] [decimal](10, 2) NOT NULL,
		[ImporteGastosIntermAlq] [decimal](10, 2) NOT NULL,
		[ExpensasRelacionCategoria] [decimal](10, 4) NOT NULL,
		[Alto] [decimal](6, 2) NOT NULL,
		[Ancho] [decimal](6, 2) NOT NULL,
		[Largo] [decimal](6, 2) NOT NULL,
		[IdInteres] [int] NULL,
	 CONSTRAINT [PK_CategoriasEmbarcaciones] PRIMARY KEY CLUSTERED 
	(
		[IdCategoriaEmbarcacion] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
	

	ALTER TABLE [dbo].[CategoriasEmbarcaciones]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasEmbarcaciones_Intereses] FOREIGN KEY([IdInteres])
	REFERENCES [dbo].[Intereses] ([IdInteres])
	

	ALTER TABLE [dbo].[CategoriasEmbarcaciones] CHECK CONSTRAINT [FK_CategoriasEmbarcaciones_Intereses]
	

	ALTER TABLE [dbo].[CategoriasEmbarcaciones]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasEmbarcaciones_TiposEmbarcaciones] FOREIGN KEY([IdTipoEmbarcacion])
	REFERENCES [dbo].[TiposEmbarcaciones] ([IdTipoEmbarcacion])
	
	ALTER TABLE [dbo].[CategoriasEmbarcaciones] CHECK CONSTRAINT [FK_CategoriasEmbarcaciones_TiposEmbarcaciones]
	
END 
GO
PRINT ' 20 Tabla: CategoriasEmbarcaciones  ------------------------------------------------------------------------------------------------------------------------------'

PRINT 'Actualiza las funciones en Sisen para usen las pantallas de Siga.'
BEGIN
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposNavesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'NavesABM'
	update Funciones set Archivo = 'Eniac.Win', IdPadre = 'Archivos'  where id = 'AreasComunesABM'
	update Funciones set Archivo = 'Eniac.Win', IdPadre = 'Archivos'  where id = 'SectoresABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposEmbarcacionesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CamasABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CategoriasAccionesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CategoriasEmbarcacionesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CategoriasImagenesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CategoriasCamasABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'CasillerosABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'DestinosABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'DocumentosABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'MarcasEmbarcacionesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'ModelosEmbarcacionesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'ModelosMotoresABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'MarcasMotoresABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposSociedadesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposTimonelesABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposMatriculasABM'
	update Funciones set Archivo = 'Eniac.Win'  where id = 'TiposMotoresABM'
END
GO
PRINT ' 21 Actualizada las Funciones Ex SISEN  ------------------------------------------------------------------------------------------------------------------------------'
IF dbo.BaseConCuit('30714757128') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Reservas de Botados Express'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, 
        Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ImportarChequesElectronicos', 'Importacion de Cheques Electrónicos', 'Importacion de Cheques Electrónicos', 
		'True', 'False', 'True', 'True', 'CobranzaElectronica',41, 'Eniac.Win', 'ImportarChequesElectronicos', null, null,'N','S','N','N','True')

    PRINT ''
    PRINT '4.2. Roles para función: Reservas de Botados Express '
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImportarChequesElectronicos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END;
GO
PRINT ' 22 Creado Menu: Reservas de Botado Express ------------------------------------------------------------------------------------------------------------------------------'

ALTER TABLE dbo.Clientes ADD ActualizadorAptoParaInstalar bit NULL
ALTER TABLE dbo.Clientes ADD ActualizadorFunciona varchar(15) NULL
ALTER TABLE dbo.Clientes ADD ActualizadorFechaInstalacion datetime NULL
ALTER TABLE dbo.Clientes ADD ActualizadorVersion varchar(50) NULL

ALTER TABLE dbo.Clientes ADD IdImpositivoOtroPais varchar(50) NULL
GO

UPDATE Clientes
   SET ActualizadorAptoParaInstalar = 'False'
     , ActualizadorFunciona         = 'PENDIENTE'
     , ActualizadorFechaInstalacion = NULL
     , ActualizadorVersion          = '';

ALTER TABLE dbo.Clientes ALTER COLUMN ActualizadorAptoParaInstalar bit NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ActualizadorFunciona varchar(15) NOT NULL
ALTER TABLE dbo.Clientes ALTER COLUMN ActualizadorVersion varchar(50) NOT NULL
GO

ALTER TABLE dbo.AuditoriaClientes ADD ActualizadorAptoParaInstalar bit NULL
ALTER TABLE dbo.AuditoriaClientes ADD ActualizadorFunciona varchar(15) NULL
ALTER TABLE dbo.AuditoriaClientes ADD ActualizadorFechaInstalacion datetime NULL
ALTER TABLE dbo.AuditoriaClientes ADD ActualizadorVersion varchar(50) NULL

ALTER TABLE dbo.AuditoriaClientes ADD IdImpositivoOtroPais varchar(50) NULL
GO


ALTER TABLE dbo.Prospectos ADD ActualizadorAptoParaInstalar bit NULL
ALTER TABLE dbo.Prospectos ADD ActualizadorFunciona varchar(15) NULL
ALTER TABLE dbo.Prospectos ADD ActualizadorFechaInstalacion datetime NULL
ALTER TABLE dbo.Prospectos ADD ActualizadorVersion varchar(50) NULL

ALTER TABLE dbo.Prospectos ADD IdImpositivoOtroPais varchar(50) NULL
GO

UPDATE Prospectos
   SET ActualizadorAptoParaInstalar = 'False'
     , ActualizadorFunciona         = 'PENDIENTE'
     , ActualizadorFechaInstalacion = NULL
     , ActualizadorVersion          = '';

ALTER TABLE dbo.Prospectos ALTER COLUMN ActualizadorAptoParaInstalar bit NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ActualizadorFunciona varchar(15) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN ActualizadorVersion varchar(50) NOT NULL
GO

ALTER TABLE dbo.AuditoriaProspectos ADD ActualizadorAptoParaInstalar bit NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ActualizadorFunciona varchar(15) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ActualizadorFechaInstalacion datetime NULL
ALTER TABLE dbo.AuditoriaProspectos ADD ActualizadorVersion varchar(50) NULL

ALTER TABLE dbo.AuditoriaProspectos ADD IdImpositivoOtroPais varchar(50) NULL
GO
