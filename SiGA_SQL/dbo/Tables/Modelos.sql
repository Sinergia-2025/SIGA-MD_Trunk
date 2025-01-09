CREATE TABLE [dbo].[Modelos] (
    [IdModelo]     INT          NOT NULL,
    [NombreModelo] VARCHAR (30) NOT NULL,
    [IdMarca]      INT          NOT NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED ([IdModelo] ASC),
    CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([IdMarca])
);

