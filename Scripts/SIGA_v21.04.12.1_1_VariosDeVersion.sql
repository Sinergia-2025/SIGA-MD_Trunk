PRINT ''
PRINT '1. Tabla CRMTiposNovedadesDinamicos'
 IF dbo.BaseConCuit('33631312379')  = 'True'
BEGIN
    INSERT CRMTiposNovedadesDinamicos 
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden) 
    VALUES ('TICKETS', 'OBSERVACION', 'True', 11)
END

PRINT ''
PRINT '2. Tabla CRMNovedades: Nuevo Campo Observacion'
ALTER TABLE CRMNovedades ADD Observacion varchar(200) null
GO

PRINT ''
PRINT '3. Tabla AuditoriaCRMNovedades: Nuevo Campo Observacion'
ALTER TABLE AuditoriaCRMNovedades ADD Observacion varchar(200) null
GO
