
--creo la tabla para insertar el log de los cheques
CREATE TABLE [ChequesHistorial](
	[IdSucursal] [int] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaCobro] [datetime] NOT NULL,
	[Titular] [varchar](40) NULL,
	[Importe] [decimal](10, 2) NOT NULL,
	[IdCajaIngreso] [int] NULL,
	[NroPlanillaIngreso] [int] NULL,
	[NroMovimientoIngreso] [int] NULL,
	[IdCajaEgreso] [int] NULL,
	[NroPlanillaEgreso] [int] NULL,
	[NroMovimientoEgreso] [int] NULL,
	[EsPropio] [bit] NOT NULL,
	[IdCuentaBancaria] [int] NULL,
	[IdEstadoCheque] [varchar](10) NOT NULL,
	[IdEstadoChequeAnt] [varchar](10) NULL,
	[TipoDocCliente] [varchar](5) NULL,
	[NroDocCliente] [varchar](12) NULL,
	[TipoDocProveedor] [varchar](5) NULL,
	[NroDocProveedor] [bigint] NULL)
GO


--creo el desencadenador para actualizar el historial
CREATE TRIGGER ChequesActualizaHistorial 
   ON  Cheques 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO ChequesHistorial
           ([IdSucursal]
           ,[NumeroCheque]
           ,[IdBanco]
           ,[IdBancoSucursal]
           ,[IdLocalidad]
           ,[FechaEmision]
           ,[FechaCobro]
           ,[Titular]
           ,[Importe]
           ,[IdCajaIngreso]
           ,[NroPlanillaIngreso]
           ,[NroMovimientoIngreso]
           ,[IdCajaEgreso]
           ,[NroPlanillaEgreso]
           ,[NroMovimientoEgreso]
           ,[EsPropio]
           ,[IdCuentaBancaria]
           ,[IdEstadoCheque]
           ,[IdEstadoChequeAnt]
           ,[TipoDocCliente]
           ,[NroDocCliente]
           ,[TipoDocProveedor]
           ,[NroDocProveedor])
    SELECT [IdSucursal]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[FechaEmision]
      ,[FechaCobro]
      ,[Titular]
      ,[Importe]
      ,[IdCajaIngreso]
      ,[NroPlanillaIngreso]
      ,[NroMovimientoIngreso]
      ,[IdCajaEgreso]
      ,[NroPlanillaEgreso]
      ,[NroMovimientoEgreso]
      ,[EsPropio]
      ,[IdCuentaBancaria]
      ,[IdEstadoCheque]
      ,[IdEstadoChequeAnt]
      ,[TipoDocCliente]
      ,[NroDocCliente]
      ,[TipoDocProveedor]
      ,[NroDocProveedor]
  FROM   inserted

END
GO
