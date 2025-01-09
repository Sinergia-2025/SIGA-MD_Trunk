CREATE TABLE [dbo].[EmpleadosComisionesProductosPrecios] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdProducto]      VARCHAR (15)   NOT NULL,
    [IdListaPrecios]  INT            NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesProductosPrecios] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdProducto] ASC, [IdListaPrecios] ASC),
    CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_ListasDePrecios] FOREIGN KEY ([IdListaPrecios]) REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios]),
    CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

