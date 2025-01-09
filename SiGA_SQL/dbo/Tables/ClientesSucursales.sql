CREATE TABLE [dbo].[ClientesSucursales] (
    [IdSucursal] INT    NOT NULL,
    [IdCliente]  BIGINT NOT NULL,
    CONSTRAINT [PK_ClientesSucursales] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC),
    CONSTRAINT [FK_ClientesSucursales_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_ClientesSucursales_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

