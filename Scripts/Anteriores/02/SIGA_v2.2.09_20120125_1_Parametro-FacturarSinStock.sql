
DELETE Parametros 
 WHERE IdParametro IN ('FACTURASINSTOCKPERMITE', 'FACTURASINSTOCKNOPERMITE', 'FACTURASINSTOCKAVISAPERMITE')
GO

INSERT INTO Parametros 
           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
     VALUES
           ('FACTURARSINSTOCK', 'PERMITIR', NULL, 'Facturar Sin Stock.')
GO

--INSERT INTO Parametros 
--           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
--     VALUES
--           ('FACTURASINSTOCKPERMITE', 'True', NULL, 'Permitir')
--GO

--INSERT INTO Parametros 
--           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
--     VALUES
--           ('FACTURASINSTOCKNOPERMITE', 'False', NULL, 'No Permitir')
--GO

--INSERT INTO Parametros 
--           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
--     VALUES
--           ('FACTURASINSTOCKAVISAPERMITE', 'False', NULL, 'Avisar y Permitir')
--GO