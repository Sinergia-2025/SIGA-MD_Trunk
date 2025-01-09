
UPDATE Impresoras 
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',PEDIDO'
 WHERE IdImpresora = 'NORMAL'
   AND ComprobantesHabilitados NOT LIKE '%,PEDIDO,%'
   AND 'PEDIDO' IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE IdTipoComprobante = 'PEDIDO')
GO
