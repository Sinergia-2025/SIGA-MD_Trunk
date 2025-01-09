PRINT ''
PRINT '1. Nueva Tabla: CRMTiposCategoriasNovedades'
CREATE TABLE CRMTiposCategoriasNovedades (
	IdTipoCategoriaNovedad INT NOT NULL,
	NombreTipoCategoriaNovedad VARCHAR(20) NOT NULL,
	Posicion INT NOT NULL,
	IdTipoNovedad VARCHAR(10) NOT NULL,
	PRIMARY KEY (IdTipoCategoriaNovedad)
)
GO

PRINT ''
PRINT '2. FK_CRMTiposCategoriasNovedades_CRMTiposNovedades'
ALTER TABLE CRMTiposCategoriasNovedades
	ADD CONSTRAINT FK_CRMTiposCategoriasNovedades_CRMTiposNovedades
	FOREIGN KEY (IdTipoNovedad) REFERENCES CRMTiposNovedades (IdTipoNovedad)
GO

PRINT ''
PRINT '3. Registros iniciales en la tabla CRMTiposCategoriasNovedades'
INSERT INTO CRMTiposCategoriasNovedades
  SELECT ROW_NUMBER() OVER(ORDER BY IdTipoNovedad)*10 AS IdTipoCategoriaNovedad
       , 'GENERAL' NombreTipoCategoriaNovedad 
       , 10 Posicion
       , TN.IdTipoNovedad
    FROM CRMTiposNovedades TN
  IF (SELECT IdTipoNovedad FROM CRMTiposNovedades WHERE IdTipoNovedad = 'TICKETS') IS NOT NULL
  BEGIN
	INSERT INTO CRMTiposCategoriasNovedades
	SELECT (1 + (SELECT COUNT(1) FROM CRMTiposNovedades TN))*10 AS IdTipoCategoriaNovedad, 'SEGUIR' NombreTipoCategoriaNovedad , 20 Posicion , 'TICKETS'
	UNION 
	SELECT (2 + (SELECT COUNT(1) FROM CRMTiposNovedades TN))*10 AS IdTipoCategoriaNovedad, 'NO SEGUIR' NombreTipoCategoriaNovedad , 30 Posicion , 'TICKETS'
  END
  IF (SELECT IdTipoNovedad FROM CRMTiposNovedades WHERE IdTipoNovedad = 'RECCLTE') IS NOT NULL
  BEGIN
	INSERT INTO CRMTiposCategoriasNovedades
	SELECT (3 + (SELECT COUNT(1) FROM CRMTiposNovedades TN))*10 AS IdTipoCategoriaNovedad, 'SEGUIR' NombreTipoCategoriaNovedad , 20 Posicion , 'RECCLTE'
	UNION 
	SELECT (4 + (SELECT COUNT(1) FROM CRMTiposNovedades TN))*10 AS IdTipoCategoriaNovedad, 'NO SEGUIR' NombreTipoCategoriaNovedad , 30 Posicion , 'RECCLTE'
  END
GO

PRINT ''
PRINT '4. Nuevo Campo: IdTipoCategoriaNovedad en CRMCategoriasNovedades'
ALTER TABLE CRMCategoriasNovedades
	ADD IdTipoCategoriaNovedad INT NULL
GO

PRINT ''
PRINT '5. FK_CRMCategoriasNovedades_CRMTiposCategoriasNovedades'
ALTER TABLE CRMCategoriasNovedades
	ADD CONSTRAINT FK_CRMCategoriasNovedades_CRMTiposCategoriasNovedades
	FOREIGN KEY (IdTipoCategoriaNovedad) REFERENCES CRMTiposCategoriasNovedades (IdTipoCategoriaNovedad)
GO

PRINT ''
PRINT '6. Actualización de los registros pre-existentes'
UPDATE CN SET CN.IdTipoCategoriaNovedad = TCN.IdTipoCategoriaNovedad FROM CRMCategoriasNovedades CN
	LEFT JOIN CRMTiposCategoriasNovedades TCN ON CN.IdTipoNovedad = TCN.IdTipoNovedad
GO

PRINT ''
PRINT '7. Cambio los valores a NOT NULL'
ALTER TABLE CRMCategoriasNovedades
	ALTER COLUMN IdTipoCategoriaNovedad INT NOT NULL
GO

PRINT ''
PRINT '8. Tabla CalidadListasControlTipos: Nueva Tabla'
/****** Object:  Table [dbo].[CalidadListasControlTipos]    Script Date: 11/11/2020 15:17:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadListasControlTipos](
	[IdListaControlTipo] [int] NOT NULL,
	[NombreListaControlTipo] [varchar](100) NOT NULL,
	[RangoDesde] [int] NOT NULL,
	[RangoHasta] [int] NOT NULL,
 CONSTRAINT [PK_CalidadListasControlTipos] PRIMARY KEY CLUSTERED 
(
	[IdListaControlTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '9. Tabla CalidadListasControlTipos: Datos por defecto'
INSERT INTO [dbo].[CalidadListasControlTipos]
           ([IdListaControlTipo]
           ,[NombreListaControlTipo]
           ,[RangoDesde]
           ,[RangoHasta])
     VALUES
           (1,'A definir', 0, 0)
GO

PRINT ''
PRINT '10. Tabla CalidadListasControl: Nuevo campo IdListaControlTipo'
ALTER TABLE CalidadListasControl ADD IdListaControlTipo int null
GO

UPDATE CalidadListasControl SET IdListaControlTipo = 1
GO

ALTER TABLE CalidadListasControl ALTER COLUMN IdListaControlTipo int not null
GO

ALTER TABLE [dbo].[CalidadListasControl]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControl_CalidadListasControlTipos] FOREIGN KEY([IdListaControlTipo])
REFERENCES [dbo].[CalidadListasControlTipos] ([IdListaControlTipo])
GO

ALTER TABLE [dbo].[CalidadListasControl] CHECK CONSTRAINT [FK_CalidadListasControl_CalidadListasControlTipos]
GO

PRINT ''
PRINT '11. ABM Tipos de Listas de Control'
IF dbo.ExisteFuncion('Calidad') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ListasControlTiposABM', 'ABM de Tipos Listas de Control', 'ABM de Tipos Listas de Control', 'True', 'False', 'True', 'True'
        ,'Calidad', 125, 'Eniac.Win', 'ListasControlTiposABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ListasControlTiposABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '12. Nueva Tabla de Auditoría: AuditoriaCRMNovedades'
CREATE TABLE AuditoriaCRMNovedades(
	FechaAuditoria DATETIME NOT NULL,
	OperacionAuditoria CHAR(1) NOT NULL,
	UsuarioAuditoria VARCHAR(10) NOT NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [bigint] NOT NULL,
	[FechaNovedad] [datetime] NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[IdPrioridadNovedad] [int] NOT NULL,
	[IdCategoriaNovedad] [int] NOT NULL,
	[IdEstadoNovedad] [int] NOT NULL,
	[FechaEstadoNovedad] [datetime] NOT NULL,
	[IdUsuarioEstadoNovedad] [varchar](10) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[IdUsuarioAlta] [varchar](10) NOT NULL,
	[IdUsuarioAsignado] [varchar](10) NULL,
	[Avance] [decimal](5, 2) NOT NULL,
	[IdMedioComunicacionNovedad] [int] NULL,
	[IdCliente] [bigint] NULL,
	[IdProspecto] [bigint] NULL,
	[IdFuncion] [varchar](30) NULL,
	[IdSistema] [varchar](10) NULL,
	[FechaProximoContacto] [datetime] NULL,
	[BanderaColor] [int] NULL,
	[Interlocutor] [varchar](30) NULL,
	[IdMetodoResolucionNovedad] [int] NULL,
	[IdProveedor] [bigint] NULL,
	[IdProyecto] [int] NULL,
	[RevisionAdministrativa] [bit] NOT NULL,
	[Priorizado] [bit] NOT NULL,
	[IdTipoNovedadPadre] [varchar](10) NULL,
	[IdNovedadPadre] [bigint] NULL,
	[Version] [varchar](20) NULL,
	[VersionFecha] [datetime] NULL,
	[FechaInicioPlan] [datetime] NULL,
	[FechaFinPlan] [datetime] NULL,
	[TiempoEstimado] [decimal](12, 2) NULL,
	[IdUsuarioResponsable] [varchar](10) NULL,
	[Cantidad] [decimal](8, 2) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[LetraPadre] [varchar](1) NULL,
	[CentroEmisorPadre] [smallint] NULL,
	[IdSucursalService] [int] NULL,
	[IdTipoComprobanteService] [varchar](15) NULL,
	[LetraService] [varchar](1) NULL,
	[CentroEmisorService] [int] NULL,
	[NumeroComprobanteService] [bigint] NULL,
	[IdProducto] [varchar](15) NULL,
	[CantidadProducto] [decimal](12, 2) NULL,
	[CostoReparacion] [decimal](12, 2) NULL,
	[IdProductoPrestado] [varchar](15) NULL,
	[CantidadProductoPrestado] [decimal](12, 2) NULL,
	[ProductoPrestadoDevuelto] [bit] NOT NULL,
	[IdProveedorService] [bigint] NULL,
	[Contador1] [int] NOT NULL,
	[Contador2] [int] NOT NULL,
	[FechaActualizacionWeb] [datetime] NOT NULL,
	[IdProductoNovedad] [varchar](15) NULL,
	[EtiquetaNovedad] [varchar](max) NOT NULL,
	[NroDeSerie] [varchar](50) NULL,
	[TieneGarantiaService] [bit] NULL,
	[UbicacionService] [varchar](30) NULL,
	[Imprime] [bit] NULL,
	[Reporte] [varchar](150) NULL,
	[Embebido] [bit] NULL
	PRIMARY KEY (FechaAuditoria, IdTipoNovedad, IdNovedad, CentroEmisor, Letra)
)
GO

PRINT ''
PRINT '13. FK_AuditoriaCRMNovedades_Usuarios'
ALTER TABLE AuditoriaCRMNovedades
	ADD CONSTRAINT FK_AuditoriaCRMNovedades_Usuarios
	FOREIGN KEY (UsuarioAuditoria) REFERENCES Usuarios (Id)
GO


PRINT ''
PRINT '14. Nuevo Toolstrip: Auditorias de ... en CRM'
IF dbo.ExisteFuncion('CRM') = 1
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('CRMAuditorias', 'Auditorias de ...', 'Auditorias de ...', 'True', 'False', 'True', 'True'
	    ,'CRM', 5, NULL, NULL, NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMAuditorias' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '15. Nuevos Informes de Auditoría CRM'
IF dbo.ExisteFuncion('CRM') = 1
BEGIN	
	INSERT INTO Funciones
	        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT 'InfAuditoriaCRM' + IdTipoNovedad                AS Id
             , 'Inf. Auditoría de ' + NombreTipoNovedad         AS Nombre
             , 'Inf. Auditoría de ' + NombreTipoNovedad         AS Descripcion
             , 'True' EsMenu, 'False' EsBotno, 'True' [Enabled], 'True' Visible
	         , 'CRMAuditorias'                                  AS IdPadre
             , ROW_NUMBER() OVER(ORDER BY IdTipoNovedad) * 10   AS Posicion
             , 'Eniac.Win' AS Archivo
             , 'InfAuditoriaCRMNovedades'                AS Pantalla
             , NULL AS Icono
             , IdTipoNovedad AS Parametros
             ,'True' PermiteMultiplesInstancias, 'S' Plus, 'N' Express, 'N' Basica, 'N' PV
          FROM CRMTiposNovedades

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfAuditoriaCRM' + IdTipoNovedad
      FROM CRMTiposNovedades N
     INNER JOIN Funciones F ON F.Id = 'CRMNovedadesABM' + IdTipoNovedad
     INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
END
