CREATE TABLE [dbo].[ProductosConceptos] (
    [IdProducto] VARCHAR (15) NOT NULL,
    [IdConcepto] INT          NOT NULL,
    CONSTRAINT [PK_ProductosConceptos] PRIMARY KEY CLUSTERED ([IdConcepto] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_ProductosConceptos_Conceptos] FOREIGN KEY ([IdConcepto]) REFERENCES [dbo].[Conceptos] ([IdConcepto]),
    CONSTRAINT [FK_ProductosConceptos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

