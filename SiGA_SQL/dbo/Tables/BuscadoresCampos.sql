CREATE TABLE [dbo].[BuscadoresCampos] (
    [IdBuscador]            INT          NOT NULL,
    [IdBuscadorNombreCampo] VARCHAR (50) NOT NULL,
    [Orden]                 INT          NOT NULL,
    [Titulo]                VARCHAR (50) NOT NULL,
    [Alineacion]            INT          NOT NULL,
    [Ancho]                 INT          NOT NULL,
    [Formato]               VARCHAR (50) NULL,
    CONSTRAINT [PK_BuscadoresCampos] PRIMARY KEY CLUSTERED ([IdBuscador] ASC, [IdBuscadorNombreCampo] ASC),
    CONSTRAINT [FK_BuscadoresCampos_Buscadores] FOREIGN KEY ([IdBuscador]) REFERENCES [dbo].[Buscadores] ([IdBuscador])
);

