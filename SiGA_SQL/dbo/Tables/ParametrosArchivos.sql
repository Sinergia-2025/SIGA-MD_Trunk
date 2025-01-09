CREATE TABLE [dbo].[ParametrosArchivos] (
    [IdParametroArchivo]    VARCHAR (50)   NOT NULL,
    [ValorParametroArchivo] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ParametrosArchivos] PRIMARY KEY CLUSTERED ([IdParametroArchivo] ASC)
);

