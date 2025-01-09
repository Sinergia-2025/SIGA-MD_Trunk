PRINT ''
PRINT '1. Tabla Pedidos: Agrego campo Palets .'
ALTER TABLE dbo.Pedidos ADD Palets  int NULL
GO
PRINT ''
PRINT '1.1. Tabla Pedidos: Valores por defecto a campo Palets.'
UPDATE Pedidos SET Palets  = 1;
PRINT ''
PRINT '1.2. Tabla Pedidos: Campo Palets NOT NULL.'
ALTER TABLE dbo.Pedidos ALTER COLUMN Palets int NOT NULL

PRINT ''
PRINT '2. Tabla Ventas: Agrego campo Palets .'
ALTER TABLE dbo.Ventas ADD Palets  int NULL
GO
PRINT ''
PRINT '2.1. Tabla Pedidos: Valores por defecto a campo Palets.'
UPDATE Ventas SET Palets  = 1;
PRINT ''
PRINT '2.2. Tabla Pedidos: Campo Palets NOT NULL.'
ALTER TABLE dbo.Ventas ALTER COLUMN Palets int NOT NULL

PRINT ''
PRINT '3. Tabla Transportistas: Corregir valores por defecto para campos KilosMaximo y PaletsMaximo'
UPDATE Transportistas SET KilosMaximo = 9999999, PaletsMaximo = 9999;


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT ''
PRINT '4. Nueva Tabla CalidadGruposListasControlItems'
CREATE TABLE [dbo].[CalidadGruposListasControlItems](
	[IdGrupoListaControlItem] [varchar](50) NOT NULL,
	[NombreGrupoListaControlItem] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CalidadGruposListasControlItems] PRIMARY KEY CLUSTERED 
(
	[IdGrupoListaControlItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '5. Nueva Tabla CalidadSubGruposListasControlItems'
CREATE TABLE [dbo].[CalidadSubGruposListasControlItems](
	[IdGrupoListaControlItem] [varchar](50) NOT NULL,
	[IdSubGrupoListaControlItem] [varchar](50) NOT NULL,
	[NombreSubGrupoListaControlItem] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CalidadSubGruposListasControlItems2] PRIMARY KEY CLUSTERED 
(
	[IdGrupoListaControlItem] ASC,
	[IdSubGrupoListaControlItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadSubGruposListasControlItems]  WITH CHECK ADD  CONSTRAINT [FK_CalidadSubGruposListasControlItems_CalidadGruposListasControlItems] FOREIGN KEY([IdGrupoListaControlItem])
REFERENCES [dbo].[CalidadGruposListasControlItems] ([IdGrupoListaControlItem])
GO

ALTER TABLE [dbo].[CalidadSubGruposListasControlItems] CHECK CONSTRAINT [FK_CalidadSubGruposListasControlItems_CalidadGruposListasControlItems]
GO

PRINT ''
PRINT '6. Nueva Tabla CalidadListasControlItems'
CREATE TABLE [dbo].[CalidadListasControlItems](
	[IdListaControlItem] [int] NOT NULL,
	[NombreListaControlItem] [varchar](100) NOT NULL,
	[IdGrupoListaControlItem] [varchar](50) NOT NULL,
	[IdSubGrupoListaControlItem] [varchar](50) NULL,
 CONSTRAINT [PK_CalidadListasControlItems] PRIMARY KEY CLUSTERED 
(
	[IdListaControlItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadListasControlItems]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlItems_CalidadGruposListasControlItems] FOREIGN KEY([IdGrupoListaControlItem])
REFERENCES [dbo].[CalidadGruposListasControlItems] ([IdGrupoListaControlItem])
GO

ALTER TABLE [dbo].[CalidadListasControlItems] CHECK CONSTRAINT [FK_CalidadListasControlItems_CalidadGruposListasControlItems]
GO

PRINT ''
PRINT '7. Nueva Tabla CalidadListasControl'
CREATE TABLE [dbo].[CalidadListasControl](
	[IdListaControl] [int] NOT NULL,
	[NombreListaControl] [varchar](100) NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_CalidadListasControl] PRIMARY KEY CLUSTERED 
(
	[IdListaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '8. Nueva Tabla CalidadListasControlConfig'
CREATE TABLE [dbo].[CalidadListasControlConfig](
	[IdListaControl] [int] NOT NULL,
	[Item] [int] NOT NULL,
	[IdListaControlItem] [int] NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_CalidadListasControlConfig] PRIMARY KEY CLUSTERED 
(
	[IdListaControl] ASC,
	[Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadListasControlConfig]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfig_CalidadListasControlItems] FOREIGN KEY([IdListaControlItem])
REFERENCES [dbo].[CalidadListasControlItems] ([IdListaControlItem])
GO

ALTER TABLE [dbo].[CalidadListasControlConfig] CHECK CONSTRAINT [FK_CalidadListasControlConfig_CalidadListasControlItems]
GO

PRINT ''
PRINT '9. Nueva Tabla CalidadListasControlUsuarios'
CREATE TABLE [dbo].[CalidadListasControlUsuarios](
	[IdListaControl] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CalidadListasControlUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdListaControl] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadListasControlUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlUsuarios_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO

ALTER TABLE [dbo].[CalidadListasControlUsuarios] CHECK CONSTRAINT [FK_CalidadListasControlUsuarios_CalidadListasControl]
GO

ALTER TABLE [dbo].[CalidadListasControlUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlUsuarios_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadListasControlUsuarios] CHECK CONSTRAINT [FK_CalidadListasControlUsuarios_Usuarios]
GO


PRINT ''
PRINT '10. Tabla Productos: Agrego nuevos campo para Módulo de Calidad.'
ALTER TABLE Productos ADD CalidadStatusLiberado	bit	null
						,CalidadFechaLiberado	datetime	null
						,CalidadUserLiberado	varchar(10)	null
						,CalidadStatusEntregado	bit	null
						,CalidadFechaEntregado	datetime	null
						,CalidadUserEntregado	varchar(10)	null
						,CalidadFechaIngreso	datetime	null
						,CalidadFechaEgreso	datetime	null
						,CalidadNroCertificado	int	null
						,CalidadFecCertificado	datetime	null
						,CalidadUsrCertificado	varchar(100)	null
						,CalidadObservaciones	varchar(MAX)	null
						,CalidadFechaPreEnt	datetime	null
						,CalidadFechaEntProg	datetime	null
GO

PRINT ''
PRINT '10.1. Tabla Productos: Valores por defecto para nuevos campo para Módulo de Calidad.'
UPDATE Productos SET CalidadStatusLiberado = 'False' 
					,CalidadStatusEntregado = 'False'

PRINT ''
PRINT '10.2. Tabla Productos: NOT NULL de nuevos campo para Módulo de Calidad.'
ALTER TABLE Productos ALTER COLUMN CalidadStatusLiberado	bit	not null	
ALTER TABLE Productos ALTER COLUMN CalidadStatusEntregado	bit not	null


PRINT ''
PRINT '11. Tabla AuditoriaProductos: Agrego nuevos campo para Módulo de Calidad.'
ALTER TABLE AuditoriaProductos ADD CalidadStatusLiberado	bit	null
						,CalidadFechaLiberado	datetime	null
						,CalidadUserLiberado	varchar(10)	null
						,CalidadStatusEntregado	bit	null
						,CalidadFechaEntregado	datetime	null
						,CalidadUserEntregado	varchar(10)	null
						,CalidadFechaIngreso	datetime	null
						,CalidadFechaEgreso	datetime	null
						,CalidadNroCertificado	int	null
						,CalidadFecCertificado	datetime	null
						,CalidadUsrCertificado	varchar(100)	null
						,CalidadObservaciones	varchar(MAX)	null
						,CalidadFechaPreEnt	datetime	null
						,CalidadFechaEntProg	datetime	null
