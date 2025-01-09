CREATE TABLE [dbo].[SincronizaTablas] (
    [IdSucursal]           INT           NOT NULL,
    [NombreTabla]          VARCHAR (100) NOT NULL,
    [TipoDeSincronizacion] VARCHAR (1)   NOT NULL,
    CONSTRAINT [PK_SincronizaTablas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NombreTabla] ASC),
    CONSTRAINT [FK_SincronizaTablas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

