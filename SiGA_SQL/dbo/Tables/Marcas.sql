CREATE TABLE [dbo].[Marcas] (
    [IdMarca]          INT            NOT NULL,
    [NombreMarca]      NVARCHAR (50)  NOT NULL,
    [ComisionPorVenta] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED ([IdMarca] ASC)
);

