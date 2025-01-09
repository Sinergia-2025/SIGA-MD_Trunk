
UPDATE Ventas 
   SET Ventas.Direccion = C.Direccion
      ,Ventas.IdLocalidad = C.IdLocalidad
 FROM Ventas V 
 INNER JOIN SIGA.dbo.CLientes C ON V.IdCliente = C.IdCliente
 WHERE V.Direccion IS NULL
GO
