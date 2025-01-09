
-- Acomodar los Nombres, el No Fiscal decir "Ticket" en descripcion.
 
UPDATE TiposComprobantes
   SET Descripcion = 'Ticket No Fiscal'
 WHERE IdTipoComprobante = 'TICKET-NOFISCAL';
 
UPDATE TiposComprobantes
   SET DescripcionAbrev = 'Ticket CF.'
 WHERE IdTipoComprobante = 'TICKET-F';
