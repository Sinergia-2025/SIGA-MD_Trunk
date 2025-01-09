CREATE TABLE [dbo].[ProductosComponentes] (
    [IdProducto]           VARCHAR (15)    NOT NULL,
    [IdProductoComponente] VARCHAR (15)    NOT NULL,
    [Cantidad]             DECIMAL (14, 4) NOT NULL,
    [IdFormula]            INT             NOT NULL,
    CONSTRAINT [PK_ProductosComponentes] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [IdFormula] ASC, [IdProductoComponente] ASC),
    CONSTRAINT [FK_ProductosComponentes_Productos2] FOREIGN KEY ([IdProductoComponente]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_ProductosComponentes_ProductosFormulas] FOREIGN KEY ([IdProducto], [IdFormula]) REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
);

