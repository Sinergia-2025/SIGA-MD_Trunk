
PRINT ''
PRINT '1. Tabla CRMTiposNovedades: Agrego campo LetrasHabilitadas y Asigno "X".'
GO
ALTER TABLE dbo.CRMTiposNovedades ADD LetrasHabilitadas varchar(20) NULL
GO
UPDATE CRMTiposNovedades SET LetrasHabilitadas = 'X'
GO
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN LetrasHabilitadas varchar(20) NOT NULL
GO


PRINT ''
PRINT '2. Tabla CRMNovedadesSeguimiento: Borro FKs y PK.'
GO
ALTER TABLE [dbo].[CRMNovedadesSeguimiento] DROP CONSTRAINT [FK_CRMNovedadesSeguimiento_CRMNovedades]
GO
ALTER TABLE [dbo].[CRMNovedades] DROP CONSTRAINT [FK_CRMNovedades_CRMNovedades]
GO
ALTER TABLE dbo.CRMNovedades DROP CONSTRAINT PK_CRMNovedades
GO


PRINT ''
PRINT '3. Tabla CRMNovedades: Agrego campos Letra, CentroEmisor, LetraPadre, CentroEmisorPadre y Actualizo.'
GO
ALTER TABLE dbo.CRMNovedades ADD Letra varchar(1) NULL
ALTER TABLE dbo.CRMNovedades ADD CentroEmisor smallint NULL
ALTER TABLE dbo.CRMNovedades ADD LetraPadre varchar(1) NULL
ALTER TABLE dbo.CRMNovedades ADD CentroEmisorPadre smallint NULL
GO
UPDATE CRMNovedades SET Letra = 'X', CentroEmisor = 1
GO
ALTER TABLE dbo.CRMNovedades ALTER COLUMN Letra varchar(1) NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN CentroEmisor smallint NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN IdNovedad bigint NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN IdNovedadPadre bigint NULL
GO


PRINT ''
PRINT '4. Tabla CRMNovedades: Creo PK.'
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT PK_CRMNovedades
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


PRINT ''
PRINT '5. Tabla CRMNovedadesSeguimiento: Borro PK.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento DROP CONSTRAINT PK_CRMNovedadesSeguimiento
GO


PRINT ''
PRINT '6. Tabla CRMNovedadesSeguimiento: Agrego campos Letra, CentroEmisor y Actualizo.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD Letra varchar(1) NULL
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CentroEmisor smallint NULL
GO
UPDATE CRMNovedadesSeguimiento SET Letra = 'X', CentroEmisor = 1
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN Letra varchar(1) NOT NULL
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN CentroEmisor smallint NOT NULL
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN IdNovedad bigint NOT NULL
GO


PRINT ''
PRINT '7. Tabla CRMNovedadesSeguimiento: Creo PK.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT PK_CRMNovedadesSeguimiento
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad,IdSeguimiento)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


PRINT ''
PRINT '8. Tabla CRMNovedadesSeguimientoAdjuntos: Borro PK.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos DROP CONSTRAINT PK_CRMNovedadesSeguimientoAdjuntos
GO


PRINT ''
PRINT '9. Tabla CRMNovedadesSeguimientoAdjuntos: Agrego campos Letra, CentroEmisor y Actualizo.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ADD Letra varchar(1) NULL
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ADD CentroEmisor smallint NULL
GO
UPDATE CRMNovedadesSeguimientoAdjuntos SET Letra = 'X', CentroEmisor = 1
GO
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ALTER COLUMN Letra varchar(1) NOT NULL
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ALTER COLUMN CentroEmisor smallint NOT NULL
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ALTER COLUMN IdNovedad bigint NOT NULL
GO


PRINT ''
PRINT '10. Tabla CRMNovedadesSeguimientoAdjuntos: Creo PK.'
GO
--ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos DROP CONSTRAINT PK_CRMNovedadesSeguimientoAdjuntos
--GO                                                              
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ADD CONSTRAINT PK_CRMNovedadesSeguimientoAdjuntos
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad,IdSeguimiento)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


PRINT ''
PRINT '11. Tabla CRMNovedades: Creo FK_CRMNovedades_CRMNovedades_Padre.'
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMNovedades_Padre
    FOREIGN KEY (IdTipoNovedad,LetraPadre,CentroEmisorPadre,IdNovedadPadre)
    REFERENCES dbo.CRMNovedades (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '12. Tabla CRMNovedadesSeguimiento: Creo FK_CRMNovedadesSeguimiento_CRMNovedades.'
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT FK_CRMNovedadesSeguimiento_CRMNovedades
    FOREIGN KEY (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    REFERENCES dbo.CRMNovedades (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
