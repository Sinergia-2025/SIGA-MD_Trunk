/* Agrega y setea la Cantidad de copias por Tipo de Comprobantes */

ALTER TABLE TiposComprobantes ADD CantidadCopias int NULL
GO

UPDATE TiposComprobantes SET CantidadCopias = 2
 WHERE IdTipoComprobante IN ('FACT', 'NCRED', 'NDEB')
GO

UPDATE TiposComprobantes SET CantidadCopias = 1
 WHERE IdTipoComprobante NOT IN ('FACT', 'NCRED', 'NDEB')
GO

ALTER TABLE TiposComprobantes ALTER COLUMN CantidadCopias int NOT NULL
GO


