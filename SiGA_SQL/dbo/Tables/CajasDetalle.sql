CREATE TABLE [dbo].[CajasDetalle] (
    [IdSucursal]         INT             NOT NULL,
    [IdCaja]             INT             CONSTRAINT [DF_CajasDetalle_IdCaja] DEFAULT ((1)) NOT NULL,
    [NumeroPlanilla]     INT             NOT NULL,
    [NumeroMovimiento]   INT             NOT NULL,
    [FechaMovimiento]    DATETIME        NOT NULL,
    [IdCuentaCaja]       INT             NOT NULL,
    [IdTipoMovimiento]   CHAR (1)        NOT NULL,
    [ImportePesos]       DECIMAL (10, 2) NOT NULL,
    [ImporteDolares]     DECIMAL (10, 2) NOT NULL,
    [ImporteEuros]       DECIMAL (10, 2) NOT NULL,
    [ImporteCheques]     DECIMAL (10, 2) NOT NULL,
    [ImporteTarjetas]    DECIMAL (10, 2) NOT NULL,
    [Observacion]        VARCHAR (100)   NULL,
    [EsModificable]      BIT             NOT NULL,
    [ImporteTickets]     DECIMAL (10, 2) NOT NULL,
    [IdUsuario]          VARCHAR (10)    NOT NULL,
    [IdAsiento]          INT             NULL,
    [ImporteBancos]      DECIMAL (10, 2) NOT NULL,
    [ImporteRetenciones] DECIMAL (10, 2) NOT NULL,
    [IdPlanCuenta]       INT             NULL,
    CONSTRAINT [PK_CajasDetalle] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC, [NumeroPlanilla] ASC, [NumeroMovimiento] ASC),
    CONSTRAINT [FK_CajasDetalle_Cajas] FOREIGN KEY ([IdSucursal], [IdCaja], [NumeroPlanilla]) REFERENCES [dbo].[Cajas] ([IdSucursal], [IdCaja], [NumeroPlanilla]),
    CONSTRAINT [FK_CajasDetalle_CuentasDeCajas] FOREIGN KEY ([IdCuentaCaja]) REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja]),
    CONSTRAINT [FK_CajasDetalle_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);



