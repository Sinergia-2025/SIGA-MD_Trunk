CREATE TABLE [dbo].[Observaciones] (
    [IdObservacion]      INT           NOT NULL,
    [DetalleObservacion] VARCHAR (100) NOT NULL,
    [Tipo]               VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Observaciones] PRIMARY KEY CLUSTERED ([IdObservacion] ASC)
);

