CREATE TABLE [dbo].[EmpleadosComisionesProductos] (
    [TipoDocEmpleado] VARCHAR (5)    NOT NULL,
    [NroDocEmpleado]  VARCHAR (12)   NOT NULL,
    [IdProducto]      VARCHAR (15)   NOT NULL,
    [Comision]        DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EmpleadosComisionesProductos] PRIMARY KEY CLUSTERED ([TipoDocEmpleado] ASC, [NroDocEmpleado] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_EmpleadosComisionesProductos_Empleados] FOREIGN KEY ([TipoDocEmpleado], [NroDocEmpleado]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]),
    CONSTRAINT [FK_EmpleadosComisionesProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

