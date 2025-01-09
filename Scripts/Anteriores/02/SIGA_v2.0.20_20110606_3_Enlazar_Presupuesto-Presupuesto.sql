
UPDATE TiposComprobantes SET
    ComprobantesAsociados = '''PRESUP''',
    EsFacturador = 'True'
  WHERE IdTipoComprobante = 'PRESUP'
GO
