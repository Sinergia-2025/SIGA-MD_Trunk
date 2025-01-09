CREATE TABLE [dbo].[EmpleadosComisionesRubros] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdRubro]         INT            NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesRubros] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdRubro] ASC),
    CONSTRAINT [FK_EmpleadosComisionesRubros_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesRubros_Rubros] FOREIGN KEY ([IdRubro]) REFERENCES [dbo].[Rubros] ([IdRubro])
);

