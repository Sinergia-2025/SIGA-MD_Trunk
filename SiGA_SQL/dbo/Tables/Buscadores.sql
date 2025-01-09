CREATE TABLE [dbo].[Buscadores] (
    [IdBuscador] INT          NOT NULL,
    [Titulo]     VARCHAR (50) NOT NULL,
    [AnchoAyuda] INT          NOT NULL,
    CONSTRAINT [PK_Buscadores] PRIMARY KEY CLUSTERED ([IdBuscador] ASC)
);



