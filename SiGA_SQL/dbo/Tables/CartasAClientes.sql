CREATE TABLE [dbo].[CartasAClientes] (
    [IdSucursal]       INT          NOT NULL,
    [NroOperacion]     INT          NOT NULL,
    [FechaEnvio]       DATETIME     NOT NULL,
    [TipoCarta]        VARCHAR (20) NOT NULL,
    [Usuario]          VARCHAR (10) NOT NULL,
    [IdCliente]        BIGINT       NOT NULL,
    [IdClienteGarante] BIGINT       NULL,
    CONSTRAINT [PK_CartasAClientes] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC, [NroOperacion] ASC, [FechaEnvio] ASC),
    CONSTRAINT [FK_CartasAClientes_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_CartasAClientes_Clientes_Garante] FOREIGN KEY ([IdClienteGarante]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_CartasAClientes_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_CartasAClientes_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

