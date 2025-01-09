CREATE TABLE [dbo].[Tareas] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]   DATETIME      NOT NULL,
    [Tarea]   VARCHAR (255) NOT NULL,
    [Usuario] VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tareas_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

