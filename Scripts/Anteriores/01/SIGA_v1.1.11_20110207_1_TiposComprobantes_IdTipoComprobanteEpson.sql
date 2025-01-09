
ALTER TABLE TiposComprobantes ADD
	IdTipoComprobanteEpson char(1) NULL
GO


UPDATE TiposComprobantes SET
	IdTipoComprobanteEpson = 'F'
 WHERE IdTipoComprobante = 'FACT-F'
GO

UPDATE TiposComprobantes SET
	IdTipoComprobanteEpson = 'T'
 WHERE IdTipoComprobante = 'TCK-FACT-F'
GO

UPDATE TiposComprobantes SET
	IdTipoComprobanteEpson = 'N'
 WHERE IdTipoComprobante = 'NCRED-F'
GO


UPDATE TiposComprobantes SET
	IdTipoComprobanteEpson = '.'
 WHERE IdTipoComprobanteEpson IS NULL
GO


ALTER TABLE TiposComprobantes ALTER COLUMN
	IdTipoComprobanteEpson char(1) NOT NULL
GO

