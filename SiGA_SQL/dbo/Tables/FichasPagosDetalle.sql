CREATE TABLE [dbo].[FichasPagosDetalle] (
    [NroOperacion]     INT             NOT NULL,
    [NroCuota]         INT             NOT NULL,
    [FechaPago]        DATETIME        NOT NULL,
    [Importe]          DECIMAL (10, 2) NOT NULL,
    [TipoDocCobrador]  VARCHAR (5)     NULL,
    [NroDocCobrador]   VARCHAR (12)    NULL,
    [IdSucursal]       INT             NOT NULL,
    [IdCaja]           INT             CONSTRAINT [DF_FichasPagosDetalle_IdCaja] DEFAULT ((1)) NULL,
    [NumeroPlanilla]   INT             NOT NULL,
    [NumeroMovimiento] INT             NOT NULL,
    [IdCliente]        BIGINT          NOT NULL,
    CONSTRAINT [PK_FichasPagosDetalle] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC, [NroOperacion] ASC, [NroCuota] ASC, [FechaPago] ASC)
);



