CREATE TABLE [dbo].[Usuarios] (
    [Id]     VARCHAR (10) NOT NULL,
    [Nombre] VARCHAR (50) NOT NULL,
    [Clave]  VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

