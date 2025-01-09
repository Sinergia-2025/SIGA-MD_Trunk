
ALTER TABLE VentasProductos ADD IdListaPrecios	int	null
GO

ALTER TABLE VentasProductos ADD NombreListaPrecios	varchar(50)	null
GO

UPDATE VentasProductos SET IdListaPrecios = 0 
GO

UPDATE VentasProductos SET NombreListaPrecios = '*' 
GO

ALTER TABLE VentasProductos ALTER COLUMN IdListaPrecios	int	NOT null
GO

ALTER TABLE VentasProductos ALTER COLUMN NombreListaPrecios	varchar(50) NOT null
GO
