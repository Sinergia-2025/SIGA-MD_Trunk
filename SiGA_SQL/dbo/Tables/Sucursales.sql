CREATE TABLE [dbo].[Sucursales] (
    [IdSucursal]           INT           NOT NULL,
    [Nombre]               VARCHAR (50)  NOT NULL,
    [Direccion]            VARCHAR (50)  NOT NULL,
    [IdLocalidad]          INT           NOT NULL,
    [Telefono]             VARCHAR (50)  NULL,
    [Correo]               VARCHAR (100) NULL,
    [FechaInicioActiv]     DATETIME      NULL,
    [EstoyAca]             BIT           NOT NULL,
    [SoyLaCentral]         BIT           NOT NULL,
    [Id]                   INT           NOT NULL,
    [IdSucursalAsociada]   INT           NULL,
    [ColorSucursal]        INT           NOT NULL,
    [LogoSucursal]         IMAGE         NULL,
    [DireccionComercial]   VARCHAR (50)  NOT NULL,
    [IdLocalidadComercial] INT           NOT NULL,
    CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED ([IdSucursal] ASC),
    CONSTRAINT [FK_Sucursales_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_Sucursales_LocalidadesComercial] FOREIGN KEY ([IdLocalidadComercial]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_Sucursales_Sucursales] FOREIGN KEY ([IdSucursalAsociada]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);



