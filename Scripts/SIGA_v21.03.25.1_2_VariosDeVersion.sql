/****** Object:  Trigger [dbo].[ChequesActualizaHistorial]    Script Date: 09/03/2021 15:17:16 ******/
ALTER TRIGGER [dbo].[ChequesActualizaHistorial] 
   ON  [dbo].[Cheques] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO ChequesHistorial
			(IdSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad
           , FechaEmision, FechaCobro, Titular, Importe, IdCajaIngreso
           , NroPlanillaIngreso, NroMovimientoIngreso, IdCajaEgreso, NroPlanillaEgreso, NroMovimientoEgreso
           , EsPropio, IdCuentaBancaria, IdEstadoCheque, IdEstadoChequeAnt, Cuit
           , IdCliente, IdProveedor, IdProveedorPreasignado, IdUsuarioActualizacion, IdTipoCheque
           , NroOperacion, IdCheque)
      SELECT IdSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad
           , FechaEmision, FechaCobro, Titular, Importe, IdCajaIngreso
           , NroPlanillaIngreso, NroMovimientoIngreso, IdCajaEgreso, NroPlanillaEgreso, NroMovimientoEgreso
           , EsPropio, IdCuentaBancaria, IdEstadoCheque, IdEstadoChequeAnt, Cuit
           , IdCliente, IdProveedor, IdProveedorPreasignado, IdUsuarioActualizacion, IdTipoCheque
           , NroOperacion, IdCheque
        FROM INSERTED
END