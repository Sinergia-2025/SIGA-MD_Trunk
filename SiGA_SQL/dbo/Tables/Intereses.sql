CREATE TABLE [dbo].[Intereses] (
    [DiasDesde] INT            NOT NULL,
    [DiasHasta] INT            NOT NULL,
    [Interes]   DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_Intereses_1] PRIMARY KEY CLUSTERED ([DiasDesde] ASC, [DiasHasta] ASC)
);

