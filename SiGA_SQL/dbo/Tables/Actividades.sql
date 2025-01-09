CREATE TABLE [dbo].[Actividades] (
    [IdProvincia]     CHAR (2)        NOT NULL,
    [IdActividad]     INT             NOT NULL,
    [NombreActividad] VARCHAR (50)    NOT NULL,
    [Porcentaje]      DECIMAL (5, 2)  NOT NULL,
    [BaseImponible]   DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED ([IdProvincia] ASC, [IdActividad] ASC),
    CONSTRAINT [FK_Actividades_Provincias] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[Provincias] ([IdProvincia])
);

