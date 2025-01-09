CREATE TABLE [dbo].[Funciones] (
    [Id]          VARCHAR (30)  NOT NULL,
    [Nombre]      VARCHAR (60)  NOT NULL,
    [Descripcion] VARCHAR (150) NOT NULL,
    [EsMenu]      BIT           CONSTRAINT [DF_Funciones_EsMenu] DEFAULT ((0)) NOT NULL,
    [EsBoton]     BIT           CONSTRAINT [DF_Funciones_EsBoton] DEFAULT ((0)) NOT NULL,
    [Enabled]     BIT           CONSTRAINT [DF_Funciones_Enabled] DEFAULT ((1)) NOT NULL,
    [Visible]     BIT           CONSTRAINT [DF_Funciones_Visible] DEFAULT ((1)) NOT NULL,
    [IdPadre]     VARCHAR (30)  NULL,
    [Posicion]    INT           NOT NULL,
    [Archivo]     VARCHAR (90)  NULL,
    [Pantalla]    VARCHAR (90)  NULL,
    [Icono]       IMAGE         NULL,
    CONSTRAINT [PK_Funciones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Funciones_Funciones] FOREIGN KEY ([IdPadre]) REFERENCES [dbo].[Funciones] ([Id])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Si es menu en la aplicación se le coloca 1, sino 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'EsMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Determina si es un boton de la toolbar', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'EsBoton';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Determina si el menu o boton salen habilitados o deshabilitados, por defecto sale habilitado', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'Enabled';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Determina si sale oculto o visible el menu o boton, por defecto esta visible', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'Visible';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Es el padre en el menú despleglable', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'IdPadre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Determina la posición dentro del nivel que se encuentra el menú', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'Posicion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identifica el nombre completo de la clase a ejecutar si es menú o boton, el nombre debe incluir el espacio de nombres', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'Archivo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identifica el icono a mostrar en el menu y toolbar', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Funciones', @level2type = N'COLUMN', @level2name = N'Icono';

