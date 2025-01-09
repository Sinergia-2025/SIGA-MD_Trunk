SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Tabla Ventas: Cambiar campos Observacion a VARCAHR(MAX)'
ALTER TABLE Ventas ALTER COLUMN Observacion VARCHAR(MAX) NULL
IF dbo.ExisteTabla('MovimientosVentas') = 1
BEGIN
    ALTER TABLE MovimientosVentas ALTER COLUMN Observacion VARCHAR(MAX) NULL
END
IF dbo.ExisteTabla('MovimientosStock') = 1
BEGIN
    ALTER TABLE MovimientosStock ALTER COLUMN Observacion VARCHAR(MAX) NULL
END
ALTER TABLE CuentasCorrientes ALTER COLUMN Observacion VARCHAR(MAX) NULL
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN Observacion VARCHAR(MAX) NULL

PRINT ''
PRINT '2. Tabla Aplicaciones: Agregar campo PropietarioAplicacion'
IF dbo.ExisteCampo('Aplicaciones', 'PropietarioAplicacion') = 0
BEGIN
    ALTER TABLE dbo.Aplicaciones ADD PropietarioAplicacion varchar(10) NULL
END
GO
PRINT ''
PRINT '2.1. Tabla Aplicaciones: Campo PropietarioAplicacion actualizar registros pre-existentes'
UPDATE Aplicaciones SET PropietarioAplicacion = 'PROPIO' WHERE PropietarioAplicacion IS NULL;  --PROPIO / TERCEROS
PRINT ''
PRINT '2.2. Tabla Aplicaciones: Campo PropietarioAplicacion NOT NULL'
ALTER TABLE dbo.Aplicaciones ALTER COLUMN PropietarioAplicacion varchar(10) NOT NULL
GO

PRINT ''
PRINT '3. Nueva Tabla: CRMMotivosNovedades'
IF dbo.ExisteTabla('CRMMotivosNovedades') = 0
BEGIN
    CREATE TABLE CRMMotivosNovedades(
	    IdMotivoNovedad int NOT NULL,
	    NombreMotivoNovedad varchar(100) NOT NULL,
	    Posicion int NOT NULL,
	    IdTipoNovedad varchar(10) NOT NULL,
     CONSTRAINT PK_CRMMotivosNovedades PRIMARY KEY CLUSTERED (IdMotivoNovedad ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '3.1. Tabla CRMMotivosNovedades: FK_CRMMotivosNovedades_CRMTiposNovedades'
IF dbo.ExisteFK('FK_CRMMotivosNovedades_CRMTiposNovedades') = 0
BEGIN
    ALTER TABLE dbo.CRMMotivosNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMMotivosNovedades_CRMTiposNovedades FOREIGN KEY(IdTipoNovedad)
    REFERENCES dbo.CRMTiposNovedades (IdTipoNovedad)
    ALTER TABLE dbo.CRMMotivosNovedades CHECK CONSTRAINT FK_CRMMotivosNovedades_CRMTiposNovedades
END
GO

PRINT ''
PRINT '4. Tabla Aplicaciones: Crear aplicación A DEFINIR de Tercero'
IF NOT EXISTS(SELECT * FROM Aplicaciones WHERE PropietarioAplicacion = 'TERCERO')
BEGIN
    INSERT INTO Aplicaciones (IdAplicacion, NombreAplicacion, IdAplicacionBase, PropietarioAplicacion)
                      VALUES ('A DEFINIR', 'A DEFINIR', NULL, 'TERCERO')
END
PRINT ''
PRINT '4.1. Tabla CRMMotivosNovedades: Crear motivo A DEFINIR'
IF NOT EXISTS(SELECT * FROM CRMMotivosNovedades)
BEGIN
    INSERT INTO CRMMotivosNovedades (IdMotivoNovedad, NombreMotivoNovedad, Posicion, IdTipoNovedad)
                             VALUES (1, 'A DEFINIR', 1, 'PROSP')
END
GO

PRINT ''
PRINT '4.2. Tabla CRMNovedades: Nuevo campo IdAplicacionTerceros'
IF dbo.ExisteCampo('CRMNovedades', 'IdAplicacionTerceros') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD IdAplicacionTerceros varchar(20) NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdAplicacionTerceros varchar(20) NULL
END
PRINT ''
PRINT '4.3. Tabla CRMNovedades: Nuevo campo IdMotivoNovedad'
IF dbo.ExisteCampo('CRMNovedades', 'IdMotivoNovedad') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD IdMotivoNovedad int NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdMotivoNovedad int NULL
END
GO

PRINT ''
PRINT '4.4. Tabla CRMNovedades: Setear IdMotivoNovedad y IdAplicacionTerceros como A DEFINIR para Seguimiento de Prospectos'
UPDATE CRMNovedades
   SET IdAplicacionTerceros = 'A DEFINIR'
     , IdMotivoNovedad = 1
 WHERE IdTipoNovedad = 'PROSP'
   AND IdAplicacionTerceros IS NULL

PRINT ''
PRINT '4.5. Tabla CRMTiposNovedadesDinamicos: Agregar Dinamicos de Motivos y Aplicacion de terceros a Seguimiento de Prospectos'
IF EXISTS (SELECT * FROM CRMNovedades WHERE IdTipoNovedad = 'PROSP') AND
   NOT EXISTS (SELECT * FROM CRMTiposNovedadesDinamicos WHERE IdTipoNovedad = 'PROSP' AND IdNombreDinamico = 'MOTIVOS')
BEGIN
    DECLARE @max int = ISNULL((SELECT MAX(Orden) FROM CRMTiposNovedadesDinamicos WHERE IdTipoNovedad = 'PROSP'), 0)
    INSERT INTO CRMTiposNovedadesDinamicos
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden)
    VALUES ('PROSP', 'MOTIVOS', 'False', @max + 10),
           ('PROSP', 'APLICACIONTERCERO', 'False', @max + 20)
END
GO

PRINT ''
PRINT '5. Tabla CRMNovedades: Agregar campo ComentarioPrincipal'
IF dbo.ExisteCampo('CRMNovedades', 'ComentarioPrincipal') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD ComentarioPrincipal varchar(10) NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD ComentarioPrincipal varchar(10) NULL
END
GO
PRINT ''
PRINT '5.1. Tabla CRMNovedades: Indicar ComentarioPrincipal como Ninguno a todo'
UPDATE CRMNovedades SET ComentarioPrincipal = 'Ninguno' WHERE ComentarioPrincipal IS NULL;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN ComentarioPrincipal varchar(10) NOT NULL
GO

PRINT ''
PRINT '5.2. Tabla CRMNovedadesSeguimiento: Agregar campo ComentarioPrincipal'
IF dbo.ExisteCampo('CRMNovedadesSeguimiento', 'ComentarioPrincipal') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedadesSeguimiento ADD ComentarioPrincipal bit NULL
END
GO
PRINT ''
PRINT '5.3. Tabla CRMNovedadesSeguimiento: Indicar ComentarioPrincipal en False a todos los seguimientos'
UPDATE CRMNovedadesSeguimiento SET ComentarioPrincipal = 'False' WHERE ComentarioPrincipal IS NULL;
PRINT ''
PRINT '5.4. Tabla CRMNovedadesSeguimiento: Campo ComentarioPrincipal NOT NULL'
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN ComentarioPrincipal bit NOT NULL
GO

PRINT ''
PRINT '6. Tabla Clientes: Modifica campos IdEstadoCivil'
DECLARE @IdEstado AS Integer
SET @IdEstado = (SELECT IdEstadoCivil FROM EstadosCiviles WHERE NombreEstadoCivil = 'A Definir') 
BEGIN
    UPDATE Clientes SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
    UPDATE Prospectos SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
END
GO

PRINT ''
PRINT '6.1. Tabla Estados Civiles: Elimina IdEstadoCivil = 0'
BEGIN
	DELETE FROM EstadosCiviles WHERE IdEstadoCivil = 0
END
GO
