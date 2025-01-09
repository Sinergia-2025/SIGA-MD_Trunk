
ALTER TABLE TiposComprobantes ADD EsAnticipo bit null
GO

UPDATE TiposComprobantes SET EsAnticipo = 'False'
GO

UPDATE TiposComprobantes SET EsAnticipo = 'True'
 WHERE IdTipoComprobante like '%ANTICIPO%'
GO

ALTER TABLE TiposComprobantes ALTER COLUMN EsAnticipo bit not null
GO
