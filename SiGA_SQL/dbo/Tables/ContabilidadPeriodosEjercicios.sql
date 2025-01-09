CREATE TABLE [dbo].[ContabilidadPeriodosEjercicios] (
    [IdEjercicio] INT         NOT NULL,
    [IdPeriodo]   VARCHAR (7) NOT NULL,
    [Cerrado]     BIT         NOT NULL,
    [Orden]       INT         NOT NULL,
    CONSTRAINT [PK_ContabilidadPeriodosEjercicios] PRIMARY KEY CLUSTERED ([IdEjercicio] ASC, [IdPeriodo] ASC),
    CONSTRAINT [FK_ContabilidadPeriodosEjercicios_ContabilidadEjercicios] FOREIGN KEY ([IdEjercicio]) REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio])
);

