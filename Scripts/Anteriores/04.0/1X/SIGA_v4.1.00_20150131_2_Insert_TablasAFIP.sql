
--Insertar a las tablas de AFIP la relación de los tickets fiscales para el CitiVentas

PRINT '81: TCK-FACT-F - A';
UPDATE AFIPTiposComprobantes 
	SET IdTipoComprobante = 'TCK-FACT-F'
	  , Letra = 'A'
WHERE IdAFIPTipoComprobante = 81;

PRINT '82: TCK-FACT-F - B';
UPDATE AFIPTiposComprobantes 
	SET IdTipoComprobante = 'TCK-FACT-F'
	  , Letra = 'B'
WHERE IdAFIPTipoComprobante = 82;

PRINT '83: TICKET-F - B';
UPDATE AFIPTiposComprobantes 
	SET IdTipoComprobante = 'TICKET-F'
	  , Letra = 'B'
WHERE IdAFIPTipoComprobante = 83;
