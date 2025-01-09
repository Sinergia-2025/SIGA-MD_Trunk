PRINT ''
PRINT '1. TiposComprobantes: Ajusto Minutas a Numeracion Automatica'
GO
UPDATE TiposComprobantes
   SET NumeracionAutomatica = 'True'
 WHERE EsRecibo = 'True'
   AND ImporteMinimo = 0
   AND ImporteTope = 0 
   AND NumeracionAutomatica = 'False'
GO

PRINT ''
PRINT '2. TiposComprobantes: Ajusto Recibos Electronicos/Automaticos a Numeracion Automatica'
GO
UPDATE TiposComprobantes
   SET NumeracionAutomatica = 'True'
 WHERE EsRecibo = 'True'
   AND (ImporteMinimo <> 0 OR ImporteTope <> 0 )
   AND (Descripcion like '%Electr%' or Descripcion like '%aut%')

GO

PRINT ''
PRINT '3. TiposComprobantes: Ajusto Devolucion a Numeracion Automatica'
GO
UPDATE TiposComprobantes
   SET NumeracionAutomatica = 'True'
 WHERE EsRecibo = 'True'
   AND IdTipoComprobante = 'DEVOLUCION'
GO
