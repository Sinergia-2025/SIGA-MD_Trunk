
ALTER TABLE TiposComprobantes ADD MarcaInvocado bit null
GO

UPDATE TiposComprobantes SET MarcaInvocado = 'True'
GO

ALTER TABLE TiposComprobantes ALTER COLUMN MarcaInvocado bit not null
GO

UPDATE TiposComprobantes 
   SET MarcaInvocado = 'False'  
 WHERE IdTipoComprobante  IN ('eNCCE', 'eNDCE', 'eNDCECHEQRE')
GO
