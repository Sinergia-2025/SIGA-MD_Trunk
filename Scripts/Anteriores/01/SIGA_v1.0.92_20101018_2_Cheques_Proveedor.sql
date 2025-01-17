
ALTER TABLE dbo.Cheques ADD
	TipoDocProveedor varchar(5) NULL,
	NroDocProveedor bigint NULL
GO


  
-- ACTUALIZA LOS CHEQUES EGRESADOS DE CUENTAS CORRIENTES (Propios o de Terceros).
UPDATE Cheques SET 
 TipoDocProveedor = 
    ( SELECT CCPC.TipoDocProveedor
        FROM CuentasCorrientesProvCheques CCPC
       WHERE CCPC.idSucursal = Cheques.idSucursal
         AND CCPC.NumeroCheque = Cheques.NumeroCheque
         AND CCPC.IdBanco = Cheques.IdBanco
         AND CCPC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND CCPC.IdLocalidad = Cheques.IdLocalidad
     ),
 NroDocProveedor = 
    ( SELECT CCPC.NroDocProveedor
        FROM CuentasCorrientesProvCheques CCPC
       WHERE CCPC.idSucursal = Cheques.idSucursal
         AND CCPC.NumeroCheque = Cheques.NumeroCheque
         AND CCPC.IdBanco = Cheques.IdBanco
         AND CCPC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND CCPC.IdLocalidad = Cheques.IdLocalidad
     )
 WHERE TipoDocProveedor IS NULL
GO 
