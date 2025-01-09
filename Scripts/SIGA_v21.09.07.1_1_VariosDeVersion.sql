ALTER TABLE dbo.CRMNovedades ADD ServiceLugarCompra varchar(100) NULL
ALTER TABLE dbo.CRMNovedades ADD ServiceLugarCompraFecha date NULL
ALTER TABLE dbo.CRMNovedades ADD ServiceLugarCompraTipoComprobante varchar(50) NULL
ALTER TABLE dbo.CRMNovedades ADD ServiceLugarCompraNumeroComprobante varchar(50) NULL
GO

UPDATE CRMNovedades
   SET ServiceLugarCompra = ''
     , ServiceLugarCompraTipoComprobante = ''
     , ServiceLugarCompraNumeroComprobante = ''
;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN ServiceLugarCompra varchar(100) NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN ServiceLugarCompraTipoComprobante varchar(50) NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN ServiceLugarCompraNumeroComprobante varchar(50) NOT NULL

ALTER TABLE dbo.AuditoriaCRMNovedades ADD ServiceLugarCompra varchar(100) NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD ServiceLugarCompraFecha date NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD ServiceLugarCompraTipoComprobante varchar(50) NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD ServiceLugarCompraNumeroComprobante varchar(50) NULL
GO

ALTER TABLE PedidosTiendasWeb ALTER COLUMN Adicional Varchar(200) NULL
GO

IF dbo.BaseConCuit('30716345501') = 1
BEGIN
    INSERT INTO CRMTiposNovedadesDinamicos
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden)
    SELECT IdTipoNovedad, 'SERVICELUGARCOMPRA', EsRequerido, Orden
      FROM CRMTiposNovedadesDinamicos
     WHERE IdNombreDinamico = 'SERVICE'
END
