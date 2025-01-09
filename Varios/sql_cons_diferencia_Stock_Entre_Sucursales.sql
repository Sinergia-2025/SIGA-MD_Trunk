
-- Sucursal 1 y 3 estan enlazadas / STOCK

select a.Idproducto, P.NombreProducto, str(A.stock,8,0) AS Stock_S1, str(B.stock,8,0) AS Stock_S2, A.StockInicial,  B.StockInicial
 FROM Productos P,
(
select * from productossucursales
 where IdSucursal = 1
) A, 
(
select * from productossucursales B
 where IdSucursal = 3
) B
 WHERE P.IdProducto = A.IdProducto
   AND A.IdProducto = B.IdProducto
   AND A.Stock <> B.Stock
GO

 
-- Sucursal 1 y 3 estan enlazadas / STOCK INICIAL

select a.Idproducto, P.NombreProducto, A.StockInicial,  B.StockInicial, str(A.stock,8,0) AS Stock_S1, str(B.stock,8,0) AS Stock_S2
 FROM Productos P,
(
select * from productossucursales
 where IdSucursal = 1
) A, 
(
select * from productossucursales B
 where IdSucursal = 3
) B
 WHERE P.IdProducto = A.IdProducto
   AND A.IdProducto = B.IdProducto
   AND A.StockInicial <> B.StockInicial
GO
