
--DELETE Parametros 
-- WHERE IdParametro IN ('FACTURACIONMARGENIZQUIERDO','FACTURACIONMARGENDERECHO')
--go

INSERT INTO Parametros 
   (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
   ('FACTURACIONMARGENIZQUIERDO', '50', NULL, 'Facturacion: Imp. Margen Izquierdo (mm)')
GO

INSERT INTO Parametros 
   (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
   ('FACTURACIONMARGENDERECHO', '50', NULL, 'Facturacion: Imp. Margen Derecho (mm)')
GO
