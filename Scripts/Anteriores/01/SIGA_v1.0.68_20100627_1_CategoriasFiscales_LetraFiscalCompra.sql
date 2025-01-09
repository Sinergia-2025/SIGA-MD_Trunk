
ALTER TABLE CategoriasFiscales ADD LetraFiscalCompra char(1) NULL
GO

UPDATE CategoriasFiscales  SET
   LetraFiscalCompra='A'
 WHERE IdCategoriaFiscal in (2, 3, 7)
GO

UPDATE CategoriasFiscales  SET
   LetraFiscalCompra='B'
 WHERE IdCategoriaFiscal in (1, 4, 5)
GO

UPDATE CategoriasFiscales  SET
   LetraFiscalCompra='C'
 WHERE IdCategoriaFiscal = 6
GO

ALTER TABLE CategoriasFiscales ALTER COLUMN LetraFiscalCompra char(1) NOT NULL
GO
