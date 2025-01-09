
ALTER TABLE dbo.CuentasCorrientes ADD
	TipoDocVendedor varchar(5) NULL,
	NroDocVendedor varchar(12) NULL
GO


UPDATE CuentasCorrientes SET 
 TipoDocVendedor = 
       ( select TipoDocVendedor from Clientes C
           where TipoDocCliente=C.TipoDocumento
             AND NroDocCliente=C.NroDocumento
         ),
 NroDocVendedor = 
       ( select NroDocVendedor from Clientes C
           where TipoDocCliente=C.TipoDocumento
             AND NroDocCliente=C.NroDocumento
         )
   
 WHERE TipoDocVendedor IS NULL
GO

ALTER TABLE dbo.CuentasCorrientes ALTER COLUMN TipoDocVendedor varchar(5) NOT NULL
GO

ALTER TABLE dbo.CuentasCorrientes ALTER COLUMN NroDocVendedor varchar(12) NOT NULL
GO
