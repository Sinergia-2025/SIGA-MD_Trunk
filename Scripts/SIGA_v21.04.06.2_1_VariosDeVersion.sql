PRINT ''
PRINT '4.1. Tabla AFIPTiposComprobantesTiposCbtes: Ajustar seteo para AFIPWSRequiereComprobanteAsociado'
UPDATE TP SET AFIPWSRequiereReferenciaTransferencia = 'True'
  FROM AFIPTiposComprobantesTiposCbtes Atp
 INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobanteSecundario = Atp.IdTipoComprobante
 WHERE Atp.IdAFIPTipoComprobante IN (201, 206, 211)
   AND TP.EsPreElectronico = 'True'
