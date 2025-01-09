BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
PRINT ''
PRINT '1. Tabla Productos: Cambio el CodigoSAE de Integer a Varchar(15) .'
ALTER TABLE dbo.Productos ALTER COLUMN CodigoSAE  varchar(15) NULL
PRINT ''
PRINT '2. Tabla AuditoriaProductos: Cambio el CodigoSAE de Integer a Varchar(15) .'
ALTER TABLE dbo.AuditoriaProductos ALTER COLUMN CodigoSAE  varchar(15) NULL
PRINT ''
PRINT '3. Tabla PedidosProductos: Cambio el CodigoSAE de Integer a Varchar(15) .'
ALTER TABLE dbo.PedidosProductos ALTER COLUMN CodigoSAE  varchar(15) NULL
PRINT ''
PRINT '4. Tabla ProduccionProductos: Cambio el CodigoSAE de Integer a Varchar(15) .'
ALTER TABLE dbo.ProduccionProductos ALTER COLUMN CodigoSAE  varchar(15) NULL
GO
COMMIT

PRINT ''
PRINT '5.- CREA TABLA VersionesScripts'
CREATE TABLE [VersionesScripts](
	[IdAplicacion] [varchar](20) NOT NULL,
	[NroVersion] [varchar](50) NOT NULL,
	[Orden] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Script] [varchar](max) NOT NULL,
	[Obligatorio] [bit] NOT NULL,
	[CodigoCliente] [bigint] NULL,
 CONSTRAINT [PK_VersionesScripts] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[NroVersion] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-------------------------------------------------------
PRINT ''
PRINT '6.- CREA TABLA VersionesScriptsEjecuciones'

CREATE TABLE [VersionesScriptsEjecuciones](
	[IdAplicacion] [varchar](20) NOT NULL,
	[NroVersion] [varchar](50) NOT NULL,
	[Orden] [int] NOT NULL,
	[CodigoCliente] [bigint] NOT NULL,
	[Base] [varchar](50) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Script] [varchar](max) NOT NULL,
	[Obligatorio] [bit] NOT NULL,
	[FechaEjecucion] [datetime] NULL,
	[Exitoso] [bit] NULL,
	[Mensaje] [varchar](100) NULL,
 CONSTRAINT [PK_EjecucionesScripts] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[NroVersion] ASC,
	[Orden] ASC,
	[CodigoCliente] ASC,
	[Base] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


-------------------------------------------------------
PRINT ''
PRINT '7.- INSERTAR PARAMETRO MSI y CONFIG. SITIO VIRTUAL'

MERGE INTO Parametros AS P
        USING (SELECT 'UBICACIONMSI'    AS IdParametro, 'c:\Eniac\SiGA\Instaladores\'                                ValorParametro, 'Ubicacion MSI' DescripcionParametro UNION
               SELECT 'URLACTUALIZADOR' AS IdParametro, 'http://w1021701.ferozo.com/actualizador/WSActualizador.svc' ValorParametro, ''              DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;


-------------------------------------------------------
PRINT ''
PRINT '8.- CREA TABLA VersionesClientes'

CREATE TABLE [dbo].[VersionesClientes](
	[IdCliente] [bigint] NOT NULL,
	[IdAplicacion] [varchar](20) NOT NULL,
	[NombreBase] [varchar](100) NOT NULL,
	[NroVersionHabilitada] [varchar](50) NOT NULL,
	[ClaveCliente] [varchar](50) NOT NULL,
	[PermiteActualizar] [bit] NOT NULL,
 CONSTRAINT [PK_VersionesClientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdAplicacion] ASC,
	[NombreBase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-------------------------------------------------------
PRINT 'SOLO SINERGIA SOFTWARE'
PRINT '9.- CREA MENU de Scripts de Version'
IF dbo.ExisteFuncion('CRM') = 1 AND dbo.BaseConCuit('33711345499') = 1
BEGIN
	PRINT '9.1. Inserto la funcion'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV)
         VALUES
             ('ScriptsVersion', 'Carga de Scripts de Versión', 'Carga de Scripts de Versión', 'True', 'False', 'True', 'True', 
              'CRM', 55, 'Eniac.Win', 'ScriptsVersion', NULL, NULL, 'True', 'NO', 'NO', 'NO', 'NO');

	PRINT '9.2. Inserto RolesFunciones'
    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ScriptsVersion' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'CRM';
END;

-------------------------------------------------------
PRINT 'SOLO SINERGIA SOFTWARE'
PRINT '10.- CREA MENU de Actualizador de Version'

--IF dbo.ExisteFuncion('Configuraciones') = 1 AND dbo.BaseConCuit('33711345499') = 1
--BEGIN
--	PRINT '10.1. Inserto la funcion'
--    INSERT INTO [dbo].Funciones
--             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
--              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV)
--         VALUES
--             ('Actualizador', 'Actualizador de Versión', 'Actualizador de Versión', 'True', 'False', 'True', 'True', 
--              'Configuraciones', 90, 'Eniac.Win', 'Actualizador', NULL, NULL, 'True', 'NO', 'NO', 'NO', 'NO');

--    PRINT '10.2. Inserto RolesFunciones'
--    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
--    SELECT DISTINCT Id AS Rol, 'Actualizador' AS Pantalla FROM [dbo].Roles
--        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'Configuraciones';
--END;


-------------------------------------------------------
PRINT 'SOLO SINERGIA SOFTWARE'
PRINT '11.- CREA MENU de Administración de Versiones'
IF dbo.ExisteFuncion('CRM') = 1 AND dbo.BaseConCuit('33711345499') = 1
BEGIN
	PRINT '11.1. Inserto la funcion'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV)
         VALUES
             ('AdministracionDeVersiones', 'Administración de Versiones', 'Administración de Versiones', 'True', 'False', 'True', 'True', 
              'CRM', 95, 'Eniac.Win', 'AdministracionDeVersiones', NULL, NULL, 'True', 'NO', 'NO', 'NO', 'NO');

	PRINT '11.2. Inserto RolesFunciones'
    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AdministracionDeVersiones' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'CRM';
END;

