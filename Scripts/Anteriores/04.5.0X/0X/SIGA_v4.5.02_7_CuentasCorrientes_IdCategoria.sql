
ALTER TABLE CuentasCorrientes ADD IdCategoria int null
GO

UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdCategoria = C.IdCategoria 
 FROM CuentasCorrientes CC
 INNER JOIN CLientes C ON CC.IdCliente = C.IdCliente
GO

ALTER TABLE CuentasCorrientes ALTER COLUMN IdCategoria int not null
GO
