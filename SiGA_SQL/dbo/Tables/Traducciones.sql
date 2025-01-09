CREATE TABLE [dbo].[Traducciones] (
    [IdIdioma] VARCHAR (10)  NOT NULL,
    [Pantalla] VARCHAR (90)  NOT NULL,
    [Control]  VARCHAR (90)  NOT NULL,
    [Texto]    VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Traducciones] PRIMARY KEY CLUSTERED ([IdIdioma] ASC, [Pantalla] ASC, [Control] ASC)
);

