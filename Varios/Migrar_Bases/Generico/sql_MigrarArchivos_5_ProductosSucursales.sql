
DELETE ProductosSucursalesPrecios
GO

DELETE ProductosSucursales
GO  

INSERT INTO ProductosSucursales
           ([IdProducto]
           ,[IdSucursal]
           ,[PrecioFabrica]
           ,[PrecioCosto]
           ,[Usuario]
           ,[FechaActualizacion]
           ,[Stock]
           ,[StockInicial]
           ,[PuntoDePedido]
           ,[StockMinimo]
           ,[StockMaximo]
		   ,[StockFuturo]
		   ,[StockFuturoReservado]
		   ,[StockDefectuoso]
		   )
SELECT [IdProducto]
      ,[IdSucursal]
      ,[PrecioFabrica]
      ,[PrecioCosto]
      ,[Usuario]
      ,[FechaActualizacion]
      ,0 as [xStock]
      ,0 as [StockInicial] 
      ,[PuntoDePedido]
      ,[StockMinimo]
      ,0 as [xStockMaximo]
	  ,0 as [StockFuturo]
	  ,0 as [StockFuturoReservado]
	  ,0 as [StockDefectuoso]
  FROM MO_SIGA.DBO.ProductosSucursales
--  where IdProducto in (SELECT IdProducto FROM SIGA.DBO.Productos)  
GO

INSERT INTO ProductosSucursalesPrecios
           ([IdProducto]
           ,[IdSucursal]
           ,[IdListaPrecios]
           ,[PrecioVenta]
           ,[FechaActualizacion]
           ,[Usuario])
SELECT [IdProducto]
      ,[IdSucursal]
      ,[IdListaPrecios]
      ,[PrecioVenta]
      ,[FechaActualizacion]
      ,[Usuario]
  FROM MO_SIGA.DBO.[ProductosSucursalesPrecios]
--  where IdProducto in (SELECT IdProducto FROM SIGA.DBO.Productos)  
GO
