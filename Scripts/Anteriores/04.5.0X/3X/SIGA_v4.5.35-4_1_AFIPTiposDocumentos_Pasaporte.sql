IF NOT EXISTS (SELECT 1 FROM TiposDocumento WHERE TipoDocumento = 'PAS')
    BEGIN
		  INSERT INTO TiposDocumento
           (TipoDocumento, NombreTipoDocumento, EsAutoincremental)
     VALUES
           ('PAS', 'Pasaporte', 'False');
    END;

UPDATE AFIPTiposDocumentos
   SET TipoDocumento = 'PAS'
 WHERE IdAFIPTipoDocumento = 94
GO
