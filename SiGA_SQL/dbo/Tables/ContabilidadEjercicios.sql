CREATE TABLE [dbo].[ContabilidadEjercicios] (
    [IdEjercicio] INT  NOT NULL,
    [FechaDesde]  DATE NOT NULL,
    [FechaHasta]  DATE NOT NULL,
    [Cerrado]     BIT  CONSTRAINT [DF_ContabilidadEjercicios_cerrado] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ContabilidadEjercicios] PRIMARY KEY CLUSTERED ([IdEjercicio] ASC)
);

