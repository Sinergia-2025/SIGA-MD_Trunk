SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

PRINT ''
PRINT '1. Tabla ReservasPasajeros: Nuevo campo IdClientePasajero'
ALTER TABLE ReservasPasajeros ADD IdClientePasajero bigint not null

PRINT ''
PRINT '2. Tabla ReservasPasajeros: Campo CentroEmisorComprobante como smallint'
ALTER TABLE ReservasPasajeros ALTER COLUMN CentroEmisorComprobante smallint null
GO

PRINT ''
PRINT '3. Nueva Tabla CRMTiposComentariosNovedades'
CREATE TABLE [dbo].[CRMTiposComentariosNovedades](
	[IdTipoComentarioNovedad] [int] NOT NULL,
	[NombreTipoComentarioNovedad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[PorDefecto] [bit] NOT NULL,
	[Color] [int] NULL,
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[VisibleParaCliente] [bit] NULL,
	[VisibleParaRepresentante] [bit] NULL,
 CONSTRAINT [PK_CRMTiposComentariosNovedades] PRIMARY KEY CLUSTERED 
([IdTipoComentarioNovedad] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CRMTiposComentariosNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposComentariosNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO
ALTER TABLE [dbo].[CRMTiposComentariosNovedades] CHECK CONSTRAINT [FK_CRMTiposComentariosNovedades_CRMTiposNovedades]
GO

PRINT ''
PRINT '3.1. Tabla CRMTiposComentariosNovedades: Datos iniciales para tableros'
INSERT INTO [dbo].[CRMTiposComentariosNovedades]
           ([IdTipoComentarioNovedad]
           ,[NombreTipoComentarioNovedad]
           ,[Posicion]
           ,[PorDefecto]
           ,[Color]
           ,[IdTipoNovedad]
           ,[VisibleParaCliente]
           ,[VisibleParaRepresentante])
SELECT ((ROW_NUMBER() OVER(ORDER BY IdTipoNovedad DESC)) * 100) + 1 AS IdTipoComentarioNovedad
     , 'COMENTARIO'     AS NombreTipoComentarioNovedad
     , 10               AS Posicion
     , 'True'           AS PorDefecto
     , NULL             AS Color
     , IdTipoNovedad
     , 'False'          AS VisibleParaCliente
     , 'False'          AS VisibleParaRepresentante
  FROM CRMTiposNovedades TN
 WHERE IdTipoNovedad <> 'PENDIENTE'

IF EXISTS (SELECT 1 FROM CRMTiposNovedades WHERE IdTipoNovedad = 'PENDIENTE')
BEGIN
    PRINT ''
    PRINT '3.2. Tabla CRMTiposComentariosNovedades: Datos iniciales para tableros (Solo Pendiente)'
    INSERT INTO [dbo].[CRMTiposComentariosNovedades]
               ([IdTipoComentarioNovedad]
               ,[NombreTipoComentarioNovedad]
               ,[Posicion]
               ,[PorDefecto]
               ,[Color]
               ,[IdTipoNovedad]
               ,[VisibleParaCliente]
               ,[VisibleParaRepresentante])
        VALUES (1, 'COMENTARIO',            10, 'True',  NULL,      'PENDIENTE', 'False', 'False'),
               (2, 'ERROR REV.TEC.FUNC.',   20, 'False', -32704,    'PENDIENTE', 'False', 'False'),
               (3, 'ERROR TESTING',         30, 'False', -44288,    'PENDIENTE', 'False', 'False'),
               (4, 'ERROR MENOR',           40, 'False', -19055,    'PENDIENTE', 'False', 'False'),
               (5, 'ADJUNTO',               50, 'False', -16711681, 'PENDIENTE', 'False', 'False'),
               (6, 'COMENTARIO PUBLICO',    60, 'False', -8323328,  'PENDIENTE', 'True',  'True')
END

PRINT ''
PRINT '4. Tabla CRMNovedadesSeguimiento: Nuevo campo IdTipoComentarioNovedad'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD IdTipoComentarioNovedad int NULL
GO
PRINT ''
PRINT '4.1. Tabla CRMNovedadesSeguimiento: FK para el campo IdTipoComentarioNovedad'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT FK_CRMNovedadesSeguimiento_CRMTiposComentariosNovedades
FOREIGN KEY (IdTipoComentarioNovedad)
REFERENCES dbo.CRMTiposComentariosNovedades (IdTipoComentarioNovedad)
ON UPDATE  NO ACTION ON DELETE  NO ACTION 
PRINT ''
PRINT '4.2. Tabla CRMNovedadesSeguimiento: Datos por defecto para el campo IdTipoComentarioNovedad'
UPDATE NS
   SET IdTipoComentarioNovedad = TCN.IdTipoComentarioNovedad
  FROM CRMNovedadesSeguimiento NS
  LEFT JOIN CRMTiposComentariosNovedades TCN ON TCN.IdTipoNovedad = NS.IdTipoNovedad
 WHERE TCN.PorDefecto = 'True'
   AND NS.EsComentario = 'True'
   AND TCN.IdTipoComentarioNovedad IS NOT NULL

PRINT ''
PRINT '5. Tabla CRMNovedadesSeguimiento: Nuevo campo Activo'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD Activo bit NULL
GO
PRINT ''
PRINT '5.1. Tabla CRMNovedadesSeguimiento: Datos iniciales para el campo Activo'
UPDATE CRMNovedadesSeguimiento SET Activo = 'True'
PRINT ''
PRINT '5.2. Tabla CRMNovedadesSeguimiento: NOT NULL el campo Activo'
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN Activo bit NOT NULL

PRINT ''
PRINT '6. Tabla CRMNovedadesSeguimiento: Nuevo campo Comentario'
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN Comentario varchar(2000) NOT NULL

PRINT ''
PRINT '7. Tabla CRMNovedadesSeguimiento: Nuevo campo IdEstadoNovedad'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD IdEstadoNovedad int NULL
GO
PRINT ''
PRINT '7.1. Tabla CRMNovedadesSeguimiento: FK para el campo IdEstadoNovedad'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT FK_CRMNovedadesSeguimiento_CRMEstadosNovedades 
    FOREIGN KEY (IdEstadoNovedad) 
    REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '8. Tabla CRMEstadosNovedades: Nuevos campos AcumulaContador1 y AcumulaContador2'
ALTER TABLE dbo.CRMEstadosNovedades ADD AcumulaContador1 bit NULL
ALTER TABLE dbo.CRMEstadosNovedades ADD AcumulaContador2 bit NULL
GO
PRINT ''
PRINT '8.1. Tabla CRMEstadosNovedades: Datos iniciales para los campos AcumulaContador1 y AcumulaContador2'
UPDATE CRMEstadosNovedades SET AcumulaContador1 = 'False', AcumulaContador2 = 'False'
UPDATE CRMEstadosNovedades SET AcumulaContador1 = 'True' WHERE IdEstadoNovedad = 442
PRINT ''
PRINT '8.2. Tabla CRMEstadosNovedades: NOT NULL los campos AcumulaContador1 y AcumulaContador2'
ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN AcumulaContador1 bit NOT NULL
ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN AcumulaContador2 bit NOT NULL
GO


PRINT ''
PRINT '9. Tabla CRMNovedades: Nuevos campos Contador1 y Contador2'
ALTER TABLE dbo.CRMNovedades ADD Contador1 int NULL
ALTER TABLE dbo.CRMNovedades ADD Contador2 int NULL
GO
PRINT ''
PRINT '9.1. Tabla CRMNovedades: Valores iniciales para los campos Contador1 y Contador2'
UPDATE CRMNovedades SET Contador1 = 0, Contador2 = 0;
PRINT ''
PRINT '9.2. Tabla CRMNovedades: FK para los campos Contador1 y Contador2'
ALTER TABLE dbo.CRMNovedades ALTER COLUMN Contador1 int NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN Contador2 int NOT NULL
GO

SET ANSI_PADDING OFF
GO


PRINT ''
PRINT '10. Tabla EstadosTurismo: Nuevo estado de turismo'
IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN

    INSERT INTO [dbo].[EstadosTurismo]
               ([IdEstadoTurismo],[NombreEstadoTurismo],[Posicion]
               ,[Finalizado],[PorDefecto],[Color],[SolicitaPasajeros])
         VALUES
               (2, 'CONFIRMADA', 2,
                'False', 'False', -128,'True')

END

PRINT ''
PRINT '11. Menu ABM de Tipos de Comentarios'
IF dbo.ExisteFuncion('CRMABMs') = 'True'
BEGIN
    PRINT ''
    PRINT '11.1. Nueva Función ABM de Tipos de Comentarios'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CRMTiposComentariosNovABM', 'ABM de Tipos de Comentarios', 'ABM de Tipos de Comentarios', 'True', 'False', 'True', 'True'
        ,'CRMABMs', 590, 'Eniac.Win', 'CRMTiposComentariosNovedadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '11.2. Roles para función ABM de Tipos de Comentarios (copia de estado de novedades)'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'CRMTiposComentariosNovABM' FROM RolesFunciones WHERE IdFuncion = 'CRMEstadosNovedadesABM'
END

PRINT ''
PRINT '12. Tabla CRMNovedadesSeguimiento: Datos iniciale para el campo IdEstadoNovedad'
UPDATE NS
   SET NS.IdEstadoNovedad = N.IdEstadoNovedad
  FROM CRMNovedadesSeguimiento NS
 INNER JOIN CRMNovedades N ON N.IdTipoNovedad = NS.IdTipoNovedad
                          AND N.Letra = NS.Letra
                          AND N.CentroEmisor = NS.CentroEmisor
                          AND N.IdNovedad = NS.IdNovedad
