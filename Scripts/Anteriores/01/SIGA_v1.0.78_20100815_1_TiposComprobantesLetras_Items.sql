ALTER TABLE dbo.TiposComprobantesLetras ADD
	CantidadItemsProductos int NULL,
	CantidadItemsObservaciones int NULL
GO


UPDATE TiposComprobantesLetras SET
  CantidadItemsProductos = (
  SELECT TC.CantidadMaximaItems FROM TiposComprobantes TC
   WHERE TC.IdTipoComprobante=TiposComprobantesLetras.IdTipoComprobante
                            ),
  CantidadItemsObservaciones=0
GO


ALTER TABLE TiposComprobantesLetras ALTER COLUMN CantidadItemsProductos int NOT NULL
GO

ALTER TABLE TiposComprobantesLetras ALTER COLUMN CantidadItemsObservaciones int NOT NULL
GO
