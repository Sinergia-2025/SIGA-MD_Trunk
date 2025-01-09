CREATE TABLE [dbo].[Monedas] (
    [IdMoneda]           INT            NOT NULL,
    [NombreMoneda]       VARCHAR (30)   NOT NULL,
    [IdTipoMoneda]       VARCHAR (15)   NOT NULL,
    [OperadorConversion] CHAR (1)       NOT NULL,
    [FactorConversion]   DECIMAL (5, 3) NOT NULL,
    [IdBanco]            INT            NULL,
    [Simbolo]            VARCHAR (15)   NOT NULL,
    CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED ([IdMoneda] ASC)
);

