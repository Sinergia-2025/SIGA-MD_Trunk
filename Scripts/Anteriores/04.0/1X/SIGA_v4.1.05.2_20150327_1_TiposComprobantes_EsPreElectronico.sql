
ALTER TABLE TiposComprobantes ADD EsPreElectronico bit null
GO

UPDATE TiposComprobantes SET EsPreElectronico = 'False'
GO

UPDATE TiposComprobantes SET EsPreElectronico = 'True'
 WHERE IdTipoComprobante LIKE 'ePRE-%'
GO

ALTER TABLE TiposComprobantes ALTER COLUMN EsPreElectronico bit not null
GO

UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'eFACT'
 WHERE IdTipoComprobante = 'ePRE-FACT'
GO
 
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'eNCRED'
 WHERE IdTipoComprobante = 'ePRE-NCRED'
GO
 
UPDATE TiposComprobantes SET IdTipoComprobanteSecundario = 'eNDEB'
 WHERE IdTipoComprobante = 'ePRE-NDEB'
GO
