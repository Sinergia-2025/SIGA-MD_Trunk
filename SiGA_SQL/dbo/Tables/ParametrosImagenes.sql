CREATE TABLE [dbo].[ParametrosImagenes] (
    [IdParametroImagen]    VARCHAR (50) NOT NULL,
    [ValorParametroImagen] IMAGE        NULL,
    CONSTRAINT [PK_ParametrosImagenes] PRIMARY KEY CLUSTERED ([IdParametroImagen] ASC)
);

