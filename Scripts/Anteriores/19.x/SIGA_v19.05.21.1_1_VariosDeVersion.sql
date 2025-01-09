SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

PRINT ''
PRINT '1. Nueva Tabla Modulos'
CREATE TABLE [dbo].[AplicacionesModulos](
	[IdModulo] [int] NOT NULL,
	[NombreModulo] [varchar](100) NOT NULL,
    CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

If dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Datos iniciales de Tabla Modulos'
    INSERT INTO AplicacionesModulos (IdModulo, NombreModulo)
        SELECT ROW_NUMBER() OVER (ORDER BY id) AS rownum, pp.id FROM (SELECT distinct id, idpadre FROM dbo.Funciones WHERE IdPadre is NULL) pp WHERE pp.IdPadre is NULL
END

PRINT ''
PRINT '2. Nueva Tabla AplicacionesEdiciones'
CREATE TABLE [AplicacionesEdiciones](
	[IdAplicacion] [varchar](20) NOT NULL,
	[IdEdicion] [varchar](15) NOT NULL,
	[NombreEdicion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AplicacionesEdiciones] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[IdEdicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[AplicacionesEdiciones]  WITH CHECK ADD  CONSTRAINT [FK_AplicacionesEdiciones_AplicacionesEdiciones] FOREIGN KEY([IdAplicacion])
 REFERENCES [dbo].[Aplicaciones] ([IdAplicacion])
ALTER TABLE [dbo].[AplicacionesEdiciones] CHECK CONSTRAINT [FK_AplicacionesEdiciones_AplicacionesEdiciones]

PRINT ''
PRINT '3. Nueva Tabla AplicacionesEdicionesModulos'
CREATE TABLE [AplicacionesEdicionesModulos](
	[IdAplicacion] [varchar](20) NOT NULL,
	[IdEdicion] [varchar](15) NOT NULL,
	[IdModulo] [int] NOT NULL,
 CONSTRAINT [PK_AplicacionesEdicionesModulos] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[IdEdicion] ASC,
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[AplicacionesEdicionesModulos]  WITH CHECK ADD  CONSTRAINT [FK_AplicacionesEdicionesModulos_Aplicaciones] FOREIGN KEY([IdAplicacion])
REFERENCES [dbo].[Aplicaciones] ([IdAplicacion])
ALTER TABLE [dbo].[AplicacionesEdicionesModulos] CHECK CONSTRAINT [FK_AplicacionesEdicionesModulos_Aplicaciones]

PRINT ''
PRINT '4. Nueva Función AplicacionesModulosABM y AplicacionesEdicionesABM'
If dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '4.1. Agregar Opción de Menu AplicacionesModulosABM'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
       ('AplicacionesModulosABM', 'Aplicaciones Módulos', 'Aplicaciones Módulos', 'True', 'False', 'True', 'True'
       ,'Archivos', 43, 'Eniac.Win', 'AplicacionesModulosABM', NULL, NULL
       ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '4.2. Asigna Roles a AplicacionesModulosABM'
    INSERT INTO RolesFunciones 
               (IdRol,IdFuncion)
    SELECT IdRol, 'AplicacionesModulosABM' FROM RolesFunciones WHERE IdFuncion = 'AplicacionesABM'

    PRINT ''
    PRINT '4.3. Agregar Opción de Menu AplicacionesEdicionesABM'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
       ('AplicacionesEdicionesABM', 'Aplicaciones Ediciones', 'Aplicaciones Ediciones', 'True', 'False', 'True', 'True'
       ,'Archivos', 43, 'Eniac.Win', 'AplicacionesEdicionesABM', NULL, NULL
       ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '4.4. Asigna Roles a AplicacionesEdicionesABM'
    INSERT INTO RolesFunciones 
               (IdRol,IdFuncion)
    SELECT IdRol, 'AplicacionesEdicionesABM' FROM RolesFunciones WHERE IdFuncion = 'AplicacionesModulosABM'

END
