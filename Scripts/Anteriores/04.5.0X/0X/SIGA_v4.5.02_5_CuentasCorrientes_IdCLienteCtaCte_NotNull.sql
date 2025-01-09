
UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdClienteCtaCte = (CASE WHEN C.IdClienteCtaCte IS NULL THEN C.IdCliente ELSE C.IdClienteCtaCte END)
 FROM CuentasCorrientes CC 
 INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente
GO

ALTER TABLE CuentasCorrientes ALTER COLUMN IdClienteCtaCte bigint not null
GO
