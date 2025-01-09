CREATE TABLE [dbo].[SueldosTiposVinculoFamiliar] (
    [IdTipoVinculoFamiliar] VARCHAR (5)  NOT NULL,
    [NombreVinculoFamiliar] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SueldosTiposVinculoFamiliar] PRIMARY KEY CLUSTERED ([IdTipoVinculoFamiliar] ASC)
);

