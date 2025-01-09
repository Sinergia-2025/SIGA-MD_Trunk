CREATE TABLE [dbo].[TiposDeExension] (
    [IdTipoDeExension]          SMALLINT     NOT NULL,
    [NombreTipoDeExension]      VARCHAR (40) NOT NULL,
    [NombreTipoDeExensionAbrev] VARCHAR (10) NOT NULL,
    [Activo]                    BIT          NOT NULL,
    CONSTRAINT [PK_TipoDeExension] PRIMARY KEY CLUSTERED ([IdTipoDeExension] ASC)
);

