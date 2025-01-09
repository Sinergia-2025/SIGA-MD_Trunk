
UPDATE Clientes 
   SET Direccion = '.' 
 WHERE Direccion IS NULL OR Direccion = ''
GO

UPDATE Clientes 
   SET IdLocalidad = 2000 
 WHERE IdLocalidad IS NULL;
GO

UPDATE Ventas 
   SET Ventas.Direccion = C.Direccion
      ,Ventas.IdLocalidad = C.IdLocalidad
 FROM Ventas V 
 INNER JOIN CLientes C ON V.IdCliente = C.IdCliente
  WHERE V.Direccion IS NULL
GO


ALTER TABLE Ventas ALTER COLUMN Direccion varchar(100) NOT NULL
GO
ALTER TABLE Ventas ALTER COLUMN IdLocalidad int NOT NULL
GO
