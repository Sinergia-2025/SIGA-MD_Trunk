CREATE TABLE [dbo].[Parametros] (
    [IdParametro]          VARCHAR (50)  NOT NULL,
    [ValorParametro]       VARCHAR (110) NULL,
    [CategoriaParametro]   VARCHAR (20)  NULL,
    [DescripcionParametro] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED ([IdParametro] ASC)
);

