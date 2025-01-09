CREATE TABLE [dbo].[ListasDePrecios] (
    [IdListaPrecios]     INT          NOT NULL,
    [NombreListaPrecios] VARCHAR (50) NOT NULL,
    [FechaVigencia]      DATETIME     NOT NULL,
    CONSTRAINT [PK_ListasDePrecios] PRIMARY KEY CLUSTERED ([IdListaPrecios] ASC)
);

