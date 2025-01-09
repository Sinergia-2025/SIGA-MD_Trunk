/****** Object:  Trigger [ChequesActualizaHistorial]    Script Date: 11/15/2016 13:51:38 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[ChequesActualizaHistorial]'))
DROP TRIGGER [dbo].[ChequesActualizaHistorial]
GO

/****** Object:  Trigger [dbo].[ChequesActualizaHistorial]    Script Date: 11/15/2016 13:51:38 ******/
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
			, IdProveedor
			, IdCajaActual
			, NroPlanillaActual
			, NroMovimientoActual)
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
		, IdCajaActual
		, NroPlanillaActual
		, NroMovimientoActual
  FROM   inserted

END


GO


