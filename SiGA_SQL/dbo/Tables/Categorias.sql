CREATE TABLE [dbo].[Categorias] (
    [IdCategoria]       INT            NOT NULL,
    [NombreCategoria]   VARCHAR (30)   NOT NULL,
    [DescuentoRecargo]  DECIMAL (5, 2) NOT NULL,
    [IdCaja]            INT            NULL,
    [IdTipoComprobante] VARCHAR (15)   NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([IdCategoria] ASC),
    CONSTRAINT [FK_Categorias_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

