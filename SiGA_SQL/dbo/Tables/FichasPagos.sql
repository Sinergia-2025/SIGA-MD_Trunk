CREATE TABLE [dbo].[FichasPagos] (
    [NroOperacion]     INT             NOT NULL,
    [NroCuota]         INT             NOT NULL,
    [FechaVencimiento] DATETIME        NOT NULL,
    [Importe]          DECIMAL (10, 2) NULL,
    [Saldo]            DECIMAL (10, 2) NULL,
    [IdSucursal]       INT             NOT NULL,
    [IdCliente]        BIGINT          NOT NULL,
    CONSTRAINT [PK_FichasPagos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC, [NroOperacion] ASC, [NroCuota] ASC)
);

