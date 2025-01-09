
/* Agrega parametro para permitir Ventas con precio en CERO */

INSERT INTO Parametros 
           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
     VALUES
           ('VENTASCONPRODUCTOSENCERO', 'False', NULL, 'Permite ingresar productos con precio cero')
GO


