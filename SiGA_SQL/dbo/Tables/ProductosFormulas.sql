CREATE TABLE [dbo].[ProductosFormulas] (
    [IdProducto]    VARCHAR (15)  NOT NULL,
    [IdFormula]     INT           NOT NULL,
    [NombreFormula] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ProductosFromulas] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [IdFormula] ASC),
    CONSTRAINT [FK_ProductosFormulas_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

