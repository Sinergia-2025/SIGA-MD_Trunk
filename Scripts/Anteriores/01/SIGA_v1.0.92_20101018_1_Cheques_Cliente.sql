
ALTER TABLE dbo.Cheques ADD
	TipoDocCliente varchar(5) NULL,
	NroDocCliente varchar(12) NULL
GO


-- ACTUALIZA LOS CHEQUES INGRESADOS DE VENTAS.
UPDATE Cheques SET 
 TipoDocCliente = 
    ( SELECT V.TipoDocCliente
        FROM VentasCheques VC, Ventas V
       WHERE VC.idSucursal = V.IdSucursal
         AND VC.IdTipoComprobante = V.IdTipoComprobante
         AND VC.Letra = V.Letra
         AND VC.NumeroComprobante = V.NumeroComprobante
         AND VC.idSucursal = Cheques.idSucursal
         AND VC.NumeroCheque = Cheques.NumeroCheque
         AND VC.IdBanco = Cheques.IdBanco
         AND VC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND VC.IdLocalidad = Cheques.IdLocalidad
     ),
 NroDocCliente = 
    ( SELECT V.NroDocCliente
        FROM VentasCheques VC, Ventas V
       WHERE VC.idSucursal = V.IdSucursal
         AND VC.IdTipoComprobante = V.IdTipoComprobante
         AND VC.Letra = V.Letra
         AND VC.NumeroComprobante = V.NumeroComprobante
         AND VC.idSucursal = Cheques.idSucursal
         AND VC.NumeroCheque = Cheques.NumeroCheque
         AND VC.IdBanco = Cheques.IdBanco
         AND VC.IdBancoSucursal = Cheques.IdBancoSucursal
         AND VC.IdLocalidad = Cheques.IdLocalidad
     )
 WHERE TipoDocCliente IS NULL
GO 
  
-- ACTUALIZA LOS CHEQUES INGRESADOS DE CUENTAS CORRIENTES.
UPDATE Cheques SET 
 TipoDocCliente = 
    ( SELECT CC.TipoDocCliente
        FROM CuentasCorrientesCheques CCC, CuentasCorrientes CC
       WHERE CCC.idSucursal = CC.IdSucursal
         AND CCC.IdTipoComprobante = CC.IdTipoComprobante
         AND CCC.Letra = CC.Letra
         AND CCC.NumeroComprobante = CC.NumeroComprobante
         AND CCC.idSucursal = Cheques.idSucursal
         AND CCC.NumeroCheque = Cheques.NumeroCheque
         AND CCC.IdBancoCheque = Cheques.IdBanco
         AND CCC.IdBancoSucursalCheque = Cheques.IdBancoSucursal
         AND CCC.IdLocalidadCheque = Cheques.IdLocalidad
     ),
 NroDocCliente = 
    ( SELECT CC.NroDocCliente
        FROM CuentasCorrientesCheques CCC, CuentasCorrientes CC
       WHERE CCC.idSucursal = CC.IdSucursal
         AND CCC.IdTipoComprobante = CC.IdTipoComprobante
         AND CCC.Letra = CC.Letra
         AND CCC.NumeroComprobante = CC.NumeroComprobante
         AND CCC.idSucursal = Cheques.idSucursal
         AND CCC.NumeroCheque = Cheques.NumeroCheque
         AND CCC.IdBancoCheque = Cheques.IdBanco
         AND CCC.IdBancoSucursalCheque = Cheques.IdBancoSucursal
         AND CCC.IdLocalidadCheque = Cheques.IdLocalidad
     )
 WHERE TipoDocCliente IS NULL
GO 


-- ACTUALIZA LOS CHEQUES INGRESADOS DE CHEQ. RECHAZADOS (ALGUNO TAL VEZ INGRESO POR CAJA).
UPDATE Cheques SET 
 TipoDocCliente = 
    ( SELECT V.TipoDocCliente
        FROM VentasChequesRechazados VCR, Ventas V
       WHERE VCR.idSucursal = V.IdSucursal
         AND VCR.IdTipoComprobante = V.IdTipoComprobante
         AND VCR.Letra = V.Letra
         AND VCR.NumeroComprobante = V.NumeroComprobante
         AND VCR.idSucursal = Cheques.idSucursal
         AND VCR.NumeroCheque = Cheques.NumeroCheque
         AND VCR.IdBanco = Cheques.IdBanco
         AND VCR.IdBancoSucursal = Cheques.IdBancoSucursal
         AND VCR.IdLocalidad = Cheques.IdLocalidad
     ),
 NroDocCliente = 
    ( SELECT V.NroDocCliente
        FROM VentasChequesRechazados VCR, Ventas V
       WHERE VCR.idSucursal = V.IdSucursal
         AND VCR.IdTipoComprobante = V.IdTipoComprobante
         AND VCR.Letra = V.Letra
         AND VCR.NumeroComprobante = V.NumeroComprobante
         AND VCR.idSucursal = Cheques.idSucursal
         AND VCR.NumeroCheque = Cheques.NumeroCheque
         AND VCR.IdBanco = Cheques.IdBanco
         AND VCR.IdBancoSucursal = Cheques.IdBancoSucursal
         AND VCR.IdLocalidad = Cheques.IdLocalidad
     )
 WHERE TipoDocCliente IS NULL
GO 
