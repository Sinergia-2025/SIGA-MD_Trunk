CREATE TABLE [dbo].[PadronARBA] (
    [PeriodoInformado]   INT            NOT NULL,
    [IdPadronARBA]       BIGINT         NOT NULL,
    [TipoRegimen]        VARCHAR (1)    NOT NULL,
    [FechaPublicacion]   DATETIME       NOT NULL,
    [FechaVigenciaDesde] DATETIME       NOT NULL,
    [FechaVigenciaHasta] DATETIME       NOT NULL,
    [CUIT]               BIGINT         NOT NULL,
    [TipoContribuyente]  VARCHAR (1)    NOT NULL,
    [AccionARBA]         VARCHAR (1)    NOT NULL,
    [CambioAlicuota]     BIT            NOT NULL,
    [Alicuota]           DECIMAL (5, 2) NOT NULL,
    [Grupo]              INT            NOT NULL,
    CONSTRAINT [PK_PadronARBA] PRIMARY KEY CLUSTERED ([PeriodoInformado] ASC, [IdPadronARBA] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PadronARBA]
    ON [dbo].[PadronARBA]([CUIT] ASC, [PeriodoInformado] ASC);

