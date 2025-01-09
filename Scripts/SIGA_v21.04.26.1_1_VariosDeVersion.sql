/****** Object:  Table [dbo].[TiposUsuarios]    Script Date: 20/4/2021 09:28:30 ******/
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1.Nueva Tabla: ConcesionarioTiposUnidades'
CREATE TABLE ConcesionarioTiposUnidades(
	IdTipoUnidad INT NOT NULL,
	NombreTipoUnidad VARCHAR(30) NOT NULL,
	DescripcionTipoUnidad Varchar(150) NOT NULL

    CONSTRAINT PK_ConcesionarioTiposUnidades PRIMARY KEY (IdTipoUnidad)
)

PRINT ''
PRINT '2. Nueva Tabla: ConcesionarioSubTiposUnidades'
CREATE TABLE ConcesionarioSubTiposUnidades(
    IdSubTipoUnidad INT NOT NULL,
    NombreSubTipoUnidad VARCHAR(30) NOT NULL,
    DescripcionSubTipoUnidad VARCHAR(150) NOT NULL,
    IdTipoUnidad INT FOREIGN KEY REFERENCES ConcesionarioTiposUnidades(IdTipoUnidad),
    SolicitaCantPuertasLaterales BIT,
    SolicitaCantPisos BIT,
    SolicitaVolumen BIT

    CONSTRAINT [PK_IdSubTipoUnidad] PRIMARY KEY CLUSTERED 
)

PRINT ''
PRINT '3. Nueva Tabla: ConcesionarioDistribucionEjes'
CREATE TABLE ConcesionarioDistribucionEjes(
    IdEje INT NOT NULL,
    NombreEje VARCHAR(30) NOT NULL,
    DescripcionEje VARCHAR(150) NOT NULL,
    IdTipoUnidad INT FOREIGN KEY REFERENCES ConcesionarioTiposUnidades(IdTipoUnidad)

    CONSTRAINT PK_ConcesionarioDistribucionEjes PRIMARY KEY (IdEje)
)

PRINT ''
PRINT '4. Nueva Tabla: TiposUsuarios'
CREATE TABLE [dbo].[TiposUsuarios](
	[IdTipoUsuario] [int] NOT NULL,
	[NombreTipoUsuario] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TiposUsuarios] PRIMARY KEY CLUSTERED ([IdTipoUsuario] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
PRINT ''
PRINT '4.1. Tabla TiposUsuarios: Registros iniciales'
INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [NombreTipoUsuario]) VALUES (1, N'Individuos')
INSERT [dbo].[TiposUsuarios] ([IdTipoUsuario], [NombreTipoUsuario]) VALUES (2, N'Procesos')
GO


PRINT ''
PRINT '5. Tabla CuentasCorrientesProv: Nuevo campo RefProveedor'
ALTER TABLE dbo.CuentasCorrientesProv ADD RefProveedor varchar(20) NULL


PRINT ''
PRINT '5. Tabla Usuarios: Nuevo campo TipoUsuario'
ALTER TABLE dbo.Usuarios ADD TipoUsuario int NULL
GO

PRINT ''
PRINT '5.1. Tabla Usuarios: Actualizar registros pre-existentes para el campo TipoUsuario'
UPDATE Usuarios SET TipoUsuario = 1;
PRINT ''
PRINT '5.2. Tabla Usuarios: NOT NULL para el campo TipoUsuario'
ALTER TABLE dbo.Usuarios ALTER COLUMN TipoUsuario int NOT NULL
GO

PRINT ''
PRINT '5.3. Tabla Usuarios: IDX_TipoUsuario'
CREATE NONCLUSTERED INDEX IDX_TipoUsuario ON dbo.Usuarios (TipoUsuario)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '5.4. Tabla Usuarios: FK_Usuarios_TiposUsuarios'
ALTER TABLE dbo.Usuarios ADD CONSTRAINT FK_Usuarios_TiposUsuarios
    FOREIGN KEY (TipoUsuario) 
    REFERENCES dbo.TiposUsuarios (IdTipoUsuario)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '6. Tabla ProyectosEstados: Nuevo campo Posicion'
ALTER TABLE dbo.ProyectosEstados ADD Posicion int NULL
GO

PRINT ''
PRINT '6.1. Tabla ProyectosEstados: Actualizar registros pre-existentes para el campo Posicion'
UPDATE dbo.ProyectosEstados SET Posicion = 0
PRINT ''
PRINT '6.2. Tabla ProyectosEstados: NOT NULL para el campo Posicion'
ALTER TABLE dbo.ProyectosEstados ALTER COLUMN Posicion int NOT NULL
GO

PRINT ''
PRINT '7. Tabla TiposComprobantes: Nuevo campo ActivaTildeMercDespacha'
ALTER TABLE dbo.TiposComprobantes ADD ActivaTildeMercDespacha bit NULL
GO

PRINT ''
PRINT '7.1. Tabla TiposComprobantes: Actualizar registros pre-existentes para el campo ActivaTildeMercDespacha'
UPDATE dbo.TiposComprobantes 
    SET ActivaTildeMercDespacha = (SELECT TOP 1 ValorParametro FROM Parametros WHERE IdParametro = 'TILDEMERCDESPACHADA')
GO

PRINT ''
PRINT '7.2. Tabla TiposComprobantes: NOT NULL para el campo ActivaTildeMercDespacha'
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN ActivaTildeMercDespacha bit NOT NULL
GO

