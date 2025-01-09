PRINT ''
PRINT '1. Tabla Cheques: Agrego campo IdUsuarioActualizacion .'
GO
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cheques ADD IdUsuarioActualizacion  varchar(10) NULL
GO
ALTER TABLE [dbo].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_Cheques_Usuarios] FOREIGN KEY([IdUsuarioActualizacion])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Cheques] CHECK CONSTRAINT [FK_Cheques_Usuarios]
GO
/*-----------------------------------------------------------------------*/
COMMIT
PRINT ''
PRINT '2. Tabla ChequesHistorial: Agrego campo IdUsuarioActualizacion .'
GO
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequesHistorial ADD IdUsuarioActualizacion  varchar(10) NULL
GO
/*-----------------------------------------------------------------------*/
COMMIT
PRINT ''
PRINT '3. Actualizar Triggers Cheques'
GO
ALTER TRIGGER [dbo].[ChequesActualizaHistorial] 
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
			, IdProveedorPreasignado
			,IdUsuarioActualizacion)
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
		, IdProveedorPreasignado
		,IdUsuarioActualizacion
  FROM INSERTED
END
GO

PRINT ''
PRINT '4. Tabla Cheques: Cambiar Pantalla FacturacionPedido a PedidosClientesV2.'
UPDATE Funciones
   SET Pantalla = 'PedidosClientesV2'
 WHERE Pantalla = 'FacturacionPedido'
