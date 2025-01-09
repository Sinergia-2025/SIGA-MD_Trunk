
--Poner Facturable el comprobante a Invocar para Reemplazar (conversion a Ticket Fiscal)

UPDATE TiposComprobantes 
   SET EsFacturable = 'True' 
 WHERE IdTipoComprobante = 'TICKET-CAJA'
GO
