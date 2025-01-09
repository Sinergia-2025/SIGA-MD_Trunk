CREATE TABLE [dbo].[Localidades] (
    [IdLocalidad]     INT          NOT NULL,
    [NombreLocalidad] VARCHAR (50) NOT NULL,
    [IdProvincia]     CHAR (2)     NOT NULL,
    CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED ([IdLocalidad] ASC),
    CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[Provincias] ([IdProvincia])
);

