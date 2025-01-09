
PRINT ''
PRINT '1.1. TiposComprobantes: Valores por defecto en FALSO a campo EsComercial en Liquido/Liquido NC.'
GO
UPDATE TiposComprobantes 
  SET EsComercial = 'False' 
WHERE IdTipoComprobante IN ('LIQUIDO','LIQUIDO-NC')
GO
