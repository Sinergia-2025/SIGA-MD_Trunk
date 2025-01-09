CREATE TABLE [dbo].[ArchivosAImprimir] (
    [IdSucursal]            INT           NOT NULL,
    [NombreReporteOriginal] VARCHAR (200) NOT NULL,
    [ReporteSecundario]     VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ArchivosAImprimir] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NombreReporteOriginal] ASC),
    CONSTRAINT [FK_ArchivosAImprimir_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

