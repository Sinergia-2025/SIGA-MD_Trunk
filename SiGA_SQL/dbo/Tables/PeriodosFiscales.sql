CREATE TABLE [dbo].[PeriodosFiscales] (
    [PeriodoFiscal]         INT             NOT NULL,
    [TotalNetoVentas]       DECIMAL (10, 2) NOT NULL,
    [TotalImpuestosVentas]  DECIMAL (10, 2) NOT NULL,
    [TotalVentas]           DECIMAL (10, 2) NOT NULL,
    [TotalNetoCompras]      DECIMAL (10, 2) NOT NULL,
    [TotalImpuestosCompras] DECIMAL (10, 2) NOT NULL,
    [TotalCompras]          DECIMAL (10, 2) NOT NULL,
    [Posicion]              DECIMAL (10, 2) NOT NULL,
    [FechaCierre]           DATE            NULL,
    [UsuarioCierre]         VARCHAR (10)    NULL,
    [TotalRetenciones]      DECIMAL (10, 2) NOT NULL,
    [TotalPercepciones]     DECIMAL (10, 2) NOT NULL,
    [PosicionFinal]         DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_PeriodosFiscales] PRIMARY KEY CLUSTERED ([PeriodoFiscal] ASC),
    CONSTRAINT [FK_PeriodosFiscales_Usuarios] FOREIGN KEY ([UsuarioCierre]) REFERENCES [dbo].[Usuarios] ([Id])
);

