
UPDATE TiposComprobantes
    SET CantidadMaximaItems = 100
  WHERE CantidadMaximaItems IS NULL
GO

ALTER TABLE TiposComprobantes ALTER COLUMN CantidadMaximaItems int NOT NULL
GO

