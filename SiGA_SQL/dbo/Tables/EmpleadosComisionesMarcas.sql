CREATE TABLE [dbo].[EmpleadosComisionesMarcas] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdMarca]         INT            NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesMarcas] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdMarca] ASC),
    CONSTRAINT [FK_EmpleadosComisionesMarcas_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesMarcas_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([IdMarca])
);

