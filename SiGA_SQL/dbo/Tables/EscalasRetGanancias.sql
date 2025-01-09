CREATE TABLE [dbo].[EscalasRetGanancias] (
    [IdEscala]       INT             NOT NULL,
    [MontoMasDe]     DECIMAL (14, 2) NULL,
    [MontoA]         DECIMAL (14, 2) NULL,
    [Importe]        DECIMAL (14, 2) NULL,
    [MasPorcentaje]  DECIMAL (14, 2) NULL,
    [SobreExcedente] DECIMAL (14, 2) NULL,
    CONSTRAINT [PK_EscalasRetGanancias] PRIMARY KEY CLUSTERED ([IdEscala] ASC)
);

