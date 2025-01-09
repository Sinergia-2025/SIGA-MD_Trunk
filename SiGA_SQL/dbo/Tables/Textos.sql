CREATE TABLE [dbo].[Textos] (
    [IdTexto] INT            NOT NULL,
    [Id]      VARCHAR (30)   NOT NULL,
    [Asunto]  VARCHAR (100)  NULL,
    [Cuerpo]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Textos] PRIMARY KEY CLUSTERED ([IdTexto] ASC, [Id] ASC),
    CONSTRAINT [FK_Textos_Funciones] FOREIGN KEY ([Id]) REFERENCES [dbo].[Funciones] ([Id])
);

