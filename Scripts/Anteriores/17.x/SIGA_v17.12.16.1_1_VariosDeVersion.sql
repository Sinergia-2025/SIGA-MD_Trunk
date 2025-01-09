
PRINT '1. Tabla TiposComprobantes: Actualizo PEDIDOPROVEEDOR a EsFacturable = True.'
UPDATE TiposComprobantes 
   SET EsFacturable = 'True'
WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR';


PRINT ''
PRINT '2. Tabla TiposComprobantes: Actualizo TICKET a EsFiscal = False / Ajusto Descripcion.'
UPDATE TiposComprobantes 
   SET EsFiscal = 'False'
      ,Descripcion = 'Ticket'
      ,DescripcionAbrev = 'Ticket'
WHERE IdTipoComprobante = 'TICKET';
