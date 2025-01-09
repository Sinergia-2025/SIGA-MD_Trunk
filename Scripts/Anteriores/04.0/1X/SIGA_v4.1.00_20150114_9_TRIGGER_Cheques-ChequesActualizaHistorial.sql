
/****** Object:  Trigger [dbo].[ChequesActualizaHistorial]    Script Date: 01/14/2015 15:44:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--creo el desencadenador para actualizar el historial
CREATE TRIGGER [dbo].[ChequesActualizaHistorial] 
   ON  [dbo].[Cheques] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO ChequesHistorial
			(IdSucursal
			, NumeroCheque
			, IdBanco
			, IdBancoSucursal
			, IdLocalidad
			, FechaEmision
			, FechaCobro
			, Titular
			, Importe
			, IdCajaIngreso
			, NroPlanillaIngreso
			, NroMovimientoIngreso
			, IdCajaEgreso
			, NroPlanillaEgreso
			, NroMovimientoEgreso
			, EsPropio
			, IdCuentaBancaria
			, IdEstadoCheque
			, IdEstadoChequeAnt
			, Cuit
			, IdCliente
			, IdProveedor)
    SELECT IdSucursal
		, NumeroCheque
		, IdBanco
		, IdBancoSucursal
		, IdLocalidad
		, FechaEmision
		, FechaCobro
		, Titular
		, Importe
		, IdCajaIngreso
		, NroPlanillaIngreso
		, NroMovimientoIngreso
		, IdCajaEgreso
		, NroPlanillaEgreso
		, NroMovimientoEgreso
		, EsPropio
		, IdCuentaBancaria
		, IdEstadoCheque
		, IdEstadoChequeAnt
		, Cuit
		, IdCliente
		, IdProveedor
  FROM   inserted

END

GO
