
-- No permito emitir 'B', que lo haga con el Ticket comun
-- La HASAR no lo deja e igualmente no tiene sentido

UPDATE TiposComprobantes 
   SET LetrasHabilitadas = 'A,C'	
 WHERE IdTipoComprobante = 'TCK-FACT-F'
GO
