CREATE TABLE [dbo].[SueldosPersonalFamiliares] (
    [IdLegajo]                INT          NOT NULL,
    [CuilFamiliar]            VARCHAR (13) NOT NULL,
    [NombreFamiliar]          VARCHAR (50) NOT NULL,
    [FechaNacimientoFamiliar] DATETIME     NOT NULL,
    [SexoFamiliar]            CHAR (1)     NOT NULL,
    [IdTipoVinculoFamiliar]   VARCHAR (5)  NOT NULL,
    CONSTRAINT [PK_SueldosPersonalFamiliares] PRIMARY KEY CLUSTERED ([IdLegajo] ASC, [CuilFamiliar] ASC),
    CONSTRAINT [FK_SueldosPersonalFamiliares_SueldosTiposVinculoFamiliar] FOREIGN KEY ([IdTipoVinculoFamiliar]) REFERENCES [dbo].[SueldosTiposVinculoFamiliar] ([IdTipoVinculoFamiliar])
);

