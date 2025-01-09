
ALTER TABLE dbo.Productos ADD CodigoDeBarras bigint NULL
GO

/* SIEMPRE Y CUANDO UTILICEN CODIGO DE BARRAS */

SELECT * FROM Productos 
  WHERE LEN(IdProducto) > 10
GO

UPDATE Productos SET
   CodigoDeBarras = IdProducto
  WHERE LEN(IdProducto) > 10
GO

