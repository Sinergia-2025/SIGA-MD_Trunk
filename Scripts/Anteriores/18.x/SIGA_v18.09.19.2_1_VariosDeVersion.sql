
PRINT ''
PRINT '1. Nueva Pantalla: CRM\ABM de Versiones.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CRM')
 AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499')) -- HAR
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('VersionesABM', 'ABM de Versiones', 'ABM de Versiones', 'True', 'False', 'True', 'True',
              'CRM', 610, 'Eniac.Win', 'VersionesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'VersionesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm');
    END;


PRINT ''
PRINT '2. Pantalla: CRM\Aplicacion - Ajusto Nombre y Posicion.'
GO
  
UPDATE Funciones
   SET Nombre = 'ABM de Aplicaciones'
     , Descripcion = 'ABM de Aplicaciones'
     , Posicion = 490
 WHERE Id = 'AplicacionesABM'
GO


PRINT ''
PRINT '3. Nueva Tabla: Versiones y FKs.'
GO

/****** Object:  Table [dbo].[Versiones]    Script Date: 09/18/2018 17:12:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Versiones](
	[IdAplicacion] [varchar](20) NOT NULL,
	[NroVersion] [varchar](50) NOT NULL,
	[VersionFecha] [datetime] NOT NULL,
	[IdAplicacionBase] [varchar](20) NULL,
	[NroVersionAplicacionBase] [varchar](50) NULL,
	[VersionFramework] [varchar](20) NOT NULL,
	[VersionReportViewer] [varchar](20) NOT NULL,
	[VersionLenguaje] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Versiones] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[NroVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Aplicaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Versiones ADD CONSTRAINT
	FK_Versiones_Aplicaciones FOREIGN KEY
	(
	IdAplicacion
	) REFERENCES dbo.Aplicaciones
	(
	IdAplicacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Versiones ADD CONSTRAINT
	FK_Versiones_Aplicaciones_Base FOREIGN KEY
	(
	IdAplicacionBase
	) REFERENCES dbo.Aplicaciones
	(
	IdAplicacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Versiones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '4. Tabla CobradoresSucursales: Agrego Campo Observacion.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.CobradoresSucursales ADD Observacion varchar(100) NULL
GO
ALTER TABLE dbo.CobradoresSucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
