
PRINT ''
PRINT '1. Tabla TiposComprobantes: Agrego campo PermiteSeleccionarAlicuotaIVA, dejo en False salvo para Liquido Producto/NC.'
GO
ALTER TABLE dbo.TiposComprobantes ADD PermiteSeleccionarAlicuotaIVA bit NULL
GO
UPDATE TiposComprobantes SET PermiteSeleccionarAlicuotaIVA = 'False';
UPDATE TiposComprobantes SET PermiteSeleccionarAlicuotaIVA = 'True'
 WHERE IdTipoComprobante IN ('LIQUIDO', 'LIQUIDO-NC');
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN PermiteSeleccionarAlicuotaIVA bit NOT NULL
GO

PRINT ''
PRINT '2. Tabla TiposComprobantes: Dejo en 0 (Cero) el CoeficienteStock para Liquido Producto/NC.'
GO
UPDATE TiposComprobantes
  SET CoeficienteStock = 0
 WHERE IdTipoComprobante IN ('LIQUIDO', 'LIQUIDO-NC')
GO
