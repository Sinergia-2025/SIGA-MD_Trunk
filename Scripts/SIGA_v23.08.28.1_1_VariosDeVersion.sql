PRINT ''
PRINT '1. Tabla Clientes: Modifica campos IdEstadoCivil'
DECLARE @IdEstado AS Integer
SET @IdEstado = (SELECT IdEstadoCivil FROM EstadosCiviles WHERE NombreEstadoCivil = 'A Definir') 
BEGIN
	UPDATE Clientes SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
    UPDATE Prospectos SET IdEstadoCivil = @IdEstado WHERE IdEstadoCivil = 0
END
GO

PRINT ''
PRINT '2. Tabla Estados Civiles: Elimina IdEstadoCivil = 0'
BEGIN
	DELETE FROM EstadosCiviles WHERE IdEstadoCivil = 0
END
GO


PRINT ''
PRINT '3. FACTURACIONCANTIDADCARACTERESOBSERVACIONES'
BEGIN

	DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADCARACTERESOBSERVACIONES'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Cantidad caracteres en Observaciones'
	DECLARE @valorParametro VARCHAR(MAX) = '100'
	IF dbo.BaseConCuit('30711915695') = 1
		SET @valorParametro = '300'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
	;
END
GO

PRINT ''
PRINT '4. Tabla Ventas'
BEGIN
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
END
GO

PRINT ''
PRINT '5. InformeSaldosCajas'
IF dbo.ExisteFuncion('Caja') = 1 AND dbo.ExisteFuncion('InformeSaldosCajas') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InformeSaldosCajas', 'Informe Saldos de Cajas', 'Informe de Saldos de Cajas', 'True', 'False', 'True', 'True'
        ,'Caja', 145, 'Eniac.Win', 'InformeSaldosCajas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeSaldosCajas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END
GO

IF dbo.ExisteCampo('Aplicaciones', 'PropietarioAplicacion') = 0
BEGIN
    ALTER TABLE dbo.Aplicaciones ADD PropietarioAplicacion varchar(10) NULL
END
GO
UPDATE Aplicaciones SET PropietarioAplicacion = 'PROPIO' WHERE PropietarioAplicacion IS NULL;  --PROPIO / TERCEROS
ALTER TABLE dbo.Aplicaciones ALTER COLUMN PropietarioAplicacion varchar(10) NOT NULL
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
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

IF dbo.ExisteFK('FK_CRMMotivosNovedades_CRMTiposNovedades') = 0
BEGIN
    ALTER TABLE dbo.CRMMotivosNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMMotivosNovedades_CRMTiposNovedades FOREIGN KEY(IdTipoNovedad)
    REFERENCES dbo.CRMTiposNovedades (IdTipoNovedad)
    ALTER TABLE dbo.CRMMotivosNovedades CHECK CONSTRAINT FK_CRMMotivosNovedades_CRMTiposNovedades
END
GO

IF NOT EXISTS(SELECT * FROM Aplicaciones WHERE PropietarioAplicacion = 'TERCERO')
BEGIN
    INSERT INTO Aplicaciones (IdAplicacion, NombreAplicacion, IdAplicacionBase, PropietarioAplicacion)
                      VALUES ('A DEFINIR', 'A DEFINIR', NULL, 'TERCERO')
END
IF NOT EXISTS(SELECT * FROM CRMMotivosNovedades)
BEGIN
    INSERT INTO CRMMotivosNovedades (IdMotivoNovedad, NombreMotivoNovedad, Posicion, IdTipoNovedad)
                             VALUES (1, 'A DEFINIR', 1, 'PROSP')
END
GO

IF dbo.ExisteCampo('CRMNovedades', 'IdAplicacionTerceros') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD IdAplicacionTerceros varchar(20) NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdAplicacionTerceros varchar(20) NULL
END
IF dbo.ExisteCampo('CRMNovedades', 'IdMotivoNovedad') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD IdMotivoNovedad int NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdMotivoNovedad int NULL
END
GO

UPDATE CRMNovedades
   SET IdAplicacionTerceros = 'A DEFINIR'
     , IdMotivoNovedad = 1
 WHERE IdTipoNovedad = 'PROSP'
   AND IdAplicacionTerceros IS NULL

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

IF dbo.ExisteFuncion('CRMABMs') = 1 AND dbo.ExisteFuncion('CRMMotivosNovedadesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CRMMotivosNovedadesABM', 'ABM Motivos de Novedades', 'ABM Motivos de Novedades', 'True', 'False', 'True', 'True'
        ,'CRMABMs', 145, 'Eniac.Win', 'CRMMotivosNovedadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMMotivosNovedadesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteCampo('CRMNovedades', 'ComentarioPrincipal') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD ComentarioPrincipal varchar(10) NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD ComentarioPrincipal varchar(10) NULL
END
GO
UPDATE CRMNovedades SET ComentarioPrincipal = 'Ninguno' WHERE ComentarioPrincipal IS NULL;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN ComentarioPrincipal varchar(10) NOT NULL
GO

IF dbo.ExisteCampo('CRMNovedadesSeguimiento', 'ComentarioPrincipal') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedadesSeguimiento ADD ComentarioPrincipal bit NULL
END
GO
UPDATE CRMNovedadesSeguimiento SET ComentarioPrincipal = 'False' WHERE ComentarioPrincipal IS NULL;
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN ComentarioPrincipal bit NOT NULL
GO
