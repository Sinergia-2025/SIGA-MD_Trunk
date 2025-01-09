CREATE TABLE [dbo].[Bancos] (
    [IdBanco]       INT          NOT NULL,
    [NombreBanco]   VARCHAR (40) NOT NULL,
    [DebitoDirecto] BIT          NOT NULL,
    [Empresa]       INT          NULL,
    [Convenio]      INT          NULL,
    [Servicio]      VARCHAR (10) NULL,
    CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED ([IdBanco] ASC)
);

