PRINT ''
PRINT '1. Tabla CRMEstadosNovedades: Nuevo campo RequiereComentarios'
ALTER TABLE dbo.CRMEstadosNovedades ADD RequiereComentarios bit NULL
GO
PRINT ''
PRINT '1.1. Tabla CRMEstadosNovedades: Valor por defecto para RequiereComentarios'
UPDATE CRMEstadosNovedades SET RequiereComentarios = 0;
PRINT ''
PRINT '1.2. Tabla CRMEstadosNovedades: NOT NULL para campo RequiereComentarios'
ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN RequiereComentarios bit NULL
GO
IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '1.3. Tabla CRMEstadosNovedades: Definir valor True en RequiereComentarios para HAR'
    UPDATE CRMEstadosNovedades SET RequiereComentarios = 1
     WHERE IdEstadoNovedad IN (404, 451, 425, 472, 476, 447, 442, 407,  -- PENDIENTE
                               433, 470, 461);                          -- TICKET
END


PRINT ''
PRINT '2. Tabla CuentasCorrientes: Nuevo Campo IdEmbarcacion'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CuentasCorrientes' AND COLUMN_NAME = 'IdEmbarcacion')
BEGIN
    ALTER TABLE CuentasCorrientes ADD IdEmbarcacion bigint NULL;
END
GO

PRINT ''
PRINT '3. Tabla CuentasCorrientesPagos: Nuevo Campo IdEmbarcacion'
PRINT ''
PRINT 'B1. Insertar Nuevo Campo: IdEmbarcacion'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CuentasCorrientesPagos' AND COLUMN_NAME = 'IdEmbarcacion')
BEGIN
    ALTER TABLE CuentasCorrientesPagos ADD IdEmbarcacion bigint NULL;
END
GO

PRINT ''
PRINT '4. Tabla Ventas: Nuevos Campos'
BEGIN 
    PRINT ''
    PRINT '4.1. Tabla Ventas: Nuevo Campo IdEmbarcacion'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'IdEmbarcacion')
    BEGIN
        ALTER TABLE Ventas ADD IdEmbarcacion bigint NULL;
    END
    PRINT ''
    PRINT '4.2. Tabla Ventas: Nuevo Campo CodigoEmbarcacion'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'CodigoEmbarcacion')
    BEGIN
        ALTER TABLE Ventas ADD CodigoEmbarcacion bigint NULL;
    END
    PRINT ''
    PRINT '4.3. Tabla Ventas: Nuevo Campo NombreEmbarcacion'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'NombreEmbarcacion')
    BEGIN
        ALTER TABLE Ventas ADD NombreEmbarcacion Varchar(100) NULL;
    END
    PRINT ''
    PRINT '4.4. Tabla Ventas: Nuevo Campo IdCategoriaEmbarcacion'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'IdCategoriaEmbarcacion')
    BEGIN
        ALTER TABLE Ventas ADD IdCategoriaEmbarcacion int NULL;
    END
    PRINT ''
    PRINT '4.5. Tabla Ventas: Nuevo Campo NombreCategoriaEmbarcacion'
    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'NombreCategoriaEmbarcacion')
    BEGIN
        ALTER TABLE Ventas ADD NombreCategoriaEmbarcacion Varchar(30) NULL;
    END
END
GO

PRINT ''
PRINT '5. Tabla Embarcaciones: Nuevos Campos'
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Embarcaciones')
BEGIN
    ALTER TABLE dbo.Embarcaciones ADD TieneObservacionesTurno bit NULL
    ALTER TABLE dbo.Embarcaciones ADD ObservacionesTurno varchar(1000) NULL
    ALTER TABLE dbo.Embarcaciones ADD BloqueaTurno bit NULL
END
GO

PRINT ''
PRINT '5.1. Tabla Embarcaciones: Nuevos Campos'
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Embarcaciones')
BEGIN
    UPDATE Embarcaciones
       SET TieneObservacionesTurno   = 'False'
         , ObservacionesTurno        = ''
         , BloqueaTurno              = 'False';

    ALTER TABLE dbo.Embarcaciones ALTER COLUMN TieneObservacionesTurno bit NOT NULL
    ALTER TABLE dbo.Embarcaciones ALTER COLUMN ObservacionesTurno varchar(1000) NOT NULL
    ALTER TABLE dbo.Embarcaciones ALTER COLUMN BloqueaTurno bit NOT NULL
END
GO

PRINT ''
PRINT '6. Parametros de Liquidacion por CtaCte SISEN.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'CUENTACORRIENTEEMBARCACION' AS IdParametro, 
            'False' ValorParametro, 
            'Cargos' CategoriaParametro, 
            'CUENTACORRIENTEEMBARCACION' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
GO


PRINT ''
PRINT '7. Funciones de Menu: Nueva opciones de Informe de CRM Cambios de Estado'
DELETE rolesfunciones   WHERE idfuncion LIKE 'InformeDeNovEstados%'
DELETE bitacora         WHERE idfuncion LIKE 'InformeDeNovEstados%'
DELETE funciones        WHERE id        LIKE 'InformeDeNovEstados%'

    INSERT INTO Funciones
         (Id, Nombre, Descripcion, 
          EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,Plus, Express, Basica, PV, EsMDIChild)
    SELECT 'InformeDeNovEstados' + IdTipoNovedad, 'Informe de ' + NombreTipoNovedad + ' Cambios de Estado', 'Informe de ' + IdTipoNovedad + ' Cambios de Estado', 
          'True', 'False', 'True', 'True', 
          'CRM', 300 + ROW_NUMBER ( ) OVER ( ORDER BY IdTipoNovedad ), 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, IdTipoNovedad,'X','N','N','N', 'True'
      FROM CRMTiposNovedades
    

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT RF.IdRol, 'InformeDeNovEstados' + IdTipoNovedad
      FROM RolesFunciones RF
     CROSS JOIN CRMTiposNovedades N
     INNER JOIN Funciones F ON F.Id = 'InformeDeNovedades' + N.IdTipoNovedad
     WHERE RF.IdFuncion = F.Id

