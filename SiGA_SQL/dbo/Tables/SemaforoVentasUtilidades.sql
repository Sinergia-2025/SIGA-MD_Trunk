CREATE TABLE [dbo].[SemaforoVentasUtilidades] (
    [IdSemaforo]      INT            NOT NULL,
    [PorcentajeHasta] DECIMAL (6, 2) NOT NULL,
    [ColorSemaforo]   INT            NOT NULL,
    [NombreColor]     VARCHAR (15)   NOT NULL,
    CONSTRAINT [PK_SemaforoVentasUtilidades] PRIMARY KEY CLUSTERED ([IdSemaforo] ASC)
);

