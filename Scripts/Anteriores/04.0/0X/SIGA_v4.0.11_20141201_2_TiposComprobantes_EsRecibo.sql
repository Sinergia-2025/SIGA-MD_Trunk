
ALTER TABLE TiposComprobantes ADD EsRecibo bit null
GO

UPDATE TiposComprobantes SET EsRecibo = 'False'
GO

UPDATE TiposComprobantes SET EsRecibo = 'True'
 WHERE IdTipoComprobante like '%RECIBO%'
GO

ALTER TABLE TiposComprobantes ALTER COLUMN EsRecibo bit not null
GO
