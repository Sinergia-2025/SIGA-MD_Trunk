CREATE TABLE [dbo].[UnidadesDeMedidas] (
    [IdUnidadDeMedida]     CHAR (2)       NOT NULL,
    [NombreUnidadDeMedida] VARCHAR (15)   NOT NULL,
    [ConversionAKilos]     DECIMAL (7, 3) NOT NULL,
    [IdAFIP]               INT            NULL,
    CONSTRAINT [PK_UnidadesDeMedidas] PRIMARY KEY CLUSTERED ([IdUnidadDeMedida] ASC)
);

