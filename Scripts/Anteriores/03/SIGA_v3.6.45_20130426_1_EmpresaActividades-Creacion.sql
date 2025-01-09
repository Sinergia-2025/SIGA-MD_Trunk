

CREATE TABLE [dbo].[EmpresaActividades](
	[IdProvincia] [char](2) NOT NULL,
	[IdActividad] [int] NOT NULL,
	[Principal] [bit] NOT NULL
 CONSTRAINT [PK_EmpresaActividades] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC,
	[IdActividad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




