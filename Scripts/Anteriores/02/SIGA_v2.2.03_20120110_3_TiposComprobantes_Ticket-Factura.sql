
-- Ejecutar en los lugares con Fiscales EPSON

UPDATE TiposComprobantes 
   SET LetrasHabilitadas = 'A,B,C'	
 WHERE IdTipoComprobante = 'TCK-FACT-F'
GO
