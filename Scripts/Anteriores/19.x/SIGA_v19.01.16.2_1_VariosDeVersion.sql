
PRINT ''
PRINT '1. Tabla Parametros: Renombrar CLIENTEUTILIZATABADICIONALES por EXTRASSINERGIA.'
GO
UPDATE Parametros
  SET IdParametro = 'EXTRASSINERGIA'
    , DescripcionParametro = 'Utiliza Extra Sinergias'
WHERE IdParametro = 'CLIENTEUTILIZATABADICIONALES'
GO


PRINT ''
PRINT '2. Tabla TiposComprobantes: Quito "E" a ePRE-Comprobantes.'
GO
UPDATE TiposComprobantes
   SET LetrasHabilitadas = REPLACE(LetrasHabilitadas,',E','')
 WHERE EsPreElectronico = 'True'
GO


PRINT ''
PRINT '2. Tabla AFIPTiposComprobantesTiposCbtes: Borro todo aquelle con letra "E".'
GO
DELETE AFIPTiposComprobantesTiposCbtes
 WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE EsPreElectronico = 'True')
  AND Letra = 'E'
GO