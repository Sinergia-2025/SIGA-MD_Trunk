
ALTER TABLE TiposComprobantes ADD
	UsaFacturacion bit NULL
GO


UPDATE TiposComprobantes SET 
     UsaFacturacion = 1
  WHERE IdTipoComprobante NOT IN ('eFACT')
GO


UPDATE TiposComprobantes SET 
     UsaFacturacion = 0
  WHERE IdTipoComprobante  IN ('eFACT')
GO


ALTER TABLE TiposComprobantes ALTER COLUMN
	UsaFacturacion bit NOT NULL
GO
