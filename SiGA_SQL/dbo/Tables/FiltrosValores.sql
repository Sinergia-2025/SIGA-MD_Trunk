CREATE TABLE [dbo].[FiltrosValores] (
    [IdTipoFiltro]   VARCHAR (50)  NOT NULL,
    [IdNombreFiltro] VARCHAR (50)  NOT NULL,
    [IdColumna]      VARCHAR (50)  NOT NULL,
    [IdRegistro]     INT           NOT NULL,
    [Valor]          VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_FiltrosValores] PRIMARY KEY CLUSTERED ([IdTipoFiltro] ASC, [IdNombreFiltro] ASC, [IdColumna] ASC, [IdRegistro] ASC)
);

