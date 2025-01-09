CREATE TABLE [dbo].[SubRubros] (
    [IdSubRubro]       INT            NOT NULL,
    [NombreSubRubro]   VARCHAR (50)   NOT NULL,
    [DescuentoRecargo] DECIMAL (5, 2) NOT NULL,
    [IdRubro]          INT            NOT NULL,
    CONSTRAINT [PK_SubRubros] PRIMARY KEY CLUSTERED ([IdSubRubro] ASC)
);

