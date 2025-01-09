CREATE TABLE [dbo].[PedidosCriticidades] (
    [IdCriticidad] VARCHAR (10) NOT NULL,
    [Orden]        INT          NOT NULL,
    CONSTRAINT [PK_PedidosCriticidades] PRIMARY KEY CLUSTERED ([IdCriticidad] ASC)
);

