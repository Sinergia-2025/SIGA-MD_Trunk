
DELETE ProductosSucursalesPrecios
  WHERE IdSucursal = 2
GO

DELETE ProductosSucursales
  WHERE IdSucursal = 2
GO  

INSERT INTO [ProductosSucursales]
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
           ,Ubicacion
           ,StockReservado
		   ,FechaActualizacionWeb
		   ,StockDefectuoso
		   ,StockFuturo
		   ,StockFuturoReservado)
SELECT [IdProducto]
      ,2 AS [xIdSucursal]
      ,[PrecioFabrica]
      ,[PrecioCosto]
      ,[Usuario]
      ,[FechaActualizacion]
      ,[Stock]
      ,[StockInicial]
      ,[PuntoDePedido]
      ,[StockMinimo]
      ,[StockMaximo]
           ,Ubicacion
           ,StockReservado
		   ,FechaActualizacionWeb
		   ,StockDefectuoso
		   ,StockFuturo
		   ,StockFuturoReservado
  FROM [ProductosSucursales]
  WHERE IdSucursal = 1
GO

INSERT INTO [ProductosSucursalesPrecios]
           ([IdProducto]
           ,[IdSucursal]
           ,[IdListaPrecios]
           ,[PrecioVenta]
           ,[FechaActualizacion]
           ,[Usuario]
           ,[FechaActualizacionWeb])
SELECT [IdProducto]
      ,2 as [XIdSucursal]
      ,[IdListaPrecios]
      ,[PrecioVenta]
      ,[FechaActualizacion]
      ,[Usuario]
      ,[FechaActualizacionWeb]
  FROM [ProductosSucursalesPrecios]
  WHERE IdSucursal = 1
GO
