CREATE TABLE [dbo].[Cheques] (
    [IdSucursal]           INT             NOT NULL,
    [NumeroCheque]         INT             NOT NULL,
    [IdBanco]              INT             NOT NULL,
    [IdBancoSucursal]      INT             NOT NULL,
    [IdLocalidad]          INT             NOT NULL,
    [FechaEmision]         DATETIME        NOT NULL,
    [FechaCobro]           DATETIME        NOT NULL,
    [Titular]              VARCHAR (40)    NULL,
    [Importe]              DECIMAL (10, 2) NOT NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NULL,
    [NroMovimientoIngreso] INT             NULL,
    [IdCajaEgreso]         INT             NULL,
    [NroPlanillaEgreso]    INT             NULL,
    [NroMovimientoEgreso]  INT             NULL,
    [EsPropio]             BIT             NOT NULL,
    [IdCuentaBancaria]     INT             NULL,
    [IdEstadoCheque]       VARCHAR (10)    NOT NULL,
    [IdEstadoChequeAnt]    VARCHAR (10)    NULL,
    [Cuit]                 VARCHAR (13)    NULL,
    [IdCliente]            BIGINT          NULL,
    [IdProveedor]          BIGINT          NULL,
    [FotoFrente]           IMAGE           NULL,
    [FotoDorso]            IMAGE           NULL,
    CONSTRAINT [PK_Cheques] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC),
    CONSTRAINT [FK_Cheques_Bancos] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[Bancos] ([IdBanco]),
    CONSTRAINT [FK_Cheques_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]),
    CONSTRAINT [FK_Cheques_CajasDetalleEgreso] FOREIGN KEY ([IdSucursal], [IdCajaEgreso], [NroPlanillaEgreso], [NroMovimientoEgreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]),
    CONSTRAINT [FK_Cheques_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Cheques_CuentasBancarias] FOREIGN KEY ([IdCuentaBancaria]) REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria]),
    CONSTRAINT [FK_Cheques_EstadosCheques] FOREIGN KEY ([IdEstadoCheque]) REFERENCES [dbo].[EstadosCheques] ([IdEstadoCheque]),
    CONSTRAINT [FK_Cheques_EstadosChequesAnt] FOREIGN KEY ([IdEstadoChequeAnt]) REFERENCES [dbo].[EstadosCheques] ([IdEstadoCheque]),
    CONSTRAINT [FK_Cheques_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_Cheques_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_Cheques_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);


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

