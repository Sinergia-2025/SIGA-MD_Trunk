
--SELECT IDPRODUCTO, NOMBREPRODUCTO, REPLACE(IDPRODUCTO,'/','.')  FROM Productos
--WHERE IdProducto LIKE '%/%'
-- AND CodigoDeBarras IS NULL
--GO

UPDATE Productos
  SET CodigoDeBarras = REPLACE(IDPRODUCTO,'/','') 
WHERE IdProducto LIKE '%/%'
--  AND CodigoDeBarras IS NULL
GO
