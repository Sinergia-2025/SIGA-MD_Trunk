
ALTER TABLE TiposComprobantes ADD
    CantidadMaximaItemsObserv int NULL
GO

UPDATE TiposComprobantes SET
  CantidadMaximaItemsObserv = 0
GO

ALTER TABLE TiposComprobantes ALTER COLUMN CantidadMaximaItemsObserv int NOT NULL
GO

