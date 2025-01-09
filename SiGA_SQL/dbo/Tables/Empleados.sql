CREATE TABLE [dbo].[Empleados] (
    [TipoDocEmpleado]    VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]     VARCHAR (12)   NOT NULL,
    [NombreEmpleado]     VARCHAR (100)  NULL,
    [TelefonoEmpleado]   VARCHAR (100)  NULL,
    [CelularEmpleado]    VARCHAR (100)  NULL,
    [EsVendedor]         BIT            NOT NULL,
    [EsComprador]        BIT            NOT NULL,
    [IdUsuario]          VARCHAR (10)   NULL,
    [ComisionPorVenta]   DECIMAL (5, 2) NOT NULL,
    [Direccion]          VARCHAR (100)  NOT NULL,
    [IdLocalidad]        INT            NOT NULL,
    [GeoLocalizacionLat] FLOAT (53)     NULL,
    [GeoLocalizacionLng] FLOAT (53)     NULL,
    CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC),
    CONSTRAINT [FK_Empleados_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_Empleados_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

