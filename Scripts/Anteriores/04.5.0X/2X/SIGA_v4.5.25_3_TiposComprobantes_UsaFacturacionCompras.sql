
UPDATE TiposComprobantes
   SET UsaFacturacion = 'True'
 WHERE IdTipoComprobante IN ('SALARIO','SUELDO')
GO
