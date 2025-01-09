/****** Object:  Table [dbo].[ImpresorasExtracciones]    Script Date: 31/5/2021 18:32:30 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Nueva Tabla: ImpresorasExtracciones'
CREATE TABLE [dbo].[ImpresorasExtracciones](
	[IdSucursal] [int] NOT NULL,
	[IdImpresora] [varchar](15) NOT NULL,
	[Secuencia] [int] NOT NULL,
	[ZetaDesde] [int] NOT NULL,
	[ZetaHasta] [int] NOT NULL,
	[FechaExtraccionDesde] [datetime] NOT NULL,
	[FechaExtraccionHasta] [datetime] NOT NULL,
	[FechaExtraccion] [datetime] NOT NULL,
	[IdUsuarioExtraccion] [varchar](10) NOT NULL,
	[NombreArchivo] [varchar](512) NOT NULL,
	[MD5Archivo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ImpresorasExtracciones] 
 PRIMARY KEY CLUSTERED  ([IdSucursal] ASC,[IdImpresora] ASC,[Secuencia] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ImpresorasExtracciones]  WITH CHECK ADD  CONSTRAINT [FK_ImpresorasExtracciones_Impresoras] FOREIGN KEY([IdSucursal], [IdImpresora])
REFERENCES [dbo].[Impresoras] ([IdSucursal], [IdImpresora])
ALTER TABLE [dbo].[ImpresorasExtracciones] CHECK CONSTRAINT [FK_ImpresorasExtracciones_Impresoras]
GO

ALTER TABLE [dbo].[ImpresorasExtracciones]  WITH CHECK ADD  CONSTRAINT [FK_ImpresorasExtracciones_Usuarios] FOREIGN KEY([IdUsuarioExtraccion])
REFERENCES [dbo].[Usuarios] ([Id])
ALTER TABLE [dbo].[ImpresorasExtracciones] CHECK CONSTRAINT [FK_ImpresorasExtracciones_Usuarios]
GO


PRINT ''
PRINT '2. Tabla Clientes: Nuevos Campos: FechaCambioCategoria, Observaciones IdCategoriaCambio'
ALTER TABLE Clientes
    ADD [FechaCambioCategoria] [date] NULL,
	    [ObservacionCambioCategoria] [varchar](1000) NULL,
	    [IdCategoriaCambio] [int] NULL
GO


PRINT ''
PRINT '2.1 Tabla Clientes: Actualizar registros pre-existentes para los campos'
UPDATE Clientes SET
    [FechaCambioCategoria] = NULL,
    [ObservacionCambioCategoria] = NULL,
    [IdCategoriaCambio] = NULL
GO

PRINT ''
PRINT '2.2. Se agrega Foreign Key a IdCategoriaCambio'
ALTER TABLE [dbo].Clientes  WITH CHECK ADD  CONSTRAINT [FK_Clientes_IdCategoriaCambio] FOREIGN KEY([IdCategoriaCambio])
    REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

PRINT ''
PRINT '3. Tabla AuditoriaClientes: Nuevos Campo:FechaCambioCategoria, Observaciones IdCategoriaCambio'
ALTER TABLE AuditoriaClientes
    ADD [FechaCambioCategoria] [date] NULL,
	    [ObservacionCambioCategoria] [varchar](1000) NULL,
	    [IdCategoriaCambio] [int] NULL
GO

PRINT ''
PRINT '3.1 Tabla AuditoriaClientes: Actualizar registros pre-existentes para los campos'
UPDATE AuditoriaClientes SET
    [FechaCambioCategoria] = NULL,
    [ObservacionCambioCategoria] = NULL,
    [IdCategoriaCambio] = NULL
GO

PRINT ''
PRINT '4. Tabla Prospectos: Nuevos campos: FechaCambioCategoria, Observaciones IdCategoriaCambio'
ALTER TABLE Prospectos
    ADD [FechaCambioCategoria] [date] NULL,
	    [ObservacionCambioCategoria] [varchar](1000) NULL,
	    [IdCategoriaCambio] [int] NULL
GO

PRINT ''
PRINT '4.1 Tabla Prospectos: Actualizar registros pre-existentes para los campos'
UPDATE Prospectos SET
    [FechaCambioCategoria] = NULL,
    [ObservacionCambioCategoria] = NULL,
    [IdCategoriaCambio] = NULL
GO

PRINT ''
PRINT '5 Tabla AuditoriaProspectos: Nuevos campos: FechaCambioCategoria, Observaciones IdCategoriaCambio'
ALTER TABLE AuditoriaProspectos
    ADD [FechaCambioCategoria] [date] NULL,
	    [ObservacionCambioCategoria] [varchar](1000) NULL,
	    [IdCategoriaCambio] [int] NULL
GO

PRINT ''
PRINT '5.1 Tabla AuditoriaProspectos: Actualizar registros pre-existentes para los campos'
UPDATE AuditoriaProspectos SET
    [FechaCambioCategoria] = NULL,
    [ObservacionCambioCategoria] = NULL,
    [IdCategoriaCambio] = NULL
GO

PRINT ''
PRINT '6. Borrar funcion CRMNovdedadesABM'
UPDATE Funciones SET 
	EsMenu = 'False',
	[Enabled] = 'False',
	Visible = 'False'
 WHERE Id = 'CRMNovedadesABM';


PRINT ''
PRINT '7. Tabla ClientesDirecciones: Se borran los registros en donde no exista una igualdad entre la FK y la PK'
DELETE CD FROM ClientesDirecciones CD
	WHERE NOT EXISTS (SELECT * FROM Clientes C WHERE C.IdCliente = CD.IdCliente)

PRINT ''
PRINT '7.1. Tabla ClientesDirecciones: Se crea una Foreign Key de IdCliente con referencia a Clientes'
ALTER TABLE [dbo].[ClientesDirecciones]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDirecciones_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesDirecciones] CHECK CONSTRAINT [FK_ClientesDirecciones_Clientes]
GO

