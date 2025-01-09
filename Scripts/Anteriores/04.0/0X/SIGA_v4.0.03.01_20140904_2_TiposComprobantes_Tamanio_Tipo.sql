
ALTER TABLE TiposComprobantes ALTER COLUMN Tipo varchar(15) NOT NULL
GO

UPDATE TiposComprobantes
   SET Tipo = 'PEDIDOSCLIE'
     , UsaFacturacion = 'True'
 WHERE IdTipoComprobante = 'PEDIDO'
GO

