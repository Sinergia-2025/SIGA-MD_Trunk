
--Para Metalsur borra CHASIS importados por error

DELETE FROM ProductosSucursalesPrecios
 WHERE IdProducto IN(SELECT IdProducto 
                 FROM productos WHERE IdProductoTipoServicio = 3) 
GO

DELETE FROM ProductosSucursales
 WHERE IdProducto IN(SELECT IdProducto 
                 FROM productos WHERE IdProductoTipoServicio = 3)
GO

 DELETE from productos where IdProductoTipoServicio = 3
GO
