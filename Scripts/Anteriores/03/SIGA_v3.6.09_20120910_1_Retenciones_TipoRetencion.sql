
UPDATE dbo.Retenciones 
   SET TipoRetencion = 'VENTA'
  WHERE TipoRetencion IS NULL
GO

ALTER TABLE dbo.Retenciones ALTER COLUMN TipoRetencion	varchar(6)	NOT NULL
GO
