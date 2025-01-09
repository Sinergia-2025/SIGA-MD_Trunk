SELECT * FROM Marcas
   WHERE IdMarca IN (6, 7, 15, 17) 
GO

UPDATE Productos SET
	 Lote = 'True'
   WHERE IdMarca IN (6, 7, 15, 17) 
GO

INSERT INTO ProductosLotes
           (IdSucursal
           ,IdProducto
           ,IdLote
           ,FechaIngreso
           ,FechaVencimiento
           ,CantidadInicial
           ,CantidadActual
           ,Habilitado)
SELECT PS.IdSucursal
      ,PS.IdProducto
      ,'1' AS IdLote
      ,GETDATE() AS FechaIngreso
      ,GETDATE()+30 AS FechaVencimiento
      ,PS.Stock AS CantidadInicial
      ,PS.Stock AS CantidadActual
      ,'True' AS Habilitado
   FROM ProductosSucursales PS, Productos P
  WHERE PS.IdProducto = P.IdProducto
    AND P.Lote = 'True'
    AND PS.Stock > 0
GO
