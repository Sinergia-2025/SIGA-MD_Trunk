
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTURACIONDECIMALESENTOTALXPRODUCTO', '2', NULL, 'Cant. Decimales a Mostrar en Total x Producto')
GO

-- NO SE USA.
DELETE Parametros 
 WHERE IdParametro IN ('DECIMALESAMOSTRARVENTA')
GO

-- Nuevo para Items
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTURACIONDECIMALESENPRECIO', '2', NULL, 'Cantidad Decimales a Mostrar en Precio')
GO


-- NO SE USA.
DELETE Parametros 
 WHERE IdParametro IN('VALORREDONDEOVENTA')
GO

-- Nuevo para Items
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('FACTURACIONDECIMALESREDONDEOENPRECIO', '4', NULL, 'Cantidad Decimales Redondeo en Precio')
GO
