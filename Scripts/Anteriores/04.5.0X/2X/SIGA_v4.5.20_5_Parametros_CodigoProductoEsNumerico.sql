-- SI EXISTE AL MENOS 1 REGISTRO CON LETRAS, CONSIDERO QUE UTILIZA CODIGOS ALFANUMERICOS.

IF EXISTS (SELECT * FROM Productos
            WHERE IdProducto NOT LIKE '[0-9]%')
    BEGIN

		INSERT INTO [Parametros]
			  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
		  VALUES
			  ('PRODUCTOCODIGONUMERICO', 'False', NULL, 'Codigo de Producto es numérico')
		;

    END
ELSE
    BEGIN

		INSERT INTO [Parametros]
			  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
		  VALUES
			  ('PRODUCTOCODIGONUMERICO', 'True', NULL, 'Codigo de Producto es numérico')
		;
    END
GO


SELECT ValorParametro FROM Parametros
 WHERE IdParametro = 'PRODUCTOCODIGONUMERICO'
GO

 
  
 