
UPDATE TiposComprobantes 
   SET LetrasHabilitadas = 'A,B,C,E'
 WHERE LetrasHabilitadas = 'A,B,C'
   AND EsFiscal = 'False'
GO
