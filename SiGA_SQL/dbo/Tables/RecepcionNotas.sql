﻿CREATE TABLE [dbo].[RecepcionNotas] (
    [IdSucursal]          INT             NOT NULL,
    [NroNota]             INT             NOT NULL,
    [IdTipoComprobante]   VARCHAR (15)    NULL,
    [Letra]               VARCHAR (1)     NULL,
    [CentroEmisor]        INT             NULL,
    [NumeroComprobante]   BIGINT          NULL,
    [IdProducto]          VARCHAR (15)    NOT NULL,
    [FechaNota]           DATETIME        NOT NULL,
    [CantidadProductos]   DECIMAL (12, 2) NOT NULL,
    [CostoReparacion]     DECIMAL (12, 2) NOT NULL,
    [DefectoProducto]     VARCHAR (250)   NOT NULL,
    [Observacion]         VARCHAR (250)   NOT NULL,
    [EstaPrestado]        BIT             NOT NULL,
    [IdProductoPrestado]  VARCHAR (15)    NULL,
    [CantidadPrestada]    DECIMAL (12, 2) NULL,
    [ObservacionPrestamo] VARCHAR (150)   NULL,
    [Usuario]             VARCHAR (50)    NOT NULL,
    [IdCliente]           BIGINT          NOT NULL,
    CONSTRAINT [PK_RecepcionNotas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NroNota] ASC),
    CONSTRAINT [FK_RecepcionNotas_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_RecepcionNotas_ProductoPrestado] FOREIGN KEY ([IdProductoPrestado]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_RecepcionNotas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_RecepcionNotas_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]),
    CONSTRAINT [FK_ReparacionNotas_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

