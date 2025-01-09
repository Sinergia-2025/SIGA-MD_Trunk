PRINT ''
PRINT '1. Nueva Tabla: CalidadListasControlProductosProceso.'
GO
CREATE TABLE CalidadListasControlProductosProceso(
	[IdProducto] [varchar](15) NOT NULL,
	[IdListaControl] [int] NOT NULL,
	[OrdenItem] [int] NOT NULL,
	[CincoS] [varchar](25) NULL,
	[CincoSComment] [varchar](8000) NULL,
	[CincoSUsr] [varchar](50) NULL,
	[CincoSFecha] [datetime] NULL,
	[SoyCalidad] [bit] NOT NULL,
	[SoyProduccion] [bit] NOT NULL,
	[Procesado] [bit] NOT NULL,
	[MensajeProcesado] [text] NOT NULL,
 CONSTRAINT [PK_CalidadListasControlProductosProceso] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdListaControl] ASC,
	[OrdenItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
