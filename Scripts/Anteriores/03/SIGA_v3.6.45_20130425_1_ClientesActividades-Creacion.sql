

CREATE TABLE [dbo].[ClientesActividades](
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdProvincia] [char](2) NOT NULL,
	[IdActividad] [int] NOT NULL
 CONSTRAINT [PK_ClientesActividades] PRIMARY KEY CLUSTERED 
(
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdProvincia] ASC,
	[IdActividad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




