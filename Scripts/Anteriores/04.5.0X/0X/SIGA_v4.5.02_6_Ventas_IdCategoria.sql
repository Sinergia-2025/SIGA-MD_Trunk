
ALTER TABLE Ventas ADD IdCategoria int null
GO

UPDATE Ventas 
   SET Ventas.IdCategoria = C.IdCategoria 
 FROM Ventas V 
 INNER JOIN CLientes C ON V.IdCliente = C.IdCliente
GO

ALTER TABLE Ventas ALTER COLUMN IdCategoria int not null
GO
