CREATE TABLE [dbo].[ClientesActividades] (
    [IdProvincia] CHAR (2) NOT NULL,
    [IdActividad] INT      NOT NULL,
    [IdCliente]   BIGINT   NOT NULL,
    CONSTRAINT [PK_ClientesActividades] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdProvincia] ASC, [IdActividad] ASC),
    CONSTRAINT [FK_ClientesActividades_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente])
);

