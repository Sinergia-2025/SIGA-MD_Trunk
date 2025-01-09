CREATE TABLE [dbo].[Rubros] (
    [IdRubro]          INT             NOT NULL,
    [NombreRubro]      VARCHAR (50)    NOT NULL,
    [IdProvincia]      CHAR (2)        NULL,
    [IdActividad]      INT             NULL,
    [ComisionPorVenta] DECIMAL (5, 2)  NOT NULL,
    [UnidHasta1]       INT             DEFAULT ((0)) NOT NULL,
    [UnidHasta2]       INT             DEFAULT ((0)) NOT NULL,
    [UnidHasta3]       INT             DEFAULT ((0)) NOT NULL,
    [UHPorc1]          DECIMAL (14, 2) DEFAULT ((0)) NOT NULL,
    [UHPorc2]          DECIMAL (14, 2) DEFAULT ((0)) NOT NULL,
    [UHPorc3]          DECIMAL (14, 2) DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Rubros] PRIMARY KEY CLUSTERED ([IdRubro] ASC),
    CONSTRAINT [FK_Rubros_Actividades] FOREIGN KEY ([IdProvincia], [IdActividad]) REFERENCES [dbo].[Actividades] ([IdProvincia], [IdActividad])
);



