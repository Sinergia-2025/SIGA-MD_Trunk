CREATE TABLE [dbo].[EmpleadosComisionesRubrosPrecios] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdRubro]         INT            NOT NULL,
    [IdListaPrecios]  INT            NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesRubrosPrecios] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdRubro] ASC, [IdListaPrecios] ASC),
    CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_ListasDePrecios] FOREIGN KEY ([IdListaPrecios]) REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios]),
    CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Rubros] FOREIGN KEY ([IdRubro]) REFERENCES [dbo].[Rubros] ([IdRubro])
);

