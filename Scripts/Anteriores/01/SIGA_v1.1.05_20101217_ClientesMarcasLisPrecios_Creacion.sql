
CREATE TABLE [dbo].[ClientesMarcasLisPrecios](
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
 CONSTRAINT [PK_ClientesMarcasLisPrecios] PRIMARY KEY CLUSTERED 
(
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

