CREATE TABLE [dbo].[SincronizaRegistros] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [FechaHora]        DATETIME       NOT NULL,
    [SucursalOrigen]   INT            NOT NULL,
    [SucursalDestino]  INT            NOT NULL,
    [Query]            VARCHAR (5000) NOT NULL,
    [Tabla]            VARCHAR (200)  NOT NULL,
    [FechaHoraProceso] DATETIME       NULL,
    [Estado]           CHAR (1)       NOT NULL,
    CONSTRAINT [PK_SincronizaRegistros] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SincronizaRegistros_Sucursales] FOREIGN KEY ([SucursalDestino]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_SincronizaRegistros_Sucursales1] FOREIGN KEY ([SucursalOrigen]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

