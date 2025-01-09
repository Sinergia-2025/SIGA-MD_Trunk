


CREATE TABLE [dbo].[FiltrosValores](
	[IdTipoFiltro] [varchar](50) NOT NULL,
	[IdNombreFiltro] [varchar](50) NOT NULL,
	[IdColumna] [varchar](50) NOT NULL,
	[IdRegistro] [int] NOT NULL,
	[Valor] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FiltrosValores] PRIMARY KEY CLUSTERED 
(
	[IdTipoFiltro] ASC,
	[IdNombreFiltro] ASC,
	[IdColumna] ASC,
	[IdRegistro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



