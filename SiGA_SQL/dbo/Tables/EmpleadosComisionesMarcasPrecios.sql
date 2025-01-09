CREATE TABLE [dbo].[EmpleadosComisionesMarcasPrecios] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdMarca]         INT            NOT NULL,
    [IdListaPrecios]  INT            NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesMarcasPrecios] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdMarca] ASC, [IdListaPrecios] ASC),
    CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_ListasDePrecios] FOREIGN KEY ([IdListaPrecios]) REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios]),
    CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([IdMarca])
);

