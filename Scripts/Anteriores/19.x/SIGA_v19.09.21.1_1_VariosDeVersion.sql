
PRINT ''
PRINT '1. Tabla Ventas: Nueva columna ReferenciaComercial.'
GO
ALTER TABLE dbo.Ventas ADD ReferenciaComercial varchar(300) NULL
GO

PRINT ''
PRINT '2. Tabla TiposComprobantes: COnfiguro AFIPWSRequiereComprobanteAsociado para FCE y NCE.'
GO
UPDATE TC
   SET AFIPWSRequiereReferenciaComercial = 'True'
     , AFIPWSRequiereComprobanteAsociado = CASE WHEN CoeficienteValores < 0 THEN 'True' ELSE 'False' END
     , AFIPWSIncluyeFechaVencimiento = CASE WHEN CoeficienteValores < 0 THEN 'False' ELSE 'True' END
  FROM TiposComprobantes TC
 WHERE (TC.AFIPWSEsFEC = 'True' OR TC.IdTipoComprobante IN ('ePRE-FCE','ePRE-NCCE','ePRE-NDCE','ePRE-NDCECHEQR'))
GO

PRINT ''
PRINT '3. Tabla TiposComprobantes: Nueva columna AFIPWSRequiereCBU.'
GO
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSRequiereCBU bit NULL
GO

PRINT ''
PRINT '3.1. Tabla TiposComprobantes: Valores por defecto para AFIPWSRequiereCBU'
GO
UPDATE TiposComprobantes
   SET AFIPWSRequiereCBU = 'False'
GO

PRINT ''
PRINT '3.2. Tabla TiposComprobantes: NOT NULL AFIPWSRequiereCBU.'
GO
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSRequiereCBU bit NOT NULL
GO

PRINT ''
PRINT '3.3. Tabla TiposComprobantes: Configuro AFIPWSRequiereCBU.'
GO
UPDATE TiposComprobantes
   SET AFIPWSRequiereCBU = 'True'
 WHERE IdTipoComprobante IN ('ePRE-FCE','eFCE')
GO

PRINT ''
PRINT '4. Tabla TiposComprobantes: Nueva columna AFIPWSCodigoAnulacion.'
GO
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSCodigoAnulacion bit NULL
GO

PRINT ''
PRINT '4.1. Tabla TiposComprobantes: Valores por defecto para AFIPWSCodigoAnulacion'
UPDATE TiposComprobantes
   SET AFIPWSCodigoAnulacion = 'False'
GO

PRINT ''
PRINT '4.2. Tabla TiposComprobantes: NOT NULL AFIPWSCodigoAnulacion'
GO
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSCodigoAnulacion bit NOT NULL
GO

PRINT ''
PRINT '4.3. Tabla TiposComprobantes: Configuro AFIPWSCodigoAnulacion.'
GO
UPDATE TiposComprobantes
   SET AFIPWSCodigoAnulacion = 'True'
 WHERE IdTipoComprobante IN ('eNCCE','eNDCE','ePRE-NCCE','ePRE-NDCE','eNDCECHEQRECH','ePRE-NDCECHEQR')
GO

PRINT ''
PRINT '5. Tabla Ventas: Nueva columna AnulacionFCE'
GO
ALTER TABLE dbo.Ventas ADD AnulacionFCE bit NULL
GO
