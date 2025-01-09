
ALTER TABLE dbo.VentasProductos ADD
	NombreProducto varchar(60) NULL
GO

UPDATE VentasProductos SET 
 NombreProducto = 
    ( SELECT P.NombreProducto FROM Productos P
       WHERE P.IdProducto = VentasProductos.IdProducto
     )
  WHERE NombreProducto IS NULL
GO 

ALTER TABLE dbo.VentasProductos ALTER COLUMN
	NombreProducto varchar(60) NOT NULL
GO
