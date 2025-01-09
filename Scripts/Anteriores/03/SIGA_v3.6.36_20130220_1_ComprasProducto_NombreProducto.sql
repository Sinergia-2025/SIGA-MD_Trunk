
ALTER TABLE dbo.ComprasProductos ADD
	NombreProducto varchar(60) NULL
GO

UPDATE ComprasProductos SET 
 NombreProducto = 
    ( SELECT P.NombreProducto FROM Productos P
       WHERE P.IdProducto = ComprasProductos.IdProducto
     )
  WHERE NombreProducto IS NULL
GO 

ALTER TABLE dbo.ComprasProductos ALTER COLUMN
	NombreProducto varchar(60) NOT NULL
GO
