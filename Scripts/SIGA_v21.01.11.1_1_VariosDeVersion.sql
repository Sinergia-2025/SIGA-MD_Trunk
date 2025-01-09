PRINT ''
PRINT '1. Tabla CRMNovedades: Nuevos campos FechaEntregado, FechaFinalizado, IdEstadoNovedadEntregado y IdEstadoNovedadFinalizado'
ALTER TABLE dbo.CRMNovedades ADD FechaEntregado datetime NULL
ALTER TABLE dbo.CRMNovedades ADD FechaFinalizado datetime NULL
ALTER TABLE dbo.CRMNovedades ADD IdEstadoNovedadEntregado int NULL
ALTER TABLE dbo.CRMNovedades ADD IdEstadoNovedadFinalizado int NULL
GO

PRINT ''
PRINT '1.1. Tabla CRMNovedades: Datos Históricos para FechaEntregado, FechaFinalizado, IdEstadoNovedadEntregado y IdEstadoNovedadFinalizado'
UPDATE N
   SET FechaFinalizado = FechaEstadoNovedad
     , IdEstadoNovedadFinalizado = N.IdEstadoNovedad
     --, FechaEntregado = FechaEstadoNovedad
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE E.Finalizado = 'True'

ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMEstadosNovedades_Entregado
    FOREIGN KEY (IdEstadoNovedadEntregado) 
    REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMEstadosNovedades_Finalizado
    FOREIGN KEY (IdEstadoNovedadFinalizado)
    REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '1.2. Tabla AuditoriaCRMNovedades: Datos Históricos para FechaEntregado, FechaFinalizado, IdEstadoNovedadEntregado y IdEstadoNovedadFinalizado'
ALTER TABLE dbo.AuditoriaCRMNovedades ADD FechaEntregado datetime NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD FechaFinalizado datetime NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdEstadoNovedadEntregado int NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdEstadoNovedadFinalizado int NULL
GO


PRINT ''
PRINT '2. Tabla CRMEstadosNovedades: Nuevo campo Entregado'
ALTER TABLE dbo.CRMEstadosNovedades ADD Entregado VARCHAR(10) NULL
GO
PRINT ''
PRINT '2.1. Tabla CRMEstadosNovedades: Datos historicos para Entregado = NoAfecta'
UPDATE CRMEstadosNovedades SET Entregado = 'NoAfecta';
PRINT ''
PRINT '2.2. Tabla CRMEstadosNovedades: NOT NULL para Entregado'
ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN Entregado VARCHAR(10) NOT NULL
GO

PRINT ''
PRINT '2.3. Tabla CRMEstadosNovedades: Datos historicos para Entregado = Graba/Limpia'
UPDATE CRMEstadosNovedades
   SET Entregado = CASE WHEN IdEstadoNovedad IN (449, 448, 477, 432, 436, 434, 423, 403, 450, 404) THEN 'Graba' ELSE CASE WHEN IdEstadoNovedad IN (442, 461) THEN 'Limpia' ELSE 'NoAfecta' END END
 WHERE IdTipoNovedad IN ('TICKETS', 'PENDIENTE')
   AND IdEstadoNovedad IN (442, 448, 449, 477, 461, 432, 436, 434, 423, 403, 450, 404)

PRINT ''
PRINT '2.4. Tabla CRMEstadosNovedades: Datos historicos para Entregado = Graba Cuando es Finalizado y no es Ticket/Pendiente/Actividad'
UPDATE CRMEstadosNovedades
   SET Entregado = 'Graba'
 WHERE NOT IdTipoNovedad IN ('TICKETS', 'PENDIENTE', 'ACTIVIDAD')
   AND Finalizado = 'True'


PRINT ''
PRINT '3. Opción de menú Archivar Adjuntos de CRM'
IF dbo.ExisteFuncion('CRM') = 1
BEGIN
    PRINT ''
    PRINT '3.1. Creo opción de menú Archivar Adjuntos de CRM'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CRMArchivarAdjuntos', 'Archivar Adjuntos de CRM', 'Archivar Adjuntos de CRM', 'True', 'False', 'True', 'True'
        ,'CRM', 850, 'Eniac.Win', 'CRMArchivarAdjuntos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.2. Asigno roles a opción de menú Archivar Adjuntos de CRM'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'CRMArchivarAdjuntos' FROM RolesFunciones WHERE IdFuncion = 'Backups'
END


PRINT ''
PRINT '4. Parametro MESESARCHIVARCRMFINALIZADOS: Default = 6'
DECLARE @idParametro VARCHAR(MAX) = 'MESESARCHIVARCRMFINALIZADOS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'CRM: Meses a archivar adjuntos de finalizados'
DECLARE @valorParametro VARCHAR(MAX) = '6'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

