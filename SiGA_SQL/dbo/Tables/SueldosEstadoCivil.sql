CREATE TABLE [dbo].[SueldosEstadoCivil] (
    [IdEstadoCivil]     INT          NOT NULL,
    [NombreEstadoCivil] VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_SueldosEstadoCivil] PRIMARY KEY CLUSTERED ([IdEstadoCivil] ASC)
);

