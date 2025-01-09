IF dbo.ExisteCampo('TiposComprobantes', 'ClaseComprobante') = 0
BEGIN
    ALTER TABLE TiposComprobantes ADD ClaseComprobante VARCHAR(15) NULL
END
GO
UPDATE TiposComprobantes SET ClaseComprobante = '';
ALTER TABLE TiposComprobantes ALTER COLUMN ClaseComprobante VARCHAR(15) NOT NULL
GO

UPDATE TC
   SET ClaseComprobante = 'NOTADEB'
  FROM AFIPTiposComprobantesTiposCbtes TCC
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = TCC.IdTipoComprobante
 WHERE TCC.IdAFIPTipoComprobante IN (002, 007, 012, 020, 037, 045, 046, 047, 
                                 052, 115, 116, 117, 120, 202, 207, 212)
