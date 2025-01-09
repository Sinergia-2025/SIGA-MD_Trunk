CREATE TABLE [dbo].[TiposDocumento] (
    [TipoDocumento]       VARCHAR (5)  NOT NULL,
    [NombreTipoDocumento] VARCHAR (50) NOT NULL,
    [EsAutoincremental]   BIT          NOT NULL,
    CONSTRAINT [PK_TiposDocumento] PRIMARY KEY CLUSTERED ([TipoDocumento] ASC)
);

