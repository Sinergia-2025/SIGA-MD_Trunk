
/****** TABLA ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SemaforoVentasUtilidades](
	[IdSemaforo] [int] NOT NULL,
	[PorcentajeHasta] [decimal](6, 2) NOT NULL,
	[ColorSemaforo] [int] NOT NULL,
	[NombreColor] [varchar](15) NOT NULL,
 CONSTRAINT [PK_SemaforoVentasUtilidades] PRIMARY KEY CLUSTERED 
(
	[IdSemaforo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** REGISTROS ******/

INSERT INTO SemaforoVentasUtilidades (IdSemaforo, PorcentajeHasta, ColorSemaforo, NombreColor)
    VALUES (0, 0, -16777216, 'Blanco')
GO

INSERT INTO SemaforoVentasUtilidades (IdSemaforo, PorcentajeHasta, ColorSemaforo, NombreColor)
    VALUES (10, 9, -65536, 'Rojo')
GO

INSERT INTO SemaforoVentasUtilidades (IdSemaforo, PorcentajeHasta, ColorSemaforo, NombreColor)
    VALUES (20, 25, -256, 'Amarillo')
GO

INSERT INTO SemaforoVentasUtilidades (IdSemaforo, PorcentajeHasta, ColorSemaforo, NombreColor)
    VALUES (30, 99, -16744448, 'Verde')
GO

INSERT INTO SemaforoVentasUtilidades (IdSemaforo, PorcentajeHasta, ColorSemaforo, NombreColor)
    VALUES (100, 100, -16777216, 'Negro')
GO
