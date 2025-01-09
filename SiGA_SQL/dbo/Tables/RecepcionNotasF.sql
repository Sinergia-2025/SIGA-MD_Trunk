CREATE TABLE [dbo].[RecepcionNotasF] (
    [IdSucursal]          INT             NOT NULL,
    [NroNota]             INT             NOT NULL,
    [NroOperacion]        INT             NOT NULL,
    [IdProducto]          VARCHAR (15)    NOT NULL,
    [FechaNota]           DATETIME        NULL,
    [CantidadProductos]   DECIMAL (12, 2) NULL,
    [CostoReparacion]     DECIMAL (12, 2) NULL,
    [DefectoProducto]     VARCHAR (250)   NULL,
    [Observacion]         VARCHAR (250)   NULL,
    [IdProductoPrestado]  VARCHAR (15)    NULL,
    [CantidadPrestada]    DECIMAL (12, 2) NULL,
    [ObservacionPrestamo] VARCHAR (150)   NULL,
    [EstaPrestado]        BIT             NULL,
    [Usuario]             VARCHAR (50)    NOT NULL,
    [IdCliente]           BIGINT          NOT NULL,
    CONSTRAINT [PK_RecepcionNotasF] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NroNota] ASC),
    CONSTRAINT [FK_RecepcionNotasF_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_RecepcionNotasF_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_RecepcionNotasF_RecepcionNotasF] FOREIGN KEY ([IdProductoPrestado]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_RecepcionNotasF_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

