CREATE TABLE [dbo].[Produccion] (
    [IdSucursal]         INT          NOT NULL,
    [IdProduccion]       INT          NOT NULL,
    [Fecha]              DATETIME     NOT NULL,
    [Usuario]            VARCHAR (10) NOT NULL,
    [TipoDocResponsable] VARCHAR (5)  NOT NULL,
    [NroDocResponsable]  VARCHAR (12) NOT NULL,
    [IdEstado]           VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Produccion_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProduccion] ASC),
    CONSTRAINT [FK_Produccion_Empleados] FOREIGN KEY ([TipoDocResponsable], [NroDocResponsable]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_Produccion_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_Produccion_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

