SELECT IdCliente, CodigoCliente, NombreCliente FROM Clientes
 ORDER BY NombreCliente
GO

UPDATE Clientes 
  SET CodigoCliente = NumeroRegistro 
 FROM Clientes
 INNER JOIN 
  (SELECT IdCliente, row_number() OVER (ORDER BY NombreCliente) AS NumeroRegistro
     FROM Clientes) TablaNumerada ON TablaNumerada.IdCliente = Clientes.IdCliente
GO

UPDATE AuditoriaClientes
   SET AuditoriaClientes.CodigoCliente = C.CodigoCliente
 FROM AuditoriaClientes AC
 INNER JOIN Clientes C ON AC.IdCliente = C.IdCliente
-- WHERE V.Direccion IS NULL
GO
