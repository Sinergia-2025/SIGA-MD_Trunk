
ALTER TABLE TiposComprobantesLetras ADD CantidadCopias int null
GO

UPDATE TiposComprobantesLetras
 SET CantidadCopias =   
       ( SELECT CantidadCopias FROM TiposComprobantes TC
           WHERE TiposComprobantesLetras.IdTipoComprobante = TC.IdTipoComprobante
         )
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN CantidadCopias int not null
GO
