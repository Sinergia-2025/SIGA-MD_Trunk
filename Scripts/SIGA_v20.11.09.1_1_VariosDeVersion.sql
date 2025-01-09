IF dbo.BaseConCuit('30708422254') = 1
  PRINT ''
  PRINT '1. Cambio de comprobante a Duplicado: ENC Autopartes'
  UPDATE TiposComprobantesLetras SET ArchivoAImprimir = '376_eComprobante_x_2.rdlc', IdTipoImpresionFiscalArchivoAImprimir = 2
  	WHERE ArchivoAImprimir = '376_eComprobante.rdlc'
GO