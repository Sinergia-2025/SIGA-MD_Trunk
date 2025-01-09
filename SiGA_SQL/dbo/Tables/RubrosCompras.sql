CREATE TABLE [dbo].[RubrosCompras] (
    [IdRubro]     INT          NOT NULL,
    [NombreRubro] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_RubrosCompras] PRIMARY KEY CLUSTERED ([IdRubro] ASC)
);

