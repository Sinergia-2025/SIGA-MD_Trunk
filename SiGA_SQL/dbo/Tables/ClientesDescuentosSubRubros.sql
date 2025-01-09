CREATE TABLE [dbo].[ClientesDescuentosSubRubros] (
    [IdSubRubro]       INT            NOT NULL,
    [DescuentoRecargo] DECIMAL (5, 2) NULL,
    [IdCliente]        BIGINT         NOT NULL,
    CONSTRAINT [PK_ClientesDescuentosSubRubros] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdSubRubro] ASC),
    CONSTRAINT [FK_ClientesDescuentosSubRubros_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_ClientesDescuentosSubRubros_SubRubros] FOREIGN KEY ([IdSubRubro]) REFERENCES [dbo].[SubRubros] ([IdSubRubro])
);

