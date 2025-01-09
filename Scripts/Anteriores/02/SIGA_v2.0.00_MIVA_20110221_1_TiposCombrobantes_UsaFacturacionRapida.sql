
ALTER TABLE TiposComprobantes ADD
	UsaFacturacionRapida bit NULL
GO


UPDATE TiposComprobantes SET 
     UsaFacturacionRapida = 'True'
  WHERE IdTipoComprobante IN ('COTIZACION', 'DEV-COTIZACION', 'FACT', 'FACT-F', 'NCRED', 'NCRED-F', 'NDEB', 'NDEB-F', 'TCK-FACT-F', 'TICKET-F')
GO


UPDATE TiposComprobantes SET 
     UsaFacturacionRapida = 'False'
  WHERE IdTipoComprobante NOT IN ('COTIZACION', 'DEV-COTIZACION', 'FACT', 'FACT-F', 'NCRED', 'NCRED-F', 'NDEB', 'NDEB-F', 'TCK-FACT-F', 'TICKET-F')
GO


ALTER TABLE TiposComprobantes ALTER COLUMN
	UsaFacturacionRapida bit NOT NULL
GO
