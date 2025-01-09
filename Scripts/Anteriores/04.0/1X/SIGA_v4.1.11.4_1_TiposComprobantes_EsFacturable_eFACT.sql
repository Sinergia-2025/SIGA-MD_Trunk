
PRINT '1. Ajusto el campo -EsFacturable- para los eComprobantes segun los Pre-Impresos'
GO
UPDATE TiposComprobantes
   SET EsFacturable = (SELECT EsFacturable FROM TiposComprobantes
                        WHERE IdTipoComprobante = 'FACT')
 WHERE IdTipoComprobante = 'eFACT'
GO

UPDATE TiposComprobantes
   SET EsFacturable = (SELECT EsFacturable FROM TiposComprobantes
                        WHERE IdTipoComprobante = 'NCRED')
 WHERE IdTipoComprobante = 'eNCRED'
GO

UPDATE TiposComprobantes
   SET EsFacturable = (SELECT EsFacturable FROM TiposComprobantes
                        WHERE IdTipoComprobante = 'NDEB')
 WHERE IdTipoComprobante = 'eNDEB'
GO

UPDATE TiposComprobantes
   SET EsFacturable = (SELECT EsFacturable FROM TiposComprobantes
                        WHERE IdTipoComprobante = 'NDEBCHEQRECH')
 WHERE IdTipoComprobante = 'eNDEBCHEQRECH'
GO


PRINT '2. Ajusto el campo -ComprobantesAsociados- para los eComprobantes segun los Pre-Impresos'
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'eFACT' + CHAR(39)
 WHERE Tipo = 'VENTAS'
   AND ComprobantesAsociados LIKE '%' + CHAR(39) + 'FACT' + CHAR(39) + '%' 
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'eNCRED' + CHAR(39)
 WHERE Tipo = 'VENTAS'
   AND ComprobantesAsociados LIKE '%' + CHAR(39) + 'NCRED' + CHAR(39) + '%' 
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'eNDEB' + CHAR(39)
 WHERE Tipo = 'VENTAS'
   AND ComprobantesAsociados LIKE '%' + CHAR(39) + 'NDEB' + CHAR(39) + '%' 
GO

UPDATE TiposComprobantes
   SET ComprobantesAsociados = ComprobantesAsociados + ',' + CHAR(39) + 'eNDEBCHEQRECH' + CHAR(39)
 WHERE Tipo = 'VENTAS'
   AND ComprobantesAsociados LIKE '%' + CHAR(39) + 'NDEBCHEQRECH' + CHAR(39) + '%' 
GO
