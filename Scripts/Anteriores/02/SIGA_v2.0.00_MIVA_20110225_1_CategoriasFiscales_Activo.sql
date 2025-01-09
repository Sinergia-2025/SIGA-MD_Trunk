
ALTER TABLE CategoriasFiscales ADD Activo bit NULL
GO

UPDATE CategoriasFiscales SET
  Activo = (CASE WHEN IdCategoriaFiscal <> 3 THEN 'True' ELSE 'False' END)
GO 


/** MIRO LAS CATEGORIAS FISCALES FICTISIAS **/

SELECT * FROM CategoriasFiscales
 WHERE IdCategoriaFiscal > 6
GO

SELECT * FROM Clientes
 WHERE IdCategoriaFiscal > 6
GO

SELECT * FROM Ventas
 WHERE IdCategoriaFiscal > 6
GO

UPDATE Clientes SET
    IdCategoriaFiscal = 2
 WHERE IdCategoriaFiscal > 6
GO

UPDATE Ventas SET
    IdCategoriaFiscal = 2
 WHERE IdCategoriaFiscal > 6
GO

DELETE CategoriasFiscales
 WHERE IdCategoriaFiscal > 6
GO

/* -------------------------------------------- */

ALTER TABLE CategoriasFiscales ALTER COLUMN Activo bit NOT NULL
GO
