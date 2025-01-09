CREATE TABLE [dbo].[FichasPagosAjustes] (
    [NroOperacion]     INT             NOT NULL,
    [IdSucursal]       INT             NOT NULL,
    [FechaPago]        DATETIME        NOT NULL,
    [Importe]          DECIMAL (10, 2) NULL,
    [Concepto]         VARCHAR (50)    NULL,
    [IdCaja]           INT             CONSTRAINT [DF_FichasPagosAjustes_IdCaja] DEFAULT ((1)) NOT NULL,
    [NumeroPlanilla]   INT             NOT NULL,
    [NumeroMovimiento] INT             NOT NULL,
    [IdCliente]        BIGINT          NOT NULL,
    CONSTRAINT [PK_FichasPagosAjustes] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC, [NroOperacion] ASC, [FechaPago] ASC)
);

